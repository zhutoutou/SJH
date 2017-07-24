using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 呼叫记录信息上报的应答
    /// </summary>
    public class CallRcordDataResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 呼叫记录流水号
        /// </summary>
        public string CallID { get; set; }
        /// <summary>
        /// 上报结果1:   上报成功0:   上报失败
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailtureReason { get; set; }

    }
}
