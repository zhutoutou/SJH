using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using ZIT.LOG;
using ZIT.XJHServer.Model;
using ZIT.XJHServer.Model.DataExchangeFunction;
using ZIT.XJHServer.Model.SystemFunction;
using ZIT.XJHServer.Model.DispatchFunction;
using ZIT.XJHServer.Model.HuaiAnFunction;
using ZIT.XJHServer.Model.PositioningFunction;
using ZIT.XJHServer.fnDataAccess.DataSync;
using ZIT.XJHServer.bsController.SJHServer;
using System.Collections.Concurrent;

namespace ZIT.XJHServer.bsController.DataUpload
{
    class UploadData
    {
        /// <summary>
        /// 采集数据发送时间间隔
        /// </summary>
        int Interval = 100;

        /// <summary>
        /// 先传单位 车辆信息 先受理信息
        /// </summary>
        /// <param name="c"></param>
        public void ScanOnTime()
        {
            IGetData Data = ExchangeDataAccess.GetDataAccess();
            //20160712 修改人：朱星汉 修改内容：添加定时重发机制
            IUpdateMidState MidState = ExchangeDataAccess.UpdateMidStateAccess();
            while (true)
            {
                Thread.Sleep(2000);
                //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                
                //同步单位信息数据
                try
                {

                    List<UnitInfoData> list = Data.GetUnitInfoData();
                    foreach (UnitInfoData item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql=MidState.UpdateUnitInfoData(item.UnitCode);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                ////同步车辆信息数据
                try
                {
                    List<VehicleData> list = Data.GetVehicleData();
                    foreach (VehicleData item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateVehicleData(item.VehicleCode);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);

                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                // //同步系统人员信息数据
                try
                {
                    List<SysUserData> list = Data.GetSysUserData();
                    foreach (SysUserData item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateSysUserData(item.UserName);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);

                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                ////同步呼叫记录信息
                try
                {
                    List<CallRcordData> list = Data.GetCallRcordData();
                    foreach (CallRcordData item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateCallRcordData(item.CallID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);

                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                ////同步受理信息

                try
                {
                    List<DealData> list = Data.GetDealData();
                    foreach (DealData item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateDealData(item.DealRecordID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);

                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                ////同步调度分站信息
                try
                {
                    List<DispatchStationInfoData> list = Data.GetDispatchStationInfoData();
                    foreach (DispatchStationInfoData item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateDispatchStationInfoData(item.ID,item.DispatchVehicleUnit);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                //同步派车信息
                try
                {
                    List<DispatchVehicleData> list = Data.GetDispatchVehicleData();
                    foreach (DispatchVehicleData item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateDispatchVehicle(item.DealRecordID,item.Times,item.VehicleCode);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }


                //同步病历填写项目信息
                try
                {
                    List<Web_MedicalProject> list = Data.GetWeb_MedicalProjectData();
                    foreach (Web_MedicalProject item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateWeb_MedicalProjectData(item.ID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                //同步病历填写项目值信息
                try
                {
                    List<Web_MedicalProjectValue> list = Data.GetWeb_MedicalProjectValueData();
                    foreach (Web_MedicalProjectValue item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateWeb_MedicalProjectValueData(item.ID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }
                //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
                // 病历记录删除记录表数据
                try
                {
                    List<LWBLTBDELB> list = Data.GetLWBLTBDELBData();
                    foreach (LWBLTBDELB item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateLWBLTBDELData(item.ID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }
                //同步病历记录信息
                try
                {
                    List<Web_MedicalRecords> list = Data.GetWeb_MedicalRecordsData();
                    foreach (Web_MedicalRecords item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateWeb_MedicalRecordsData(item.ID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }
                
                //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
                // 症状关系删除记录表数据
                try
                {
                    List<LWBLGXTBDELB> list = Data.GetLWBLGXTBDELBData();
                    foreach (LWBLGXTBDELB item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateLWBLGXTBDELData(item.ID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                //同步病历填写项目与值对应信息
                try
                {
                    List<Web_MedicalStatistics> list = Data.GetWeb_MedicalStatisticsData();
                    foreach (Web_MedicalStatistics item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateWeb_MedicalStatisticsData(item.ID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        } 
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

               // 病历基础信息表数据
               try
                {
                    List<BLJCXXB> list = Data.GetBLJCXXBData();
                    foreach (BLJCXXB item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateBLJCXXBData(item.LX,item.MC);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }

                // 呼救区域表数据
               try
                {
                    List<HJQYB> list = Data.GetHJQYBData();
                    foreach (HJQYB item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateHJQYBData(item.XH);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }
                /// 来电类型表数据
               try
                {
                    List<LDLXB> list = Data.GetLDLXBData();
                    foreach (LDLXB item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateLDLXBData(item.XH);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }
                // 值班员信息表数据
               try
                {
                    List<ZBYXXB> list = Data.GetZBYXXBData();
                    foreach (ZBYXXB item in list)
                    {
                        string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                        Controller.GetInstance().us.SendMessage(sendMessageStr);
                        //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                        string strReSendSql = MidState.UpdateZBYXXBData(item.ID);
                        if (ExistSQL(strReSendSql))
                        {
                            UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                        }
                        Thread.Sleep(Interval);
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteLog("", ex);
                }


                // 症状表数据
               try
               {
                   List<ZZB> list = Data.GetZZBData();
                   foreach (ZZB item in list)
                   {
                       string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                       Controller.GetInstance().us.SendMessage(sendMessageStr);
                       //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                       string strReSendSql = MidState.UpdateZZBData(item.XH);
                       if (ExistSQL(strReSendSql))
                       {
                           UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                       }
                       Thread.Sleep(Interval);
                   }

               }
               catch (System.Exception ex)
               {
                   LogHelper.WriteLog("", ex);
               }

               // 大型事故数据
               try
               {
                   List<DXSGB> list = Data.GetDXSGBData();
                   foreach (DXSGB item in list)
                   {
                       string sendMessageStr = XmlUtil.Serializer(item.GetType(), item);
                       Controller.GetInstance().us.SendMessage(sendMessageStr);
                       //20160712 修改人：朱星汉 修改内容：添加定时重发机制
                       string strReSendSql = MidState.UpdateDXSGBData(item.LSH);
                       if (ExistSQL(strReSendSql))
                       {
                           UploadServer.reSendQueue.Enqueue(new ReSendMsg(DateTime.Now, strReSendSql));
                       }
                       Thread.Sleep(Interval);
                   }

               }
               catch (System.Exception ex)
               {
                   LogHelper.WriteLog("", ex);
               }
             

                //定时扫描
                int TimeSpan = Controller.GetInstance().Args.args.DataGatherInterval;
                Thread.Sleep(TimeSpan);

            }
        }


        //避免插入同样的sql进行重复的更新
        private bool ExistSQL(string strReSendSql)
        {
            bool result = true;
            try
            {
                ConcurrentQueue<ReSendMsg> tempQueue=new ConcurrentQueue<ReSendMsg>();
                tempQueue = UploadServer.reSendQueue;
                foreach (ReSendMsg item in tempQueue)
                {
                    if (item.reUpdateSQL == strReSendSql)
                    {
                        result = false;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            return result;
        }

        /// <summary>
        /// 处理单位信息上报应答消息
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealUnitInfoDataResp(string recStr)
        {
            try
            {
                //单位信息上报应答
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    string UnitCode = XmlUtil.XmlAnalysis("UnitCode", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateUnitInfoData(UnitCode);
                }
                else
                {
                    string UnitCode = XmlUtil.XmlAnalysis("UnitCode", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateUnitInfoData(UnitCode);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 车辆信息上报应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealVehicleDataResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    string CLBH = XmlUtil.XmlAnalysis("VehicleCode", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateVehicleData(CLBH);
                }
                else
                {
                    string CLBH = XmlUtil.XmlAnalysis("VehicleCode", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateVehicleData(CLBH);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 系统人员上报应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealSysUserDataResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    string PK = XmlUtil.XmlAnalysis("UserName", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateSysUserData(PK);
                }
                else
                {
                    string PK = XmlUtil.XmlAnalysis("UserName", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateSysUserData(PK);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 呼叫记录应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealCallRcordDataResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("CallID", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateCallRcordData(lsh);
                }
                else
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("CallID", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateCallRcordData(lsh);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 受理记录应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealDealDataResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateDealData(lsh);
                }
                else
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateDealData(lsh);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 调度分站记录信息应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealDispatchStationInfoData(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("ID", recStr);
                    string ccdw = XmlUtil.XmlAnalysis("DispatchVehicleUnit", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateDispatchStationInfoData(lsh, ccdw);
                }
                else
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("ID", recStr);
                    string ccdw = XmlUtil.XmlAnalysis("DispatchVehicleUnit", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateDispatchStationInfoData(lsh, ccdw);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 出车记录应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealDispatchVehicleDataResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    string Times = XmlUtil.XmlAnalysis("Times", recStr);
                    string CLBH = XmlUtil.XmlAnalysis("VehicleCode", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateDispatchVehicle(lsh, Times, CLBH);
                   
                }
                else
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    string Times = XmlUtil.XmlAnalysis("Times", recStr);
                    string CLBH = XmlUtil.XmlAnalysis("VehicleCode", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateDispatchVehicle(lsh, Times, CLBH);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        
  
        /// <summary>
        /// 患者信息应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealSuffererDataResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    string SuffererNo = XmlUtil.XmlAnalysis("SuffererNo", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateSuffererData(lsh, SuffererNo);

                }
                else
                {
                    //操作数据库置相应的数据为已经更新
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    string SuffererNo = XmlUtil.XmlAnalysis("SuffererNo", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateSuffererData(lsh, SuffererNo);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 患者病例信息应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealSuffererCaseHistoryDataResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    //操作数据库置相应的数据为已经更新
                    string SuffererNo = XmlUtil.XmlAnalysis("SuffererNo", recStr);
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateSuffererCaseHistoryData(SuffererNo, lsh);

                }
                else
                {
                    //操作数据库置相应的数据为已经更新
                    string SuffererNo = XmlUtil.XmlAnalysis("SuffererNo", recStr);
                    string lsh = XmlUtil.XmlAnalysis("DealRecordID", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdateSuffererCaseHistoryData(SuffererNo, lsh);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 同步急救人员及急救车辆关系应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealPVRelationResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                if (flag == "1")
                {
                    //操作数据库置相应的数据为已经更新
                    string xh = XmlUtil.XmlAnalysis("Index", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdatePVRelationData(xh);

                }
                else
                {
                    //操作数据库置相应的数据为已经更新
                    string xh = XmlUtil.XmlAnalysis("Index", recStr);
                    int i = ExchangeDataAccess.UpdateDadaAccess().UpdatePVRelationData(xh);
                }
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }


        /// <summary>
        /// 同步病历填写项目值数据应答
        /// </summary>
        /// <param name="recStr"></param>
        /// <returns></returns>
        public void DealWeb_MedicalProjectValueResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("ID", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateWeb_MedicalProjectValueData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }

        }
        /// <summary>
        /// 同步病历填写项目数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealWeb_MedicalProjectResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("ID", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateWeb_MedicalProjectData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }

        }
        /// <summary>
        /// 同步病历记录数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealWeb_MedicalRecordsResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("ID", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateWeb_MedicalRecordsData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }

        }
        /// <summary>
        /// 同步病历填写项目与值对应数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealWeb_MedicalStatisticsResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("ID", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateWeb_MedicalStatisticsData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }

        }

        /// <summary>
        /// 同步病历基础信息表数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealBLJCXXBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string lx = XmlUtil.XmlAnalysis("LX", recStr);
                string mc = XmlUtil.XmlAnalysis("MC", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateBLJCXXBData(lx,mc);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        /// <summary>
        /// 同步呼救区域表数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealHJQYBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("XH", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateHJQYBData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        /// <summary>
        /// 同步来电类型表数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealLDLXBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("XH", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateLDLXBData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        /// <summary>
        /// 同步值班员信息表数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealZBYXXBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("ID", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateZBYXXBData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        /// <summary>
        /// 同步症状表数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealZZBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("XH", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateZZBData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        //20151216修改人:朱星汉 修改内容:添加病历关系记录删除表的上传
        /// <summary>
        /// 病历关系记录删除表
        /// </summary>
        /// <param name="recStr"></param>
        public void DealLWBLGXTBDELBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("ID", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateLWBLGXTBDELData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        //20160105修改人:朱星汉 修改内容:添加病历记录删除表的上传
        /// <summary>
        /// 病历记录删除表
        /// </summary>
        /// <param name="recStr"></param>
        public void DealLWBLTBDELBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("ID", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateLWBLTBDELData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }

        /// <summary>
        /// 同步大型事故数据应答
        /// </summary>
        /// <param name="recStr"></param>
        public void DealDXSGBResp(string recStr)
        {
            try
            {
                string flag = XmlUtil.XmlAnalysis("Result", recStr);
                string id = XmlUtil.XmlAnalysis("LSH", recStr);
                int i = ExchangeDataAccess.UpdateDadaAccess().UpdateDXSGBData(id);
            }
            catch (Exception ex) { LogHelper.WriteLog("", ex); }
        }
        
    }
}
