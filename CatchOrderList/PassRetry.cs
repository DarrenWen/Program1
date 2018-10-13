using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class PassRetry : Form
    {
        public PassRetry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text =  Express.DBUtility.DESEncrypt.Encrypt(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Express.DBUtility.DESEncrypt.Decrypt(textBox1.Text);
        }
    }
}
