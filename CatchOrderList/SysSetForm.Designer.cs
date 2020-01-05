namespace CatchOrderList
{
    partial class SysSetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysSetForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.CheckBox();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnfoldpath = new System.Windows.Forms.Button();
            this.txtimagepath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nintervel = new System.Windows.Forms.NumericUpDown();
            this.nrate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pnlVIP = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.cbReadP = new System.Windows.Forms.CheckBox();
            this.cbOrderVali = new System.Windows.Forms.CheckBox();
            this.cbAutoCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOp2 = new System.Windows.Forms.TextBox();
            this.txtOp1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.npage = new System.Windows.Forms.NumericUpDown();
            this.txtpage = new System.Windows.Forms.TextBox();
            this.cbSpeedImport = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtzcAccount = new System.Windows.Forms.TextBox();
            this.txtzcpass = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nintervel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrate)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.pnlVIP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npage)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(424, 214);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCusName);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cb);
            this.tabPage1.Controls.Add(this.cbAutoLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(416, 188);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基础设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCusName
            // 
            this.txtCusName.Location = new System.Drawing.Point(83, 16);
            this.txtCusName.MaxLength = 20;
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(302, 21);
            this.txtCusName.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtCusName, "最大20个字符");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "客户名称:";
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.Location = new System.Drawing.Point(321, 155);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(72, 16);
            this.cb.TabIndex = 0;
            this.cb.Text = "开机启动";
            this.cb.UseVisualStyleBackColor = true;
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.Location = new System.Drawing.Point(18, 155);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.cbAutoLogin.TabIndex = 0;
            this.cbAutoLogin.Text = "自动登录";
            this.toolTip1.SetToolTip(this.cbAutoLogin, "自动登录");
            this.cbAutoLogin.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnfoldpath);
            this.tabPage2.Controls.Add(this.txtimagepath);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.nintervel);
            this.tabPage2.Controls.Add(this.nrate);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(416, 188);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "高级设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnfoldpath
            // 
            this.btnfoldpath.Location = new System.Drawing.Point(341, 106);
            this.btnfoldpath.Name = "btnfoldpath";
            this.btnfoldpath.Size = new System.Drawing.Size(51, 23);
            this.btnfoldpath.TabIndex = 9;
            this.btnfoldpath.Text = "...";
            this.btnfoldpath.UseVisualStyleBackColor = true;
            this.btnfoldpath.Click += new System.EventHandler(this.btnfoldpath_Click);
            // 
            // txtimagepath
            // 
            this.txtimagepath.Enabled = false;
            this.txtimagepath.Location = new System.Drawing.Point(88, 106);
            this.txtimagepath.Name = "txtimagepath";
            this.txtimagepath.Size = new System.Drawing.Size(244, 21);
            this.txtimagepath.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "运单图片路径:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(21, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(371, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "系统提示：在订单网络不稳定的情况下，建议将刷单频率和间隔调大!";
            // 
            // nintervel
            // 
            this.nintervel.Enabled = false;
            this.nintervel.Location = new System.Drawing.Point(72, 57);
            this.nintervel.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nintervel.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nintervel.Name = "nintervel";
            this.nintervel.Size = new System.Drawing.Size(80, 21);
            this.nintervel.TabIndex = 5;
            this.toolTip1.SetToolTip(this.nintervel, "取值范围:500~5000");
            this.nintervel.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // nrate
            // 
            this.nrate.Enabled = false;
            this.nrate.Location = new System.Drawing.Point(72, 15);
            this.nrate.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nrate.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nrate.Name = "nrate";
            this.nrate.Size = new System.Drawing.Size(80, 21);
            this.nrate.TabIndex = 4;
            this.toolTip1.SetToolTip(this.nrate, "取值范围:500~5000");
            this.nrate.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "刷单间隔:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "毫秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "毫秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "刷单频率:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pnlVIP);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(416, 188);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "VIP专属功能";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pnlVIP
            // 
            this.pnlVIP.Controls.Add(this.label1);
            this.pnlVIP.Controls.Add(this.cbDate);
            this.pnlVIP.Controls.Add(this.cbReadP);
            this.pnlVIP.Controls.Add(this.cbOrderVali);
            this.pnlVIP.Controls.Add(this.cbAutoCheck);
            this.pnlVIP.Controls.Add(this.groupBox1);
            this.pnlVIP.Controls.Add(this.npage);
            this.pnlVIP.Controls.Add(this.txtpage);
            this.pnlVIP.Controls.Add(this.cbSpeedImport);
            this.pnlVIP.Controls.Add(this.label7);
            this.pnlVIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVIP.Location = new System.Drawing.Point(3, 3);
            this.pnlVIP.Name = "pnlVIP";
            this.pnlVIP.Size = new System.Drawing.Size(410, 182);
            this.pnlVIP.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "每页记录数:";
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Location = new System.Drawing.Point(168, 129);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(84, 16);
            this.cbDate.TabIndex = 9;
            this.cbDate.Text = "数据库管理";
            this.toolTip1.SetToolTip(this.cbDate, "单号重复验证");
            this.cbDate.UseVisualStyleBackColor = true;
            this.cbDate.CheckedChanged += new System.EventHandler(this.cbDate_CheckedChanged);
            // 
            // cbReadP
            // 
            this.cbReadP.AutoSize = true;
            this.cbReadP.Location = new System.Drawing.Point(15, 40);
            this.cbReadP.Name = "cbReadP";
            this.cbReadP.Size = new System.Drawing.Size(108, 16);
            this.cbReadP.TabIndex = 0;
            this.cbReadP.Text = "读取收件人信息";
            this.toolTip1.SetToolTip(this.cbReadP, "读取收件人的姓名和电话");
            this.cbReadP.UseVisualStyleBackColor = true;
            // 
            // cbOrderVali
            // 
            this.cbOrderVali.AutoSize = true;
            this.cbOrderVali.Location = new System.Drawing.Point(15, 129);
            this.cbOrderVali.Name = "cbOrderVali";
            this.cbOrderVali.Size = new System.Drawing.Size(72, 16);
            this.cbOrderVali.TabIndex = 8;
            this.cbOrderVali.Text = "导入验证";
            this.toolTip1.SetToolTip(this.cbOrderVali, "单号重复验证");
            this.cbOrderVali.UseVisualStyleBackColor = true;
            // 
            // cbAutoCheck
            // 
            this.cbAutoCheck.AutoSize = true;
            this.cbAutoCheck.Location = new System.Drawing.Point(15, 69);
            this.cbAutoCheck.Name = "cbAutoCheck";
            this.cbAutoCheck.Size = new System.Drawing.Size(72, 16);
            this.cbAutoCheck.TabIndex = 1;
            this.cbAutoCheck.Text = "智能查单";
            this.toolTip1.SetToolTip(this.cbAutoCheck, "智能查单");
            this.cbAutoCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOp2);
            this.groupBox1.Controls.Add(this.txtOp1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(168, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 97);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "页面参数";
            // 
            // txtOp2
            // 
            this.txtOp2.Location = new System.Drawing.Point(73, 63);
            this.txtOp2.Name = "txtOp2";
            this.txtOp2.Size = new System.Drawing.Size(100, 21);
            this.txtOp2.TabIndex = 1;
            // 
            // txtOp1
            // 
            this.txtOp1.Location = new System.Drawing.Point(73, 23);
            this.txtOp1.Name = "txtOp1";
            this.txtOp1.Size = new System.Drawing.Size(100, 21);
            this.txtOp1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "触发源:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "数据源:";
            // 
            // npage
            // 
            this.npage.Location = new System.Drawing.Point(87, 9);
            this.npage.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.npage.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.npage.Name = "npage";
            this.npage.Size = new System.Drawing.Size(75, 21);
            this.npage.TabIndex = 3;
            this.toolTip1.SetToolTip(this.npage, "取值范围10~500000");
            this.npage.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // txtpage
            // 
            this.txtpage.Location = new System.Drawing.Point(75, 152);
            this.txtpage.Name = "txtpage";
            this.txtpage.Size = new System.Drawing.Size(319, 21);
            this.txtpage.TabIndex = 6;
            // 
            // cbSpeedImport
            // 
            this.cbSpeedImport.AutoSize = true;
            this.cbSpeedImport.Location = new System.Drawing.Point(15, 100);
            this.cbSpeedImport.Name = "cbSpeedImport";
            this.cbSpeedImport.Size = new System.Drawing.Size(72, 16);
            this.cbSpeedImport.TabIndex = 4;
            this.cbSpeedImport.Text = "快速导入";
            this.toolTip1.SetToolTip(this.cbSpeedImport, "快速导入");
            this.cbSpeedImport.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "参数页面:";
            this.toolTip1.SetToolTip(this.label7, "参数页面");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(416, 188);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "系统扩展功能";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtzcAccount);
            this.groupBox2.Controls.Add(this.txtzcpass);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 176);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "仲裁系统设置";
            this.toolTip1.SetToolTip(this.groupBox2, "设置完成以后可以自动登录仲裁系统");
            // 
            // txtzcAccount
            // 
            this.txtzcAccount.Location = new System.Drawing.Point(46, 46);
            this.txtzcAccount.Name = "txtzcAccount";
            this.txtzcAccount.Size = new System.Drawing.Size(145, 21);
            this.txtzcAccount.TabIndex = 1;
            // 
            // txtzcpass
            // 
            this.txtzcpass.Location = new System.Drawing.Point(46, 81);
            this.txtzcpass.Name = "txtzcpass";
            this.txtzcpass.PasswordChar = '*';
            this.txtzcpass.Size = new System.Drawing.Size(145, 21);
            this.txtzcpass.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "密码:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "工号:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(222, 220);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(325, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SysSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 250);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SysSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SysSetForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nintervel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrate)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.pnlVIP.ResumeLayout(false);
            this.pnlVIP.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npage)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbAutoLogin;
        private System.Windows.Forms.CheckBox cb;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cbAutoCheck;
        private System.Windows.Forms.CheckBox cbReadP;
        private System.Windows.Forms.NumericUpDown npage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nrate;
        private System.Windows.Forms.NumericUpDown nintervel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbSpeedImport;
        private System.Windows.Forms.TextBox txtpage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOp2;
        private System.Windows.Forms.TextBox txtOp1;
        private System.Windows.Forms.CheckBox cbOrderVali;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.Panel pnlVIP;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtzcAccount;
        private System.Windows.Forms.TextBox txtzcpass;
        private System.Windows.Forms.Button btnfoldpath;
        private System.Windows.Forms.TextBox txtimagepath;
        private System.Windows.Forms.Label label13;
    }
}