using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.XJHServer.bsController.SJHServer;
using ZIT.XJHServer.bsController.BusinessServer;
using ZIT.XJHServer.bsController.GpsServer;
using ZIT.XJHServer.fnArgs;


namespace ZIT.XJHServer.bsController
{
    public class Controller
    {
        /// <summary>
        /// 确保NetHandler只有一个实例。
        /// </summary>
        private static Controller instance = null;

        /// <summary>
        /// 与120业务服务器连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> BServerConnectionStatusChanged;

        /// <summary>
        /// 与GPS业务服务器连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> GServerConnectionStatusChanged;

        /// <summary>
        /// 与数据交换通道连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> ExchangeServerConnectionStatusChanged;

        /// <summary>
        /// 与数据上传通道连接状态改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> UploadServerConnectionStatusChanged;


        /// <summary>
        /// 与数据上传通道连接状态改变事件
        /// </summary>
        public event EventHandler<DisplayMessageEventArgs> MessageDisplayChanged;

        internal UploadServer us;
        internal ExchangeServer es;
        internal BServer bs;
        internal GServer gs;

        /// <summary>
        /// 系统参数
        /// </summary>
        public SystemArgs Args;

        /// <summary>
        /// 系统单位编号
        /// </summary>
        public string strUnitCode;
        /// <summary>
        /// 系统单位名称
        /// </summary>
        public string strUnitName;

        /// <summary>
        /// 与服务器握手时间间隔
        /// </summary>
        public int SharkHandsInterval;

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
            strUnitCode = Args.args.UnitCode;
            strUnitName = Args.args.UnitName;
            SharkHandsInterval = Args.args.SharkHandsInterval;

            us = new UploadServer();
            es = new ExchangeServer();
            bs = new BServer();
            gs = new GServer();
        }

        /// <summary>
        /// 开始数据交换服务
        /// </summary>
        public void StartService()
        {
            try
            {
                //连接数据上传通道
                us.UploadServerIP = Args.args.UploadServerIP;
                us.UploadServerPort = Args.args.UploadServerPort;
                us.ConnectionStatusChanged += UploadServer_StatusChanged;
                us.Start();
            }
            catch (Exception ex) { LOG.LogHelper.WriteLog("", ex); }
            try
            {
                //连接数据交换通道
                es.ExchangeServerIP = Args.args.ExchangeServerIP;
                es.ExchangeServerPort = Args.args.ExchangeServerPort;
                es.ConnectionStatusChanged += ExchangeServer_StatusChanged;
                es.Start();
            }
            catch (Exception ex) { LOG.LogHelper.WriteLog("", ex); }
            try
            {
             //连接120业务服务器
             bs.strRemoteIP = Args.args.BusnessServerIP;
             bs.nRemotePort = Args.args.BusnessServerPort;
             bs.nLocalPort = Args.args.BusnessServerLocalPort;
             bs.ConnectionStatusChanged += BusnessServer_StatusChanged;
             bs.Start();
            }
            catch (Exception ex) { LOG.LogHelper.WriteLog("", ex); }
            try
            {
             //连接GPS业务服务器
             gs.nLocalPort = Args.args.GPSServerLocalPort;
             gs.Start();
            }
            catch (Exception ex) { LOG.LogHelper.WriteLog("", ex); }
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

        private void UploadServer_StatusChanged(object sender, StatusEventArgs e)
        {
            OnUploadServerConnectionStatusChanged(e.Status);
        }

        private void ExchangeServer_StatusChanged(object sender, StatusEventArgs e)
        {
            OnExchangeServerConnectionStatusChanged(e.Status);
        }

        private void BusnessServer_StatusChanged(object sender, StatusEventArgs e)
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
        /// Raises ExchangeServerConnectionStatusChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        protected virtual void OnExchangeServerConnectionStatusChanged(NetStatus status)
        {
            var handler = ExchangeServerConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(status));
            }
        }

        /// <summary>
        /// Raises UploadServerConnectionStatusChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        protected virtual void OnUploadServerConnectionStatusChanged(NetStatus status)
        {
            var handler = UploadServerConnectionStatusChanged;
            if (handler != null)
            {
                handler(this, new StatusEventArgs(status));
            }
        }

        
        /// <summary>
        /// Raises UploadServerConnectionStatusChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        protected virtual void OnMessageDisplayChanged(string message)
        {
            var handler = MessageDisplayChanged;
            if (handler != null)
            {
                handler(this, new DisplayMessageEventArgs(message));
            }
        }
    }
}
