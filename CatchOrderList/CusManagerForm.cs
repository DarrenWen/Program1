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
    public partial class CusManagerForm : Form
    {
        private CusManagerForm()
        {
            InitializeComponent();
            anpageinfo.PageIndexChanged += anpageinfo_PageIndexChanged;
            cbRoleType.SelectedIndex = 0;
            anpageinfo.PageSize = ClientInfo.SysSetInfo.PageSize.Value;
            foreach (var item in anpageinfo.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox obj = (TextBox)item;
                    obj.KeyPress += obj_KeyPress;
                }
            }
            InitialData();
        }

        private static CusManagerForm thisForm;

        public static CusManagerForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new CusManagerForm();
                }
                return CusManagerForm.thisForm; }
            set { CusManagerForm.thisForm = value; }
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

        /// <summary>
        /// 初始化数据信息
        /// </summary>
        private void InitialData()
        {
            int recordCount = new Express.BLL.CustomerInfo().GetRecordCount(SearchCondition);
            anpageinfo.RecordCount = recordCount;
            
            InitialView();
        }

        /// <summary>
        /// 初始化界面信息
        /// </summary>
        private void InitialView()
        {
            DataSet dsInfo = new Express.BLL.CustomerInfo().GetListByPage(SearchCondition, "cid", anpageinfo.PageSize, anpageinfo.PageIndex);
            DataTable dt = dsInfo.Tables[0];
            gvInfo.Rows.Clear();
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                gvInfo.Rows.Add(rowCount);
            }
            rowCount = 0;
            foreach (DataRow item in dt.Rows)
            {
                gvInfo.Rows[rowCount].Cells[0].Value = item["cid"];
                gvInfo.Rows[rowCount].Cells[1].Value = (rowCount + 1);
                gvInfo.Rows[rowCount].Cells[2].Value = item["cusname"];
                gvInfo.Rows[rowCount].Cells[3].Value = item["departmentname"];
                gvInfo.Rows[rowCount].Cells[4].Value = ConvertState(Convert.ToInt32(item["CState"]));
                gvInfo.Rows[rowCount].Cells[5].Value = item["contactphone"];
                gvInfo.Rows[rowCount].Cells[6].Value = item["contactperson"];
                gvInfo.Rows[rowCount].Cells[7].Value = item["Address"];
                gvInfo.Rows[rowCount].Cells[8].Value = item["UserDate3"];
                gvInfo.Rows[rowCount].Cells[9].Value = item["OperUser3"];
                rowCount++;
            }
        }

        private string ConvertState(int state)
        {
            return state == 0 ? "启用" : "禁用";
        }

        private string SearchCondition
        {
            get {
                string condition = " 0=0 ";
                if(!string.IsNullOrEmpty(txtKeyWord.Text))
                {
                    condition += string.Format(" and cusname like '%{0}%' or departmentname like '%{0}%' or contactperson like '%{0}%' or remark like '%{0}%'",txtKeyWord.Text);
                }
                if(cbRoleType.SelectedIndex>0)
                {
                    condition += " and CState="+(cbRoleType.SelectedIndex-1);
                }
                return condition; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (new CusEditForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitialData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckSelectedOne())
            {
                if (new CusEditForm(Convert.ToInt32(gvInfo.SelectedRows[0].Cells[0].Value)).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitialData();
                }
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
                if (MessageBox.Show("确认要删除选中的数据吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (new Express.BLL.OrderInfo().GetRecordCount(" CustomerID in ("+SelectedIds+")") > 0)
                    {
                        MessageBox.Show("选择的客户信息已经使用，请先删除子信息!","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool sucess = new Express.BLL.CustomerInfo().DeleteList(SelectedIds);
                    string msg = sucess ? "删除客户信息成功!" : "删除客户信息失败!";
                    MessageBox.Show(msg, " 系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitialData();
                }
            }
        }

        private string SelectedIds
        {
            get
            {
                string ids = "0";
                for (int i = 0; i < gvInfo.SelectedRows.Count; i++)
                {
                    if (gvInfo.SelectedRows[i].Cells[2].Value.ToString().ToLower() != "admin")//系统管理员不能被删除
                        ids += "," + gvInfo.SelectedRows[i].Cells[0].Value.ToString();
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
            ExportManager.ExportDataGridViewToExcel(gvInfo, "客户信息管理");
        }
    }
}
