using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.HuaiAnFunction
{
    /// <summary>
    ///6113 如果分中心未接听电话，关闭分中心调度界面时会发送6113消息
    /// </summary>
   public class DispatchTaskNoAnswer
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 中心流水号
        /// </summary>
        public string ZLSH { get; set; }
        /// <summary>
        /// 分中心编码
        /// </summary>
        public string FZXBM { get; set; }
    }
}
