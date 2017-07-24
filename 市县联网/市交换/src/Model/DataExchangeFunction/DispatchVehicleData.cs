using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 出车信息数据上报
    /// </summary>
    public class DispatchVehicleData
    {
        /// <summary>
        /// 消息名
        /// </summary>
        public string CommandID { get; set; }
        //201511201 修改人:朱星汉 修改内容:添加车辆编号
        /// <summary>
        /// 上报数据车辆的车辆编号
        /// </summary>
        public string VehicleCode { get; set; }
        /// <summary>
        /// 与本次出车所对应的受理记录流水号
        /// </summary>
        public string DealRecordID { get; set; }
        /// <summary>
        /// 出车车次
        /// </summary>
        public string Times { get; set; }
        /// <summary>
        /// 出车类型,如普通出救、大型事故、行政出车等
        /// </summary>
        public string DispatchVehicleType { get; set; }
        /// <summary>
        /// 调度员用户名或工号
        /// </summary>
        public string Dispatcher { get; set; }
        /// <summary>
        /// 随车司机工号
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// 医生工号列表,多个医生之间以“｜”分隔
        /// </summary>
        public string Doctor { get; set; }
        /// <summary>
        /// 护士工号列表,多个医生之间以“｜”分隔
        /// </summary>
        public string Nurse { get; set; }

        /// <summary>
        /// 担架员工号列表,多个担架员之间以“｜”分隔
        /// </summary>
        public string StretcherPerson { get; set; }
        /// <summary>
        /// 派车时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string DispatchVehicleTime { get; set; }
        /// <summary>
        /// 收到信息时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ReceiveTaskTime { get; set; }
        /// <summary>
        /// 出车地点
        /// </summary>
        public string StartoffAddress { get; set; }
        /// <summary>
        /// 出发时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string StartoffTime { get; set; }
        /// <summary>
        /// 到达地点
        /// </summary>
        public string ArriveAddress { get; set; }
        /// <summary>
        /// 到达现场时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ArriveSceneTime { get; set; }
        /// <summary>
        /// 上车时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string GetInVehicleTime { get; set; }
        /// <summary>
        /// 到达目的地时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ArriveDestinationTime { get; set; }
        /// <summary>
        /// 任务完成时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string FinishTaskTime { get; set; }

        /// <summary>
        /// 返站时间, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string ReturnParkTime { get; set; }
        /// <summary>
        /// 出车用时，出车时间减派车时间，单位为秒
        /// </summary>
        public string StartoffUseTime { get; set; }
        /// <summary>
        /// 路途用时,到达现场时间减出车时间,单位为秒
        /// </summary>
        public string ArriveSceneUseTime { get; set; }
        /// <summary>
        /// 现场用时,上车时间减到达现场时间，单位为秒
        /// </summary>
        public string SceneUseTime { get; set; }
        /// <summary>
        /// 在途用时,到达时间减上车时间，单位为秒
        /// </summary>
        public string AarriveDestinationUseTime { get; set; }
        /// <summary>
        /// 总耗时,完成时间减派车时间，单位为秒
        /// </summary>
        public string TotalUseTime { get; set; }
        /// <summary>
        /// 行驶里程,单位为公里
        /// </summary>
        public string SteerMileage { get; set; }
        /// <summary>
        /// 送往医院
        /// </summary>
        public string AcceptHospital { get; set; }
        /// <summary>
        /// 特殊事件
        /// </summary>
        public string SpecialEvent { get; set; }
        /// <summary>
        /// 特殊原因(110送走、任务取消、放空返回、它车送走)
        /// </summary>
        public string SpecialReason { get; set; }
        /// <summary>
        /// 特殊事件时间,格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string SpecialEventTime { get; set; }
        /// <summary>
        /// 出车ID自己公司用
        /// </summary>
        public string VehicleID { get; set; }
        /// <summary>
        /// 车辆状态
        /// </summary>
        public string VehicleState { get; set; }   /// <summary>
        /// 车辆单位
        /// </summary>
        public string VehicleUnit { get; set; }
        //20151210 修改人:朱星汉 修改内容:添加车辆信息状态字段
        ///<summary>
        ///车辆状态
        ///</summary>
        public string VehicleZT { get; set; }
        //20160106 修改人:朱星汉 修改内容:添加出车车次(CCCC)字段
        ///<summary>
        ///出车车次(CCCC)
        ///</summary>
        public string VehicleCCCC { get; set; }
    }
}
