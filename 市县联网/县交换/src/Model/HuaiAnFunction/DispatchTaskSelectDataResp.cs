using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.HuaiAnFunction
{
    /// <summary>
    /// 中心交换给分中心交换6101应答
    /// </summary>
    public class DispatchTaskSelectDataResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 中心流水号
        /// </summary>
        public string ZXLSH { get; set; }
        /// <summary>
        /// 呼叫地址
        /// </summary>
        public string HJDZ { get; set; }
        /// <summary>
        /// 主叫姓名（HZ）
        /// </summary>
        public string ZJXM { get; set; }
        /// <summary>
        /// 主叫号码
        /// </summary>
        public string ZJHM { get; set; }
        /// <summary>
        /// 分中心流水号
        /// </summary>
        public string FZXLSH { get; set; }
        /// <summary>
        /// 分中心受理台号
        /// </summary>
        public string FZXSLTH { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DWBH { get; set; }
    }
}
