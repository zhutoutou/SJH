using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 请求获取报警电话位置信息
    /// </summary>
    public class GetReportAlarmLocationInfo
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 发送方网络单位ID
        /// </summary>
        public string SourceUnitID { get; set; }
        /// <summary>
        /// 数据接收方网络单位ID
        /// </summary>
        public string TargetUnitID { get; set; }
        /// <summary>
        /// 报警电话号码
        /// </summary>
        public string Telephone { get; set; }
    }
}
