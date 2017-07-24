using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 系统人员数据的应答
    /// </summary>
    public class SysUserDataResp
    {
       
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 系统登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 上报结果1:   上报成功0:   上报失败s
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailtureReason { get; set; }
    }
}
