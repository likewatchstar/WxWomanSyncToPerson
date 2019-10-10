using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WxWomanSyncToZPerson
{
    class SqlHelper
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        public static string CityConnectionString = ConfigurationManager.AppSettings["CityConnectionString"].ToString();
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(ConnectionString,CommandType.Text, commandText, null);
        }
        public static int ExecuteNonQuery(string commandText,CommandType commandType)
        {
            return ExecuteNonQuery(ConnectionString,commandType, commandText, null);
        }
        public static int ExecuteNonQuery(string commandText, CommandType commandType,params SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery(ConnectionString,commandType, commandText, sqlParameters);
        }
        public static int ExecuteNonQuery(string commandText,SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery(ConnectionString,CommandType.Text, commandText, sqlParameters);
        }
        public static int ExecuteNonQuery(string ThisConnection,string commandText)
        {
            return ExecuteNonQuery(ThisConnection, CommandType.Text, commandText, null);
        }
        public static int ExecuteNonQuery(string ThisConnection, string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(ThisConnection, commandType, commandText, null);
        }
        public static int ExecuteNonQuery(string ThisConnection, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery(ThisConnection, commandType, commandText, sqlParameters);
        }
        public static int ExecuteNonQuery(string ThisConnection, string commandText, params SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery(ThisConnection, CommandType.Text, commandText, sqlParameters);
        }
        public static int ExecuteNonQuery(SqlTransaction sqlTransaction, string commandText)
        {
            return ExecuteNonQuery(sqlTransaction, CommandType.Text, commandText, null);
        }
        public static int ExecuteNonQuery(SqlTransaction sqlTransaction, string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(sqlTransaction, commandType, commandText, null);
        }
        public static int ExecuteNonQuery(SqlTransaction sqlTransaction, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery(sqlTransaction, commandType, commandText, sqlParameters);
        }
        public static int ExecuteNonQuery(SqlTransaction sqlTransaction, string commandText, params SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery(sqlTransaction, CommandType.Text, commandText, sqlParameters);
        }










        public static int ExecuteNonQuery(string Connection, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {
            
            if (Connection == null||Connection.Length==0) throw new ArgumentNullException("ConnectionString");
            SqlCommand sqlCommand = new SqlCommand();
            PrepareCommand(sqlCommand,Connection,commandType,commandText,sqlParameters);
            int result = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            sqlCommand.Connection.Close();
            return result;
        }

        public static int ExecuteNonQuery(SqlTransaction sqlTransaction,CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {
            if (sqlTransaction == null) throw new ArgumentNullException("sqlTransaction");
            if (sqlTransaction.Connection == null||sqlTransaction.Connection.ToString().Length==0) throw new ArgumentNullException("ConnectionString");
            SqlCommand sqlCommand = new SqlCommand();
            PrepareCommand(sqlCommand,sqlTransaction, commandType, commandText, sqlParameters);
            int result = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            return result;
        }





        public static DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(ConnectionString, CommandType.Text, commandText, null);
        }
        public static DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            return ExecuteDataSet(ConnectionString, commandType, commandText, null);
        }
        public static DataSet ExecuteDataSet(string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return ExecuteDataSet(ConnectionString, commandType, commandText, sqlParameters);
        }
        public static DataSet ExecuteDataSet(string commandText, params SqlParameter[] sqlParameters)
        {
            return ExecuteDataSet(ConnectionString, CommandType.Text, commandText, sqlParameters);
        }
        public static DataSet ExecuteDataSet(string ThisConnection, string commandText)
        {
            return ExecuteDataSet(ThisConnection, CommandType.Text, commandText, null);
        }
        public static DataSet ExecuteDataSet(string ThisConnection, string commandText, CommandType commandType)
        {
            return ExecuteDataSet(ThisConnection, commandType, commandText, null);
        }
        public static DataSet ExecuteDataSet(string ThisConnection, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return ExecuteDataSet(ThisConnection, commandType, commandText, sqlParameters);
        }
        public static DataSet ExecuteDataSet(string ThisConnection, string commandText, params SqlParameter[] sqlParameters)
        {
            return ExecuteDataSet(ThisConnection, CommandType.Text, commandText, sqlParameters);
        }
        public static DataSet ExecuteDataSet(SqlTransaction sqlTransaction, string commandText)
        {
            return ExecuteDataSet(sqlTransaction, CommandType.Text, commandText, null);
        }
        public static DataSet ExecuteDataSet(SqlTransaction sqlTransaction, string commandText, CommandType commandType)
        {
            return ExecuteDataSet(sqlTransaction, commandType, commandText, null);
        }
        public static DataSet ExecuteDataSet(SqlTransaction sqlTransaction, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return ExecuteDataSet(sqlTransaction, commandType, commandText, sqlParameters);
        }
        public static DataSet ExecuteDataSet(SqlTransaction sqlTransaction, string commandText, params SqlParameter[] sqlParameters)
        {
            return ExecuteDataSet(sqlTransaction, CommandType.Text, commandText, sqlParameters);
        }
        public static DataSet ExecuteDataSet(string Connection,CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {

            if (Connection == null) throw new ArgumentNullException("ConnectionString");
            SqlCommand sqlCommand = new SqlCommand();
            PrepareCommand(sqlCommand,Connection,commandType, commandText, sqlParameters); 
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
                return dataSet;
            }
        }

        public static DataSet ExecuteDataSet(SqlTransaction sqlTransaction,CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {

            if (sqlTransaction== null) throw new ArgumentNullException("sqlTransaction");
            if (sqlTransaction.Connection == null|| sqlTransaction.Connection.ToString().Length==0) throw new ArgumentNullException("ConnectionString");
            SqlCommand sqlCommand = new SqlCommand();
            
            PrepareCommand(sqlCommand,sqlTransaction,commandType, commandText, sqlParameters);
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                sqlCommand.Parameters.Clear();
 
                return dataSet;
            }
        }





        public static void PrepareCommand(SqlCommand cmd,string Connection,CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {
            SqlConnection sqlConnection = new SqlConnection(Connection);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            cmd.Connection = sqlConnection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = 0;
            if (sqlParameters != null&&sqlParameters.Length!=0)
            {
                foreach (SqlParameter parm in sqlParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }


        public static void PrepareCommand(SqlCommand cmd,SqlTransaction tran, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {
            SqlConnection sqlConnection = tran.Connection;
            
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            cmd.Connection = sqlConnection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = 0;

           
            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            if (sqlParameters != null && sqlParameters.Length != 0)
            {
                foreach (SqlParameter parm in sqlParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
    }
}
