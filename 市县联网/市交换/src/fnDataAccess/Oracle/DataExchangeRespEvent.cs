using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.SJHServer.Model.DataExchangeFunction;
using ZIT.SJHServer.Model.DispatchFunction;

namespace ZIT.SJHServer.fnDataAccess.Oracle
{
    /// <summary>
    ///  /// <summary>
    /// 交换数据答应  映射到Mobile并通知上层
    /// </summary>
    /// </summary>
    public class DataExchangeRespEvent
    {
        /// <summary>
        /// 呼叫记录信息数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> CallRcordDataRespExchange;
        protected virtual void OnMessageDataExchange(CallRcordDataResp message)
        {
            var handler = CallRcordDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 受理信息数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> DealDataRespExchange;
        protected virtual void OnMessageDataExchange(DealDataResp message)
        {
            var handler = DealDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 调度分站记录信息答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> DispatchStationInfoDataRespExchange;
        protected virtual void OnMessageDataExchange(DispatchStationInfoDataResp message)
        {
            var handler = DispatchStationInfoDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 车辆状态应答
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> VehicleStatusRespExchange;
        protected virtual void OnMessageDataExchange(VehicleStatusResp message)
        {
            var handler = VehicleStatusRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 出车信息数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> DispatchVehicleDataRespExchange;
        protected virtual void OnMessageDataExchange(DispatchVehicleDataResp message)
        {
            var handler = DispatchVehicleDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 急救人员及急救车辆数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> PVRelationRespExchange;
        protected virtual void OnMessageDataExchange(PVRelationResp message)
        {
            var handler = PVRelationRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 患者病历信息数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> SuffererCaseHistoryDataRespExchange;
        protected virtual void OnMessageDataExchange(SuffererCaseHistoryDataResp message)
        {
            var handler = SuffererCaseHistoryDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 患者信息数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> SuffererDataRespExchange;
        protected virtual void OnMessageDataExchange(SuffererDataResp message)
        {
            var handler = SuffererDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 系统人员数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> SysUserDataRespExchange;
        protected virtual void OnMessageDataExchange(SysUserDataResp message)
        {
            var handler = SysUserDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 单位信息数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> UnitInfoDataRespExchange;
        protected virtual void OnMessageDataExchange(UnitInfoDataResp message)
        {
            var handler = UnitInfoDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 车辆基础数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> VehicleDataRespExchange;
        protected virtual void OnMessageDataExchange(VehicleDataResp message)
        {
            var handler = VehicleDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }
        /// <summary>
        /// 大型事故数据答应
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> LargeSlipDataRespExchange;
        protected virtual void OnMessageDataExchange(LargeSlipDataResp message)
        {
            var handler = LargeSlipDataRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }

        /// <summary>
        /// 病历填写项目应答
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> Web_MedicalProjectRespExchange;
        protected virtual void OnMessageDataExchange(Web_MedicalProjectResp message)
        {
            var handler = Web_MedicalProjectRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }

        /// <summary>
        /// 病历填写项目值应答
        /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> Web_MedicalProjectValueRespExchange;
         protected virtual void OnMessageDataExchange(Web_MedicalProjectValueResp message)
         {
             var handler = Web_MedicalProjectValueRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

        /// <summary>
        /// 病历记录应答
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> Web_MedicalRecordsRespExchange;

        protected virtual void OnMessageDataExchange(Web_MedicalRecordsResp message)
        {
            var handler = Web_MedicalRecordsRespExchange;
            if (handler != null)
            {
                handler(this, new DataExchangeRespEventArgs(message));
            }
        }

        /// <summary>
        /// 病历填写项目与值对应关系数据应答
        /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> Web_MedicalStatisticsRespExchange;
         protected virtual void OnMessageDataExchange(Web_MedicalStatisticsResp message)
         {
             var handler = Web_MedicalStatisticsRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

        /// <summary>
        /// 病历基础信息表数据
        /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> BLJCXXBRespExchange;
         protected virtual void OnMessageDataExchange(BLJCXXBResp message)
         {
             var handler = BLJCXXBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }
        /// <summary>
        /// 呼救区域表数据
        /// </summary>
        public event EventHandler<DataExchangeRespEventArgs> HJQYBRespExchange;
         protected virtual void OnMessageDataExchange(HJQYBResp message)
         {
             var handler = HJQYBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }
        /// <summary>
        /// 来电类型表数据
        /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> LDLXBRespExchange;
         protected virtual void OnMessageDataExchange(LDLXBResp message)
         {
             var handler = LDLXBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

        /// <summary>
        /// 值班员信息表数据
        /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> ZBYXXBRespExchange;
         protected virtual void OnMessageDataExchange(ZBYXXBResp message)
         {
             var handler = ZBYXXBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }
        /// <summary>
        /// 症状表数据
        /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> ZZBRespExchange;
         protected virtual void OnMessageDataExchange(ZZBResp message)
         {
             var handler = ZZBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
         public event EventHandler<DataExchangeRespEventArgs> LWBLGXTBDELBRespExchange;
         protected virtual void OnMessageDataExchange(LWBLGXTBDELBResp message)
         {
             var handler = LWBLGXTBDELBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }
         //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
         public event EventHandler<DataExchangeRespEventArgs> LWBLTBDELBRespExchange;
         protected virtual void OnMessageDataExchange(LWBLTBDELBResp message)
         {
             var handler = LWBLTBDELBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }
         /// <summary>
         /// 大型事故表数据
         /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> DXSGBRespExchange;
         protected virtual void OnMessageDataExchange(DXSGBResp message)
         {
             var handler = DXSGBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

         /// <summary>
         /// 联网调度关联表数据
         /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> LWDDGLBRespExchange;
         protected virtual void OnMessageDataExchange(LWDDGLBResp message)
         {
             var handler = LWDDGLBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

         /// <summary>
         /// 联网车辆同步对应表数据
         /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> LWCLTBDYBRespExchange;
         protected virtual void OnMessageDataExchange(LWCLTBDYBResp message)
         {
             var handler = LWCLTBDYBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

         /// <summary>
         /// 联网病历同步对应表数据
         /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> LWBLTBDYBRespExchange;
         protected virtual void OnMessageDataExchange(LWBLTBDYBResp message)
         {
             var handler = LWBLTBDYBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

         /// <summary>
         /// 联网病历关系同步对应表数据
         /// </summary>
         public event EventHandler<DataExchangeRespEventArgs> LWBLGXTBDYBRespExchange;
         protected virtual void OnMessageDataExchange(LWBLGXTBDYBResp message)
         {
             var handler = LWBLGXTBDYBRespExchange;
             if (handler != null)
             {
                 handler(this, new DataExchangeRespEventArgs(message));
             }
         }

    }
}
