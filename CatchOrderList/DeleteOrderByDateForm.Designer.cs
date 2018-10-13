namespace CatchOrderList
{
    partial class DeleteOrderByDateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteOrderByDateForm));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpReciveDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbS = new System.Windows.Forms.CheckBox();
            this.cbR = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOrderState = new System.Windows.Forms.ComboBox();
            this.ddlCustomer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCatchState = new System.Windows.Forms.ComboBox();
            this.lbl01 = new System.Windows.Forms.Label();
            this.cblError = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(77, 116);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(218, 21);
            this.dtpEnd.TabIndex = 7;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpReciveDate
            // 
            this.dtpReciveDate.Location = new System.Drawing.Point(77, 65);
            this.dtpReciveDate.Name = "dtpReciveDate";
            this.dtpReciveDate.Size = new System.Drawing.Size(218, 21);
            this.dtpReciveDate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "开始时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "结束时间:";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(117, 350);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(75, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "提示:删除操作以录单时间为主";
            // 
            // cbS
            // 
            this.cbS.AutoSize = true;
            this.cbS.Enabled = false;
            this.cbS.Location = new System.Drawing.Point(144, 37);
            this.cbS.Name = "cbS";
            this.cbS.Size = new System.Drawing.Size(48, 16);
            this.cbS.TabIndex = 12;
            this.cbS.Text = "派件";
            this.cbS.UseVisualStyleBackColor = true;
            // 
            // cbR
            // 
            this.cbR.AutoSize = true;
            this.cbR.Checked = true;
            this.cbR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbR.Location = new System.Drawing.Point(77, 37);
            this.cbR.Name = "cbR";
            this.cbR.Size = new System.Drawing.Size(48, 16);
            this.cbR.TabIndex = 12;
            this.cbR.Text = "收件";
            this.cbR.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "删除类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "订单状态:";
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
            "无物流信息"});
            this.cbOrderState.Location = new System.Drawing.Point(77, 159);
            this.cbOrderState.Name = "cbOrderState";
            this.cbOrderState.Size = new System.Drawing.Size(218, 20);
            this.cbOrderState.TabIndex = 13;
            // 
            // ddlCustomer
            // 
            this.ddlCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCustomer.FormattingEnabled = true;
            this.ddlCustomer.Location = new System.Drawing.Point(77, 199);
            this.ddlCustomer.Name = "ddlCustomer";
            this.ddlCustomer.Size = new System.Drawing.Size(218, 20);
            this.ddlCustomer.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "客户名称:";
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
            this.cbCatchState.Location = new System.Drawing.Point(77, 235);
            this.cbCatchState.Name = "cbCatchState";
            this.cbCatchState.Size = new System.Drawing.Size(218, 20);
            this.cbCatchState.TabIndex = 17;
            // 
            // lbl01
            // 
            this.lbl01.AutoSize = true;
            this.lbl01.Location = new System.Drawing.Point(13, 238);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(59, 12);
            this.lbl01.TabIndex = 16;
            this.lbl01.Text = "跟单状态:";
            // 
            // cblError
            // 
            this.cblError.FormattingEnabled = true;
            this.cblError.Items.AddRange(new object[] {
            "同城件",
            "集包错误",
            "不同分部",
            "不同公司"});
            this.cblError.Location = new System.Drawing.Point(77, 261);
            this.cblError.Name = "cblError";
            this.cblError.Size = new System.Drawing.Size(218, 68);
            this.cblError.TabIndex = 22;
            // 
            // DeleteOrderByDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 393);
            this.Controls.Add(this.cblError);
            this.Controls.Add(this.cbCatchState);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.ddlCustomer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbOrderState);
            this.Controls.Add(this.cbR);
            this.Controls.Add(this.cbS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpReciveDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeleteOrderByDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "删除单号信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpReciveDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbS;
        private System.Windows.Forms.CheckBox cbR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbOrderState;
        private System.Windows.Forms.ComboBox ddlCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCatchState;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.CheckedListBox cblError;
    }
}