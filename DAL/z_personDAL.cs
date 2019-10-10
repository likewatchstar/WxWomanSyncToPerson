using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
namespace WxWomanSyncToZPerson.DAL
{
    public partial class z_personDAL
    {

        /// <summary>
        /// 增加一条数据SqlBuilder
        /// </summary>
        public bool AddByString(SqlTransaction tran,Model.z_person model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("insert into z_person with(rowlock)(");
            strSql2.Append(" Values(");


            if (!string.IsNullOrEmpty(model.Person_id))
            {
                strSql1.Append("Person_id,");
                strSql2.Append("'" + model.Person_id + "',");
            }


            if (!string.IsNullOrEmpty(model.eduId))
            {
                strSql1.Append("eduId,");
                strSql2.Append("'" + model.eduId + "',");
            }


            if (!string.IsNullOrEmpty(model.censusId))
            {
                strSql1.Append("censusId,");
                strSql2.Append("'" + model.censusId + "',");
            }


            if (!string.IsNullOrEmpty(model.marryId))
            {
                strSql1.Append("marryId,");
                strSql2.Append("'" + model.marryId + "',");
            }


            if (model.IMarrDate != null)
            {
                strSql1.Append("IMarrDate,");
                strSql2.Append("'" + model.IMarrDate + "',");
            }

            if (!string.IsNullOrEmpty(model.censusCode))
            {
                strSql1.Append("censusCode,");
                strSql2.Append("'" + model.censusCode + "',");
            }


            if (!string.IsNullOrEmpty(model.censusAddr))
            {
                strSql1.Append("censusAddr,");
                strSql2.Append("'" + model.censusAddr + "',");
            }


            if (!string.IsNullOrEmpty(model.census_DNo))
            {
                strSql1.Append("census_DNo,");
                strSql2.Append("'" + model.census_DNo + "',");
            }


            if (!string.IsNullOrEmpty(model.addrcode))
            {
                strSql1.Append("addrcode,");
                strSql2.Append("'" + model.addrcode + "',");
            }


            if (!string.IsNullOrEmpty(model.address))
            {
                strSql1.Append("address,");
                strSql2.Append("'" + model.address + "',");
            }


            if (!string.IsNullOrEmpty(model.addrDoorNo))
            {
                strSql1.Append("addrDoorNo,");
                strSql2.Append("'" + model.addrDoorNo + "',");
            }


            if (!string.IsNullOrEmpty(model.Fno))
            {
                strSql1.Append("Fno,");
                strSql2.Append("'" + model.Fno + "',");
            }


            if (!string.IsNullOrEmpty(model.czcode))
            {
                strSql1.Append("czcode,");
                strSql2.Append("'" + model.czcode + "',");
            }


            if (!string.IsNullOrEmpty(model.czdz))
            {
                strSql1.Append("czdz,");
                strSql2.Append("'" + model.czdz + "',");
            }


            if (!string.IsNullOrEmpty(model.czmph))
            {
                strSql1.Append("czmph,");
                strSql2.Append("'" + model.czmph + "',");
            }


            if (!string.IsNullOrEmpty(model.tel))
            {
                strSql1.Append("tel,");
                strSql2.Append("'" + model.tel + "',");
            }


            if (!string.IsNullOrEmpty(model.Relation))
            {
                strSql1.Append("Relation,");
                strSql2.Append("'" + model.Relation + "',");
            }


            if (!string.IsNullOrEmpty(model.pt_Id))
            {
                strSql1.Append("pt_Id,");
                strSql2.Append("'" + model.pt_Id + "',");
            }


            if (!string.IsNullOrEmpty(model.Sczk))
            {
                strSql1.Append("Sczk,");
                strSql2.Append("'" + model.Sczk + "',");
            }


            if (!string.IsNullOrEmpty(model.Zxyy))
            {
                strSql1.Append("Zxyy,");
                strSql2.Append("'" + model.Zxyy + "',");
            }


            if (model.Addtime != null)
            {
                strSql1.Append("Addtime,");
                strSql2.Append("'" + model.Addtime + "',");
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                strSql1.Append("Name,");
                strSql2.Append("'" + model.Name + "',");
            }


            if (!string.IsNullOrEmpty(model.AddBy))
            {
                strSql1.Append("AddBy,");
                strSql2.Append("'" + model.AddBy + "',");
            }


            if (model.Updatetime != null)
            {
                strSql1.Append("Updatetime,");
                strSql2.Append("'" + model.Updatetime + "',");
            }

            if (!string.IsNullOrEmpty(model.UpdateBy))
            {
                strSql1.Append("UpdateBy,");
                strSql2.Append("'" + model.UpdateBy + "',");
            }


            if (!string.IsNullOrEmpty(model.ManagementAreaCode))
            {
                strSql1.Append("ManagementAreaCode,");
                strSql2.Append("'" + model.ManagementAreaCode + "',");
            }


            if (!string.IsNullOrEmpty(model.Sex))
            {
                strSql1.Append("Sex,");
                strSql2.Append("'" + model.Sex + "',");
            }


            if (model.Birthday != null)
            {
                strSql1.Append("Birthday,");
                strSql2.Append("'" + model.Birthday + "',");
            }

            if (!string.IsNullOrEmpty(model.Zjlx))
            {
                strSql1.Append("Zjlx,");
                strSql2.Append("'" + model.Zjlx + "',");
            }


            if (!string.IsNullOrEmpty(model.Idcard))
            {
                strSql1.Append("Idcard,");
                strSql2.Append("'" + model.Idcard + "',");
            }


            if (!string.IsNullOrEmpty(model.Gj))
            {
                strSql1.Append("Gj,");
                strSql2.Append("'" + model.Gj + "',");
            }


            if (!string.IsNullOrEmpty(model.NationId))
            {
                strSql1.Append("NationId,");
                strSql2.Append("'" + model.NationId + "',");
            }


            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1)).Append(")");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1)).Append(")");
            bool result = SqlHelper.ExecuteNonQuery(tran,strSql.ToString()) > 0 ? true : false;
            return result;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SqlTransaction tran,Model.z_person model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_person with(rowlock) set ");
            if (!string.IsNullOrEmpty(model.eduId))
            {
                strSql.Append("eduId='" + model.eduId + "',");
            }

            if (!string.IsNullOrEmpty(model.censusId))
            {
                strSql.Append("censusId='" + model.censusId + "',");
            }

            if (!string.IsNullOrEmpty(model.marryId))
            {
                strSql.Append("marryId='" + model.marryId + "',");
            }

            if (model.IMarrDate != null)
            {
                strSql.Append("IMarrDate='" + model.IMarrDate + "',");
            }

            if (!string.IsNullOrEmpty(model.censusCode))
            {
                strSql.Append("censusCode='" + model.censusCode + "',");
            }

            if (!string.IsNullOrEmpty(model.censusAddr))
            {
                strSql.Append("censusAddr='" + model.censusAddr + "',");
            }

            if (!string.IsNullOrEmpty(model.census_DNo))
            {
                strSql.Append("census_DNo='" + model.census_DNo + "',");
            }

            if (!string.IsNullOrEmpty(model.addrcode))
            {
                strSql.Append("addrcode='" + model.addrcode + "',");
            }

            if (!string.IsNullOrEmpty(model.address))
            {
                strSql.Append("address='" + model.address + "',");
            }

            if (!string.IsNullOrEmpty(model.addrDoorNo))
            {
                strSql.Append("addrDoorNo='" + model.addrDoorNo + "',");
            }

            if (!string.IsNullOrEmpty(model.Fno))
            {
                strSql.Append("Fno='" + model.Fno + "',");
            }

            if (!string.IsNullOrEmpty(model.czcode))
            {
                strSql.Append("czcode='" + model.czcode + "',");
            }

            if (!string.IsNullOrEmpty(model.czdz))
            {
                strSql.Append("czdz='" + model.czdz + "',");
            }

            if (!string.IsNullOrEmpty(model.czmph))
            {
                strSql.Append("czmph='" + model.czmph + "',");
            }

            if (!string.IsNullOrEmpty(model.tel))
            {
                strSql.Append("tel='" + model.tel + "',");
            }

            if (!string.IsNullOrEmpty(model.Relation))
            {
                strSql.Append("Relation='" + model.Relation + "',");
            }

            if (!string.IsNullOrEmpty(model.pt_Id))
            {
                strSql.Append("pt_Id='" + model.pt_Id + "',");
            }

            if (!string.IsNullOrEmpty(model.Sczk))
            {
                strSql.Append("Sczk='" + model.Sczk + "',");
            }

            if (!string.IsNullOrEmpty(model.Zxyy))
            {
                strSql.Append("Zxyy='" + model.Zxyy + "',");
            }

            if (model.Addtime != null)
            {
                strSql.Append("Addtime='" + model.Addtime + "',");
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                strSql.Append("Name='" + model.Name + "',");
            }

            if (!string.IsNullOrEmpty(model.AddBy))
            {
                strSql.Append("AddBy='" + model.AddBy + "',");
            }

            if (model.Updatetime != null)
            {
                strSql.Append("Updatetime='" + model.Updatetime + "',");
            }

            if (!string.IsNullOrEmpty(model.UpdateBy))
            {
                strSql.Append("UpdateBy='" + model.UpdateBy + "',");
            }

            if (!string.IsNullOrEmpty(model.ManagementAreaCode))
            {
                strSql.Append("ManagementAreaCode='" + model.ManagementAreaCode + "',");
            }

            if (!string.IsNullOrEmpty(model.Sex))
            {
                strSql.Append("Sex='" + model.Sex + "',");
            }

            if (model.Birthday != null)
            {
                strSql.Append("Birthday='" + model.Birthday + "',");
            }

            if (!string.IsNullOrEmpty(model.Zjlx))
            {
                strSql.Append("Zjlx='" + model.Zjlx + "',");
            }

            if (!string.IsNullOrEmpty(model.Idcard))
            {
                strSql.Append("Idcard='" + model.Idcard + "',");
            }

            if (!string.IsNullOrEmpty(model.Gj))
            {
                strSql.Append("Gj='" + model.Gj + "',");
            }

            if (!string.IsNullOrEmpty(model.NationId))
            {
                strSql.Append("NationId='" + model.NationId + "',");
            }
            strSql.Remove(strSql.ToString().Length - 1, 1);
            strSql.Append(" where  Person_id='" + model.Person_id + "'");

            bool result = SqlHelper.ExecuteNonQuery(tran,strSql.ToString()) > 0 ? true : false;
            return result;
        }
    }


}

