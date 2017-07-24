using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using ZIT.SJHServer.fnArgs;
using ZIT.SJHServer.Model;

namespace ZIT.SJHServer.fnDataAccess
{
    public class DataAccess
    {
        /// <summary>
        /// 定义根程序集
        /// </summary>
        private static readonly string strAssemblyName = "fnDataAccess";
        private static readonly string strNameSpaceName = "ZIT.SJHServer.fnDataAccess";
        /// <summary>
        /// 读取数据库类型
        /// </summary>
        private static readonly string db = SystemArgs.GetInstance().args.DBType;
        /// <summary>
        /// 返回数据交换类
        /// </summary>
        /// <returns></returns>
        public static IDataExchangeDataAccess DataExchangeDataAccess()
        {
            string strClassName = strNameSpaceName + "." + db + ".DataExchangeDataAccess";
            return (IDataExchangeDataAccess)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }
       
        /// <summary>
        /// 返回派分中心调度单
        /// </summary>
        /// <returns></returns>
        public static IDispatchTaskSingleDataAccess DispatchTaskSingleDataAccess()
        {
            string strClassName = strNameSpaceName + "." + db + ".DispatchTaskSelectSingle";
            return (IDispatchTaskSingleDataAccess)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }
       
       
    }
}
