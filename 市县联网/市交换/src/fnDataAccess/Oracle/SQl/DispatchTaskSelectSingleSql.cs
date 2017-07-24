using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.fnDataAccess.Oracle.SQl
{
    /// <summary>
    /// 查询中心派受理单记录
    /// </summary>
    public class DispatchTaskSelectSingleSql
    {
        /// <summary>
        /// 根据中心受理台分机号码查询受理记录基础信息
        /// </summary>
        /// <param name="DDHM">中心受理台分机号码</param>
        /// <returns></returns>
        public static string GetRecordSql(string DDHM)
        {
            string strSql = "select * from ZFZXDHXXB where isread=0 and ZXSLFJHM='" + DDHM + "'";
            return strSql;
        }
        /// <summary>
        /// 根据中心受理台分机号码查询更新标识位
        /// </summary>
        /// <param name="DDHM">中心受理台分机号码</param>
        /// <returns></returns>
        public static string SetRecordFlagSql(string DDHM,string FZXLSH)
        {
            string strSql = "update ZFZXDHXXB set isread=1，fzxlsh='" + FZXLSH + "' where isread=0 and ZXSLFJHM='" + DDHM + "'";
            return strSql;
        }
    }
}
