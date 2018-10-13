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
    public partial class AddSendOrderForm : Form
    {
        private AddSendOrderForm()
        {
            InitializeComponent();
        }

        private static AddSendOrderForm thisForm;

        public static AddSendOrderForm ThisForm
        {
            get
            {
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new AddSendOrderForm();
                }
                return AddSendOrderForm.thisForm;
            }
            set
            {
                AddSendOrderForm.thisForm = value;
            }
        }

        private void InitialData()
        {
            List<Express.Model.Sys_User> users = new Express.BLL.Sys_User().GetModelList(" UState=0 and issaleman=true");
            this.ddlSaleMan.DisplayMember = "PerName";
            this.ddlSaleMan.ValueMember = "UID";
            this.ddlSaleMan.DataSource = users;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbOrderInfos.Items.Count; i++)
            {
                Express.Model.SendOrderInfo orderInfo = new Express.Model.SendOrderInfo();
                orderInfo.SalesmanID = Convert.ToInt32(ddlSaleMan.SelectedValue);
                orderInfo.OrderNo = lbOrderInfos.Items[i].ToString();
                orderInfo.Contractdate = dtpReciveDate.Value;
                orderInfo.Daterecived = orderInfo.Contractdate;
                orderInfo.OperUser = ClientInfo.Sys_UserInfo.username;
                orderInfo.UserDate = DateTime.Now;

                new Express.BLL.SendOrderInfo().Add(orderInfo);
            }
            lbOrderInfos.Items.Clear();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            InitialData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtOrderNumber.Text.Length<=10)
            {
                MessageBox.Show("订单编号录入有误，请确认订单编号!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderNumber.Text = "";
                txtOrderNumber.Focus();
                return;
            }
            if (!IsExistOrderNumber())
            lbOrderInfos.Items.Add(txtOrderNumber.Text);
            txtOrderNumber.Text = "";
            txtOrderNumber.Focus();
        }

        private bool IsExistOrderNumber()
        {
            bool ise = false;
            for (int i = 0; i < lbOrderInfos.Items.Count; i++)
            {
                if(lbOrderInfos.Items[i].ToString()==txtOrderNumber.Text)
                {
                    ise = true;
                    break;
                }
            }
            return ise;
        }

        private void lbOrderInfos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrderInfos.Items.Remove(lbOrderInfos.SelectedItem);
        }
    }
}
