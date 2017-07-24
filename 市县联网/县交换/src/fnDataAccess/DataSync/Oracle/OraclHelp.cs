using System;
using System.Configuration;
using System.Data;
using ZIT.LOG;
using System.Data.OracleClient;
using ZIT.XJHServer.fnArgs;

namespace ZIT.XJHServer.fnDataAccess.DataSync.Oracle
{
    
    public static class OraclHelp
    {
        /// <summary>
        /// 连接字符串
        /// </summary>

        private static string strConns = SystemArgs.GetInstance().args.DBConnectString;

        public static int OperationRecord(string sqlstr)
        {
            int intFlag = 0;
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConns))
                {
                    sqlConn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = sqlConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlstr;
                    intFlag = cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    LogHelper.WriteLog("执行SQL语句：" + sqlstr + ",执行结果：" + intFlag.ToString());
                    return intFlag;
                    
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("",ex);
                return -1;
            }
        }
        //查询
        public static DataTable GetRecord(string sql)
        {
            DataTable dt = new DataTable();
            try
            {

                using (OracleConnection sqlConn = new OracleConnection(strConns))
                {
                    sqlConn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = sqlConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    OracleDataAdapter oDA = new OracleDataAdapter(cmd);
                    oDA.Fill(dt);
                    sqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
