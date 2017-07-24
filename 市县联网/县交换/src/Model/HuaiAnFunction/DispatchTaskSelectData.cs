using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.HuaiAnFunction
{
    /// <summary>
    /// 6101消息转成XML格式
    /// </summary>
    public class DispatchTaskSelectData
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 分中心流水号
        /// </summary>
        public string LSH { get; set; }
        /// <summary>
        /// 中心受理台分机号码
        /// </summary>
        public string DDHM { get; set; }
        /// <summary>
        /// 分中心受理台号
        /// </summary>
        public string SLTH { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DWBH { get; set; }
    }
}
