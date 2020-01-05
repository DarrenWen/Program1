

using Tony.Controls.Winform;

namespace CatchOrderList
{
    partial class OrderManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbnoWeight = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbReturn = new System.Windows.Forms.CheckBox();
            this.cbMessageState = new System.Windows.Forms.ComboBox();
            this.cbCheckCheck = new System.Windows.Forms.CheckBox();
            this.cbPoint = new System.Windows.Forms.CheckBox();
            this.cbChuidan = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.cbCatchState = new System.Windows.Forms.ComboBox();
            this.lbl01 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvCustomer = new System.Windows.Forms.TreeView();
            this.ilInfo = new System.Windows.Forms.ImageList(this.components);
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
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsShowInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddRemark = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmicopyorderno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmicopyaddress = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMSG = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiopenimage = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTip = new System.Windows.Forms.Label();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.anpageinfo = new Tony.Controls.Winform.WinFormPager();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).BeginInit();
            this.cmsShowInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbnoWeight);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbReturn);
            this.panel1.Controls.Add(this.cbMessageState);
            this.panel1.Controls.Add(this.cbCheckCheck);
            this.panel1.Controls.Add(this.cbPoint);
            this.panel1.Controls.Add(this.cbChuidan);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.cbCatchState);
            this.panel1.Controls.Add(this.lbl01);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEnd);
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
            this.panel1.Size = new System.Drawing.Size(1200, 77);
            this.panel1.TabIndex = 0;
            // 
            // cbnoWeight
            // 
            this.cbnoWeight.AutoSize = true;
            this.cbnoWeight.ForeColor = System.Drawing.Color.Red;
            this.cbnoWeight.Location = new System.Drawing.Point(776, 13);
            this.cbnoWeight.Name = "cbnoWeight";
            this.cbnoWeight.Size = new System.Drawing.Size(108, 16);
            this.cbnoWeight.TabIndex = 24;
            this.cbnoWeight.Text = "不跳过没有重量";
            this.cbnoWeight.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(928, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 66);
            this.button1.TabIndex = 23;
            this.button1.Text = "快速查单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbReturn
            // 
            this.cbReturn.AutoSize = true;
            this.cbReturn.ForeColor = System.Drawing.Color.Red;
            this.cbReturn.Location = new System.Drawing.Point(776, 47);
            this.cbReturn.Name = "cbReturn";
            this.cbReturn.Size = new System.Drawing.Size(60, 16);
            this.cbReturn.TabIndex = 22;
            this.cbReturn.Text = "退回件";
            this.cbReturn.UseVisualStyleBackColor = true;
            // 
            // cbMessageState
            // 
            this.cbMessageState.FormattingEnabled = true;
            this.cbMessageState.Items.AddRange(new object[] {
            "==留言信息==",
            "有留言",
            "无留言"});
            this.cbMessageState.Location = new System.Drawing.Point(656, 43);
            this.cbMessageState.Name = "cbMessageState";
            this.cbMessageState.Size = new System.Drawing.Size(101, 20);
            this.cbMessageState.TabIndex = 20;
            // 
            // cbCheckCheck
            // 
            this.cbCheckCheck.AutoSize = true;
            this.cbCheckCheck.ForeColor = System.Drawing.Color.Red;
            this.cbCheckCheck.Location = new System.Drawing.Point(661, 14);
            this.cbCheckCheck.Name = "cbCheckCheck";
            this.cbCheckCheck.Size = new System.Drawing.Size(96, 16);
            this.cbCheckCheck.TabIndex = 19;
            this.cbCheckCheck.Text = "不跳过已签收";
            this.cbCheckCheck.UseVisualStyleBackColor = true;
            // 
            // cbPoint
            // 
            this.cbPoint.AutoSize = true;
            this.cbPoint.ForeColor = System.Drawing.Color.Red;
            this.cbPoint.Location = new System.Drawing.Point(582, 15);
            this.cbPoint.Name = "cbPoint";
            this.cbPoint.Size = new System.Drawing.Size(72, 16);
            this.cbPoint.TabIndex = 18;
            this.cbPoint.Text = "单号定位";
            this.cbPoint.UseVisualStyleBackColor = true;
            this.cbPoint.CheckedChanged += new System.EventHandler(this.cbPoint_CheckedChanged);
            // 
            // cbChuidan
            // 
            this.cbChuidan.AutoSize = true;
            this.cbChuidan.ForeColor = System.Drawing.Color.Red;
            this.cbChuidan.Location = new System.Drawing.Point(582, 49);
            this.cbChuidan.Name = "cbChuidan";
            this.cbChuidan.Size = new System.Drawing.Size(72, 16);
            this.cbChuidan.TabIndex = 15;
            this.cbChuidan.Text = "需要催单";
            this.cbChuidan.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1116, 47);
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
            "需要催单件",
            "未称重"});
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(414, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "至";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "订单状态:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "业务员:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(448, 45);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(121, 21);
            this.dtpEnd.TabIndex = 6;
            // 
            // dtpReciveDate
            // 
            this.dtpReciveDate.Location = new System.Drawing.Point(275, 46);
            this.dtpReciveDate.Name = "dtpReciveDate";
            this.dtpReciveDate.Size = new System.Drawing.Size(121, 21);
            this.dtpReciveDate.TabIndex = 6;
            // 
            // cbReciveDate
            // 
            this.cbReciveDate.AutoSize = true;
            this.cbReciveDate.Checked = true;
            this.cbReciveDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReciveDate.Location = new System.Drawing.Point(199, 51);
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
            this.btnImport.Location = new System.Drawing.Point(1116, 6);
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
            this.btnQuickSearch.Location = new System.Drawing.Point(1023, 46);
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
            this.btnSearch.Location = new System.Drawing.Point(1023, 6);
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
            "未处理",
            "无物流信息",
            "漏件补收"});
            this.cbOrderState.Location = new System.Drawing.Point(465, 12);
            this.cbOrderState.Name = "cbOrderState";
            this.cbOrderState.Size = new System.Drawing.Size(104, 20);
            this.cbOrderState.TabIndex = 2;
            // 
            // ddlSaleMan
            // 
            this.ddlSaleMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSaleMan.FormattingEnabled = true;
            this.ddlSaleMan.Location = new System.Drawing.Point(250, 12);
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
            this.panel2.Size = new System.Drawing.Size(1200, 543);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 543);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "单号列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvCustomer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvInfo);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1186, 511);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvCustomer
            // 
            this.tvCustomer.CheckBoxes = true;
            this.tvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCustomer.ImageIndex = 0;
            this.tvCustomer.ImageList = this.ilInfo;
            this.tvCustomer.Location = new System.Drawing.Point(0, 0);
            this.tvCustomer.Name = "tvCustomer";
            this.tvCustomer.SelectedImageIndex = 0;
            this.tvCustomer.Size = new System.Drawing.Size(213, 511);
            this.tvCustomer.TabIndex = 0;
            this.tvCustomer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvCustomer_AfterCheck);
            // 
            // ilInfo
            // 
            this.ilInfo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilInfo.ImageStream")));
            this.ilInfo.TransparentColor = System.Drawing.Color.Transparent;
            this.ilInfo.Images.SetKeyName(0, "user2.gif");
            this.ilInfo.Images.SetKeyName(1, "user_green2.jpg");
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
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column32,
            this.Column30,
            this.Column31,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28,
            this.Column29,
            this.Column33,
            this.Column34});
            this.gvInfo.ContextMenuStrip = this.cmsShowInfo;
            this.gvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvInfo.Location = new System.Drawing.Point(0, 0);
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
            this.gvInfo.Size = new System.Drawing.Size(969, 481);
            this.gvInfo.TabIndex = 3;
            this.gvInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInfo_CellContentDoubleClick);
            this.gvInfo.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvInfo_CellMouseDown);
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
            this.Column2.HeaderText = "收件日";
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
            // 
            // Column8
            // 
            this.Column8.HeaderText = "收件人";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "收件人电话";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
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
            this.Column13.HeaderText = "派件人电话";
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
            this.Column17.Visible = false;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "催单状态";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Visible = false;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "揽件公司编码";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Visible = false;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "用户备注";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "延误天数";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "揽件人员";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Visible = false;
            // 
            // Column23
            // 
            this.Column23.HeaderText = "退回件？";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            // 
            // Column24
            // 
            this.Column24.HeaderText = "重量";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            // 
            // Column32
            // 
            this.Column32.HeaderText = "订单来源";
            this.Column32.Name = "Column32";
            this.Column32.ReadOnly = true;
            // 
            // Column30
            // 
            this.Column30.HeaderText = "所属分部";
            this.Column30.Name = "Column30";
            this.Column30.ReadOnly = true;
            // 
            // Column31
            // 
            this.Column31.HeaderText = "分部编码";
            this.Column31.Name = "Column31";
            this.Column31.ReadOnly = true;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "分配给的客户";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            // 
            // Column26
            // 
            this.Column26.HeaderText = "三段码信息";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            // 
            // Column27
            // 
            this.Column27.HeaderText = "分拨中心";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            // 
            // Column28
            // 
            this.Column28.HeaderText = "公司";
            this.Column28.Name = "Column28";
            this.Column28.ReadOnly = true;
            // 
            // Column29
            // 
            this.Column29.HeaderText = "分部";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            // 
            // Column33
            // 
            this.Column33.HeaderText = "分拨中心编号";
            this.Column33.Name = "Column33";
            this.Column33.ReadOnly = true;
            // 
            // Column34
            // 
            this.Column34.HeaderText = "分公司编号";
            this.Column34.Name = "Column34";
            this.Column34.ReadOnly = true;
            // 
            // cmsShowInfo
            // 
            this.cmsShowInfo.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsShowInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tsmiUpdateDate,
            this.tsmiDel,
            this.ddToolStripMenuItem,
            this.tsmiAddRemark,
            this.复制ToolStripMenuItem,
            this.tsmiMSG,
            this.tsmiopenimage});
            this.cmsShowInfo.Name = "contextMenuStrip1";
            this.cmsShowInfo.Size = new System.Drawing.Size(125, 164);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Image = global::CatchOrderList.Properties.Resources.pf;
            this.tsmiUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(124, 22);
            this.tsmiUpdate.Text = "修改客户";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiUpdateDate
            // 
            this.tsmiUpdateDate.Image = global::CatchOrderList.Properties.Resources.design;
            this.tsmiUpdateDate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiUpdateDate.Name = "tsmiUpdateDate";
            this.tsmiUpdateDate.Size = new System.Drawing.Size(124, 22);
            this.tsmiUpdateDate.Text = "修改日期";
            this.tsmiUpdateDate.Click += new System.EventHandler(this.tsmiUpdateDate_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Image = global::CatchOrderList.Properties.Resources.wrong;
            this.tsmiDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            // tsmiAddRemark
            // 
            this.tsmiAddRemark.Image = global::CatchOrderList.Properties.Resources.columns;
            this.tsmiAddRemark.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiAddRemark.Name = "tsmiAddRemark";
            this.tsmiAddRemark.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddRemark.Text = "添加备注";
            this.tsmiAddRemark.Click += new System.EventHandler(this.tsmiAddRemark_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmicopyorderno,
            this.tsmicopyaddress});
            this.复制ToolStripMenuItem.Image = global::CatchOrderList.Properties.Resources.doc2;
            this.复制ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Visible = false;
            // 
            // tsmicopyorderno
            // 
            this.tsmicopyorderno.Image = global::CatchOrderList.Properties.Resources.square_blueS;
            this.tsmicopyorderno.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmicopyorderno.Name = "tsmicopyorderno";
            this.tsmicopyorderno.Size = new System.Drawing.Size(100, 22);
            this.tsmicopyorderno.Text = "单号";
            this.tsmicopyorderno.Click += new System.EventHandler(this.tsmicopyorderno_Click);
            // 
            // tsmicopyaddress
            // 
            this.tsmicopyaddress.Image = global::CatchOrderList.Properties.Resources.square_blueS;
            this.tsmicopyaddress.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmicopyaddress.Name = "tsmicopyaddress";
            this.tsmicopyaddress.Size = new System.Drawing.Size(100, 22);
            this.tsmicopyaddress.Text = "地址";
            this.tsmicopyaddress.Click += new System.EventHandler(this.tsmicopyaddress_Click);
            // 
            // tsmiMSG
            // 
            this.tsmiMSG.Image = global::CatchOrderList.Properties.Resources.comment;
            this.tsmiMSG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiMSG.Name = "tsmiMSG";
            this.tsmiMSG.Size = new System.Drawing.Size(124, 22);
            this.tsmiMSG.Text = "留言信息";
            this.tsmiMSG.Click += new System.EventHandler(this.tsmiMSG_Click);
            // 
            // tsmiopenimage
            // 
            this.tsmiopenimage.Image = global::CatchOrderList.Properties.Resources.folderopen;
            this.tsmiopenimage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiopenimage.Name = "tsmiopenimage";
            this.tsmiopenimage.Size = new System.Drawing.Size(124, 22);
            this.tsmiopenimage.Text = "单号图片";
            this.tsmiopenimage.Click += new System.EventHandler(this.tsmiopenimage_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTip);
            this.panel4.Controls.Add(this.pbTotal);
            this.panel4.Controls.Add(this.anpageinfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 481);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(969, 30);
            this.panel4.TabIndex = 0;
            // 
            // lblTip
            // 
            this.lblTip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(159, 4);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(100, 23);
            this.lblTip.TabIndex = 3;
            this.lblTip.Text = "0/0";
            this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTotal
            // 
            this.pbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTotal.Location = new System.Drawing.Point(0, 0);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(406, 30);
            this.pbTotal.TabIndex = 2;
            // 
            // anpageinfo
            // 
            this.anpageinfo.AutoSize = true;
            this.anpageinfo.BackColor = System.Drawing.SystemColors.Control;
            this.anpageinfo.BtnTextNext = "下页";
            this.anpageinfo.BtnTextPrevious = "上页";
            this.anpageinfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.anpageinfo.Location = new System.Drawing.Point(406, 0);
            this.anpageinfo.Margin = new System.Windows.Forms.Padding(6);
            this.anpageinfo.Name = "anpageinfo";
            this.anpageinfo.PageSize = 300;
            this.anpageinfo.RecordCount = 0;
            this.anpageinfo.Size = new System.Drawing.Size(563, 30);
            this.anpageinfo.TabIndex = 2;
            this.anpageinfo.PageIndexChanged += new Tony.Controls.Winform.WinFormPager.EventHandler(this.anpageinfo_PageIndexChanged);
            // 
            // OrderManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 620);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderManagerForm";
            this.Text = "收件跟踪";
            this.Load += new System.EventHandler(this.OrderManagerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).EndInit();
            this.cmsShowInfo.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvCustomer;
        private System.Windows.Forms.ComboBox ddlSaleMan;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gvInfo;
        private System.Windows.Forms.ImageList ilInfo;
        private System.Windows.Forms.DateTimePicker dtpReciveDate;
        private System.Windows.Forms.CheckBox cbReciveDate;
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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbChuidan;
        private System.Windows.Forms.CheckBox cbPoint;
        private System.Windows.Forms.CheckBox cbCheckCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddRemark;
        private System.Windows.Forms.ToolStripMenuItem tsmiMSG;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.ToolStripMenuItem tsmiopenimage;
        private System.Windows.Forms.ComboBox cbMessageState;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.CheckBox cbReturn;
        private System.Windows.Forms.Button button1;
        private WinFormPager anpageinfo;
        private System.Windows.Forms.CheckBox cbnoWeight;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column34;
    }
}