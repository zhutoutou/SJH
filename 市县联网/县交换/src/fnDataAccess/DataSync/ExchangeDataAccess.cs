using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace ZIT.XJHServer.fnDataAccess.DataSync
{
    public class ExchangeDataAccess
    {
        /// <summary>
        /// 定义根程序集
        /// </summary>
        private static readonly string strAssemblyName = "DAM";
        private static readonly string strNameSpaceName = "ZIT.XJHServer.fnDataAccess.DataSync";
        /// <summary>
        /// 读取数据库类型
        /// </summary>
        private static readonly string db = ConfigurationManager.AppSettings["DBType"];
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
        public static IUpdateData UpdateDadaAccess()
        {
            string strClassName = strNameSpaceName + "." + db + ".UpdateData";
            return (IUpdateData)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }
        public static IBSSData GetBSSData()
        {
            string strClassName = strNameSpaceName + "." + db + ".BSSData";
            return (IBSSData)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }
        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
        public static IUpdateMidState UpdateMidStateAccess()
        {
            string strClassName = strNameSpaceName + "." + db + ".UpdateMidState";
            return (IUpdateMidState)Assembly.Load(strAssemblyName).CreateInstance(strClassName);
        }
    }
}
