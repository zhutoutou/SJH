using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 急救人员及急救车辆关系上报的应答
    /// </summary>
    public class PVRelationResp
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 车载手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 是否上班标志（0: 下班； 1 上班）
        /// </summary>
        public int? Flag { get; set; }
        /// <summary>
        /// 司机工号
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// 医生工号列表,多个医生之间以“｜”分隔
        /// </summary>
        public string Doctor { get; set; }
        /// <summary>
        /// 护士工号列表,多个护士之间以“｜”分隔
        /// </summary>
        public string Nurse { get; set; }
        /// <summary>
        /// 担架员工号列表,多个担架员之间以“｜”分隔
        /// </summary>
        public string StretcherPerson { get; set; }
        /// <summary>
        /// 上报结果1:   上报成功0:   上报失败
        /// </summary>
        public int? Result { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailtureReason { get; set; }
        /// <summary>
        /// 公司内部标示
        /// </summary>
        public string Index { get; set; }
    }
}
