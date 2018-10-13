using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class CheckVersionForm : Form
    {
        private CheckVersionForm()
        {
            InitializeComponent();
        }

        private static CheckVersionForm thisForm;

        public static CheckVersionForm ThisForm
        {
            get
            {

                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new CheckVersionForm();
                }
                return CheckVersionForm.thisForm;
            }
            set { CheckVersionForm.thisForm = value; }
        }
    }
}
