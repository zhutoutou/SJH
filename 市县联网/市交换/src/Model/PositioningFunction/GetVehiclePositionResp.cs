using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 快速单点定位的应答
    /// </summary>
   public class GetVehiclePositionResp
    {
       /// <summary>
       /// 消息名
       /// </summary>
       public string CommandID{get;set;}
       /// <summary>
       /// 电子地图台号
       /// </summary>
       public int? StationNo{get;set;}
       /// <summary>
       /// 车载手机号码
       /// </summary>
       public string Mobile {get;set;}
       /// <summary>
       /// 车辆定位经度
       /// </summary>
       public string Longitude {get;set;}
       /// <summary>
       /// 车辆定位纬度
       /// </summary>
         public string Latitude {get;set;}
       /// <summary>
       /// 车辆位置海拔高度
       /// </summary>
        public string Height {get;set;}
       /// <summary>
       /// 车辆速度，单位为海里/小时
       /// </summary>
        public string Speed {get;set;}
       /// <summary>
       /// 车辆位置方向
       /// </summary>
        public string Direction {get;set;}
       /// <summary>
       /// 可视星数
       /// </summary>
        public int? VisibleStar {get;set;}
       /// <summary>
       /// 跟踪星数
       /// </summary>
        public int? TrackStar {get;set;}
       /// <summary>
       /// 天线状态, 0正常,1有故障
       /// </summary>
       public int? AntennaStatus {get;set;}
    }
}
