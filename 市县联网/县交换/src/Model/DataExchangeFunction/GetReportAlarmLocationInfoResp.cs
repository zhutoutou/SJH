using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 请求获取报警电话位置信息应答
    /// </summary>
    public class GetReportAlarmLocationInfoResp
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
        /// 请求结果1:成功 0:失败
        /// </summary>
        public int? ReguestResult { get; set; }
        /// <summary>
        /// 报警电话号码
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 报警地点定位经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 报警地点定位纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 报警人机主名称
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// 报警所在地址
        /// </summary>
        public string Address { get; set; }
    }
}
