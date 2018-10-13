using CatchOrderList.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class UserManagerForm : Form
    {
        private UserManagerForm()
        {
            InitializeComponent();
            cbRoleType.SelectedIndex = 0;
            anpageinfo.PageIndexChanged += anpageinfo_PageIndexChanged;
            anpageinfo.PageSize = ClientInfo.SysSetInfo.PageSize.Value;
            foreach (var item in anpageinfo.Controls)
            {
                 if(item.GetType()== typeof(TextBox))
                 {
                     TextBox obj = (TextBox)item;
                     obj.KeyPress += obj_KeyPress;
                 }
            }
            InitialData();
        }

        /// <summary>
        /// 初始化记录数据
        /// </summary>
        private void InitialData()
        {
            int recordCount = new Express.BLL.Sys_User().GetRecordCount(SearchCondition);
            anpageinfo.RecordCount = recordCount;
            DataSet dsInfo = new Express.BLL.Sys_User().GetListByPage(SearchCondition, "uid", anpageinfo.PageSize,anpageinfo.PageIndex);
            ShowData(dsInfo.Tables[0]);
        }

        private string SearchCondition
        {
            get {
                string condition = " 0=0 ";
                if (!string.IsNullOrEmpty(txtKeyWord.Text))
                {
                    condition += string.Format(" and username like '%{0}%' or pername like '%{0}%'", txtKeyWord.Text);
                }
                if(cbRoleType.SelectedIndex>0)
                {
                    string col = "";
                    switch (cbRoleType.SelectedIndex)
                    {
                        case 1:
                            col = "issaleman";
                            break;
                        case 2:
                            col = "isclerk";
                            break;
                        case 3:
                            col = "isfinance";
                            break;
                        case 4:
                            col = "isadmin";
                            break;
                        default:
                            break;
                    }
                    condition += string.Format(" and {0}=true",col);
                }
                return condition;
            }
        }


        private void ShowData(DataTable dt)
        {
            gvInfo.Rows.Clear(); 
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                gvInfo.Rows.Add(rowCount);
            }
             rowCount = 0;
            foreach (DataRow item in dt.Rows)
            {
                gvInfo.Rows[rowCount].Cells[0].Value = item["uid"];
                gvInfo.Rows[rowCount].Cells[1].Value = (rowCount + 1);
                gvInfo.Rows[rowCount].Cells[2].Value = item["username"];
                gvInfo.Rows[rowCount].Cells[3].Value = item["PerName"];
                gvInfo.Rows[rowCount].Cells[4].Value = item["issaleman"];
                gvInfo.Rows[rowCount].Cells[5].Value = item["isclerk"];
                gvInfo.Rows[rowCount].Cells[6].Value = item["isfinance"];
                gvInfo.Rows[rowCount].Cells[7].Value = item["isadmin"];
                gvInfo.Rows[rowCount].Cells[8].Value = ConvertState(Convert.ToInt32(item["UState"]));
                gvInfo.Rows[rowCount].Cells[9].Value = item["UserDate4"];
                gvInfo.Rows[rowCount].Cells[10].Value = item["OperUser4"];
                rowCount++;
            }
        }

        private string ConvertState(int state)
        {
            return state == 0 ? "启用" : "禁用";
        }
        

        void obj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }  
        }

        void anpageinfo_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

       

        private static UserManagerForm thisForm;

        public static UserManagerForm ThisForm
        {
            get {
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new UserManagerForm();
                }
                return thisForm; }
            set { thisForm = value; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserForm.ThisForm.ShowRegistInfo();
            if (AddUserForm.ThisForm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                InitialData();
            }
        }

        private bool CheckSelectedOne()
        {
            if (null == gvInfo.SelectedRows || gvInfo.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行要操作的数据!", " 系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CheckSelectedOne())
            {
                if(MessageBox.Show("确认要删除选中的数据吗?","系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                {
                    if (new Express.BLL.OrderInfo().GetRecordCount("SalesmanID in(" + SelectedIds + ")") > 0 || new Express.BLL.SendOrderInfo().GetRecordCount("SalesmanID in(" + SelectedIds + ")")>0)
                    {
                        MessageBox.Show("该用户已经被别的表使用，请先移除子项在删除!", " 系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool sucess = new Express.BLL.Sys_User().DeleteList(SelectedIds);
                    string msg = sucess ? "删除账号信息成功!" : "删除账号信息失败!";
                    MessageBox.Show(msg, " 系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitialData();
                }
            }
        }


        private string SelectedIds
        {
            get {
                string ids = "0";
                for (int i = 0; i < gvInfo.SelectedRows.Count; i++)
                {
                    if(gvInfo.SelectedRows[i].Cells[2].Value.ToString().ToLower()!="admin")//系统管理员不能被删除
                    ids += ","+gvInfo.SelectedRows[i].Cells[0].Value.ToString();
                }
                return ids;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitialData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(gvInfo, "用户信息管理");
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (CheckSelectedOne())
            {
                AddUserForm.ThisForm.ShowUpdateInfo(Convert.ToInt32(gvInfo.SelectedRows[0].Cells[0].Value));
                if (AddUserForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitialData();
                }
            }
        }

    }
}
