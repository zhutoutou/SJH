using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DispatchFunction
{
    /// <summary>
    /// 请求获取车辆状态
    /// </summary>
    public class GetVehicleStatus:GpsUnitCode
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
        ///// <summary>
        ///// 单位编号
        ///// </summary>
        //public string DWBH { get; set; }
        
    }
}
