using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.HuaiAnFunction
{
    /// <summary>
    /// 6111中心受理台发送派单消息给中心业务服务器，然后转发给中心交换服务器
    /// </summary>
    public class DispatchTaskSingle
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
        /// 中心受理台号
        /// </summary>
        public string ZSLTH { get; set; }
        /// <summary>
        /// 中心受理分机
        /// </summary>
        public string ZSLFJ { get; set; }
        /// <summary>
        /// 主叫号码
        /// </summary>
        public string ZJHM { get; set; }
        /// <summary>
        /// 主叫姓名
        /// </summary>
        public string ZJXM { get; set; }
        /// <summary>
        /// 主叫地址
        /// </summary>
        public string ZJDZ { get; set; }
        /// <summary>
        /// 分中心编码
        /// </summary>
        public string FZXBM { get; set; }

    }
}
