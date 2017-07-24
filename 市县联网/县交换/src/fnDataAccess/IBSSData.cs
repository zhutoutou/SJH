using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.XJHServer.Model.PositioningFunction;
using ZIT.XJHServer.Model.DispatchFunction;

namespace ZIT.XJHServer.fnDataAccess
{
    /// <summary>
    /// 8.0系统接口
    /// </summary>
   public interface IBSSData
    {
        /// <summary>
        /// 快速单点定位返回值
        /// </summary>
        /// <returns></returns>
       GetVehiclePositionResp GetVehiclePositionResp(int StationNo, string Mobile, string DWBH, string CLID);
        /// <summary>
        /// 轨迹回放返回值
        /// </summary>
        /// <returns></returns>
       List<MonitorData> GetMonitorData(string StartTime, string EndTime, string DWBH, string CLID, string StationNo, string Mobile,string lx);
        /// <summary>
       /// 当前车辆状态返回值
        /// </summary>
        /// <returns></returns>
       List<VehicleStatus> GetVehicleStatus(string DWBH);
    }
}
