using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 撤消实时监控的应答
    /// </summary>
    public class WithdrawMonitorResp
    {
        /// <summary>
        /// 消息名称
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 电子地图台号
        /// </summary>
        public int? StationNo { get; set; }
        /// <summary>
        /// 车载手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 1成功、0失败
        /// </summary>
        public int? WithdrawResult { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailureReason { get; set; }

    }
}
