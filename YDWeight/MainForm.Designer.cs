namespace YDWeight
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电子秤参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收件扫描ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.收件查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收件员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统管理ToolStripMenuItem,
            this.电子秤参数设置ToolStripMenuItem,
            this.收件管理ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(735, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem,
            this.注销ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Image = global::YDWeight.Properties.Resources._132;
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.登录ToolStripMenuItem.Text = "登录";
            this.登录ToolStripMenuItem.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Visible = false;
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // 电子秤参数设置ToolStripMenuItem
            // 
            this.电子秤参数设置ToolStripMenuItem.Image = global::YDWeight.Properties.Resources.ooopic_1504752146;
            this.电子秤参数设置ToolStripMenuItem.Name = "电子秤参数设置ToolStripMenuItem";
            this.电子秤参数设置ToolStripMenuItem.Size = new System.Drawing.Size(120, 21);
            this.电子秤参数设置ToolStripMenuItem.Text = "电子秤参数设置";
            this.电子秤参数设置ToolStripMenuItem.Visible = false;
            this.电子秤参数设置ToolStripMenuItem.Click += new System.EventHandler(this.电子秤参数设置ToolStripMenuItem_Click);
            // 
            // 收件管理ToolStripMenuItem
            // 
            this.收件管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.收件扫描ToolStripMenuItem1,
            this.收件查询ToolStripMenuItem,
            this.收件员管理ToolStripMenuItem});
            this.收件管理ToolStripMenuItem.Image = global::YDWeight.Properties.Resources._130;
            this.收件管理ToolStripMenuItem.Name = "收件管理ToolStripMenuItem";
            this.收件管理ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.收件管理ToolStripMenuItem.Text = "称重管理";
            this.收件管理ToolStripMenuItem.Visible = false;
            // 
            // 收件扫描ToolStripMenuItem1
            // 
            this.收件扫描ToolStripMenuItem1.Name = "收件扫描ToolStripMenuItem1";
            this.收件扫描ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.收件扫描ToolStripMenuItem1.Text = "称重扫描";
            this.收件扫描ToolStripMenuItem1.Click += new System.EventHandler(this.收件扫描ToolStripMenuItem_Click);
            // 
            // 收件查询ToolStripMenuItem
            // 
            this.收件查询ToolStripMenuItem.Name = "收件查询ToolStripMenuItem";
            this.收件查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.收件查询ToolStripMenuItem.Text = "称重查询";
            this.收件查询ToolStripMenuItem.Click += new System.EventHandler(this.收件查询ToolStripMenuItem_Click);
            // 
            // 收件员管理ToolStripMenuItem
            // 
            this.收件员管理ToolStripMenuItem.Name = "收件员管理ToolStripMenuItem";
            this.收件员管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.收件员管理ToolStripMenuItem.Text = "收件员管理";
            this.收件员管理ToolStripMenuItem.Click += new System.EventHandler(this.收件员录入ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.关于ToolStripMenuItem.Text = "关于 V1.1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 418);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "收件称重扫描";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 电子秤参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收件管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收件扫描ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 收件员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收件查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}

