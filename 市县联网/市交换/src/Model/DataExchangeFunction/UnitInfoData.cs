using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 单位信息上报
    /// </summary>
    public class UnitInfoData
    {
        public string CommandID { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UnitCode { get; set; }
        /// <summary>
        /// 单位序号
        /// </summary>
        public string SequenceNO { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 单位拼音全称
        /// </summary>
        public string Spelling { get; set; }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 单位联系电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 单位邮编
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// 单位类别 (1: 市级；2: 区（县）级；3: 其他； 4: 省级)
        /// </summary>
        public string UnitKindID { get; set; }
        /// <summary>
        /// 单位类型(1: 政府机关； 2: 事业单位；3: 企业单位；4: 急救中心；5: 急救分站；6: 医院；7: 血站；8: CDC疾控中心；9: 卫生监督所；10: 学校；11: 指挥中心；12: 应急办；13: 联动单位)
        /// </summary>
        public string UnitTypeID { get; set; }
        /// <summary>
        /// 单位小类型（1:综合医院；2: 专科医院；3: 小学；4: 中学；5: 完中；6: 纯高中；7: 中专； 8: 职校；9: 大学;11: 民办学校；271: 急救分中心）
        /// </summary>
        public string UnitSmallTypeID { get; set; }
        /// <summary>
        /// 单位级别（1: 省级； 2: 市级；3: 区级；4: 一级医院；5: 二级医院；6: 三级甲等医院；7: 部级；8: 国家级；9: 三级乙等医院；10: 三级丙等医院）
        /// </summary>
        public string UnitLevelID { get; set; }
        /// <summary>
        /// 单位性质（1: 国有；2: 股份；3: 独资；4: 合资；5: 集体；6: 三联营；7: 私营；8: 其它）
        /// </summary>
        public string UnitCharacterID { get; set; }
        /// <summary>
        /// 上级单位的名称
        /// </summary>
        public string SuperiorUnitName { get; set; }
        /// <summary>
        /// 所属城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 所属地区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 单位负责人
        /// </summary>
        public string Principal { get; set; }
        /// <summary>
        /// 特色专科
        /// </summary>
        public string SpecialityDepartment { get; set; }
        /// <summary>
        /// 床位数
        /// </summary>
        public string BedNumber { get; set; }
        /// <summary>
        /// 医院人数
        /// </summary>
        public string DoctorNumber { get; set; }
        /// <summary>
        /// 护士人数
        /// </summary>
        public string NurseNumber { get; set; }
        /// <summary>
        /// 站点类型（中心、分站）
        /// </summary>
        public string StationType { get; set; }
        /// <summary>
        /// 急救车辆数
        /// </summary>
        public string VehicleNumber { get; set; }
        /// <summary>
        /// 司机人数
        /// </summary>
        public string DriverNumber { get; set; }
        /// <summary>
        /// 担架员人数
        /// </summary>
        public string StretcherNumber { get; set; }
        /// <summary>
        /// 空闲床位数
        /// </summary>
        public string FreebedNumber { get; set; }
        /// <summary>
        /// 注销标志(0：未注销，1：注销)
        /// </summary>
        public string Cancel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
