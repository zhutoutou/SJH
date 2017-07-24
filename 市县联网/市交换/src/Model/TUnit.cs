using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ZIT.SJHServer.Model
{
    //网络单元属性结构数组
    public class TUnit
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UnitCode { get; set; }
        /// <summary>
        /// 单位行政区名称
        /// </summary>
        public string UnitXZQMC { get; set; }
        /// <summary>
        /// 单位行政编码
        /// </summary>
        public string UnitXZBM { get; set; }
    }
}
