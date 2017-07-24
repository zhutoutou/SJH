using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 病历填写项目值表
    /// </summary>
    public class Web_MedicalProjectValue
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// ID标识列，自动增长列
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 病历项目Id
        /// </summary>
        public string MEDICALPROJECTID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 注销标志：0：不注销；1：注销
        /// </summary>
        public string CANCELLATION { get; set; }

    }
}
