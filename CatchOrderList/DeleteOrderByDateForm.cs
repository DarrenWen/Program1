using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Express.Model;

namespace CatchOrderList
{
    public partial class DeleteOrderByDateForm : Form
    {
        private DeleteOrderByDateForm()
        {
            InitializeComponent();
            cbOrderState.SelectedIndex = 0;
            InitialData();
        }

        private void InitialData()
        {
            List<Express.Model.CustomerInfo> infos = new Express.BLL.CustomerInfo().GetModelList("");
            CustomerInfo first = new CustomerInfo();
            first.cusname = "==请选择==";
            first.cid = 0;
            infos.Insert(0,first);
            this.ddlCustomer.DisplayMember = "cusname";
            this.ddlCustomer.ValueMember = "cid";
            this.ddlCustomer.DataSource = infos;
        }

        private static DeleteOrderByDateForm thisForm;

        public static DeleteOrderByDateForm ThisForm
        {
            get {
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new DeleteOrderByDateForm();
                }
                
                return DeleteOrderByDateForm.thisForm; }
            set { DeleteOrderByDateForm.thisForm = value; }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchCondition
        {
            get
            {
                string condition = " 0=0 ";

                if (cbOrderState.SelectedIndex > 0)
                {
                    switch (cbOrderState.SelectedIndex)
                    {
                        case 2:
                            condition += " and OState <> 1";
                            break;
                        case 1:
                            condition += " and OState = 1";
                            break;
                        case 5:
                            condition += " and OState = 0";
                            break;
                        case 6:
                            condition += " and OState = 4";
                            break;
                        default:
                            condition += " and OState = " + (cbOrderState.SelectedIndex - 1);
                            break;
                    }
                }

                if (cbCatchState.SelectedIndex > 0)
                {
                    condition += " and Merchandiser = " + (cbCatchState.SelectedIndex);
                }

                    DateTime dtMiddle = DateTime.Now;

                    if (dtpEnd.Value < dtpReciveDate.Value)
                    {
                        dtMiddle = dtpEnd.Value;
                        dtpEnd.Value = dtpReciveDate.Value;
                        dtpReciveDate.Value = dtMiddle;

                    }

                    if (ddlCustomer.SelectedIndex > 0)
                    {
                        condition += " and CustomerID=" + ddlCustomer.SelectedValue;
                    }
                    for (int i = 0; i < cblError.Items.Count; i++)
                    {
                        if (cblError.GetItemChecked(i))
                        {
                            condition += " and mid(paream4," + (i + 1) + ",1)='1'";
                        }
                    }
                    condition += " and Daterecived between #" + dtpReciveDate.Value.Date + "# and #" + dtpEnd.Value.AddHours(1) + "#";
                return condition;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(!cbR.Checked&&!cbS.Checked)
            {
                MessageBox.Show("请选择一个要操作的类型!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            if(MessageBox.Show("该操作不可逆，确认要删除选中时间段里面的数据吗？","系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.OK)
            {
                new Express.BLL.SendOrderInfo().DeleteByCondition(SearchCondition);
                new Express.BLL.OrderInfo().DeleteByCondition(SearchCondition);
                MessageBox.Show("删除记录成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
