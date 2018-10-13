namespace CatchOrderList
{
    partial class OrderPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPageForm));
            this.uc_CatchInfo1 = new CatchOrderList.uc_CatchInfo();
            this.btnP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uc_CatchInfo1
            // 
            this.uc_CatchInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_CatchInfo1.Location = new System.Drawing.Point(0, 0);
            this.uc_CatchInfo1.Name = "uc_CatchInfo1";
            this.uc_CatchInfo1.Size = new System.Drawing.Size(779, 473);
            this.uc_CatchInfo1.TabIndex = 0;
            // 
            // btnP
            // 
            this.btnP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnP.Location = new System.Drawing.Point(636, 4);
            this.btnP.Name = "btnP";
            this.btnP.Size = new System.Drawing.Size(123, 32);
            this.btnP.TabIndex = 1;
            this.btnP.Text = "在浏览器中查看";
            this.btnP.UseVisualStyleBackColor = true;
            // 
            // OrderPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 473);
            this.Controls.Add(this.btnP);
            this.Controls.Add(this.uc_CatchInfo1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单详细页面";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderPageForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public uc_CatchInfo uc_CatchInfo1;
        private System.Windows.Forms.Button btnP;


    }
}