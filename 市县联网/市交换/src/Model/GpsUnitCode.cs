using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model
{
    /// <summary>
    /// 针对二期使用的增加的单位编号，单位ID
    /// </summary>
   public class GpsUnitCode
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DWBH { get; set; }
        /// <summary>
        /// 车辆ID
        /// </summary>
        public string CLID { get; set; }
    }
}
