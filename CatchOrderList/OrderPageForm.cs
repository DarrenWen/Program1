using CatchOrderList.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class OrderPageForm : Form
    {
        private OrderPageForm()
        {
            InitializeComponent();
        }

        private static OrderPageForm thisForm;

        public static OrderPageForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new OrderPageForm();
                }
                return OrderPageForm.thisForm; }
            set { OrderPageForm.thisForm = value; }
        }


        private void OrderPageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        
    }
}
