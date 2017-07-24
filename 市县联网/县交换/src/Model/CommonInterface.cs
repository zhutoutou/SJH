using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model
{
    /// <summary>
    /// 该接口主要是传输特定的消息，
    /// 不需要市县联网服务器重新拆包和组包，
    /// 直接转发给对应BSS或者GPS既可以了。
    /// </summary>
    public class CommonInterface
    {
        /// <summary>
        /// 消息号
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 单位编号 0值表示发送所有分中心
        /// </summary>
        public string DWBH { get; set; }
        /// <summary>
        /// BSS表示业务服务器，GPS表示GPS服务器
        /// </summary>
        public string ServerType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string NR { get; set; }
    }
}
