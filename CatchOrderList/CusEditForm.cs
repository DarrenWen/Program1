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
    public partial class CusEditForm : Form
    {
        public CusEditForm()
        {
            InitializeComponent();
            cbCstate.SelectedIndex = 0;
            new Provider().AddKeyEnterEvent(this);
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="id"></param>
        public CusEditForm(int id)
        {
            InitializeComponent();
            cbCstate.SelectedIndex = 0;
            new Provider().AddKeyEnterEvent(this);
            this.Text = "修改客户信息";
            btnOK.Tag = id;
            Express.Model.CustomerInfo info = new Express.BLL.CustomerInfo().GetModel(id);
            if (null == info)
            {
                MessageBox.Show("该客户信息已经不存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                txtAddress.Text = info.Address;
                txtContractTel.Text = info.contactphone;
                txtContractUser.Text = info.contactperson;
                txtCusName.Text = info.cusname;
                txtOrgName.Text = info.departmentname;
                txtRemark.Text = info.Remark;
                cbCstate.SelectedIndex = info.CState.Value;
                btnCancel.Tag = txtCusName.Text;//保存原始的客户简称
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckUserInput())
            {
                Express.Model.CustomerInfo model = new Express.Model.CustomerInfo();
                model.Address = txtAddress.Text;
                model.contactperson = txtContractUser.Text;
                model.contactphone = txtContractTel.Text;
                model.CState = cbCstate.SelectedIndex;
                model.cusname = txtCusName.Text;
                model.departmentname = txtOrgName.Text;
                model.OperUser3 = ClientInfo.Sys_UserInfo.username;
                model.Remark = txtRemark.Text;
                model.UserDate3 = DateTime.Now;
                string msg = "";
                if (null == btnOK.Tag)
                {
                    bool isSuc = new Express.BLL.CustomerInfo().Add(model);
                    msg = isSuc ? "添加客户信息成功!" : "添加客户信息失败!";
                }
                else
                {
                    model.cid = Convert.ToInt32(btnOK.Tag);
                    bool isSuc = new Express.BLL.CustomerInfo().Update(model);
                    msg = isSuc ? "修改客户信息成功!" : "修改客户信息失败!";
                }
                MessageBox.Show(msg,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool CheckUserInput()
        {
            bool isValidate = true;
            string errorMsg = "";
            TextBox txtTarget = txtCusName;
            if(string.IsNullOrEmpty(txtCusName.Text)||txtCusName.Text.Length<1)
            {
                isValidate = false;
                errorMsg = "请输入客户名称!";
                txtTarget = txtCusName;
            }
            else if (string.IsNullOrEmpty(txtOrgName.Text))
            {
                isValidate = false;
                errorMsg = "请输入单位名称!";
                txtTarget = txtOrgName;
            }
            else
            {
                if (null == btnOK.Tag || (btnOK.Tag != null && btnCancel.Tag.ToString() != txtCusName.Text))
                {
                    if (new Express.BLL.CustomerInfo().GetRecordCount(" cusname='" + txtCusName.Text + "'") > 0)
                    {
                        isValidate = false;
                        errorMsg = "该客户名称已经存在!";
                        txtTarget = txtCusName;
                    }
                }
            }
            if(!isValidate)
            {
                txtTarget.Focus();
                MessageBox.Show(errorMsg,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isValidate;
        }
    }
}
