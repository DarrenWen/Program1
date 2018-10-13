using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class CusSelectForm : Form
    {
        private CusSelectForm()
        {
            InitializeComponent();
        }

        private static CusSelectForm thisForm;

        public static CusSelectForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new CusSelectForm();
                }
                return CusSelectForm.thisForm; }
            set { CusSelectForm.thisForm = value; }
        }


        private void InitialData()
        {
            List<Express.Model.CustomerInfo> infos = new Express.BLL.CustomerInfo().GetModelList("");
            this.ddlCustomer.DisplayMember = "cusname";
            this.ddlCustomer.ValueMember = "cid";
            this.ddlCustomer.DataSource = infos;
        }

        private void CusSelectForm_Load(object sender, EventArgs e)
        {
            InitialData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (null != ddlCustomer.SelectedValue)
            {
                this.Tag = ddlCustomer.SelectedValue;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
}
