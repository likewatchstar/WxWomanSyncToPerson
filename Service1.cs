using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Data.SqlClient;
using System.Configuration;
using WxWomanSyncToZPerson.Comm;

namespace WxWomanSyncToZPerson
{


    public partial class Service1 : ServiceBase
    {

        System.Timers.Timer timer = new System.Timers.Timer(300000);
        public Service1()
        {
            Tool.EventLogMethod(null, "", "", "Excute Service1()", DateTime.Now, EventLogEntryType.Information);
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Tool.EventLogMethod(null, "", "", "Excute OnStart()", DateTime.Now, EventLogEntryType.Information);
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
           
        } 

        /// <summary>
        /// 项目需求:同步全员人口库所有存在字段数据(除了family,family_proprety)，没有则新增，wis信息无略过，某些意义不大字段可不必在乎(类似person_extend的父母配偶的人员id)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            Tool.EventLogMethod(null, "", "", "Excute OnTimer()", DateTime.Now, EventLogEntryType.Information);
            var PrimaryID = "";
            var DomainType = "";
            var NeedIdcard = "";
            try
            {
                DateTime IndexTime = DateTime.Now;
                timer.Stop();//调用方法时停止定时，防止还没有执行完毕就开始第二次调用
                using (SqlConnection conn = new SqlConnection(SqlHelper.CityConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {

                        try
                        {
                            DAL.z_personDAL z_PersonDAL = new DAL.z_personDAL();
                            var sql = "select * from T_SyncRequest where  LastRequestTime>(SELECT * FROM  WomanSyncToPersonDateTime) order by LastRequestTime";
                            var dt = SqlHelper.ExecuteDataSet(sql).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    PrimaryID = row["DomainID"].ToString();
                                    DomainType = row["DomainType"].ToString();
                                    DomainType = DomainType.Replace("Wis.Domain.", "").Replace(",Wis.Domain", "");
                                    if (DomainType == "Person" || DomainType == "Husband")
                                    {
                                        var sql2 = "";
                                        if (DomainType == "Person")
                                        {
                                            sql2 = "select * from w_woman where w_id='" + PrimaryID + "'";
                                        }
                                        else
                                        {
                                            var tmpdt = SqlHelper.ExecuteDataSet("select * from w_husband where pkid='" + PrimaryID + "' order by ModifyDate desc").Tables[0];
                                            if (tmpdt.Rows.Count > 0)
                                            {
                                                var idcard = tmpdt.Rows[0]["idcard"].ToString();
                                                if (idcard != "000000000000000000")
                                                {
                                                    sql2 = "select * from w_woman where idcard='" + idcard + "' order by CardDate desc";
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        var dt2 = SqlHelper.ExecuteDataSet(sql2).Tables[0];
                                        if (dt2.Rows.Count > 0)
                                        {
                                            var row2 = dt2.Rows[0];
                                            if (row2["idcard"].ToString() != "000000000000000000")
                                            {
                                                NeedIdcard = row2["idcard"].ToString();
                                                var Person_Id = "";
                                                var PersonDT = SqlHelper.ExecuteDataSet(tran, "select * from z_person where idcard='" + row2["idcard"].ToString() + "' order by addtime desc").Tables[0];
                                                if (PersonDT.Rows.Count > 0)
                                                {
                                                    Person_Id = PersonDT.Rows[0]["Person_id"].ToString();
                                                }
                                                if (Person_Id != "")
                                                {
                                                    Model.z_person Z_PersonModel = Comm.Tool.PreparePerson(row2, Person_Id);
                                                    Z_PersonModel.UpdateBy = "数据同步服务更新";
                                                    Z_PersonModel.Updatetime = IndexTime;
                                                    string Sec = Tool.SecurityData(Z_PersonModel);
                                                    if (Sec != "") { throw new Exception(Sec); }
                                                    z_PersonDAL.Update(tran, Z_PersonModel);
                                                    Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person.Update)", IndexTime, EventLogEntryType.SuccessAudit);
                                                }
                                                else
                                                {
                                                    Model.z_person Z_PersonModel = Comm.Tool.PreparePerson(row2, Guid.NewGuid().ToString());
                                                    Z_PersonModel.AddBy = "数据同步服务添加";
                                                    Z_PersonModel.Addtime = IndexTime;
                                                    Z_PersonModel.czcode = Z_PersonModel.addrcode;
                                                    Z_PersonModel.czdz = Z_PersonModel.address;
                                                    string Sec = Tool.SecurityData(Z_PersonModel);
                                                    if (Sec != "") { throw new Exception(Sec); }
                                                    z_PersonDAL.AddByString(tran, Z_PersonModel);
                                                    Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person.Insert)", IndexTime, EventLogEntryType.SuccessAudit);
                                                }
                                                var PersonExDT = SqlHelper.ExecuteDataSet(tran, "select * from z_person_extend where Person_id='" + Person_Id + "'").Tables[0];
                                                if (PersonExDT.Rows.Count > 0)
                                                {
                                                    string UpdateSql = Tool.GetUpdateExtend(row2, Person_Id, IndexTime);
                                                    SqlHelper.ExecuteNonQuery(tran, UpdateSql);
                                                    Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person_Extend.Update)", IndexTime, EventLogEntryType.SuccessAudit);
                                                }
                                                else
                                                {
                                                    string InsertSql = Tool.GetInsertExtend(row2, Person_Id, IndexTime);
                                                    SqlHelper.ExecuteNonQuery(tran, InsertSql);
                                                    Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person_Extend.Insert)", IndexTime, EventLogEntryType.SuccessAudit);
                                                }
                                            }
                                        }
                                    }
                                    else if (DomainType == "Marriage")
                                    {
                                        var dt2 = SqlHelper.ExecuteDataSet("select * from w_marriage where pkid='" + PrimaryID + "'").Tables[0];
                                        if (dt2.Rows.Count > 0)
                                        {
                                            var row2 = dt2.Rows[0];
                                            var wid = row2["w_id"].ToString();
                                            var marryId = row2["marryId"].ToString().Replace("04", "");
                                            if (marryId.Length > 2) { throw new Exception("marryId长度超出;"); }
                                            var marryDate = (marryId == "21" || marryId == "22" || marryId == "23") ? row2["changeDate"].ToString() : "";//如果婚姻状况为初婚,再婚,复婚则同步结婚日期
                                            var poname = row2["h_name"].ToString();
                                            var poidcard = row2["h_idcard"].ToString();
                                            var dt3 = SqlHelper.ExecuteDataSet("select  * from w_woman where w_id='" + wid + "'").Tables[0];
                                            if (dt3.Rows.Count > 0)
                                            {
                                                var idcard = dt3.Rows[0]["idcard"].ToString();
                                                if (idcard != "000000000000000000" && idcard != "000000000000000")
                                                {
                                                    NeedIdcard = idcard;
                                                    var Person_id = "";
                                                    var PersonDT = SqlHelper.ExecuteDataSet(tran, "select * from  z_person where idcard='" + idcard + "' order by AddTime desc").Tables[0];
                                                    if (PersonDT.Rows.Count > 0)
                                                    {
                                                        Person_id = PersonDT.Rows[0]["Person_Id"].ToString();
                                                    }
                                                    if (Person_id != "")
                                                    {
                                                        StringBuilder UpdateSql = new StringBuilder();
                                                        UpdateSql.Append("update z_person with(rowlock) set marryId = '" + marryId + "'");
                                                        if (marryDate != "")
                                                        {
                                                            UpdateSql.Append(",IMarrDate='" + marryDate + "'");
                                                        }
                                                        UpdateSql.Append(",UpdateBy='数据同步服务更新',UpdateTime='" + IndexTime + "'");
                                                        UpdateSql.Append(" where Person_id='" + Person_id + "'");
                                                        SqlHelper.ExecuteNonQuery(tran, UpdateSql.ToString());
                                                        Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person.Update)", IndexTime, EventLogEntryType.SuccessAudit);
                                                    }
                                                    else
                                                    {
                                                        Model.z_person Z_PersonModel = Tool.PreparePerson(dt3.Rows[0], Guid.NewGuid().ToString());
                                                        Z_PersonModel.marryId = marryId;
                                                        Z_PersonModel.IMarrDate = marryDate == "" ? (DateTime?)null : DateTime.Parse(marryDate);
                                                        Z_PersonModel.czcode = Z_PersonModel.addrcode;
                                                        Z_PersonModel.czdz = Z_PersonModel.address;
                                                        Z_PersonModel.AddBy = "数据同步服务添加";
                                                        Z_PersonModel.Addtime = IndexTime;
                                                        z_PersonDAL.AddByString(tran, Z_PersonModel);
                                                        Person_id = Z_PersonModel.Person_id;
                                                        Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person.Insert)", IndexTime, EventLogEntryType.SuccessAudit);
                                                    }
                                                    var PersonExDT = SqlHelper.ExecuteDataSet(tran, "select * from z_person_extend where Person_id='" + Person_id + "'").Tables[0];
                                                    if (PersonExDT.Rows.Count > 0)
                                                    {
                                                        StringBuilder UpdateSql = new StringBuilder();
                                                        UpdateSql.Append(" Update z_person_extend with(rowlock) set Person_id='" + Person_id + "' ");
                                                        if (poidcard != "")
                                                        {
                                                            if (poidcard != "000000000000000000" && poidcard != "000000000000000")
                                                            {
                                                                UpdateSql.Append(" ,p_posfz='" + poidcard + "'");
                                                            }
                                                        }
                                                        if (poname != "")
                                                        {
                                                            UpdateSql.Append(",p_poxm='" + poname + "'");
                                                        }
                                                        UpdateSql.Append(",UpdateBy='数据同步服务更新',UpdateTime='" + IndexTime + "'");
                                                        UpdateSql.Append("  where Person_id='" + Person_id + "'");
                                                        SqlHelper.ExecuteNonQuery(tran, UpdateSql.ToString());
                                                        Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person_Extend.Update)", IndexTime, EventLogEntryType.SuccessAudit);
                                                    }
                                                    else
                                                    {
                                                        StringBuilder InsertSql1 = new StringBuilder();
                                                        StringBuilder InsertSql2 = new StringBuilder();
                                                        InsertSql1.Append("insert into z_person_extend with(rowlock) (PKID,Person_id");
                                                        InsertSql2.Append(" Values('" + Guid.NewGuid().ToString() + "','" + Person_id + "'");
                                                        if (poidcard != "")
                                                        {
                                                            if (poidcard != "000000000000000000" && poidcard != "000000000000000")
                                                            {
                                                                InsertSql1.Append(" ,p_posfz");
                                                                InsertSql2.Append(",'" + poidcard + "'");
                                                            }
                                                        }
                                                        if (poname != "")
                                                        {
                                                            InsertSql1.Append(",p_poxm");
                                                            InsertSql2.Append(",'" + poname + "'");
                                                        }
                                                        InsertSql1.Append(",AddBy,AddTime) ");
                                                        InsertSql2.Append(",'数据同步服务添加','" + IndexTime + "') ");
                                                        var Sql = InsertSql1.ToString() + InsertSql2.ToString();
                                                        SqlHelper.ExecuteNonQuery(tran, Sql);
                                                        Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Person_Extend.Insert)", IndexTime, EventLogEntryType.SuccessAudit);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (DomainType == "Child")
                                    {
                                        var dt1 = SqlHelper.ExecuteDataSet("select * from w_child where pkid='" + PrimaryID + "'").Tables[0];
                                        if (dt1.Rows.Count > 0)
                                        {
                                            var idcard = dt1.Rows[0]["idcard"].ToString();
                                            if (idcard != "000000000000000000")
                                            {
                                                NeedIdcard = idcard;
                                                var ChildDT = SqlHelper.ExecuteDataSet(tran, "select * from z_child where idcard='" + idcard + "' order by AddTime Desc").Tables[0];
                                                if (ChildDT.Rows.Count > 0)
                                                {
                                                    string UpdateSql = Tool.GetUpdateChild(tran, dt1.Rows[0], ChildDT.Rows[0]["PKID"].ToString(), IndexTime);
                                                    SqlHelper.ExecuteNonQuery(tran, UpdateSql);
                                                    Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Child.Update)", IndexTime, EventLogEntryType.SuccessAudit);
                                                }
                                                else
                                                {
                                                    string InsertSql = Tool.GetInsertChild(tran, dt1.Rows[0], Guid.NewGuid().ToString(), IndexTime);
                                                    SqlHelper.ExecuteNonQuery(tran, InsertSql);
                                                    Tool.EventLogMethod(tran, DomainType, PrimaryID + ":" + NeedIdcard, "同步成功(Z_Child.Insert)", IndexTime, EventLogEntryType.SuccessAudit);
                                                }
                                            }
                                        }
                                    }
                                }
                                SqlHelper.ExecuteNonQuery(SqlHelper.CityConnectionString,"update WomanSyncToPersonDateTime  set id='" + IndexTime + "'");
                                tran.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                timer.Start();
            }
            catch(Exception ex)
            {
                Tool.EventLogMethod(null, DomainType, PrimaryID, ex.Message, DateTime.Now, EventLogEntryType.Error);
                timer.Start();
            }
        }
    }
}
