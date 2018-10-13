using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeDogAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iMax;


            string csInfo = "[Find OK], Find Num:  ";

            InfoBox.Text += "\r\n";


            CRockey2 ry2_Find = new CRockey2();

            iMax = CRockey2.Find();

            if (iMax <= 0)
            {

                csInfo = "Error: ";
                csInfo += iMax;
            }
            else
            {
                csInfo += iMax;

            }


            csInfo += "\r\n";
            InfoBox.Text += csInfo;


            CRockey2 ry2_Open = new CRockey2();

            uint hid = 0;
            uint uid = 0;

            iMax = CRockey2.Open(CRockey2.AUTO_MODE, uid, ref hid);

            if (iMax >= 0)
            {

                csInfo = "[Open OK], HID :  ";
                csInfo += hid;

            }
            else
            {
                csInfo = "Error: code ";
                csInfo += iMax;
            }

            csInfo += "\r\n";
            InfoBox.Text += csInfo;

            int handle;
            handle = iMax;

            int block_index = 0;
            StringBuilder csReadData = new StringBuilder("", 512);
            CRockey2 ry2_Read = new CRockey2();
            iMax = CRockey2.Read(handle, block_index, csReadData);


            if (iMax >= 0)
            {

                csInfo = "[Read OK], Read  Date :  ";
                csInfo += Express.Common.DEncrypt.DESEncrypt.Decrypt(csReadData.ToString());

            }
            else
            {
                csInfo = "Error: code ";
                csInfo += iMax;
            }

            csInfo += "\r\n";
            InfoBox.Text += csInfo;

            CRockey2 ry2_Close = new CRockey2();

            iMax = CRockey2.Close(handle);

            csInfo = "\r\n";
            InfoBox.Text += csInfo;
        }
    }
}
