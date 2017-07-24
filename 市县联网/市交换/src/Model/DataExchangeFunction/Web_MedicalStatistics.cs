using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 病历填写项目与值对应表
    /// </summary>
    public class Web_MedicalStatistics
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        ///  ID标识列，自动增长列
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 病历项目值ID
        /// </summary>
        public string CONTROLID { get; set; }
        /// <summary>
        /// 病历ID
        /// </summary>
        public string MEDICALRECORDSID { get; set; }
        /// <summary>
        /// 专门做统计用的列
        /// </summary>
        public string CONTROLVALUE { get; set; }
        /// <summary>
        /// 病历项目ID
        /// </summary>
        public string CONTROLPARENTID { get; set; }
        //20151213 修改人:朱星汉 修改内容:添加联网转单上传本地库联网信息关联表识别字段LSH,CS,CLBH,对应这该患者所在的车辆信息
        /// <summary>
        ///流水号
        /// </summary>
        public string LSH { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        public string CS { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string CLBH { get; set; }
    }
}
