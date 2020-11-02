namespace 时间校准器
{
    partial class FrmMian
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMian));
            this.label1 = new System.Windows.Forms.Label();
            this.lbIDCTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lbBeiJingTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTigs = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.rbFast = new System.Windows.Forms.RadioButton();
            this.rbSlow = new System.Windows.Forms.RadioButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.labelUrl = new System.Windows.Forms.Label();
            this.labLog = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前系统时间";
            // 
            // lbIDCTime
            // 
            this.lbIDCTime.AutoSize = true;
            this.lbIDCTime.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIDCTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbIDCTime.Location = new System.Drawing.Point(127, 20);
            this.lbIDCTime.Name = "lbIDCTime";
            this.lbIDCTime.Size = new System.Drawing.Size(0, 20);
            this.lbIDCTime.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(35, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "北京标准时间";
            // 
            // lbBeiJingTime
            // 
            this.lbBeiJingTime.AutoSize = true;
            this.lbBeiJingTime.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBeiJingTime.ForeColor = System.Drawing.Color.Teal;
            this.lbBeiJingTime.Location = new System.Drawing.Point(127, 59);
            this.lbBeiJingTime.Name = "lbBeiJingTime";
            this.lbBeiJingTime.Size = new System.Drawing.Size(0, 20);
            this.lbBeiJingTime.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbTigs);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSecond);
            this.groupBox1.Controls.Add(this.txtMinute);
            this.groupBox1.Controls.Add(this.txtHour);
            this.groupBox1.Controls.Add(this.rbFast);
            this.groupBox1.Controls.Add(this.rbSlow);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(28, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "慢";
            // 
            // lbTigs
            // 
            this.lbTigs.AutoSize = true;
            this.lbTigs.ForeColor = System.Drawing.Color.Red;
            this.lbTigs.Location = new System.Drawing.Point(156, 114);
            this.lbTigs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTigs.Name = "lbTigs";
            this.lbTigs.Size = new System.Drawing.Size(23, 12);
            this.lbTigs.TabIndex = 8;
            this.lbTigs.Text = "5秒";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "快";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(51, 81);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(237, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 30;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(108, 144);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(122, 36);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始校正";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "分";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "小时";
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(212, 53);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(48, 21);
            this.txtSecond.TabIndex = 1;
            this.txtSecond.Text = "0";
            this.txtSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSecond.TextChanged += new System.EventHandler(this.txtSecond_TextChanged);
            // 
            // txtMinute
            // 
            this.txtMinute.Location = new System.Drawing.Point(140, 53);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(48, 21);
            this.txtMinute.TabIndex = 1;
            this.txtMinute.Text = "0";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinute.TextChanged += new System.EventHandler(this.txtMinute_TextChanged);
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(58, 52);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(48, 21);
            this.txtHour.TabIndex = 1;
            this.txtHour.Text = "0";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHour.TextChanged += new System.EventHandler(this.txtHour_TextChanged);
            // 
            // rbFast
            // 
            this.rbFast.AutoSize = true;
            this.rbFast.Location = new System.Drawing.Point(194, 21);
            this.rbFast.Name = "rbFast";
            this.rbFast.Size = new System.Drawing.Size(95, 16);
            this.rbFast.TabIndex = 0;
            this.rbFast.Text = "比北京时间快";
            this.rbFast.UseVisualStyleBackColor = true;
            // 
            // rbSlow
            // 
            this.rbSlow.AutoSize = true;
            this.rbSlow.Checked = true;
            this.rbSlow.Location = new System.Drawing.Point(50, 21);
            this.rbSlow.Name = "rbSlow";
            this.rbSlow.Size = new System.Drawing.Size(95, 16);
            this.rbSlow.TabIndex = 0;
            this.rbSlow.TabStop = true;
            this.rbSlow.Text = "比北京时间慢";
            this.rbSlow.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "时间校准器";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpen.Image")));
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(100, 22);
            this.tsmiOpen.Text = "打开";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Image = ((System.Drawing.Image)(resources.GetObject("tsmiClose.Image")));
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(100, 22);
            this.tsmiClose.Text = "关闭";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUrl.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelUrl.Location = new System.Drawing.Point(51, 319);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(293, 12);
            this.labelUrl.TabIndex = 3;
            this.labelUrl.Text = "开发赞助商：资源驿站（www.zy13.net），点击访问。";
            this.labelUrl.Click += new System.EventHandler(this.labelUrl_Click);
            // 
            // labLog
            // 
            this.labLog.ForeColor = System.Drawing.Color.Green;
            this.labLog.Location = new System.Drawing.Point(37, 89);
            this.labLog.Name = "labLog";
            this.labLog.Size = new System.Drawing.Size(330, 12);
            this.labLog.TabIndex = 10;
            this.labLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 342);
            this.Controls.Add(this.labLog);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.lbBeiJingTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbIDCTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "时间校准器 V3.0";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FrmMian_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIDCTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbBeiJingTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFast;
        private System.Windows.Forms.RadioButton rbSlow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.TextBox txtMinute;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTigs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labLog;
    }
}

