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
    public partial class AddOrderForm : Form
    {
        private AddOrderForm()
        {
            InitializeComponent();
        }

        private static AddOrderForm thisForm;

        public static AddOrderForm ThisForm
        {
            get
            {
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new AddOrderForm();
                }
                return AddOrderForm.thisForm;
            }
            set
            {
                AddOrderForm.thisForm = value;
            }
        }

        private void InitialData()
        {
            List<Express.Model.CustomerInfo> infos = new Express.BLL.CustomerInfo().GetModelList("");
            this.ddlCustomer.DisplayMember = "cusname";
            this.ddlCustomer.ValueMember = "cid";
            this.ddlCustomer.DataSource = infos;
            List<Express.Model.Sys_User> users = new Express.BLL.Sys_User().GetModelList(" UState=0 and issaleman=true");
            this.ddlSaleMan.DisplayMember = "PerName";
            this.ddlSaleMan.ValueMember = "UID";
            this.ddlSaleMan.DataSource = users;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private bool CheckIsExistsOrder(List<string> infos, string d)
        {
            bool isE = false;
            for (int i = 0; i < infos.Count; i++)
            {
                if (d == infos[i])
                {
                    isE = true;
                    break;
                }
            }
            return isE;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ddlCustomer.SelectedIndex >= 0)
            {
                string[] infos = txtOrderNumber.Text.Trim().Replace(" ", "").Replace("\r", "").Split('\n');

                List<string> orders = new List<string>();
                for (int i = 0; i < infos.Length; i++)
                {
                    if (!CheckIsExistsOrder(orders, infos[i]))
                    {
                        orders.Add(infos[i]);
                    }
                }
                for (int i = 0; i < orders.Count; i++)
                {
                    Express.Model.OrderInfo orderInfo = new Express.Model.OrderInfo();
                    orderInfo.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
                    orderInfo.SalesmanID = Convert.ToInt32(ddlSaleMan.SelectedValue);
                    orderInfo.OrderNo = orders[i];
                    orderInfo.Daterecived = dtpReciveDate.Value;
                    orderInfo.Contractdate = orderInfo.Daterecived;
                    orderInfo.OperUser = ClientInfo.Sys_UserInfo.username;
                    orderInfo.UserDate = DateTime.Now;
                    new Express.BLL.OrderInfo().Add(orderInfo);
                }
                txtOrderNumber.Text = "";
            }
            else
            {
                MessageBox.Show("没有客户信息，请先增加客户!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            InitialData();
        }


       
    }
}
