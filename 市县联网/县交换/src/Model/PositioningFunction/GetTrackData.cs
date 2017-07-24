using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 请求车辆轨迹回放数据
    /// </summary>
    public class GetTrackData : GpsUnitCode
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
        /// 车载手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 轨迹回放的开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 轨迹回放的结束时间
        /// </summary>
        public string EndTime { get; set; }

    }
}
