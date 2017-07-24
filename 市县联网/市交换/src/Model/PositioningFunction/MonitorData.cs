using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 上报实时定位监控数据
    /// </summary>
    public class MonitorData:GpsUnitCode
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID{get;set;}
        /// <summary>
        /// 电子地图台号
        /// </summary>
        public string StationNo{get;set;}
        /// <summary>
        /// 车载手机号码
        /// </summary>
        public string Mobile{get;set;}
        /// <summary>
        /// 定位条件类型1:  规定时间间隔16:  车辆轨迹回放的数据
        /// </summary>
        public string MonitorType{get;set;}
        /// <summary>
        /// 车辆实时定位监控数据的个数
        /// </summary>
        public string DataNumber{get;set;}
        /// <summary>
        /// 每一个车辆实时定位的时间
        /// </summary>
        public string LocateTime1 { get; set; }
        /// <summary>
        /// 车辆定位经度
        /// </summary>
        public string Longitude1 { get; set; }
        /// <summary>
        /// 车辆定位纬度
        /// </summary>
        public string Latitude1 { get; set; }
        /// <summary>
        /// 车辆位置海拔高度
        /// </summary>
        public string Height1 { get; set; }
        /// <summary>
        /// 车辆速度
        /// </summary>
        public string Speed1 { get; set; }
        /// <summary>
        /// 车辆位置方向
        /// </summary>
        public string Direction1 { get; set; }
        /// <summary>
        /// 可视星数
        /// </summary>
        public string VisibleStar1 { get; set; }
        /// <summary>
        /// 跟踪星数
        /// </summary>
        public string TrackStar1 { get; set; }
        /// <summary>
        /// 天线状态, 0正常,1有故障
        /// </summary>
        public string AntennaStatus1 { get; set; }

    }
}
