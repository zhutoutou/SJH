using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 规定时间间隔的定时监控
    /// </summary>
    public class Monitor:GpsUnitCode
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
        /// <summary>
        /// 开始监控时间
        /// </summary>
        public string StartMonitorTime { get; set; }
        /// <summary>
        /// 车辆监控时间长度，单位为秒
        /// </summary>
        public string TimeLength { get; set; }
        /// <summary>
        /// 车辆监控时间间隔，单位为秒，最小为1秒 
        /// </summary>
        public string TimeInterval { get; set; }
       
    }
}
