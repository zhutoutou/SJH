using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 车辆实时定位监控数据
    /// </summary>
   public class LocationData
    {
        /// <summary>
        /// 每一个车辆实时定位的时间
        /// </summary>
        public string LocateTime { get; set; }
        /// <summary>
        /// 车辆定位经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 车辆定位纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 车辆位置海拔高度
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// 车辆速度
        /// </summary>
        public string Speed { get; set; }
        /// <summary>
        /// 车辆位置方向
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// 可视星数
        /// </summary>
        public string VisibleStar { get; set; }
        /// <summary>
        /// 跟踪星数
        /// </summary>
        public string TrackStar { get; set; }
        /// <summary>
        /// 天线状态, 0正常,1有故障
        /// </summary>
        public string AntennaStatus { get; set; }
    }
}
