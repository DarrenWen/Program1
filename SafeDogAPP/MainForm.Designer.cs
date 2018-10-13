namespace SafeDogAPP
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCheek = new System.Windows.Forms.Button();
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.btnReadContent = new System.Windows.Forms.Button();
            this.btnWriteSafeDog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCheek
            // 
            this.btnCheek.Location = new System.Drawing.Point(137, 357);
            this.btnCheek.Name = "btnCheek";
            this.btnCheek.Size = new System.Drawing.Size(87, 23);
            this.btnCheek.TabIndex = 0;
            this.btnCheek.Text = "加密狗初始化";
            this.btnCheek.UseVisualStyleBackColor = true;
            this.btnCheek.Click += new System.EventHandler(this.btnCheek_Click);
            // 
            // InfoBox
            // 
            this.InfoBox.Location = new System.Drawing.Point(12, 12);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(548, 325);
            this.InfoBox.TabIndex = 1;
            // 
            // btnReadContent
            // 
            this.btnReadContent.Location = new System.Drawing.Point(247, 357);
            this.btnReadContent.Name = "btnReadContent";
            this.btnReadContent.Size = new System.Drawing.Size(87, 23);
            this.btnReadContent.TabIndex = 0;
            this.btnReadContent.Text = "读加密狗内容";
            this.btnReadContent.UseVisualStyleBackColor = true;
            this.btnReadContent.Click += new System.EventHandler(this.btnReadContent_Click);
            // 
            // btnWriteSafeDog
            // 
            this.btnWriteSafeDog.Location = new System.Drawing.Point(358, 357);
            this.btnWriteSafeDog.Name = "btnWriteSafeDog";
            this.btnWriteSafeDog.Size = new System.Drawing.Size(87, 23);
            this.btnWriteSafeDog.TabIndex = 0;
            this.btnWriteSafeDog.Text = "写加密狗内容";
            this.btnWriteSafeDog.UseVisualStyleBackColor = true;
            this.btnWriteSafeDog.Click += new System.EventHandler(this.btnWriteSafeDog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 392);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.btnWriteSafeDog);
            this.Controls.Add(this.btnReadContent);
            this.Controls.Add(this.btnCheek);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Darren 软件加密狗专用程序";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheek;
        private System.Windows.Forms.TextBox InfoBox;
        private System.Windows.Forms.Button btnReadContent;
        private System.Windows.Forms.Button btnWriteSafeDog;
    }
}

