using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Configuration;
using ZIT.XJHServer.Model;


namespace ZIT.XJHServer.fnArgs
{
    public class SystemArgs
    {
        /// <summary>
        /// 确保SystemArgs只有一个实例。
        /// </summary>
        private static SystemArgs instance = null;

        /// <summary>
        /// 系统参数值
        /// </summary>
        public SysAgrs args { get; private set; }


        /// <summary>
        /// 获取当前类实例
        /// </summary>
        /// <returns></returns>
        public static SystemArgs GetInstance()
        {
            if (null == instance)
            {
                instance = new SystemArgs();
            }
            return instance;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        private SystemArgs()
        {
            GetSystemArgs();
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <returns></returns>
        private void GetSystemArgs()
        {
            try
            {
                args = new SysAgrs();
                args.BusnessServerIP = ConfigurationManager.AppSettings["BusnessServerIP"].Trim();
                args.BusnessServerLocalPort = short.Parse(ConfigurationManager.AppSettings["BusnessServerLocalPort"].Trim());
                args.BusnessServerPort = short.Parse(ConfigurationManager.AppSettings["BusnessServerPort"].Trim());
                args.DBConnectString = ConfigurationManager.AppSettings["DBConnectString"].Trim();
                args.DBType = ConfigurationManager.AppSettings["DBType"].Trim();
                args.ExchangeServerIP = ConfigurationManager.AppSettings["ExchangeServerIP"].Trim();
                args.ExchangeServerPort = short.Parse(ConfigurationManager.AppSettings["ExchangeServerPort"].Trim());
                args.GPSServerLocalPort = short.Parse(ConfigurationManager.AppSettings["GPSServerLocalPort"].Trim());
                args.UnitCode = ConfigurationManager.AppSettings["UnitCode"].Trim();
                args.UnitName = ConfigurationManager.AppSettings["UnitName"].Trim();
                args.UploadServerIP = ConfigurationManager.AppSettings["UploadServerIP"].Trim();
                args.UploadServerPort = short.Parse(ConfigurationManager.AppSettings["UploadServerPort"].Trim());
                args.SharkHandsInterval = 10;
                args.DataGatherInterval = 3000;
                args.ReadRowNumber = 30;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
