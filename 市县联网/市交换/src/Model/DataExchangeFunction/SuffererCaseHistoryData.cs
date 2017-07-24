using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 患者病历信息数据上报
    /// </summary>
    public class SuffererCaseHistoryData
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID{get;set;}
        //201511201 修改人:朱星汉 修改内容:添加车辆编号
        /// <summary>
        /// 上报数据车辆的车辆编号
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 患者所是急救车辆的车载手机号码
        /// </summary>
         public string Mobile{get;set;}
        /// <summary>
        /// 与本次出车所对应的受理记录流水号
        /// </summary>
         public string DealRecordID{get;set;}
        /// <summary>
        /// 出车记录流水号
        /// </summary>
         public string DispatchVehicleID{get;set;}
        /// <summary>
        /// 患者编号
        /// </summary>
         public string SuffererNo{get;set;}
        /// <summary>
        /// 患者姓名
        /// </summary>
         public string SuffererName{get;set;}
        /// <summary>
        /// 病情
        /// </summary>
         public string IllnessState{get;set;}
        /// <summary>
        /// 患者病史
        /// </summary>
         public string IllnessHistory{get;set;}
        /// <summary>
        /// 血压
        /// </summary>
         public string BloodPressure{get;set;}
        /// <summary>
        /// 脉搏
        /// </summary>
         public string Pulse{get;set;}

        /// <summary>
        /// 呼吸
        /// </summary>
         public string Breath{get;set;}
        /// <summary>
        /// 心率
        /// </summary>
         public string HeartRate{get;set;}
        /// <summary>
        /// 体温
        /// </summary>
         public string AnimalHeat{get;set;}
        /// <summary>
        /// 瞳孔
        /// </summary>
         public string Pupil{get;set;}
        /// <summary>
        /// 对光反射
        /// </summary>
         public string LightEcho{get;set;}
        /// <summary>
        /// 一般情况
        /// </summary>
         public string CommonlyCircs{get;set;}
        /// <summary>
        /// 神志
        /// </summary>
         public string Mind{get;set;}
        /// <summary>
        /// 皮肤
        /// </summary>
         public string Skin{get;set;}
        /// <summary>
        /// 心脏
        /// </summary>
         public string Heart{get;set;}
        /// <summary>
        /// 肺部
        /// </summary>
         public string Lung{get;set;}

        /// <summary>
        /// 腹部
        /// </summary>
        public string Abdomen{get;set;}
        /// <summary>
        /// 四肢
        /// </summary>
        public string Extremity{get;set;}
        /// <summary>
        /// 头颈部
        /// </summary>
        public string HeadNeck{get;set;}
        /// <summary>
        /// 神经系统
        /// </summary>
        public string Neural{get;set;}
        /// <summary>
        /// 急救效果
        /// </summary>
        public string FirstAidPurpose{get;set;}
        /// <summary>
        /// 其它
        /// </summary>
        public string Other{get;set;}
    }
}
