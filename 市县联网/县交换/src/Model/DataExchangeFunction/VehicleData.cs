using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 车辆基础数据上报
    /// </summary>
    public class VehicleData
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
        /// 车辆发动机编号
        /// </summary>
        public string EngineNumber{get;set;}
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string VehicleCode{get;set;}
        /// <summary>
        /// 车辆名称
        /// </summary>
        public string VehicleName{get;set;}
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string CarNumber{get;set;}
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Manufacturer{get;set;}
        /// <summary>
        /// 车辆品牌
        /// </summary>
        public string Brand{get;set;}
        /// <summary>
        /// 车辆颜色
        /// </summary>
        public string Color{get;set;}
        /// <summary>
        /// 车辆类型(1、指挥车辆；2、普通车；3、监护车等)
        /// </summary>
        public string VehicleType{get;set;}
        /// <summary>
        /// 车辆所属单位名称
        /// </summary>
        public string UnitName{get;set;}
        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductionDate{get;set;}
        /// <summary>
        /// 购买日期
        /// </summary>
        public string PurchaseDate{get;set;}
        /// <summary>
        /// 使用日期
        /// </summary>
        public string UseDate{get;set;}
        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegisterDate{get;set;}
        /// <summary>
        /// 注销标志(0：未注销，1：注销)
        /// </summary>
        public string Cancel{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark{get;set;}
        /// <summary>
        /// 车辆ID
        /// </summary>
        public string VehicleID { get; set; }
        

    }
}
