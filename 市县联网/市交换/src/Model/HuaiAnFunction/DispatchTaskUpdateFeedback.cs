using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.HuaiAnFunction
{
    /// <summary>
    /// 6104分中心交换服务器数据更新完成后通知中心交换服务器
    /// </summary>
   public class DispatchTaskUpdateFeedback
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 分中心流水号
        /// </summary>
        public string FZXLSH { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string ZXLSH { get; set; }
        /// <summary>
        /// 收到消息时间
        /// </summary>
        public string SDSJ { get; set; }
        /// <summary>
        /// 分中心名称
        /// </summary>
        public string FZXMC { get; set; }
       
    }
}
