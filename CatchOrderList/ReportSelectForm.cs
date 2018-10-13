using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class ReportSelectForm : Form
    {
        private ReportSelectForm()
        {
            InitializeComponent();
        }

        private static ReportSelectForm thisForm;

        public static ReportSelectForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new ReportSelectForm();
                }
                return ReportSelectForm.thisForm; }
            set { ReportSelectForm.thisForm = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Tag = "0";
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Tag = "1";
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
