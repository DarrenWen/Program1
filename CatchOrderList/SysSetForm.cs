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
    public partial class SysSetForm : Form
    {
        private SysSetForm()
        {
            InitializeComponent();
        }

        private static SysSetForm thisForm;

        public static SysSetForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new SysSetForm();
                }
                return SysSetForm.thisForm; }
        }

        private void SysSetForm_Load(object sender, EventArgs e)
        {
            cbAutoLogin.Checked = ClientInfo.SysSetInfo.AutoLogin;
            nrate.Value = ClientInfo.SysSetInfo.RRate.Value;
            nintervel.Value = ClientInfo.SysSetInfo.RInterver.Value;
            npage.Value = ClientInfo.SysSetInfo.PageSize.Value;

            txtOp1.Text = ClientInfo.SysSetInfo.Paream0;
            txtOp2.Text = ClientInfo.SysSetInfo.Paream1;
            txtpage.Text = ClientInfo.SysSetInfo.PageUrl;
            cbAutoLogin.Checked = Power[100] == "1" ? true : false;
            cbAutoCheck.Checked = Power[1] == "1" ? true : false;
            cbReadP.Checked = Power[0] == "1" ? true : false;
            cbSpeedImport.Checked = Power[2] == "1" ? true : false;
            cbOrderVali.Checked = Power[3] == "1" ? true : false;
            cbDate.Checked = Power[4] == "1" ? true : false;
            txtCusName.Text = ClientInfo.SysSetInfo.cusname;
            pnlVIP.Enabled = UserValidation.IsRegister;
            txtzcAccount.Text = ClientInfo.SysSetInfo.Paream3;
            txtzcpass.Text = ClientInfo.SysSetInfo.Paream4;
            txtimagepath.Text = ClientInfo.SysSetInfo.Paream5;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ClientInfo.SysSetInfo.AutoLogin = cbAutoLogin.Checked;
            ClientInfo.SysSetInfo.PageSize = (int)npage.Value;
            ClientInfo.SysSetInfo.PageUrl = txtpage.Text;
            ClientInfo.SysSetInfo.Paream0 = txtOp1.Text;
            ClientInfo.SysSetInfo.Paream1 = txtOp2.Text;
            ClientInfo.SysSetInfo.RRate = (int)nrate.Value;
            ClientInfo.SysSetInfo.RInterver = (int)nintervel.Value;
            ClientInfo.SysSetInfo.cusname = txtCusName.Text;
            ClientInfo.SysSetInfo.Paream3 = txtzcAccount.Text;
            ClientInfo.SysSetInfo.Paream4 = txtzcpass.Text;
            ClientInfo.SysSetInfo.Paream5 = txtimagepath.Text;

            Power[0] = cbReadP.Checked ? "1" : "0";
            Power[1] = cbAutoCheck.Checked ? "1" : "0";
            Power[2] = cbSpeedImport.Checked ? "1" : "0";
            Power[3] =cbOrderVali.Checked ? "1" : "0";
            Power[4] = cbDate.Checked ? "1" : "0";
            Power[100] = cbAutoLogin.Checked ? "1" : "0";
            ClientInfo.SysSetInfo.Power = String.Join("",Power);
            ClientInfo.SysSetInfo = ClientInfo.SysSetInfo;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private string[] power = new string[ClientInfo.SysSetInfo.Power.Length];

        public string[] Power
        {
            get {
                if (string.IsNullOrEmpty(power[0]))
                {
                    for (int i = 0; i < ClientInfo.SysSetInfo.Power.Length; i++)
                {
                    power[i] = ClientInfo.SysSetInfo.Power.Substring(i,1);
                }
                }
                return power; }
            set { power = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnfoldpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath+@"\";
                txtimagepath.Text = foldPath;
            }
        }
    }
}
