using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 受理信息数据上报的应答
    /// </summary>
    public class DealDataResp
    {
        /// <summary>
        ///   消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 受理记录流水号
        /// </summary>
        public string DealRecordID { get; set; }
        /// <summary>
        /// 上报结果0x01:   上报成功0x00:   上报失败

        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因，如果成功则没有这段内容
        /// </summary>
        public string FailtureReason { get; set; }
    }
}
