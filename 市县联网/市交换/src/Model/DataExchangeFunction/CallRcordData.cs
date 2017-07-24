using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 呼叫记录信息上报
    /// </summary>
    public class CallRcordData
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
        /// 主叫号码
        /// </summary>
        public string CallNumber { get; set; }
        /// <summary>
        /// 被叫号码
        /// </summary>
        public string CalledNumber { get; set; }
        /// <summary>
        /// 主叫类型 (1:普通呼救； 2:工作电话； 3:骚扰电话； 4: 咨询电话； 5: 重点用户)
        /// </summary>
        public string CallType { get; set; }
        /// <summary>
        /// 处理类型:未接听、接听(呼入时)、呼出
        /// </summary>
        public string DealType { get; set; }
        /// <summary>
        /// 呼叫时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string CallTime { get; set; }
        /// <summary>
        /// 应答时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string RespTime { get; set; }
        /// <summary>
        /// 等待时长,应答时间-呼叫时间(单位为秒)
        /// </summary>
        public string WaitTime { get; set; }
        /// <summary>
        /// 挂机时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string HangupTime { get; set; }
        /// <summary>
        /// 通话时长,挂机时间-应答时间(单位为秒)
        /// </summary>
        public string TalkTime { get; set; }
        /// <summary>
        /// 调度开始时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string AttempeStartTime { get; set; }
        /// <summary>
        /// 调度结束时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string AttempeEndTime { get; set; }
        /// <summary>
        /// 调度时长, 调度开始时间减去调度结束时间(单位为秒)
        /// </summary>
        public string AttempeTime { get; set; }
        /// <summary>
        /// 受理座席台号
        /// </summary>
        public string AgentID { get; set; }
        /// <summary>
        /// 值班员工号
        /// </summary>
        public string WatcherID { get; set; }
        /// <summary>
        /// 电话、来人、培训、演练、其他
        /// </summary>
        public string InfoSurce { get; set; }

    }
}
