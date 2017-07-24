using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 市120派单给县120
    /// </summary>
    public class DispatchTaskRequestReinforcement
    {
        /// <summary>
        /// 消息名称
        /// </summary>
        public string CommandID{get;set;}
        /// <summary>
        /// 发送方网络单位ID
        /// </summary>
        public string SourceUnitID{get;set;}
        /// <summary>
        /// 数据接收方网络单位ID
        /// </summary>
        public string TargetUnitID{get;set;}
        /// <summary>
        /// 消息流水号
        /// </summary>
        public string SequenceNo{get;set;}
        /// <summary>
        /// 受理记录流水号
        /// </summary>
        public string DealRecordID{get;set;}
        /// <summary>
        /// 信息来源(电话、来人、培训、演练、其他。与呼叫记录表中一致)
        /// </summary>
        public string InfoSource{get;set;}
        /// <summary>
        /// 受理台号
        /// </summary>
        public string AgentNo{get;set;}
        /// <summary>
        /// 值班员工号
        /// </summary>
        public string WatcherName{get;set;}
        /// <summary>
        /// 值班班次
        /// </summary>
        public string WatchShiftGroup{get;set;}
        /// <summary>
        /// 来电时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string CallTime{get;set;}
 
        /// <summary>
        /// 受理时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string DealTime{get;set;}
        /// <summary>
        /// 主叫号码
        /// </summary>
        public string CallNumber{get;set;}
        /// <summary>
        /// 电话户主
        /// </summary>
        public string HostName{get;set;}
        /// <summary>
        /// 装机地址
        /// </summary>
        public string Address{get;set;}
        /// <summary>
        /// 呼叫地址
        /// </summary>
        public string CallAddress{get;set;}
        /// <summary>
        /// 呼救区域（新北区、市区、郊区）
        /// </summary>
        public string CallArea{get;set;}
        /// <summary>
        /// 来电类型（骚扰电话、急救派车、咨询电话、工作电话、其它等）
        /// </summary>
        public string CallType{get;set;}
        /// <summary>
        /// 呼救人
        /// </summary>
        public string CallerName{get;set;}
        /// <summary>
        /// 呼车者类型（110、119、122、行人、亲属、医生）
        /// </summary>
        public string CallerType{get;set;}
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTelphone{get;set;}

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string SuffererName{get;set;}
        /// <summary>
        /// 患者性别
        /// </summary>
        public string SuffererSex{get;set;}
        /// <summary>
        /// 患者年龄
        /// </summary>
        public string SuffererAge{get;set;}
        /// <summary>
        /// 患者人数
        /// </summary>
        public string SuffererCount{get;set;}
        /// <summary>
        /// 患者国籍
        /// </summary>
        public string Nationality{get;set;}
        /// <summary>
        /// 患者身份(1:普通人员;2:重要人员)
        /// </summary>
        public string Standing{get;set;}
        /// <summary>
        /// 过敏药物
        /// </summary>
        public string AnaphylacticMedication{get;set;}
        /// <summary>
        /// 患者主要症状
        /// </summary>
        public string Symptom{get;set;}
        /// <summary>
        /// 患者病史
        /// </summary>
        public string SuffererMedicalRecord{get;set;}
        /// <summary>
        /// 接车地址
        /// </summary>
        public string MeetAddress{get;set;}

        /// <summary>
        /// 送往地点
        /// </summary>
        public string SendArriveAddress{get;set;}
        /// <summary>
        /// 处置方式
        /// </summary>
        public string TreatmentMode{get;set;}
        /// <summary>
        /// 回车标志(0：否；1：是)
        /// </summary>
        public string RejectFlag{get;set;}
        /// <summary>
        /// 回车原因
        /// </summary>
        public string RejectReason{get;set;}
        /// <summary>
        /// 挂机时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string HangupTime{get;set;}
        /// <summary>
        /// 受理时长,单位为秒
        /// </summary>
        public string DealTimeSpan{get;set;}
        /// <summary>
        /// 调度开始时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string AttemperBeginTime{get;set;}
        /// <summary>
        /// 调度结束时间，格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string AttemperEndTime{get;set;}
        /// <summary>
        /// 调度时长
        /// </summary>
        public string AttemperTimeSpan{get;set;}
        /// <summary>
        /// 呼叫地址X坐标
        /// </summary>
        public string CallAddressX{get;set;}

        /// <summary>
        /// 呼叫地址Y坐标
        /// </summary>
        public string CallAddressY{get;set;}
        /// <summary>
        /// 接车地址X坐标
        /// </summary>
        public string MeetAddressX{get;set;}
        /// <summary>
        /// 接车地址Y坐标
        /// </summary>
        public string MeetAddressY{get;set;}
        /// <summary>
        /// 呼救类型(1：普通呼叫；2：大型事故)
        /// </summary>
        public string CallHelpType{get;set;}
        /// <summary>
        /// 事故类型
        /// </summary>
        public string SlipType{get;set;}
        /// <summary>
        /// 事故原因
        /// </summary>
        public string SlipReason{get;set;}
        /// <summary>
        /// 事故名称
        /// </summary>
        public string SlipName{get;set;}
        /// <summary>
        /// 受理状态(1：接听；2：未处理；3：已处理；4：待派车；5：已派车；6：已完成；7：已归档)
        /// </summary>
        public string DealStatus{get;set;}
        /// <summary>
        /// 派车原则
        /// </summary>
        public string DispatchVehiclePrinciple{get;set;}
        /// <summary>
        /// 靠近路名
        /// </summary>
        public string AnearRoadName{get;set;}

        /// <summary>
        /// 关联案件ID
        /// </summary>
        public string RelateDealRecordID{get;set;}
        /// <summary>
        /// 管辖街道
        /// </summary>
        public string DominationStreet{get;set;}
        /// <summary>
        /// 管辖医院
        /// </summary>
        public string DominationHospital{get;set;}
        /// <summary>
        /// 发病地点
        /// </summary>
        public string HappenAddress{get;set;}
        /// <summary>
        /// 特殊案件标志(0：否；1：是)
        /// </summary>
        public string SpecialCaseFalg{get;set;}
        /// <summary>
        /// 上报标志(0：否；1：是)
        /// </summary>
        public string ReportFalg{get;set;}
        /// <summary>
        /// 初步诊断，多个初步诊断间以“|”分隔
        /// </summary>
        public string Firstdiag{get;set;}
        /// <summary>
        /// 备注，可填写希望其它中心增援要做的事
        /// </summary>
        public string Remark{get;set;}

    }
}
