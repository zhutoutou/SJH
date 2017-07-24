using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using ZIT.SJHServer.fnArgs;
using ZIT.SJHServer.Model;

namespace ZIT.SJHServer.fnLocalDataAccess
{
    public class LocalDataAccess
    {
        /// <summary>
        /// 定义根程序集
        /// </summary>
        private static readonly string strAssemblyName = "fnLocalDataAccess";
        private static readonly string strNameSpaceName = "ZIT.SJHServer.fnLocalDataAccess";
        /// <summary>
        /// 读取数据库类型
        /// </summary>
        private static readonly string db = SystemArgs.GetInstance().args.DBType;
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public static IGetData GetDataAccess()
        {
            string strClassName = strNameSpaceName + "." + db + ".GetData";
            return (IGetData)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }
        /// <summary>
        /// 更新应答数据isUpdated为0
        /// </summary>
        /// <returns></returns>
        public static IUpdateData UpdateDataAccess()
        {
            string strClassName = strNameSpaceName + "." + db + ".UpdateData";
            return (IUpdateData)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public static ISyncData SyncDataAccess()
        {
            string strClassName = strNameSpaceName + "." + db + ".SyncData";
            return (ISyncData)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }
  
    }
}
