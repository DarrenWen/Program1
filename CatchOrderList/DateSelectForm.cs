using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class DateSelectForm : Form
    {
        private DateSelectForm()
        {
            InitializeComponent();
        }

        private static DateSelectForm thisForm;

        public static DateSelectForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new DateSelectForm();
                }
                return DateSelectForm.thisForm;
            }
            set { DateSelectForm.thisForm = value; }
        }


        private void CusSelectForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
                this.Tag =  dtpReciveDate.Value;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
           
        }
    }
}
