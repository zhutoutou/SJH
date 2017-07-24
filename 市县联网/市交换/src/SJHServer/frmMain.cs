using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZIT.SJHServer.bsController;
using ZIT.SJHServer.Model;
using ZIT.LOG;


namespace ZIT.SJHServer.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
                control.ExchangeServerConnectedClientChanged += ExchangeServer_ConnectedClientChanged;
                control.UploadServerConnectedClientChanged += UploadServer_ConnectedClientChanged;
                control.StartService();

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("InitProgram", ex);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "确定要退出么？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    LOG.LogHelper.WriteLog("程序退出！");
                    Controller.GetInstance().StopService();
                    Thread.Sleep(1000);
                    System.Environment.Exit(System.Environment.ExitCode);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                LOG.LogHelper.WriteLog("", ex);
            }
        }


        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                InitGridDataUpload();
                InitGridDataExchange();

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
        /// 与120业务服务器连接状态改变事件
        /// </summary>
        private void BServer_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblBusinessServerStaus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblBusinessServerStaus.Text = "断开";
                        lblBusinessServerStaus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblBusinessServerStaus.Text = "已连接";
                        lblBusinessServerStaus.ForeColor = Color.Green;
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
            lblGpsServerStatus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblGpsServerStatus.Text = "断开";
                        lblGpsServerStatus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblGpsServerStatus.Text = "已连接";
                        lblGpsServerStatus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }

        /// <summary>
        /// 处理数据交换通道连接客户端改变事件
        /// </summary>
        private void ExchangeServer_ConnectedClientChanged(object sender, UnitsEventArgs e)
        {
            tabPageDataExchangeChannel.BeginInvoke(new MethodInvoker(() =>
            {
                tabPageDataExchangeChannel.Text = "数据交换通道连接(" + e.Units.Count.ToString() + ")";
            }));

            GridDataExchange.BeginInvoke(new MethodInvoker(() =>
            {
                GridDataExchange.DataSource = e.Units;
                GridDataExchange.Refresh();
            }));
        }
        
        /// <summary>
        /// 处理数据上传通道连接客户端改变事件
        /// </summary>
        private void UploadServer_ConnectedClientChanged(object sender, UnitsEventArgs e)
        {

            tabPageDataUploadChannel.BeginInvoke(new MethodInvoker(() =>
            {
                tabPageDataUploadChannel.Text = "数据上传通道连接(" + e.Units.Count.ToString() + ")";
            }));

            GridDataUpload.BeginInvoke(new MethodInvoker(() =>
            {
                GridDataUpload.DataSource = e.Units;
                GridDataUpload.Refresh();
            }));
        }
        
        /// <summary>
        /// 初始化GridDataUpload列
        /// </summary>
        private void InitGridDataUpload()
        {
            GridDataUpload.ReadOnly = true;
            GridDataUpload.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "IPAddress";
            c1.HeaderText = "IP地址";
            c1.DataPropertyName = "IPAddress";
            c1.Width = 120;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "UnitName";
            c2.HeaderText = "单位名称";
            c2.DataPropertyName = "UnitName";
            c2.Width = 190;

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "UnitCode";
            c3.HeaderText = "单位编号";
            c3.DataPropertyName = "UnitCode";
            c3.Width = 80;

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.Name = "Status";
            c4.DataPropertyName = "Status";
            c4.HeaderText = "连接状态";
            c4.Width = 80;

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.Name = "ConnectedTime";
            c5.DataPropertyName = "ConnectedTime";
            c5.HeaderText = "连接时间";
            c5.Width = 130;

            GridDataUpload.Columns.Add(c1);
            GridDataUpload.Columns.Add(c2);
            GridDataUpload.Columns.Add(c3);
            GridDataUpload.Columns.Add(c4);
            GridDataUpload.Columns.Add(c5);
        }
        /// <summary>
        /// 初始化GridDataExchange列
        /// </summary>
        private void InitGridDataExchange()
        {
            GridDataExchange.ReadOnly = true;
            GridDataExchange.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "IPAddress";
            c1.HeaderText = "IP地址";
            c1.DataPropertyName = "IPAddress";
            c1.Width = 120;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "UnitName";
            c2.HeaderText = "单位名称";
            c2.DataPropertyName = "UnitName";
            c2.Width = 190;

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "UnitCode";
            c3.HeaderText = "单位编号";
            c3.DataPropertyName = "UnitCode";
            c3.Width = 80;

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.Name = "Status";
            c4.DataPropertyName = "Status";
            c4.HeaderText = "连接状态";
            c4.Width = 80;

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.Name = "ConnectedTime";
            c5.DataPropertyName = "ConnectedTime";
            c5.HeaderText = "连接时间";
            c5.Width = 130;

            GridDataExchange.Columns.Add(c1);
            GridDataExchange.Columns.Add(c2);
            GridDataExchange.Columns.Add(c3);
            GridDataExchange.Columns.Add(c4);
            GridDataExchange.Columns.Add(c5);
        }

        private void GridDataUpload_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (GridDataUpload.CurrentRow != null)
            {
                GridDataUpload.CurrentRow.Selected = false;
            }  
        }

        private void GridDataExchange_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (GridDataExchange.CurrentRow != null)
            {
                GridDataExchange.CurrentRow.Selected = false;
            }  
        }
        /// <summary>
        /// 查看日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuViewLog_Click(object sender, EventArgs e)
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
             catch (Exception ex) { LogHelper.WriteLog("" , ex); }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
    }
}
