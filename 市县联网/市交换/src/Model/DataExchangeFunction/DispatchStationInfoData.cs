using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 调度分站记录信息上报
    /// </summary>
    public class DispatchStationInfoData
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 出车单位名称
        /// </summary>
        public string DispatchVehicleUnit { get; set; }
        /// <summary>
        /// 分站值班员
        /// </summary>
        public string BranchWatcher { get; set; }
        /// <summary>
        /// 分站调度时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string DispatchTime { get; set; }
        /// <summary>
        /// 分站反馈时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string FeedbackTime { get; set; }
        /// <summary>
        /// 中心值班员
        /// </summary>
        public string CenterWatcher { get; set; }
        /// <summary>
        /// 调度类型(0-中心调分中心，1-中心调分中心的分站，2-分中心请中心支援，3-分中心请另分中心支援)
        /// </summary>
        public string AttempeType { get; set; }
        /// <summary>
        /// 是否退单(是,否,null)
        /// </summary>
        public string CancelForm { get; set; }
        /// <summary>
        /// 退单原因
        /// </summary>
        public string CancelFormReason { get; set; }
        /// <summary>
        /// 退单时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string CancelFormTime { get; set; }
        /// <summary>
        /// 所属中心
        /// </summary>
        public string OwnerCenter { get; set; }
        /// <summary>
        /// 调度单位
        /// </summary>
        public string DispatchUnit { get; set; }
       
    }
}
