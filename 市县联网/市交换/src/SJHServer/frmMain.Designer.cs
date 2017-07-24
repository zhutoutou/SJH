namespace ZIT.SJHServer.UI
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblGpsServerStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBusinessServerStaus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabChannel = new System.Windows.Forms.TabControl();
            this.tabPageDataUploadChannel = new System.Windows.Forms.TabPage();
            this.GridDataUpload = new System.Windows.Forms.DataGridView();
            this.tabPageDataExchangeChannel = new System.Windows.Forms.TabPage();
            this.GridDataExchange = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.tabChannel.SuspendLayout();
            this.tabPageDataUploadChannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDataUpload)).BeginInit();
            this.tabPageDataExchangeChannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDataExchange)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "SysMenu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuViewLog,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(57, 20);
            this.menuFile.Text = "系统(S)";
            // 
            // MenuViewLog
            // 
            this.MenuViewLog.Name = "MenuViewLog";
            this.MenuViewLog.Size = new System.Drawing.Size(136, 22);
            this.MenuViewLog.Text = "查看日志(L)";
            this.MenuViewLog.Click += new System.EventHandler(this.MenuViewLog_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(136, 22);
            this.menuExit.Text = "退出系统(E)";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(58, 20);
            this.menuHelp.Text = "帮助(H)";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(113, 22);
            this.menuAbout.Text = "关于(A)";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.AutoSize = true;
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelStatus.Controls.Add(this.lblGpsServerStatus);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Controls.Add(this.lblBusinessServerStaus);
            this.panelStatus.Controls.Add(this.label1);
            this.panelStatus.Location = new System.Drawing.Point(0, 362);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(624, 42);
            this.panelStatus.TabIndex = 1;
            // 
            // lblGpsServerStatus
            // 
            this.lblGpsServerStatus.AutoSize = true;
            this.lblGpsServerStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblGpsServerStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblGpsServerStatus.Location = new System.Drawing.Point(261, 13);
            this.lblGpsServerStatus.Name = "lblGpsServerStatus";
            this.lblGpsServerStatus.Size = new System.Drawing.Size(41, 12);
            this.lblGpsServerStatus.TabIndex = 3;
            this.lblGpsServerStatus.Text = "未使用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "GPS业务服务器：";
            // 
            // lblBusinessServerStaus
            // 
            this.lblBusinessServerStaus.AutoSize = true;
            this.lblBusinessServerStaus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBusinessServerStaus.ForeColor = System.Drawing.Color.Red;
            this.lblBusinessServerStaus.Location = new System.Drawing.Point(104, 13);
            this.lblBusinessServerStaus.Name = "lblBusinessServerStaus";
            this.lblBusinessServerStaus.Size = new System.Drawing.Size(29, 12);
            this.lblBusinessServerStaus.TabIndex = 1;
            this.lblBusinessServerStaus.Text = "断开";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "120业务服务器：";
            // 
            // tabChannel
            // 
            this.tabChannel.Controls.Add(this.tabPageDataUploadChannel);
            this.tabChannel.Controls.Add(this.tabPageDataExchangeChannel);
            this.tabChannel.Location = new System.Drawing.Point(0, 28);
            this.tabChannel.Name = "tabChannel";
            this.tabChannel.SelectedIndex = 0;
            this.tabChannel.Size = new System.Drawing.Size(624, 328);
            this.tabChannel.TabIndex = 2;
            // 
            // tabPageDataUploadChannel
            // 
            this.tabPageDataUploadChannel.Controls.Add(this.GridDataUpload);
            this.tabPageDataUploadChannel.Location = new System.Drawing.Point(4, 21);
            this.tabPageDataUploadChannel.Name = "tabPageDataUploadChannel";
            this.tabPageDataUploadChannel.Size = new System.Drawing.Size(616, 303);
            this.tabPageDataUploadChannel.TabIndex = 0;
            this.tabPageDataUploadChannel.Text = "数据上传通道连接(0)";
            this.tabPageDataUploadChannel.UseVisualStyleBackColor = true;
            // 
            // GridDataUpload
            // 
            this.GridDataUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDataUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDataUpload.Location = new System.Drawing.Point(0, 0);
            this.GridDataUpload.Name = "GridDataUpload";
            this.GridDataUpload.ReadOnly = true;
            this.GridDataUpload.RowHeadersVisible = false;
            this.GridDataUpload.RowTemplate.Height = 23;
            this.GridDataUpload.Size = new System.Drawing.Size(616, 303);
            this.GridDataUpload.TabIndex = 0;
            this.GridDataUpload.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridDataUpload_DataBindingComplete);
            // 
            // tabPageDataExchangeChannel
            // 
            this.tabPageDataExchangeChannel.Controls.Add(this.GridDataExchange);
            this.tabPageDataExchangeChannel.Location = new System.Drawing.Point(4, 21);
            this.tabPageDataExchangeChannel.Name = "tabPageDataExchangeChannel";
            this.tabPageDataExchangeChannel.Size = new System.Drawing.Size(616, 303);
            this.tabPageDataExchangeChannel.TabIndex = 1;
            this.tabPageDataExchangeChannel.Text = "数据交换通道连接(0)";
            this.tabPageDataExchangeChannel.UseVisualStyleBackColor = true;
            // 
            // GridDataExchange
            // 
            this.GridDataExchange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDataExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDataExchange.Location = new System.Drawing.Point(0, 0);
            this.GridDataExchange.Name = "GridDataExchange";
            this.GridDataExchange.RowHeadersVisible = false;
            this.GridDataExchange.RowTemplate.Height = 23;
            this.GridDataExchange.Size = new System.Drawing.Size(616, 302);
            this.GridDataExchange.TabIndex = 0;
            this.GridDataExchange.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridDataExchange_DataBindingComplete);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(632, 416);
            this.Controls.Add(this.tabChannel);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(640, 443);
            this.MinimumSize = new System.Drawing.Size(640, 443);
            this.Name = "frmMain";
            this.Text = "市交换服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.tabChannel.ResumeLayout(false);
            this.tabPageDataUploadChannel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDataUpload)).EndInit();
            this.tabPageDataExchangeChannel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDataExchange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblBusinessServerStaus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGpsServerStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabChannel;
        private System.Windows.Forms.TabPage tabPageDataUploadChannel;
        private System.Windows.Forms.TabPage tabPageDataExchangeChannel;
        private System.Windows.Forms.DataGridView GridDataUpload;
        private System.Windows.Forms.DataGridView GridDataExchange;
        private System.Windows.Forms.ToolStripMenuItem MenuViewLog;
    }
}

