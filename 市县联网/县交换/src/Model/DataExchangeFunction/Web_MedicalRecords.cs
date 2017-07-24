using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 病历记录表
    /// </summary>
    public class Web_MedicalRecords
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        /// <summary>
        /// 急救员姓名
        /// </summary>
        public string JJYXM { get; set; }
        /// <summary>
        /// 输入胸部具体位置
        /// </summary>
        public string SXB { get; set; }
        /// <summary>
        /// apgar评分 新生儿评分
        /// </summary>
        public string APGAR { get; set; }
        /// <summary>
        /// 新生儿评分外键ID。
        /// </summary>
        public string TAPGAR { get; set; }
        public string MEDICALTYPE { get; set; }
        /// <summary>
        /// 病人国籍
        /// </summary>
        public string BRGJ { get; set; }
        public string BQSCTP { get; set; }
        public string ZZLB { get; set; }
        public string ZZ { get; set; }
        public string YY1 { get; set; }
        public string BS { get; set; }
        public string JJCS { get; set; }
        public string HZZJ { get; set; }
        public string HZBZ { get; set; }
        /// <summary>
        /// 标识列
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 本次出车对应流水号
        /// </summary>
        public string LSH { get; set; }
        /// <summary>
        /// 本流水号下第几次出车
        /// </summary>
        public string CS { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string CLBH { get; set; }
        /// <summary>
        /// 所属单位名称
        /// </summary>
        public string SSDWMC { get; set; }
        public string ZBCH { get; set; }
        public string BRXM { get; set; }
        public string BRNL { get; set; }
        public string BRXB { get; set; }
        public string WJDD { get; set; }
        public string SWDD { get; set; }
        public string BZ { get; set; }
        public string DJR { get; set; }
        public string DJRQ { get; set; }
        public string BRID { get; set; }
        public string XBS { get; set; }
        public string GQXGS { get; set; }
        public string ZCYZD { get; set; }
        public string YWGMS { get; set; }
        public string T { get; set; }
        public string P { get; set; }
        public string BP { get; set; }
        public string ZTK { get; set; }
        public string CBYX { get; set; }
        public string XT { get; set; }
        public string XYBHD { get; set; }
        public string XDTYX { get; set; }
        public string XDJHYX { get; set; }
        public string BRMZ { get; set; }
        public string BRZY { get; set; }
        public string BRJG { get; set; }
        public string BRGZDW { get; set; }
        public string XG_FLAG { get; set; }
        public string XG_YY { get; set; }
        public string XG_SHR { get; set; }
        public string XG_SJ { get; set; }
        public string FLAG { get; set; }
        public string R { get; set; }
        public string ZBY { get; set; }
        public string HJDH { get; set; }
        public string WJDD_TJ { get; set; }
        public string SWDD_TJ { get; set; }
        public string HYZK { get; set; }
        public string HR { get; set; }
        public string YTK { get; set; }
        public string QT { get; set; }
        public string GCS { get; set; }
        public string TI { get; set; }
        public string ZDS { get; set; }
        public string RZY { get; set; }
        public string RFBYL { get; set; }
        public string QTJC { get; set; }
        public string SWZMBH { get; set; }
        public string XDTYXFJ { get; set; }
        public string XDJHYXFJ { get; set; }
        public string TIMPLATENAME { get; set; }
        public string TIMPLATEFLAG { get; set; }
        public string JZYS { get; set; }
        public string TGCS { get; set; }
        public string TTI { get; set; }
        public string TIMPLATEPY { get; set; }
        public string TIMPLATEPARENTID { get; set; }
        public string READER { get; set; }
    }
}
