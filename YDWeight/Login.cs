using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YDWeight
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("账号不能为空!","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("密码不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUserName.Text=="SPAdmin"&&txtPass.Text=="ydadmin123")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("账号密码错误，请重新确认账号和密码!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
