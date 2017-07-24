using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 患者信息数据上报
    /// </summary>
    public class SuffererData
    {
        /// <summary>
        /// 消息名称
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
        /// 患者性别
        /// </summary>
        public string SuffererSex { get; set; }
        /// <summary>
        /// 患者年龄
        /// </summary>
        public string SuffererAge { get; set; }
        /// <summary>
        /// 患者国籍
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// 患者职业
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        /// 患者身份(1:普通人员;2:重要人员)
        /// </summary>
        public string Standing { get; set; }
        /// <summary>
        /// 患者联系电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 患者住址
        /// </summary>
        public string Addess { get; set; }
        /// <summary>
        /// 发病地址
        /// </summary>
        public string SickenAddess { get; set; }
        /// <summary>
        /// 发病时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string SickenTime { get; set; }
        /// <summary>
        /// 患者病情描述
        /// </summary>
        public string IllnessDescribing { get; set; }
        /// <summary>
        /// 入住医院
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// 床位编号
        /// </summary>
        public string BedNumber { get; set; }
        /// <summary>
        /// 患者症状
        /// </summary>
        public string Symptom { get; set; }
        /// <summary>
        /// 初步诊断
        /// </summary>
        public string FirstDiag { get; set; }
        /// <summary>
        /// 受伤程度（轻度、中度、重度、危重、死亡）
        /// </summary>
        public string InjuredDegree { get; set; }
        /// <summary>
        /// 现场抢救(1:有;0:无)
        /// </summary>
        public string LocaleSalvage { get; set; }
        /// <summary>
        /// 有效抢救(1:是;0:否)
        /// </summary>
        public string ValidSalvage { get; set; }
        /// <summary>
        /// 救治结果（有效、无效、稳定、恶化、死亡、未处置、空趟）
        /// </summary>
        public string CureResult { get; set; }
        /// <summary>
        /// 现场地点
        /// </summary>
        public string LocalePlace { get; set; }
    }
}
