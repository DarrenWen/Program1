using MainContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDWeight.data;

namespace YDWeight
{
    public partial class SearchForm : Form
    {
        MainDataContext db = new MainDataContext();
        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            gvInfo.Rows.Clear();
            string sql = "SELECT * FROM OrderWeight t1 where 1>0 ";
            sql = GetCondition(sql);
            var query = db.ExecuteQuery<OrderWeight>(sql);
            foreach (var item in query.ToList())
            {
                AddRow(item);
            }
        }

        private string GetCondition(string sql)
        {
            if (!string.IsNullOrEmpty(txtKeyWord.Text.Trim()))
            {
                var keyword = txtKeyWord.Text.Trim();
                sql += " and EmName like '%" + keyword + "%' or OrderId like '%"+keyword+"%'";
            }
            var dtstart = dtpScanTime.Value.Date;
            var dtEnd = dtpEnd.Value.Date.AddDays(1).Date;
            sql += " and ScanTime > '" + dtstart + "' AND ScanTime <= '" + dtEnd + "'";
            return sql;
        }

        /// <summary>
        /// 新增一行记录信息
        /// </summary>
        private void AddRow(OrderWeight m)
        {
            gvInfo.Rows.Add(1);
            int rowindex = gvInfo.Rows.Count - 2;
            gvInfo.Rows[rowindex].Cells[1].Value = (rowindex + 1).ToString();
            gvInfo.Rows[rowindex].Cells[2].Value = m.OrderId;
            gvInfo.Rows[rowindex].Cells[3].Value = m.ScanTime;

            gvInfo.Rows[rowindex].Cells[4].Value = m.EmName;

            gvInfo.Rows[rowindex].Cells[5].Value = m.Weight.ToString();
            gvInfo.Rows[rowindex].Cells[6].Value = m.Count.ToString();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(gvInfo, "快件称重订单查询");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除以后的数据将无法恢复，确认要这样操作吗？","系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
                string sql = "delete FROM OrderWeight where 1>0 ";
                sql = GetCondition(sql);
                int result = db.ExecuteCommand(sql);
                RefreshData();//刷新数据
            }
        }
    }
}
