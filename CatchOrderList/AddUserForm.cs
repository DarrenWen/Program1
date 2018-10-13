using CatchOrderList.data;
using CatchOrderList.Data;
using Express.Common.DEncrypt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class AddUserForm : Form
    {
        private AddUserForm()
        {
            InitializeComponent();
            cbState.SelectedIndex = 0;
            new Provider().AddKeyEnterEvent(this);
        }

        private static AddUserForm thisForm;
        /// <summary>
        /// 
        /// </summary>
        public static AddUserForm ThisForm
        {
            get { 
                if(null== thisForm|| thisForm.IsDisposed)
                {
                    thisForm = new AddUserForm();
                }
                return AddUserForm.thisForm; }
            set { AddUserForm.thisForm = value; }
        }


        /// <summary>
        /// 注册账号信息
        /// </summary>
        public void ShowRegistInfo()
        {
            this.Text = "注册用户账号";
            btnResetPass.Visible = false;
            txtUserName.Text = "";
            txtUserName.Enabled = true;
            cbState.Enabled = true;
            groupBox2.Enabled = true;
        }

        public void ShowUpdateInfo(int uid)
        {
            Express.Model.Sys_User model = new Express.BLL.Sys_User().GetModel(uid);
            if (null == model)
            {
                MessageBox.Show("该账号已经不存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.Text = "修改账号信息";
                btnResetPass.Visible = true;
                 txtUserName.Enabled = false;
                 txtUserName.Text = model.username;
                 txtPass.Text = DESEncrypt.Decrypt(model.pass);
                 txtRepass.Text = txtPass.Text;
                 cb01.Checked = model.issaleman;
                 cb02.Checked = model.isclerk;
                 cb03.Checked = model.isfinance;
                 if (model.username.ToLower() == "admin")
                 {
                     cbState.Enabled = false;
                     groupBox2.Enabled = false;
                 }
                 else
                 {
                     cbState.Enabled = true;
                     groupBox2.Enabled = true;
                 }
                 cb04.Checked = model.isadmin;
                 cbState.SelectedIndex = model.UState.Value;
                txtPerName.Text = model.PerName;
                btnResetPass.Tag = model.UID;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                Express.Model.Sys_User model = new Express.Model.Sys_User();
                model.isadmin = cb04.Checked;
                model.isclerk = cb02.Checked;
                model.isfinance = cb03.Checked;
                model.issaleman = cb01.Checked;
                model.OperUser4 = ClientInfo.Sys_UserInfo.username;
                model.pass = DESEncrypt.Encrypt(txtPass.Text);
                model.PerName = txtPerName.Text;
                model.UserDate4 = DateTime.Now;
                model.username = txtUserName.Text;
                model.UState = cbState.SelectedIndex;
                string msg = "";
                if (!btnResetPass.Visible)
                {
                    bool result = new Express.BLL.Sys_User().Add(model);
                     msg = result ? "添加账户信息成功!" : "添加账户信息失败!";
                }
                else
                {
                    model.UID = Convert.ToInt32(btnResetPass.Tag);
                    bool result = new Express.BLL.Sys_User().Update(model);
                    msg = result ? "修改账户信息成功!" : "修改账户信息失败!";
                }
                
                MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }


        private bool ValidateUserInput()
        {
            bool isValidate = true;
            string errormsg = "";
            TextBox txtTarget = txtUserName;
            if(string.IsNullOrEmpty(txtUserName.Text)||txtUserName.Text.Length<=2)
            {
                errormsg = "用户账号不能少于3个字符!";
                txtTarget = txtUserName;
                isValidate = false;
            }
            else if (txtPass.Text != txtRepass.Text)
            {
                errormsg = "两次密码输入不一致，请重新输入!";
                txtTarget = txtRepass;
                isValidate = false;
            }
            else
            {
                if(!btnResetPass.Visible)
                {
                    if (new Express.BLL.Sys_User().GetRecordCount(" username='" + txtUserName.Text + "'") > 0)
                    {
                        errormsg = "该账号已经存在，请更换其他账号!";
                        txtTarget = txtUserName;
                        isValidate = false;
                    }
                }
            }
            if(!isValidate)
            {
                txtTarget.Focus();
                MessageBox.Show(errormsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isValidate;
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要将该账号密码置空吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                Express.Model.Sys_User mondel = new Express.BLL.Sys_User().GetModel(Convert.ToInt32(btnResetPass.Tag));
                if (null != mondel)
                {
                    mondel.pass = DESEncrypt.Encrypt("");
                    bool result = new Express.BLL.Sys_User().Update(mondel);
                    string msg = result ? "密码已经成功置空!" : "修改账户信息失败!";
                    MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("该账号信息以及不存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }

        }
    }
}
