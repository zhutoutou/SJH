using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 患者信息数据上报的应答
    /// </summary>
    public class SuffererDataResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        //201511201 修改人:朱星汉 修改内容:添加车辆编号
        /// <summary>
        ///患者所是急救车的车辆编号 
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 患者所是急救车辆的车载手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 与本次出车所对应的受理记录流水号
        /// </summary>
        public string DealRecordID { get; set; }
        /// <summary>
        /// 出车记录流水号
        /// </summary>
        public string DispatchVehicleID { get; set; }
        /// <summary>
        /// 患者编号
        /// </summary>
        public string SuffererNo { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string SuffererName { get; set; }
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
