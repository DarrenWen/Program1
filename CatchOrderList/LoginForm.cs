using CatchOrderList.data;
using CatchOrderList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class LoginForm : Form
    {
        private LoginForm()
        {
            InitializeComponent();
            new Provider().AddKeyEnterEvent(this);
        }

        private static LoginForm thisForm;
        /// <summary>
        /// 对外窗体接口
        /// </summary>
        public static LoginForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new LoginForm();
                }
                return LoginForm.thisForm; }
            set { LoginForm.thisForm = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            List<Express.Model.Sys_User> models = new Express.BLL.Sys_User().GetModelList(string.Format(" username='{0}'", txtUserName.Text));
            if (models.Count <= 0)
            {
                MessageBox.Show("该账号系统不存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Express.Model.Sys_User model = models[0];
                if (model.pass == Express.Common.DEncrypt.DESEncrypt.Encrypt(txtPass.Text))
                {
                    if (model.UState == 0)
                    {
                        ClientInfo.Sys_UserInfo = model;
                        ClientInfo.SysSetInfo.AutoLogin = cbAutoLogin.Checked;
                        ClientInfo.SysSetInfo.RemPass = cbRemPass.Checked;
                        ClientInfo.SysSetInfo.UserName = txtUserName.Text;
                        ClientInfo.SysSetInfo.Pass = txtPass.Text;
                        ClientInfo.SysSetInfo = ClientInfo.SysSetInfo;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("该账号已经被禁用,不能用于系统登录!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("账号或密码输入有误!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            cbRemPass.Enabled = !cbAutoLogin.Checked;
            if(cbAutoLogin.Checked)
            {
                cbRemPass.Checked = cbAutoLogin.Checked;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            txtUserName.Text = ClientInfo.SysSetInfo.UserName;
            cbRemPass.Checked = ClientInfo.SysSetInfo.RemPass;
            cbAutoLogin.Checked = ClientInfo.SysSetInfo.AutoLogin;
            if(cbRemPass.Checked)
            {
                txtPass.Text = ClientInfo.SysSetInfo.Pass;
                
            }
            if(ClientInfo.SysSetInfo.AutoLogin)
            {
                Login();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
