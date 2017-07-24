using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DispatchFunction
{
    /// <summary>
    /// 发送车辆状态到镇江市急救指挥中心
    /// </summary>
    public class VehicleStatus
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 车辆状态改变时间
        /// </summary>
        public string StatusChangeTime { get; set; }
        /// <summary>
        /// 车载手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 定位经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 定位纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 海拔高度
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
        /// <summary>
        /// 车辆运行状态
        /// 1: 待命2: 出车3: 到达现场4: 病人上车5: 病人不去6: 车到人走7: 死亡不送8: 送达医院9: 任务完成10: 回站11：未值班12：维修13：暂停调用
        /// </summary>
        public string WorkStatus { get; set; }
        /// <summary>
        /// 车辆行驶总里程
        /// </summary>
        public string SteerTotalMileage { get; set; }
        /// <summary>
        /// 车辆行驶里程
        /// </summary>
        public string SteerMileage { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DWBH { get; set; }
        /// <summary>
        /// 系统版本转化
        /// </summary>
        public string Version { get; set; }
    }
}
