using CatchOrderList.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class DataFormatForm : Form
    {
        private DataFormatForm()
        {
            InitializeComponent();
        }

        private static DataFormatForm thisForm;

        public static DataFormatForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new DataFormatForm();
                }
                return DataFormatForm.thisForm; }
            set { DataFormatForm.thisForm = value; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ClientInfo.Sys_UserInfo.username.ToLower() == "admin")
            {
                if (ClientInfo.Sys_UserInfo.pass == Express.Common.DEncrypt.DESEncrypt.Encrypt(txtPass.Text))
                {
                    try
                    {
                        string path = SaveFile();
                        if (!string.IsNullOrEmpty(path))
                        {
                            if (Express.Common.AccessManager.Backup(Application.StartupPath + @"\\dbms.datb", path))
                            {
                                string msg = new Express.BLL.SysSetInfo().FormateData(Power)?"格式化数据成功!":"格式化数据失败";
                                MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Express.Model.CustomerInfo model = new Express.Model.CustomerInfo();
                                model.Address = "无";
                                model.contactperson = "无";
                                model.contactphone = "88888888";
                                model.CState = 0;
                                model.cusname = "系统默认";
                                model.departmentname = "系统默认";
                                model.OperUser3 = ClientInfo.Sys_UserInfo.username;
                                model.Remark = "";
                                model.UserDate3 = DateTime.Now;

                                new Express.BLL.CustomerInfo().Add(model);
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("备份数据库失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("密码输入有误，请重新输入密码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("你不能进行该操作，该操作只能超级管理员可以进行操作！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private string Power
        {
            get
            {
                string data = "";
                data += cbUser.Checked ? "1" : "0";
                data += cbSet.Checked ? "1" : "0";
                data += cbCus.Checked ? "1" : "0";
                data += cbOrder.Checked ? "1" : "0";
                data += cbSendOrder.Checked ? "1" : "0";
                return data;
            }
        }

        public string SaveFile()
        {
            SaveFileDialog opd = new SaveFileDialog();
            opd.Filter = @"数据库文件(*.datb)|*.datb";
            opd.FilterIndex = 1;
            opd.InitialDirectory = Application.StartupPath;
            opd.FileName = string.Format("快递数据备份({0})", DateTime.Now.ToFileTime());
            DialogResult result = opd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return opd.FileName;
            }
            return String.Empty;
        }

        private void cbCus_CheckedChanged(object sender, EventArgs e)
        {
            cbOrder.Checked = cbSendOrder.Checked = cbCus.Checked;
            cbSendOrder.Enabled = cbOrder.Enabled = !cbCus.Checked;
        }
    }
}
