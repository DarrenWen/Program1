﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CatchOrderList
{
    public partial class AboutForm : Form
    {
        private AboutForm()
        {
            InitializeComponent();
            InitialInfo();
        }

        private static AboutForm thisForm;

        public static AboutForm ThisForm
        {
            get {
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new AboutForm();
                }
                return AboutForm.thisForm;
            }
            set { AboutForm.thisForm = value; }
        }

        private void InitialInfo()
        {
            try
            {
                FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(Application.StartupPath + "/CatchOrderList.exe");
                lblVersion.Text = fileVersion.FileVersion;
                string fileName = Application.StartupPath + "/version.txt";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                FileStream fsRead = new FileStream(fileName, FileMode.Open);
            
                StreamReader streamReader = new StreamReader(fsRead,Encoding.GetEncoding("GB2312"));
                
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                string arry = "";
                string strLine = streamReader.ReadLine();
                do
                {
                    arry += strLine+"\r\n";
                    strLine = streamReader.ReadLine();
                } while (strLine!=null);
                streamReader.Close();
                streamReader.Dispose();
                fsRead.Close();
                fsRead.Dispose();
                //this.txtInfo.Text = arry;
                //txtInfo.Select(0, 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}