using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ZIT.SJHServer.Model
{
    public class SysAgrs
    {
        /// <summary>
        /// 120数据库类型
        /// </summary>
        public string DBType;

        /// <summary>
        /// 120全局库连接字符串
        /// </summary>
        public string DBConnectString;

        /// <summary>
        /// 120本地库连接字符串
        /// </summary>
        public string LocalDBConnectString;

        /// <summary>
        /// GPS本地库连接字符串
        /// </summary>
        public string LocalGpsDBConnectionString;

        /// <summary>
        /// 120业务服务器IP地址
        /// </summary>
        public string BusnessServerIP;
        /// <summary>
        /// 120业务服务器端口
        /// </summary>
        public short BusnessServerPort;
        /// <summary>
        /// 与120业务服务器连接的本地端口
        /// </summary>
        public short BusnessServerLocalPort;

        /// <summary>
        /// GPS业务服务器IP地址
        /// </summary>
        public string GPSServerIP;
        /// <summary>
        /// GPS业务服务器端口
        /// </summary>
        public short GPSServerPort;
        /// <summary>
        /// 与GPS业务服务器连接的本地端口
        /// </summary>
        public short GPSServerLocalPort;

        /// <summary>
        /// 数据上传通道地址
        /// </summary>
        public string UploadServerIP;
        /// <summary>
        /// 数据上传通道端口
        /// </summary>
        public short UploadServerPort;

        /// <summary>
        /// 数据交换通道地址
        /// </summary>
        public string ExchangeServerIP;
        /// <summary>
        /// 数据交换通道端口
        /// </summary>
        public short ExchangeServerPort;

        /// <summary>
        /// 与服务器握手时间间隔
        /// </summary>
        public int SharkHandsInterval;

        /// <summary>
        /// 数据采集每次的数量
        /// </summary>
        public int ReadRowNumber;

        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName;
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UnitCode;
    }
}
