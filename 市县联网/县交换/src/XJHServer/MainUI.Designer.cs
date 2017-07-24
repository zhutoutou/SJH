namespace ZIT.XJHServer.UI
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.lblBssConnectStatus = new System.Windows.Forms.Label();
            this.lblUploadServerStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGpsConnectStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExchangeServerStatus = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuSystem = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExitSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStatus.SuspendLayout();
            this.MenuSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBssConnectStatus
            // 
            this.lblBssConnectStatus.AutoSize = true;
            this.lblBssConnectStatus.ForeColor = System.Drawing.Color.Red;
            this.lblBssConnectStatus.Location = new System.Drawing.Point(105, 13);
            this.lblBssConnectStatus.Name = "lblBssConnectStatus";
            this.lblBssConnectStatus.Size = new System.Drawing.Size(29, 12);
            this.lblBssConnectStatus.TabIndex = 2;
            this.lblBssConnectStatus.Text = "断开";
            // 
            // lblUploadServerStatus
            // 
            this.lblUploadServerStatus.AutoSize = true;
            this.lblUploadServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lblUploadServerStatus.Location = new System.Drawing.Point(417, 13);
            this.lblUploadServerStatus.Name = "lblUploadServerStatus";
            this.lblUploadServerStatus.Size = new System.Drawing.Size(29, 12);
            this.lblUploadServerStatus.TabIndex = 4;
            this.lblUploadServerStatus.Text = "断开";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "数据上传通道：";
            // 
            // lblGpsConnectStatus
            // 
            this.lblGpsConnectStatus.AutoSize = true;
            this.lblGpsConnectStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblGpsConnectStatus.Location = new System.Drawing.Point(258, 13);
            this.lblGpsConnectStatus.Name = "lblGpsConnectStatus";
            this.lblGpsConnectStatus.Size = new System.Drawing.Size(41, 12);
            this.lblGpsConnectStatus.TabIndex = 7;
            this.lblGpsConnectStatus.Text = "未使用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "数据交换通道：";
            // 
            // lblExchangeServerStatus
            // 
            this.lblExchangeServerStatus.AutoSize = true;
            this.lblExchangeServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lblExchangeServerStatus.Location = new System.Drawing.Point(566, 13);
            this.lblExchangeServerStatus.Name = "lblExchangeServerStatus";
            this.lblExchangeServerStatus.Size = new System.Drawing.Size(29, 12);
            this.lblExchangeServerStatus.TabIndex = 9;
            this.lblExchangeServerStatus.Text = "断开";
            // 
            // panelStatus
            // 
            this.panelStatus.AutoSize = true;
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelStatus.Controls.Add(this.label5);
            this.panelStatus.Controls.Add(this.label6);
            this.panelStatus.Controls.Add(this.lblExchangeServerStatus);
            this.panelStatus.Controls.Add(this.lblBssConnectStatus);
            this.panelStatus.Controls.Add(this.lblGpsConnectStatus);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Controls.Add(this.label3);
            this.panelStatus.Controls.Add(this.lblUploadServerStatus);
            this.panelStatus.Location = new System.Drawing.Point(-2, 302);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(637, 42);
            this.panelStatus.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "GPS业务服务器：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "120业务服务器：";
            // 
            // MenuSystem
            // 
            this.MenuSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.MenuSystem.Location = new System.Drawing.Point(0, 0);
            this.MenuSystem.Name = "MenuSystem";
            this.MenuSystem.Size = new System.Drawing.Size(634, 25);
            this.MenuSystem.TabIndex = 11;
            this.MenuSystem.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemViewLog,
            this.menuItemExitSystem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.系统ToolStripMenuItem.Text = "系统(S)";
            // 
            // menuItemViewLog
            // 
            this.menuItemViewLog.Name = "menuItemViewLog";
            this.menuItemViewLog.Size = new System.Drawing.Size(139, 22);
            this.menuItemViewLog.Text = "查看日志(L)";
            this.menuItemViewLog.Click += new System.EventHandler(this.menuItemViewLog_Click);
            // 
            // menuItemExitSystem
            // 
            this.menuItemExitSystem.Name = "menuItemExitSystem";
            this.menuItemExitSystem.Size = new System.Drawing.Size(139, 22);
            this.menuItemExitSystem.Text = "退出系统(E)";
            this.menuItemExitSystem.Click += new System.EventHandler(this.menuItemExitSystem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(H)";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(116, 22);
            this.menuItemAbout.Text = "关于(A)";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "服务正在运行中...";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.MenuSystem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuSystem;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 381);
            this.MinimumSize = new System.Drawing.Size(650, 381);
            this.Name = "MainUI";
            this.Text = "县交换服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.MenuSystem.ResumeLayout(false);
            this.MenuSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBssConnectStatus;
        private System.Windows.Forms.Label lblUploadServerStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGpsConnectStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExchangeServerStatus;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip MenuSystem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemExitSystem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.Label label1;


    }
}

