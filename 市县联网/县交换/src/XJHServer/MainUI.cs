using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using ZIT.XJHServer.bsController;
using ZIT.LOG;


namespace ZIT.XJHServer.UI
{
    public partial class MainUI : Form
    {
        /// <summary>
        /// 调用初始化网络委托
        /// </summary>
        public delegate void InvokeInitNetwork();

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainUI_Load(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                MethodInvoker init = new MethodInvoker(InitProgram);
                init.BeginInvoke(null, null);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("主窗体加载出错", ex);
            }

        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        private void InitProgram()
        {

            try
            {
                
                Controller control = Controller.GetInstance();
                control.BServerConnectionStatusChanged += BServer_ConnectionStatusChanged;
                control.GServerConnectionStatusChanged += GServer_ConnectionStatusChanged;
                control.ExchangeServerConnectionStatusChanged += ExchangeServer_ConnectionStatusChanged;
                control.UploadServerConnectionStatusChanged += UploadServer_ConnectionStatusChanged;
                control.StartService();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("InitProgram", ex);

            }
        }

        /// <summary>
        /// 与120业务服务器连接状态改变事件
        /// </summary>
        private void BServer_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblBssConnectStatus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblBssConnectStatus.Text = "断开";
                        lblBssConnectStatus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblBssConnectStatus.Text = "已连接";
                        lblBssConnectStatus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }

        /// <summary>
        /// 与GPS业务服务器连接状态改变事件
        /// </summary>
        private void GServer_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblGpsConnectStatus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblGpsConnectStatus.Text = "断开";
                        lblGpsConnectStatus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblGpsConnectStatus.Text = "已连接";
                        lblGpsConnectStatus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }

        /// <summary>
        /// 与数据交换通道连接状态改变事件
        /// </summary>
        private void ExchangeServer_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblExchangeServerStatus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblExchangeServerStatus.Text = "断开";
                        lblExchangeServerStatus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblExchangeServerStatus.Text = "已连接";
                        lblExchangeServerStatus.ForeColor = Color.Blue;
                        break;
                    case NetStatus.Login:
                        lblExchangeServerStatus.Text = "已登录";
                        lblExchangeServerStatus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }

        /// <summary>
        /// 与数据上传通道连接状态改变事件
        /// </summary>
        private void UploadServer_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblUploadServerStatus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblUploadServerStatus.Text = "断开";
                        lblUploadServerStatus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblUploadServerStatus.Text = "已连接";
                        lblUploadServerStatus.ForeColor = Color.Blue;
                        break;
                    case NetStatus.Login:
                        lblUploadServerStatus.Text = "已登录";
                        lblUploadServerStatus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "确定要退出么？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Controller.GetInstance().StopService();
                    Thread.Sleep(1000);
                    System.Environment.Exit(System.Environment.ExitCode);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItemViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                string strLogPath;
                strLogPath = Directory.GetCurrentDirectory();
                strLogPath += "\\Log\\";
                if (Directory.Exists(strLogPath))
                {
                    Process.Start("explorer.exe", strLogPath);
                }
                else
                {
                    MessageBox.Show("未检测到日志文件目录！");
                }
            }
            catch { }
        }

        private void menuItemExitSystem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "确定要退出么？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Controller.GetInstance().StopService();
                    Thread.Sleep(1000);
                    System.Environment.Exit(System.Environment.ExitCode);
                }
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteLog("", ex);
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

    }
}
