using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using CatchOrderList.data;
using System.Diagnostics;
using CatchOrderList.Properties;

namespace CatchOrderList
{
    public partial class MainFormFC : Form
    {
        public MainFormFC()
        {
            InitializeComponent();
        
        }

        #region 属性
        /// <summary>
        /// 是否注销系统
        /// </summary>
        bool InitialSys = false;
        #endregion
       
       
        

        private void InitialSysFun(bool isEnable)
        {
            if (new UserValidation().Validate())
            {
                menuStrip1.Visible = true;
                tsmiCusMag.Enabled = isEnable;
                tsmiOrderMag.Enabled = isEnable;
                tsmiSendorderMag.Enabled = isEnable;
                tsmiUserManager.Enabled = isEnable;
                集包查询ToolStripMenuItem.Enabled = vIP单号反查系统ToolStripMenuItem.Enabled = vIP单号管理ToolStripMenuItem.Enabled = vIP用户信息设置ToolStripMenuItem.Enabled = isEnable;
                tsmiZhc.Enabled = UserValidation.IsRegister;
                if (UserValidation.IsRegister)
                {
                    tsmiDBManager.Enabled = DataRight;
                    tsmiFormat.Enabled = true;
                }
                tsmiNote.Text = ClientInfo.NoteMsg;
                if(UserValidation.IsRegister)
                {
                    this.Text = ClientInfo.SysSetInfo.cusname + "智能查单系统";
                    timCheck.Enabled = true;
                    this.BackgroundImage = Resources.bg1;
                }
            }
            else
            {
                MessageBox.Show("该软件已经超过试用期，请购买正版软件,联系人QQ:380891124！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        bool DataRight
        {
            get
            {
                return ClientInfo.SysSetInfo.Power.Substring(4, 1) == "0" ? false : true;
            }
        }

       

        private void tsmilogin_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        /// <summary>
        /// 显示登录窗体
        /// </summary>
        private void ShowLoginForm()
        {
            if (LoginForm.ThisForm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                tsmilogin.Enabled = false;
                InitialSysFun(true);
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void tsmirestart_Click(object sender, EventArgs e)
        {
            InitialSys = true;
            Application.Restart();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (InitialSys || MessageBox.Show(this, "确认要退出系统吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            InitialSys = false;
            Application.Exit();
        }

        private void tsmiSysSet_Click(object sender, EventArgs e)
        {
            SysSetForm.ThisForm.ShowDialog();
        }

        private void tsmiUserManager_Click(object sender, EventArgs e)
        {
            UserManagerForm.ThisForm.MdiParent = this;
            UserManagerForm.ThisForm.Show();
        }

        private void tsmiCusMag_Click(object sender, EventArgs e)
        {
            CusManagerForm.ThisForm.MdiParent = this;
            CusManagerForm.ThisForm.Show();
        }

        private void tsmiAddOrder_Click(object sender, EventArgs e)
        {
            AddOrderForm.ThisForm.ShowDialog();
        }

        private void tsmiSearchOrder_Click(object sender, EventArgs e)
        {
            OrderManagerForm.ThisForm.MdiParent = this;
            OrderManagerForm.ThisForm.Show();
        }

        private void tsmiAddCus_Click(object sender, EventArgs e)
        {
            new CusEditForm().ShowDialog();
        }

        private void tsmiSendOrderEdit_Click(object sender, EventArgs e)
        {
            AddSendOrderForm.ThisForm.ShowDialog();
        }

        private void tsmiSendorderSearch_Click(object sender, EventArgs e)
        {
            NewSendOrderManagerForm.ThisForm.MdiParent = this;
            NewSendOrderManagerForm.ThisForm.Show();
        }

        private void tsmiBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                string path = SaveFile();
                if (!string.IsNullOrEmpty(path))
                {
                    if (Express.Common.AccessManager.Backup(Application.StartupPath + @"\\dbms.mdb", path))
                    {
                        MessageBox.Show("备份数据库成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("备份数据库失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiRecover_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("为了确保数据安全,恢复数据库之前请先备份数据库,确认要进行该操作吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    string path = OpenFile();
                    if (!string.IsNullOrEmpty(path))
                    {
                        if (Express.Common.AccessManager.RecoverAccess(path, Application.StartupPath + @"\\dbms.mdb"))
                        {
                            MessageBox.Show("恢复数据库成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("恢复数据库失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string SaveFile()
        {
            SaveFileDialog opd = new SaveFileDialog();
            opd.Filter = @"数据库文件(*.mdb)|*.mdb";
            opd.FilterIndex = 1;
            opd.InitialDirectory = Application.StartupPath;
            opd.FileName = string.Format("快递数据备份({0})",DateTime.Now.ToFileTime());
            DialogResult result = opd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return opd.FileName;
            }
            return String.Empty;
        }

        public string OpenFile()
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = @"数据库文件(*.mdb)|*.mdb";
            opd.FilterIndex = 1;
            opd.InitialDirectory = Application.StartupPath;
            DialogResult result = opd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return opd.FileName;
            }
            return String.Empty;
        }

        private void tsmiLogo_Click(object sender, EventArgs e)
        {
            VersionForm.ThisForm.ShowDialog();
        }

        private void tsmiRegist_Click(object sender, EventArgs e)
        {
            if (UserValidation.IsRegister)
            {
                MessageBox.Show("您已经是尊贵的VIP系统用户，如有疑问请联系QQ:1686519114！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请购买正版软件,联系人QQ:380891124！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmiFormat_Click(object sender, EventArgs e)
        {
            if (DataFormatForm.ThisForm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                InitialSys = true;
                Application.Restart();
            }
        }

        private void timCheck_Tick(object sender, EventArgs e)
        {
            if (!UserValidation.IsRegister)
            {
                if(!CheckVersionForm.ThisForm.Visible)
                CheckVersionForm.ThisForm.ShowDialog();
            }
            else
            {
                if (CheckVersionForm.ThisForm.Visible)
                CheckVersionForm.ThisForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void tsmiZDzc_Click(object sender, EventArgs e)
        {
            IntercedeForm.ThisForm.ShowDialog();
        }

        private void tsmiReadMe_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath+@"\"+"help.doc");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请先在电脑上安装Office软件，再使用该功能！","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmiDelgS_Click(object sender, EventArgs e)
        {
            DeleteOrderByDateForm.ThisForm.ShowDialog();
        }

        private void tsmiDelgr_Click(object sender, EventArgs e)
        {
            DeleteOrderByDateForm.ThisForm.ShowDialog();
        }

        private void 集包查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BigOrderForm().Show();
        }

        private void 数据截取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataTrans fm = new FormDataTrans();
            fm.Show();
        }

        private void 快速查单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuickSearchOrder().Show();
        }

        private void vIP单号管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VIPOrderForm().Show();
        }

        private void vIP用户信息设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VipUser().Show();
        
        }

        private void vIP单号反查系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VIPQRScan().Show();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {

        }

        private void 快速查重量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuickWeightSearchOrder().Show();
        }
    }
}
