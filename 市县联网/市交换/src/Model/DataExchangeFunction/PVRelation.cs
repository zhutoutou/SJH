using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 急救人员及急救车辆关系上报
    /// </summary>
   public class PVRelation
    {
       /// <summary>
       /// 消息名
       /// </summary>
       public string CommandID{get;set;}
       /// <summary>
       /// 车载手机号码
       /// </summary>
        public string Mobile{get;set;}
       /// <summary>
       /// 是否上班标志（0: 下班； 1 上班）
       /// </summary>
        public string Flag{get;set;}
       /// <summary>
       /// 司机工号
       /// </summary>
        public string Driver{get;set;}
       /// <summary>
       /// 医生工号列表,多个医生之间以“｜”分隔
       /// </summary>
        public string Doctor{get;set;}
       /// <summary>
       /// 护士工号列表,多个护士之间以“｜”分隔
       /// </summary>
        public string Nurse{get;set;}
       /// <summary>
       /// 担架员工号列表,多个担架员之间以“｜”分隔
       /// </summary>
        public string StretcherPerson{get;set;}
       /// <summary>
       /// 上班(或下班)时间
       /// </summary>
        public string OnOffDutyTime{get;set;}
       /// <summary>
       /// 内部标示，其它公司不用此字段
       /// </summary>
        public string Index { get; set; }
    }
}
