using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ZIT.SJHServer.bsController.SJHServer;
using ZIT.SJHServer.bsController.BusinessServer;
using ZIT.SJHServer.bsController.GpsServer;
using ZIT.SJHServer.fnArgs;
using ZIT.SJHServer.Model;
using ZIT.SJHServer.fnDataAccess;
using ZIT.SJHServer.bsController.DataSaved;

namespace ZIT.SJHServer.bsController
{
    public class Controller
    {
        /// <summary>
        /// 与120业务服务器连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> BServerConnectionStatusChanged;

        /// <summary>
        /// 与GPS业务服务器连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> GServerConnectionStatusChanged;

        /// <summary>
        /// 与数据交换通道连接客户端改变事件
        /// </summary>
        public event EventHandler<UnitsEventArgs> ExchangeServerConnectedClientChanged;

        /// <summary>
        /// 与数据上传通道连接客户端改变事件
        /// </summary>
        public event EventHandler<UnitsEventArgs> UploadServerConnectedClientChanged;

        /// <summary>
        /// 确保NetHandler只有一个实例。
        /// </summary>
        private static Controller instance = null;

        internal UploadServer us;
        internal ExchangeServer es;
        internal BServer bs;
        internal GServer gs;

        public SystemArgs Args;

        /// <summary>
        /// 处理消息线程
        /// </summary>
        public Thread LocalSyncDataThread = null;
        
        /// <summary>
        /// 单位字典  单位编号 -- 单位结构体
        /// </summary>
        public Dictionary<string, TUnit> dicUnit;

        /// <summary>
        /// 获取当前类实例
        /// </summary>
        /// <returns></returns>
        public static Controller GetInstance()
        {
            if (null == instance)
            {
                instance = new Controller();
            }
            return instance;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        private Controller()
        {
            Args = SystemArgs.GetInstance();
            us = new UploadServer();
            es = new ExchangeServer();
            bs = new BServer();
            gs = new GServer();

            //Get all unit info
            dicUnit = new Dictionary<string, TUnit>();
            //TUnit unit = new TUnit();
            //unit.UnitCode = "001000";
            //unit.UnitName = "xx县120急救中心";
            //unit.UnitXZBM = "510112";

            //dicUnit.Add("001000", unit);
        }

        /// <summary>
        /// 开始数据交换服务
        /// </summary>
        public void StartService()
        {
            //初始化单位编号及行政编码对应字典
            try
            {
                InitDicUnit();
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }

            //启动接数据上传通道
            try
            {
                us.UploadServerPort = Args.args.UploadServerPort;
                us.ServerConnectedClientChanged += UploadServerConnectedClient_Changed;
                us.Start();
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }

            //启动数据交换通道
            try
            {
                es.ExchangeServerPort = Args.args.ExchangeServerPort;
                es.ServerConnectedClientChanged += ExchangeServerConnectedClient_Changed;
                es.Start();
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }

            //连接120业务服务器
            try
            {
                bs.strRemoteIP = Args.args.BusnessServerIP;
                bs.nRemotePort = Args.args.BusnessServerPort;
                bs.nLocalPort = Args.args.BusnessServerLocalPort;
                bs.ConnectionStatusChanged += BServerConnectionStatus_Changed;
                bs.Start();
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            //启动GPS业务服务器UDP监听
            try
            {
                gs.nLocalPort = Args.args.GPSServerLocalPort;
                gs.Start();
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
            //启动市本地库往全局库上传业务
            try
            {
                LocalSyncDataThread = new Thread(new SyncLocalData().StartSyncLocalData);
                LocalSyncDataThread.Start();
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
        }
        /// <summary>
        /// 初始化单位编号及行政编码对应字典
        /// </summary>
        private void InitDicUnit()
        {
            IDataExchangeDataAccess Data = DataAccess.DataExchangeDataAccess();
            List<TUnit> units = Data.GetAllUnitXZBM();
            foreach (var item in units)
            {
                dicUnit.Add(item.UnitCode, item);
            }
        }

        /// <summary>
        /// 停止数据交换服务
        /// </summary>
        public void StopService()
        {
            us.Stop();
            es.Stop();
            bs.Stop();
            gs.Stop();
        }

        private void UploadServerConnectedClient_Changed(object sender, UnitsEventArgs e)
        {
            OnUploadServerConnectedClientChanged(e.Units);
        }

        private void ExchangeServerConnectedClient_Changed(object sender, UnitsEventArgs e)
        {
            OnExchangeServerConnectedClientChanged(e.Units);
        }

        private void BServerConnectionStatus_Changed(object sender, StatusEventArgs e)
        {
            OnBServerConnectionStatusChanged(e.Status);
        }

        /// <summary>
        /// Raises BServerConnectionStatusChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        protected virtual void OnBServerConnectionStatusChanged(NetStatus status)
        {
            var handler = BServerConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(status));
            }
        }

        /// <summary>
        /// Raises GServerConnectionStatusChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        protected virtual void OnGServerConnectionStatusChanged(NetStatus status)
        {
            var handler = GServerConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(status));
            }
        }

        /// <summary>
        /// Raises ExchangeServerConnectedClientChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        protected virtual void OnExchangeServerConnectedClientChanged(List<OnlineUnit> units)
        {
            var handler = ExchangeServerConnectedClientChanged;
            if (handler != null)
            {
                handler(this, new UnitsEventArgs(units));
            }
        }

        /// <summary>
        /// Raises UploadServerConnectedClientChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        protected virtual void OnUploadServerConnectedClientChanged(List<OnlineUnit> units)
        {
            var handler = UploadServerConnectedClientChanged;
            if (handler != null)
            {
                handler(this, new UnitsEventArgs(units));
            }
        }

    }
}
