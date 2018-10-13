using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SafeDogAPP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCheek_Click(object sender, EventArgs e)
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

            uint uid = 0;
            uint hid = 0;

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

            CRockey2.GenUID(handle, ref uid, Seed, CRockey2.ROCKEY2_DISABLE_WRITE_PROTECT);

            if (iMax >= 0)
            {

                csInfo = "[GenUID OK],uid : ";
                csInfo += uid;

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


            // 在生成新的 UID 以后，加密锁的识别标志会一起改变，必须拔出加密锁再重新插入

            csInfo = "[在生成新的 UID 以后，加密锁的识别标志会一起改变，必须拔出加密锁再重新插入] ";
            csInfo += "\r\n";
            InfoBox.Text += csInfo;	
        }


        private char[] Seed
        {
            get
            {
                string seed = "@alibaba#tengxun$baidu*fuwenjun";
                return Express.Common.DEncrypt.DESEncrypt.Encrypt(seed).ToCharArray();
            }
        }


        private void btnReadContent_Click(object sender, EventArgs e)
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

        private void btnWriteSafeDog_Click(object sender, EventArgs e)
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
            string str = "version:1.0|true|" + "F".PadLeft(10, 'F');
            CRockey2 ry2_Wrire = new CRockey2();
            iMax = CRockey2.Write(handle, block_index, Express.Common.DEncrypt.DESEncrypt.Encrypt(str));

            if (iMax >= 0)
            {

                csInfo = "[Write OK], Write Date :  ";
                csInfo += str;

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
