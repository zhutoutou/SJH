using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.PositioningFunction
{
    /// <summary>
    /// 车辆轨迹回放停止数据
    /// </summary>
    public class StopTrack
    {
        public string CommandID { get; set; }
        public string StationNo { get; set; }
        public string Mobile { get; set; }
        public string DWBH { get; set; }
        public string CLID { get; set; }

    }
}
