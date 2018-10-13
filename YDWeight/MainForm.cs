using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YDWeight
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void 电子秤参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Config().ShowDialog();
        }

        private void 收件员录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Employee();
            form.MdiParent = this;
            form.Show();
        }

        private void 收件扫描ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrderScan();
            form.MdiParent = this;
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginAc();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginAc();
        }

        private void LoginAc()
        {
            if (new Login().ShowDialog() == DialogResult.OK)
            {
                电子秤参数设置ToolStripMenuItem.Visible = true;
                收件管理ToolStripMenuItem.Visible = true;
                登录ToolStripMenuItem.Visible = false;
                注销ToolStripMenuItem.Visible = true;
            }
        }

        private void 收件查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm();
            form.MdiParent = this;
            form.Show();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            电子秤参数设置ToolStripMenuItem.Visible = false;
            收件管理ToolStripMenuItem.Visible = false;
            登录ToolStripMenuItem.Visible = true;
            注销ToolStripMenuItem.Visible = false;
        }
    }
}
