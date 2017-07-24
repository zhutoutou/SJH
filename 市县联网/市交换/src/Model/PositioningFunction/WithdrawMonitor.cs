using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 撤消实时监控
    /// </summary>
    public class WithdrawMonitor : GpsUnitCode
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 电子地图台号
        /// </summary>
        public string StationNo { get; set; }
        /// <summary>
        /// 车载手机号码
        /// </summary>
        public string Mobile { get; set; }
    }
}
