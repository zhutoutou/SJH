using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 病历填写项目表
    /// </summary>
    public class Web_MedicalProject
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
        /// 项目名称
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 类型:0：多选，1：下拉单选，2：单选按钮，3：文本
        /// </summary>
        public string TYPE { get; set; }
        /// <summary>
        /// 0:统计,1:不统计
        /// </summary>
        public string STATISTICS { get; set; }
        /// <summary>
        /// 注销标志：0:不注销，1：注销
        /// </summary>
        public string CANCELLATION { get; set; }
        /// <summary>
        /// 编码名称，拼音的首字母
        /// </summary>
        public string CODENAME { get; set; }

    }
}
