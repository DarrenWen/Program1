namespace CatchOrderList
{
    partial class DataFormatForm
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
            this.cbUser = new System.Windows.Forms.CheckBox();
            this.cbSet = new System.Windows.Forms.CheckBox();
            this.cbCus = new System.Windows.Forms.CheckBox();
            this.cbOrder = new System.Windows.Forms.CheckBox();
            this.cbSendOrder = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbUser
            // 
            this.cbUser.AutoSize = true;
            this.cbUser.Location = new System.Drawing.Point(33, 29);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(72, 16);
            this.cbUser.TabIndex = 0;
            this.cbUser.Text = "系统用户";
            this.cbUser.UseVisualStyleBackColor = true;
            // 
            // cbSet
            // 
            this.cbSet.AutoSize = true;
            this.cbSet.Location = new System.Drawing.Point(120, 29);
            this.cbSet.Name = "cbSet";
            this.cbSet.Size = new System.Drawing.Size(72, 16);
            this.cbSet.TabIndex = 0;
            this.cbSet.Text = "配置信息";
            this.cbSet.UseVisualStyleBackColor = true;
            // 
            // cbCus
            // 
            this.cbCus.AutoSize = true;
            this.cbCus.Location = new System.Drawing.Point(33, 65);
            this.cbCus.Name = "cbCus";
            this.cbCus.Size = new System.Drawing.Size(72, 16);
            this.cbCus.TabIndex = 1;
            this.cbCus.Text = "客户信息";
            this.cbCus.UseVisualStyleBackColor = true;
            this.cbCus.CheckedChanged += new System.EventHandler(this.cbCus_CheckedChanged);
            // 
            // cbOrder
            // 
            this.cbOrder.AutoSize = true;
            this.cbOrder.Location = new System.Drawing.Point(120, 65);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(72, 16);
            this.cbOrder.TabIndex = 2;
            this.cbOrder.Text = "订单信息";
            this.cbOrder.UseVisualStyleBackColor = true;
            this.cbOrder.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // cbSendOrder
            // 
            this.cbSendOrder.AutoSize = true;
            this.cbSendOrder.Location = new System.Drawing.Point(212, 65);
            this.cbSendOrder.Name = "cbSendOrder";
            this.cbSendOrder.Size = new System.Drawing.Size(72, 16);
            this.cbSendOrder.TabIndex = 3;
            this.cbSendOrder.Text = "派单信息";
            this.cbSendOrder.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(114, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(104, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "初始化";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(95, 98);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(189, 21);
            this.txtPass.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "初始密码:";
            // 
            // DataFormatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbSendOrder);
            this.Controls.Add(this.cbOrder);
            this.Controls.Add(this.cbCus);
            this.Controls.Add(this.cbSet);
            this.Controls.Add(this.cbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataFormatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据初始化";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbUser;
        private System.Windows.Forms.CheckBox cbSet;
        private System.Windows.Forms.CheckBox cbCus;
        private System.Windows.Forms.CheckBox cbOrder;
        private System.Windows.Forms.CheckBox cbSendOrder;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
    }
}