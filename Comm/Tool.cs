using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WxWomanSyncToZPerson.Comm
{
    class Tool
    {
        public static string EventLogName = ConfigurationManager.AppSettings["EventLogName"].ToString();
        public static string EventLogSource=ConfigurationManager.AppSettings["EventLogSource"].ToString();
        public static EventLog log = new EventLog(EventLogName, Environment.MachineName,EventLogSource);
        
        public static Model.z_person PreparePerson(DataRow row,string Person_Id)
        {
            Model.z_person Model = new Model.z_person();
            Model.Person_id = Person_Id;
            Model.Fno = row["Fno"].ToString();
            Model.Name = row["name"].ToString()==""?"Wix信息为空": row["name"].ToString();
            Model.Idcard = row["Idcard"].ToString()==""?"000000000000000000": row["Idcard"].ToString();
            Model.Zjlx = "1";
            Model.Sex = row["sex"].ToString()==""?"1": row["sex"].ToString().Replace("08","");
            Model.Birthday = row["birthday"].ToString()==""?DateTime.Now:DateTime.Parse(row["birthday"].ToString());
            Model.NationId =row["NationId"].ToString().Substring(2, 2);
            Model.eduId = row["eduId"].ToString().Replace("02","");
            Model.censusId = row["censusId"].ToString().Replace("03","");
            Model.marryId = row["marryId"].ToString()==""?"10": row["marryId"].ToString().Replace("04","");
            Model.addrcode = row["addrcode"].ToString()==""?"3202": row["addrcode"].ToString();
            Model.address = row["address"].ToString();
            Model.addrDoorNo = row["addrDoorNo"].ToString();
            Model.censusCode = row["censusCode"].ToString()==""?"3202": row["censusCode"].ToString();
            Model.censusAddr = row["censusAddr"].ToString();
            Model.census_DNo = row["census_DNo"].ToString();
            Model.Relation = row["Relation"].ToString().Replace("AC","").Replace("ac","");
            Model.pt_Id = row["pt_Id"].ToString().Replace("06","");
            Model.tel = row["tel"].ToString()==""?"000":row["tel"].ToString();
            Model.Sczk = "1";
            if (row["logoutId"].ToString() != "")
            {
                if (row["logoutId"].ToString() == "132")
                {
                    Model.Sczk = "2";
                    Model.Zxyy = "2";
                }
                else if (row["logoutId"].ToString() == "134")
                {
                    Model.Sczk = "1";
                    Model.Zxyy = "1";
                }
            }
            Model.ManagementAreaCode = row["ManagementAreaCode"].ToString();
            return Model;
        }


        public static string GetUpdateExtend(DataRow row2, string Person_Id,DateTime dateTime)
        {
            StringBuilder UpdateSql = new StringBuilder();
            UpdateSql.Append("update z_person_extend with(rowlock) set Person_id='" + Person_Id + "'");
            if (row2["H_name"].ToString() != "")
            {
                UpdateSql.Append(",p_poxm='" + row2["H_name"].ToString() + "'");
            }
            if (row2["H_idcard"].ToString() != "")
            {
                var spouseIdcard = row2["H_idcard"].ToString();
                if (spouseIdcard != "000000000000000000" && spouseIdcard != "000000000000000")
                {
                    if (spouseIdcard.Length > 18)
                    {
                        throw new Exception("H_idcard长度超出");
                    }
                    UpdateSql.Append(",p_posfz='" + spouseIdcard + "'");
                }
            }
            if (row2["F_Name"].ToString() != "")
            {
                UpdateSql.Append(",p_fqxm='" + row2["F_Name"].ToString() + "'");
            }
            if (row2["F_Code"].ToString() != "")
            {
                var fatheridcard = row2["F_Code"].ToString();
                if (fatheridcard != "000000000000000000" && fatheridcard != "000000000000000")
                {
                    if (fatheridcard.Length > 18)
                    {
                        throw new Exception("F_Code长度超出");
                    }
                    UpdateSql.Append(",p_fqsfz='" + fatheridcard + "'");
                }
            }
            if (row2["M_Name"].ToString() != "")
            {
                UpdateSql.Append(",p_mqxm='" + row2["M_Name"].ToString() + "'");
            }
            if (row2["M_Code"].ToString() != "")
            {
                var matheridcard = row2["M_Code"].ToString();
                if (matheridcard != "000000000000000000" && matheridcard != "000000000000000")
                {
                    if (matheridcard.Length > 18)
                    {
                        throw new Exception("M_Code长度超出");
                    }
                    UpdateSql.Append(",p_mqsfz='" + matheridcard + "'");
                }
            }
            if (row2["jobaddr"].ToString() != "")
            {
                UpdateSql.Append(",p_gzdwdz='" + row2["jobaddr"].ToString() + "'");
            }
            UpdateSql.Append(",UpdateTime='"+dateTime+ "',UpdateBy='数据同步服务更新' where Person_id='" + Person_Id + "'");
            return UpdateSql.ToString();
        }

        public static string GetInsertExtend(DataRow row, string Person_Id,DateTime dateTime)
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            stringBuilder1.Append("insert into z_person_extend  with(rowlock)(PKID,Person_id");
            stringBuilder2.Append(" Values('" + Guid.NewGuid().ToString() + "','" + Person_Id + "'");
            if (row["F_Name"].ToString() != "")
            {
                stringBuilder1.Append(",p_fqxm");
                stringBuilder2.Append(",'"+row["F_Name"].ToString()+"'");
            }
            if (row["F_Code"].ToString() != "")
            {
                var idcard = row["F_Code"].ToString();
                if (idcard != "000000000000000000" && idcard != "000000000000000")
                {
                    if (idcard.Length > 18)
                    {
                        throw new Exception("F_Code长度超出");
                    }
                    stringBuilder1.Append(",p_fqsfz");
                    stringBuilder2.Append(",'"+idcard+"'");
                }
            }
            if (row["M_Name"].ToString() != "")
            {
                stringBuilder1.Append(",p_mqxm");
                stringBuilder2.Append(",'" + row["M_Name"].ToString() + "'");
            }
            if (row["M_Code"].ToString() != "")
            {
                var idcard = row["M_Code"].ToString();
                if (idcard != "000000000000000000")
                {
                    if (idcard.Length > 18)
                    {
                        throw new Exception("M_Code长度超出");
                    }
                    stringBuilder1.Append(",p_mqsfz");
                    stringBuilder2.Append(",'" + idcard + "'");
                }
            }
            if (row["H_Name"].ToString() != "")
            {
                stringBuilder1.Append(",p_poxm");
                stringBuilder2.Append(",'" + row["H_Name"].ToString() + "'");
            }
            if (row["H_idcard"].ToString() != "")
            {
                var idcard = row["H_idcard"].ToString();
                if (idcard != "000000000000000000")
                {
                    if (idcard.Length > 18)
                    {
                        throw new Exception("H_idcard长度超出");
                    }
                    stringBuilder1.Append(",p_posfz");
                    stringBuilder2.Append(",'" + idcard + "'");
                }
            }
            if (row["jobaddr"].ToString() != "")
            {
                stringBuilder1.Append(",p_gzdwdz");
                stringBuilder2.Append(",'" + row["jobaddr"].ToString() + "'");
            }
            stringBuilder1.Append(",AddTime,Addby)");
            stringBuilder2.Append(",'"+dateTime+ "','数据同步服务添加')");
            string result = stringBuilder1.ToString() + stringBuilder2.ToString();
            return result;

        }


        public static string GetUpdateChild(SqlTransaction tran,DataRow row2,string PKID,DateTime dateTime)
        {
            StringBuilder UpdateSql = new StringBuilder();
            UpdateSql.Append(" update z_child with(rowlock) set PKID='" + PKID + "' ");
            if (row2["w_id"].ToString() != "")
            {
                var m_wid = row2["w_id"].ToString().Replace(" ", "");
                var MatherWisDT = SqlHelper.ExecuteDataSet("select * from w_woman where w_id='" + m_wid + "' order by CardDate desc").Tables[0];
                if (MatherWisDT.Rows.Count > 0)
                {
                    var MatherIdcard = MatherWisDT.Rows[0]["idcard"].ToString();
                    if (MatherIdcard != "000000000000000000")
                    {
                        var MatherPersonDT = SqlHelper.ExecuteDataSet(tran, "select * from z_person where idcard='" + MatherIdcard + "' order by AddTime desc").Tables[0];
                        if (MatherPersonDT.Rows.Count > 0)
                        {
                            UpdateSql.Append(",Nv_PersonID='" + MatherPersonDT.Rows[0]["Person_id"].ToString() + "'");
                        }
                    }
                }
            }
            if (row2["name"].ToString() != "")
            {
                UpdateSql.Append(",name='" + row2["name"].ToString() + "'");
            }
            if (row2["sexId"].ToString() != "")
            {
                var sexId = row2["sexId"].ToString().Replace("08","");
                if (sexId.Length > 2)
                {
                    throw new Exception("sexId长度超出");
                }
                UpdateSql.Append(",sexId='" + sexId + "'");
            }
            if (row2["birthday"].ToString() != "")
            {
                UpdateSql.Append(",birthday='" + row2["birthday"].ToString() + "'");
            }
            if (row2["idcard"].ToString() != "")
            {
                var thisidcard = row2["idcard"].ToString();
                if (thisidcard != "000000000000000000")
                {
                    if (thisidcard.Length > 18)
                    {
                        throw new Exception("idcard长度超出");
                    }
                    UpdateSql.Append(",idcard='" + thisidcard + "'");
                }
            }
            if (row2["kinId"].ToString() != "")
            {
                var kinid = row2["kinId"].ToString();
                if (kinid == "1540")
                {
                    kinid = "1";
                }
                else if (kinid == "1550")
                {
                    kinid = "9";
                }
                else
                {
                    kinid = "2";
                }
                if (kinid.Length > 2)
                {
                    throw new Exception("kinid长度超出");
                }
                UpdateSql.Append(",kinId='" + kinid + "'");
            }
            if (row2["kid_seq"].ToString() != "")
            {
                UpdateSql.Append(",kid_seq='" + row2["kid_seq"].ToString() + "'");
            }
            if (row2["birth_No"].ToString() != "")
            {
                UpdateSql.Append(",birth_No='" + row2["birth_No"].ToString() + "'");
            }
            if (row2["DeadDate"].ToString() != "")
            {
                UpdateSql.Append(",DeadDate='" + row2["DeadDate"].ToString() + "'");
            }
            UpdateSql.Append(",UpdateBy='数据同步服务更新',UpdateTime='"+dateTime+"' where PKID='"+PKID+"'");
            
            return UpdateSql.ToString();
        }


        public static string GetInsertChild(SqlTransaction tran,DataRow row2,string PKID,DateTime dateTime)
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            stringBuilder1.Append(" insert into  z_child with(rowlock)(PKID");
            stringBuilder2.Append(" Values('"+PKID+"'");
            if (row2["w_id"].ToString() != "")
            {
                var m_wid = row2["w_id"].ToString().Replace(" ", "");
                var MatherWisDT = SqlHelper.ExecuteDataSet("select * from w_woman where w_id='" + m_wid + "' order by CardDate desc").Tables[0];
                if (MatherWisDT.Rows.Count > 0)
                {
                    var MatherIdcard = MatherWisDT.Rows[0]["idcard"].ToString();
                    if (MatherIdcard != "000000000000000000")
                    {
                        var MatherPersonDT = SqlHelper.ExecuteDataSet(tran, "select * from z_person where idcard='" + MatherIdcard + "' order by AddTime desc").Tables[0];
                        if (MatherPersonDT.Rows.Count > 0)
                        {
                            stringBuilder1.Append(",Nv_PersonId");
                            stringBuilder2.Append(",'"+MatherPersonDT.Rows[0]["Person_id"].ToString()+"'");
                        }
                    }
                }
            }
            if (row2["name"].ToString() != "")
            {
                stringBuilder1.Append(",name");
                stringBuilder2.Append(",'"+row2["name"].ToString()+"'");
            }
            if (row2["sexId"].ToString() != "")
            {
                var sexId = row2["sexId"].ToString().Replace("08","");
                if (sexId.Length > 2)
                {
                    throw new Exception("sexId长度超出");
                }
                stringBuilder1.Append(",sexId");
                stringBuilder2.Append(",'" + sexId + "'");
            }
            if (row2["birthday"].ToString() != "")
            {
                stringBuilder1.Append(",birthday");
                stringBuilder2.Append(",'" + row2["birthday"].ToString() + "'");
            }
            if (row2["idcard"].ToString() != "")
            {
                var thisidcard = row2["idcard"].ToString();
                if (thisidcard != "000000000000000000")
                {
                    if (thisidcard.Length > 18)
                    {
                        throw new Exception("idcard长度超出");
                    }
                    stringBuilder1.Append(",idcard");
                    stringBuilder2.Append(",'" + row2["idcard"].ToString() + "'");
                }
            }
            if (row2["kinId"].ToString() != "")
            {
                var kinid = row2["kinId"].ToString();
                if (kinid == "1540")
                {
                    kinid = "1";
                }
                else if (kinid == "1550")
                {
                    kinid = "9";
                }
                else
                {
                    kinid = "2";
                }
                if (kinid.Length > 2)
                {
                    throw new Exception("kinid长度超出");
                }
                stringBuilder1.Append(",kinId");
                stringBuilder2.Append(",'" + kinid + "'");
            }
            if (row2["kid_seq"].ToString() != "")
            {
                stringBuilder1.Append(",kid_seq");
                stringBuilder2.Append(",'" + row2["kid_seq"].ToString() + "'");
            }
            if (row2["birth_No"].ToString() != "")
            {
                stringBuilder1.Append(",birth_No");
                stringBuilder2.Append(",'" + row2["birth_No"].ToString() + "'");
            }
            if (row2["DeadDate"].ToString() != "")
            {
                stringBuilder1.Append(",DeadDate");
                stringBuilder2.Append(",'" + row2["DeadDate"].ToString() + "'");
            }
            stringBuilder1.Append(",AddBy,AddTime)");
            stringBuilder2.Append(",'数据同步服务添加','"+dateTime+"') ");
            string Result = stringBuilder1.ToString() + stringBuilder2.ToString();
            return Result;
        }
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="tran">事务</param>
        /// <param name="DomainType">T_SyncRequest.DomainType</param>
        /// <param name="PrimaryId">DomainID</param>
        /// <param name="message">日志内容</param>
        /// <param name="sqlEventLog">自定义日志类型</param>
        /// <param name="eventLogEntryType">事件查看器日志类型</param>
        public static void EventLogMethod(SqlTransaction tran,string DomainType, string PrimaryId, string message,DateTime AddTime, EventLogEntryType eventLogEntryType)
        {
            InsertSqlEventLog(tran,DomainType,PrimaryId,message, eventLogEntryType,AddTime);
            //InsertSystemEventLog(message,eventLogEntryType);
        }
        /// <summary>
        /// 插入日志到数据库
        /// </summary>
        /// <param name="domaintype">T_SyncRequest.DomainType</param>
        /// <param name="primarykey">DomainID</param>
        /// <param name="message">日志内容</param>
        /// <param name="type">日志类型</param>
        public static void InsertSqlEventLog(SqlTransaction tran,string DomainType,string PrimaryKey,string message, EventLogEntryType eventLogEntryType,DateTime AddTime)
        {
            SqlParameter parm = new SqlParameter("@message",message);
            var sql = "insert into WomanSyncToPersonLog with(rowlock) values('" + Guid.NewGuid().ToString()+"','"+PrimaryKey+"','"+DomainType+"',@message,'"+ eventLogEntryType + "','"+ AddTime+ "')";
            if (tran != null)
            {
                SqlHelper.ExecuteNonQuery(tran,sql,CommandType.Text,parm);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sql,CommandType.Text,parm);
            }
            
        }
        /// <summary>
        /// 插入日志到系统事件查看器
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="eventLogEntryType">日志类型</param>
        public static void InsertSystemEventLog(string message, EventLogEntryType eventLogEntryType)
        {
            log.WriteEntry(message,eventLogEntryType);
        }
        public static string SecurityData(Model.z_person Model)
        {
            StringBuilder result = new StringBuilder();
            if (!string.IsNullOrEmpty(Model.Sex))
            {
                if (Model.Sex.Length> 2)
                {
                    result.Append("sex长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.Idcard))
            {
                if (Model.Idcard.Length>18)
                {
                    result.Append("idcard长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.NationId))
            {
                if (Model.NationId.Length > 2)
                {
                    result.Append("nationId长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.eduId))
            {
                if (Model.eduId.Length > 2)
                {
                    result.Append("eduId长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.censusId))
            {
                if (Model.censusId.Length > 2)
                {
                    result.Append("censusId长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.marryId))
            {
                if (Model.marryId.Length > 2)
                {
                    result.Append("marryId长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.censusCode))
            {
                if (Model.censusCode.Length > 15)
                {
                    result.Append("censusCode长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.addrcode))
            {
                if (Model.addrcode.Length > 15)
                {
                    result.Append("addrcode长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.czcode))
            {
                if (Model.czcode.Length > 15)
                {
                    result.Append("czcode长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.Relation))
            {
                if (Model.Relation.Length > 6)
                {
                    result.Append("Relation长度超出;");
                }
            }
            if (!string.IsNullOrEmpty(Model.pt_Id))
            {
                if (Model.pt_Id.Length > 2)
                {
                    result.Append("pt_Id长度超出;");
                }
            }
            return result.ToString();
        }

    }
}
