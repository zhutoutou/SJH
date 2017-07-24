using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model
{
    /// <summary>
    /// 分中心状态
    /// </summary>
    public class SubordinateStatus
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DWBH { get; set; }
        /// <summary>
        /// 中心流水号
        /// </summary>
        public string ZXLSH { get; set; }
    }
}
