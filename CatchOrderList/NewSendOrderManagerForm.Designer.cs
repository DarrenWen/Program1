using Tony.Controls.Winform;

namespace CatchOrderList
{
    partial class NewSendOrderManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSendOrderManagerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCheckCheck = new System.Windows.Forms.CheckBox();
            this.cbPoint = new System.Windows.Forms.CheckBox();
            this.cbChuidan = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.cbCatchState = new System.Windows.Forms.ComboBox();
            this.lbl01 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpReciveDate = new System.Windows.Forms.DateTimePicker();
            this.cbReciveDate = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnQuickSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.cbOrderState = new System.Windows.Forms.ComboBox();
            this.ddlSaleMan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvInfo = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsShowInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmicopyorderno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmicopyaddress = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ilInfo = new System.Windows.Forms.ImageList(this.components);
            this.anpageinfo = new Tony.Controls.Winform.WinFormPager();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).BeginInit();
            this.cmsShowInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCheckCheck);
            this.panel1.Controls.Add(this.cbPoint);
            this.panel1.Controls.Add(this.cbChuidan);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.cbCatchState);
            this.panel1.Controls.Add(this.lbl01);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpReciveDate);
            this.panel1.Controls.Add(this.cbReciveDate);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnQuickSearch);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKeyWord);
            this.panel1.Controls.Add(this.cbOrderState);
            this.panel1.Controls.Add(this.ddlSaleMan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 77);
            this.panel1.TabIndex = 0;
            // 
            // cbCheckCheck
            // 
            this.cbCheckCheck.AutoSize = true;
            this.cbCheckCheck.ForeColor = System.Drawing.Color.Red;
            this.cbCheckCheck.Location = new System.Drawing.Point(702, 17);
            this.cbCheckCheck.Name = "cbCheckCheck";
            this.cbCheckCheck.Size = new System.Drawing.Size(96, 16);
            this.cbCheckCheck.TabIndex = 20;
            this.cbCheckCheck.Text = "不跳过已签收";
            this.cbCheckCheck.UseVisualStyleBackColor = true;
            // 
            // cbPoint
            // 
            this.cbPoint.AutoSize = true;
            this.cbPoint.ForeColor = System.Drawing.Color.Red;
            this.cbPoint.Location = new System.Drawing.Point(615, 18);
            this.cbPoint.Name = "cbPoint";
            this.cbPoint.Size = new System.Drawing.Size(72, 16);
            this.cbPoint.TabIndex = 17;
            this.cbPoint.Text = "单号定位";
            this.cbPoint.UseVisualStyleBackColor = true;
            this.cbPoint.CheckedChanged += new System.EventHandler(this.cbPoint_CheckedChanged);
            // 
            // cbChuidan
            // 
            this.cbChuidan.AutoSize = true;
            this.cbChuidan.ForeColor = System.Drawing.Color.Red;
            this.cbChuidan.Location = new System.Drawing.Point(615, 51);
            this.cbChuidan.Name = "cbChuidan";
            this.cbChuidan.Size = new System.Drawing.Size(72, 16);
            this.cbChuidan.TabIndex = 16;
            this.cbChuidan.Text = "需要催单";
            this.cbChuidan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(436, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(470, 47);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(121, 21);
            this.dtpEnd.TabIndex = 14;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(947, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cbCatchState
            // 
            this.cbCatchState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCatchState.FormattingEnabled = true;
            this.cbCatchState.Items.AddRange(new object[] {
            "==请选择==",
            "发现未装车",
            "公司错分件",
            "中转延误件",
            "遗失件",
            "需要催单件"});
            this.cbCatchState.Location = new System.Drawing.Point(69, 47);
            this.cbCatchState.Name = "cbCatchState";
            this.cbCatchState.Size = new System.Drawing.Size(105, 20);
            this.cbCatchState.TabIndex = 12;
            // 
            // lbl01
            // 
            this.lbl01.AutoSize = true;
            this.lbl01.Location = new System.Drawing.Point(5, 50);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(59, 12);
            this.lbl01.TabIndex = 11;
            this.lbl01.Text = "跟单状态:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "订单状态:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "业务员:";
            // 
            // dtpReciveDate
            // 
            this.dtpReciveDate.Location = new System.Drawing.Point(298, 47);
            this.dtpReciveDate.Name = "dtpReciveDate";
            this.dtpReciveDate.Size = new System.Drawing.Size(121, 21);
            this.dtpReciveDate.TabIndex = 6;
            // 
            // cbReciveDate
            // 
            this.cbReciveDate.AutoSize = true;
            this.cbReciveDate.Checked = true;
            this.cbReciveDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReciveDate.Location = new System.Drawing.Point(221, 51);
            this.cbReciveDate.Name = "cbReciveDate";
            this.cbReciveDate.Size = new System.Drawing.Size(78, 16);
            this.cbReciveDate.TabIndex = 5;
            this.cbReciveDate.Text = "收件日期:";
            this.cbReciveDate.UseVisualStyleBackColor = true;
            this.cbReciveDate.CheckedChanged += new System.EventHandler(this.cbReciveDate_CheckedChanged);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(947, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnQuickSearch
            // 
            this.btnQuickSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickSearch.Location = new System.Drawing.Point(855, 44);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(75, 23);
            this.btnQuickSearch.TabIndex = 4;
            this.btnQuickSearch.Tag = "0";
            this.btnQuickSearch.Text = "自动查单";
            this.btnQuickSearch.UseVisualStyleBackColor = true;
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(855, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(70, 12);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(105, 21);
            this.txtKeyWord.TabIndex = 3;
            // 
            // cbOrderState
            // 
            this.cbOrderState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrderState.FormattingEnabled = true;
            this.cbOrderState.Items.AddRange(new object[] {
            "==请选择==",
            "正常签收",
            "非正常签收",
            "异常签收",
            "未签收",
            "未处理"});
            this.cbOrderState.Location = new System.Drawing.Point(487, 12);
            this.cbOrderState.Name = "cbOrderState";
            this.cbOrderState.Size = new System.Drawing.Size(104, 20);
            this.cbOrderState.TabIndex = 2;
            // 
            // ddlSaleMan
            // 
            this.ddlSaleMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSaleMan.FormattingEnabled = true;
            this.ddlSaleMan.Location = new System.Drawing.Point(272, 12);
            this.ddlSaleMan.Name = "ddlSaleMan";
            this.ddlSaleMan.Size = new System.Drawing.Size(121, 20);
            this.ddlSaleMan.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "关键字:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1029, 399);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1029, 399);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvInfo);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1021, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "单号列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gvInfo
            // 
            this.gvInfo.AllowUserToAddRows = false;
            this.gvInfo.AllowUserToDeleteRows = false;
            this.gvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column12,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column9,
            this.Column8,
            this.Column3,
            this.Column6,
            this.Column11,
            this.Column10,
            this.Column7,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18});
            this.gvInfo.ContextMenuStrip = this.cmsShowInfo;
            this.gvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvInfo.Location = new System.Drawing.Point(3, 3);
            this.gvInfo.Name = "gvInfo";
            this.gvInfo.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvInfo.RowTemplate.Height = 23;
            this.gvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvInfo.ShowCellErrors = false;
            this.gvInfo.Size = new System.Drawing.Size(1015, 333);
            this.gvInfo.TabIndex = 6;
            this.gvInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInfo_CellContentDoubleClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "行号";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 70;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "单号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "派件日";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "业务员";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "客户";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "收件人";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "收件人电话";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "省";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "市";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "区";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "详细地址";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "备注";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "处理状态";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Column15";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "签收日期";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "签收人";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "催单状态";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // cmsShowInfo
            // 
            this.cmsShowInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tsmiUpdateDate,
            this.tsmiDel,
            this.ddToolStripMenuItem,
            this.复制ToolStripMenuItem});
            this.cmsShowInfo.Name = "contextMenuStrip1";
            this.cmsShowInfo.Size = new System.Drawing.Size(125, 98);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Image = global::CatchOrderList.Properties.Resources.pf;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(124, 22);
            this.tsmiUpdate.Text = "修改客户";
            this.tsmiUpdate.Visible = false;
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiUpdateDate
            // 
            this.tsmiUpdateDate.Image = global::CatchOrderList.Properties.Resources.design;
            this.tsmiUpdateDate.Name = "tsmiUpdateDate";
            this.tsmiUpdateDate.Size = new System.Drawing.Size(124, 22);
            this.tsmiUpdateDate.Text = "修改日期";
            this.tsmiUpdateDate.Click += new System.EventHandler(this.tsmiUpdateDate_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Image = global::CatchOrderList.Properties.Resources.wrong;
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(124, 22);
            this.tsmiDel.Text = "删除单号";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            this.ddToolStripMenuItem.Size = new System.Drawing.Size(121, 6);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmicopyorderno,
            this.tsmicopyaddress});
            this.复制ToolStripMenuItem.Image = global::CatchOrderList.Properties.Resources.doc2;
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Visible = false;
            // 
            // tsmicopyorderno
            // 
            this.tsmicopyorderno.Image = global::CatchOrderList.Properties.Resources.square_blueS;
            this.tsmicopyorderno.Name = "tsmicopyorderno";
            this.tsmicopyorderno.Size = new System.Drawing.Size(100, 22);
            this.tsmicopyorderno.Text = "单号";
            this.tsmicopyorderno.Click += new System.EventHandler(this.tsmicopyorderno_Click);
            // 
            // tsmicopyaddress
            // 
            this.tsmicopyaddress.Image = global::CatchOrderList.Properties.Resources.square_blueS;
            this.tsmicopyaddress.Name = "tsmicopyaddress";
            this.tsmicopyaddress.Size = new System.Drawing.Size(100, 22);
            this.tsmicopyaddress.Text = "地址";
            this.tsmicopyaddress.Click += new System.EventHandler(this.tsmicopyaddress_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.anpageinfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 336);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1015, 34);
            this.panel3.TabIndex = 5;
            // 
            // ilInfo
            // 
            this.ilInfo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilInfo.ImageStream")));
            this.ilInfo.TransparentColor = System.Drawing.Color.Transparent;
            this.ilInfo.Images.SetKeyName(0, "user2.gif");
            this.ilInfo.Images.SetKeyName(1, "user_green2.jpg");
            // 
            // anpageinfo
            // 
            this.anpageinfo.AutoSize = true;
            this.anpageinfo.BackColor = System.Drawing.SystemColors.Control;
            this.anpageinfo.BtnTextNext = "下页";
            this.anpageinfo.BtnTextPrevious = "上页";
            this.anpageinfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.anpageinfo.Enabled = false;
            this.anpageinfo.Location = new System.Drawing.Point(452, 0);
            this.anpageinfo.Name = "anpageinfo";
            this.anpageinfo.PageSize = 300;
            this.anpageinfo.RecordCount = 0;
            this.anpageinfo.Size = new System.Drawing.Size(563, 34);
            this.anpageinfo.TabIndex = 3;
            // 
            // NewSendOrderManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 476);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewSendOrderManagerForm";
            this.Text = "派件跟踪";
            this.Load += new System.EventHandler(this.OrderManagerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).EndInit();
            this.cmsShowInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ddlSaleMan;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ImageList ilInfo;
        private System.Windows.Forms.DateTimePicker dtpReciveDate;
        private System.Windows.Forms.CheckBox cbReciveDate;
        private uc_CatchInfo uc_CatchInfo1;
        private System.Windows.Forms.ContextMenuStrip cmsShowInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmicopyorderno;
        private System.Windows.Forms.ToolStripMenuItem tsmicopyaddress;
        private System.Windows.Forms.ToolStripSeparator ddToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbOrderState;
        private System.Windows.Forms.ComboBox cbCatchState;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Button btnQuickSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gvInfo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox cbChuidan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.CheckBox cbPoint;
        private System.Windows.Forms.CheckBox cbCheckCheck;
        private WinFormPager anpageinfo;
    }
}