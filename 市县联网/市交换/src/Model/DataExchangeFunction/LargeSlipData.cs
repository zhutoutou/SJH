using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 大型事故上报
    /// </summary>
    public class LargeSlipData
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string ID { get; set; }
        
        /// <summary>
        /// 事故名称
        /// </summary>
        public string SlipName { get; set; }
        /// <summary>
        /// 事故类型
        /// </summary>
        public string SlipType { get; set; }
        /// <summary>
        /// 事故原因
        /// </summary>
        public string SlipReason { get; set; }
        /// <summary>
        /// 上报部门一
        /// </summary>
        public string ReportDepartment1 { get; set; }
        /// <summary>
        /// 电话号码一
        /// </summary>
        public string Telephone1 { get; set; }
        /// <summary>
        /// 接话人一
        /// </summary>
        public string CalledPerson1 { get; set; }
        /// <summary>
        /// 上报时间一，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ReportTime1 { get; set; }
        /// <summary>
        /// 指挥车到达时间一，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ArriveTime1 { get; set; }
        /// <summary>
        /// 上报部门二
        /// </summary>
        public string ReportDepartment2 { get; set; }
        /// <summary>
        /// 电话号码二
        /// </summary>
        public string Telephone2 { get; set; }
        /// <summary>
        /// 接话人二
        /// </summary>
        public string CalledPerson2 { get; set; }
        /// <summary>
        /// 上报时间二，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ReportTime2 { get; set; }
        /// <summary>
        /// 指挥车到达时间二，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ArriveTime2 { get; set; }
        /// <summary>
        /// 上报部门三
        /// </summary>
        public string ReportDepartment3 { get; set; }
        /// <summary>
        /// 电话号码三
        /// </summary>
        public string Telephone3 { get; set; }
        /// <summary>
        /// 接话人三
        /// </summary>
        public string CalledPerson3 { get; set; }
        /// <summary>
        /// 上报时间三，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ReportTime3 { get; set; }
        /// <summary>
        /// 指挥车到达时间三，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ArriveTime3 { get; set; }
        /// <summary>
        /// 现场抢救结束时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string SalveFinishTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
