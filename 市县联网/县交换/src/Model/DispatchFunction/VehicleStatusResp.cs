using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DispatchFunction
{
    /// <summary>
    /// 发送车辆状态到镇江市急救指挥中心的应答
    /// </summary>
   public class VehicleStatusResp
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
       /// 1成功、0失败
       /// </summary>
       public int? Result { get; set; }
       /// <summary>
       /// 失败原因
       /// </summary>
       public string FailtureReason{get;set;}
       /// <summary>
       /// 单位编号
       /// </summary>
       public string DWBH { get; set; }
    }
}
