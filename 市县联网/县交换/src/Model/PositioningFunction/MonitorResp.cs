using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 规定时间间隔定时监控的应答
    /// </summary>
    public class MonitorResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 电子地图台号
        /// </summary>
        public int? StationNo { get; set; }
        /// <summary>
        /// 车载手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 1成功、0失败
        /// </summary>
        public int? SetResult { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailureReason { get; set; }

    }
}
