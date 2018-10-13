using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class OrderScanForm : Form
    {
        private OrderScanForm()
        {
            InitializeComponent();
        }


        private static OrderScanForm thisForm;

        public static OrderScanForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new OrderScanForm();
                }
                return OrderScanForm.thisForm; }
            set { OrderScanForm.thisForm = value; }
        }

        /// <summary>
        /// 定位单号委托
        /// </summary>
        /// <param name="orderNo"></param>
        public delegate void PointOrderNo(string orderNo);
        public PointOrderNo DEL_PointOrderNo;

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtOrderNo.Focus();
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderNo.Text))
            {
                if(null!=DEL_PointOrderNo)
                {
                    DEL_PointOrderNo(txtOrderNo.Text);
                    txtOrderNo.Text = "";
                }
            }
            txtOrderNo.Focus();
        }
    }
}
