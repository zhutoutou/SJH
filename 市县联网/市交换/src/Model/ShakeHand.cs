using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model
{
    /// <summary>
    /// 握手协议
    /// </summary>
    public class ShakeHand
    {
        /// <summary>
        /// ID
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DWBH { get; set; }
        /// <summary>
        /// 台类型
        /// </summary>
        public string TLX { get; set; }
        /// <summary>
        /// 单位信息
        /// </summary>
        public string DWMC { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string ZT { get; set; }
    }
}
