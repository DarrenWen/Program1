using CatchOrderList.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class IntercedeForm : Form
    {
        private IntercedeForm()
        {
            InitializeComponent();
        }

        private static IntercedeForm thisForm;

        public static IntercedeForm ThisForm
        {
            get {
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new IntercedeForm();
                }
                return IntercedeForm.thisForm; }
            set { IntercedeForm.thisForm = value; }
        }

        bool isLogin = false;

        private void wbMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string orgHtml = wbMain.Document.Window.Frames["fram_login"].Document.Body.OuterHtml;


            HtmlDocument doc = wbMain.Document.Window.Frames["fram_login"].Document;
            HtmlElement txtNo = doc.All["login_gh"].All["login_gh"];
            HtmlElement txtPass = doc.All["login_gh_pwd"];
            HtmlElement btnSubmit = doc.All["login_click_gh"];
            if (null != txtNo && null != btnSubmit && !isLogin)
            {
                timer1.Start();
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HtmlDocument doc = wbMain.Document.Window.Frames["fram_login"].Document;
            HtmlElement txtNo = doc.All["login_gh"].All["login_gh"];
            HtmlElement txtPass = doc.All["login_gh_pwd"];
            HtmlElement btnSubmit = doc.All["login_click_gh"];
            if (null != txtNo && null != btnSubmit)
            {
                txtNo.SetAttribute("value", ClientInfo.SysSetInfo.Paream3);
                txtPass.SetAttribute("value", ClientInfo.SysSetInfo.Paream4);
                btnSubmit.InvokeMember("click");
            }
            isLogin = true;
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void IntercedeForm_Load(object sender, EventArgs e)
        {
            isLogin = false;
            this.wbMain.Refresh();
        }
    }
}
