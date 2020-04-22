using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
namespace WxWomanSyncToZPerson.DAL  
{
	 	//人员扩展信息
		public partial class z_person_extendDAL
	{


		/// <summary>
		/// 增加一条数据SqlBuilder
		/// </summary>
		public bool AddByString(Model.z_person_extend model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			strSql1.Append("insert into z_person_extend (");
			strSql2.Append("Values(");
			
											
			if(!string.IsNullOrEmpty(model.PKID))
			{
			  strSql1.Append("PKID,");
			  strSql2.Append("'"+model.PKID+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_mqsfz))
			{
			  strSql1.Append("P_mqsfz,");
			  strSql2.Append("'"+model.P_mqsfz+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.p_poID))
			{
			  strSql1.Append("p_poID,");
			  strSql2.Append("'"+model.p_poID+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_poxm))
			{
			  strSql1.Append("P_poxm,");
			  strSql2.Append("'"+model.P_poxm+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.p_pozjlx))
			{
			  strSql1.Append("p_pozjlx,");
			  strSql2.Append("'"+model.p_pozjlx+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_posfz))
			{
			  strSql1.Append("P_posfz,");
			  strSql2.Append("'"+model.P_posfz+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_gzdwxz))
			{
			  strSql1.Append("P_gzdwxz,");
			  strSql2.Append("'"+model.P_gzdwxz+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_gzdwmc))
			{
			  strSql1.Append("P_gzdwmc,");
			  strSql2.Append("'"+model.P_gzdwmc+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_gzdwdz))
			{
			  strSql1.Append("P_gzdwdz,");
			  strSql2.Append("'"+model.P_gzdwdz+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_gzdwdh))
			{
			  strSql1.Append("P_gzdwdh,");
			  strSql2.Append("'"+model.P_gzdwdh+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_zylx))
			{
			  strSql1.Append("P_zylx,");
			  strSql2.Append("'"+model.P_zylx+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.Person_ID))
			{
			  strSql1.Append("Person_ID,");
			  strSql2.Append("'"+model.Person_ID+"',");
			}	
															
			if(model.AddTime!=null)
			{
			  strSql1.Append("AddTime,");
			  strSql2.Append("'"+model.AddTime+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.AddBy))
			{
			  strSql1.Append("AddBy,");
			  strSql2.Append("'"+model.AddBy+"',");
			}	
															
			if(model.UpdateTime!=null)
			{
			  strSql1.Append("UpdateTime,");
			  strSql2.Append("'"+model.UpdateTime+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.UpdateBy))
			{
			  strSql1.Append("UpdateBy,");
			  strSql2.Append("'"+model.UpdateBy+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.p_fqID))
			{
			  strSql1.Append("p_fqID,");
			  strSql2.Append("'"+model.p_fqID+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_fqxm))
			{
			  strSql1.Append("P_fqxm,");
			  strSql2.Append("'"+model.P_fqxm+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_fqzjlx))
			{
			  strSql1.Append("P_fqzjlx,");
			  strSql2.Append("'"+model.P_fqzjlx+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_fqsfz))
			{
			  strSql1.Append("P_fqsfz,");
			  strSql2.Append("'"+model.P_fqsfz+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.p_mqID))
			{
			  strSql1.Append("p_mqID,");
			  strSql2.Append("'"+model.p_mqID+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_mqxm))
			{
			  strSql1.Append("P_mqxm,");
			  strSql2.Append("'"+model.P_mqxm+"',");
			}	
															
			if(!string.IsNullOrEmpty(model.P_mqzjlx))
			{
			  strSql1.Append("P_mqzjlx,");
			  strSql2.Append("'"+model.P_mqzjlx+"',");
			}	
										
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1)).Append(")");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1)).Append(")");
			bool result=SqlHelper.ExecuteNonQuery(SqlHelper.CityConnectionString,strSql.ToString())>0?true:false;
			return result;
		}
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.z_person_extend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update z_person_extend  set ");
									
			if (!string.IsNullOrEmpty(model.PKID))
			{
			  strSql.Append("PKID='"+model.PKID+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_mqsfz))
			{
			  strSql.Append("P_mqsfz='"+model.P_mqsfz+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.p_poID))
			{
			  strSql.Append("p_poID='"+model.p_poID+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_poxm))
			{
			  strSql.Append("P_poxm='"+model.P_poxm+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.p_pozjlx))
			{
			  strSql.Append("p_pozjlx='"+model.p_pozjlx+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_posfz))
			{
			  strSql.Append("P_posfz='"+model.P_posfz+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_gzdwxz))
			{
			  strSql.Append("P_gzdwxz='"+model.P_gzdwxz+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_gzdwmc))
			{
			  strSql.Append("P_gzdwmc='"+model.P_gzdwmc+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_gzdwdz))
			{
			  strSql.Append("P_gzdwdz='"+model.P_gzdwdz+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_gzdwdh))
			{
			  strSql.Append("P_gzdwdh='"+model.P_gzdwdh+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_zylx))
			{
			  strSql.Append("P_zylx='"+model.P_zylx+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.Person_ID))
			{
			  strSql.Append("Person_ID='"+model.Person_ID+"',");
			}
            						            
			if (model.AddTime!=null)
			{
			  strSql.Append("AddTime='"+model.AddTime+"',");
			}
													
			if (!string.IsNullOrEmpty(model.AddBy))
			{
			  strSql.Append("AddBy='"+model.AddBy+"',");
			}
            						            
			if (model.UpdateTime!=null)
			{
			  strSql.Append("UpdateTime='"+model.UpdateTime+"',");
			}
													
			if (!string.IsNullOrEmpty(model.UpdateBy))
			{
			  strSql.Append("UpdateBy='"+model.UpdateBy+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.p_fqID))
			{
			  strSql.Append("p_fqID='"+model.p_fqID+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_fqxm))
			{
			  strSql.Append("P_fqxm='"+model.P_fqxm+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_fqzjlx))
			{
			  strSql.Append("P_fqzjlx='"+model.P_fqzjlx+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_fqsfz))
			{
			  strSql.Append("P_fqsfz='"+model.P_fqsfz+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.p_mqID))
			{
			  strSql.Append("p_mqID='"+model.p_mqID+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_mqxm))
			{
			  strSql.Append("P_mqxm='"+model.P_mqxm+"',");
			}
            									
			if (!string.IsNullOrEmpty(model.P_mqzjlx))
			{
			  strSql.Append("P_mqzjlx='"+model.P_mqzjlx+"',");
			}
            strSql.Append(" where Person_id='"+model.Person_ID+"'");
            						
			bool result=SqlHelper.ExecuteNonQuery(SqlHelper.CityConnectionString,strSql.ToString())>0?true:false;
			return result;
		}
		
   
	}
}