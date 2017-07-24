using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.HuaiAnFunction
{
    /// <summary>
    /// 分中心业务服务器状态
    /// </summary>
   public class SubCenterState
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 分中心名称
        /// </summary>
        public string FZXMC { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string ZT { get; set; }
        
    }
}
