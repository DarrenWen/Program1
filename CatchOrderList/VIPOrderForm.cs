using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class VIPOrderForm : Form
    {
        public VIPOrderForm()
        {
            InitializeComponent();
        }

        private void VIPOrderForm_Load(object sender, EventArgs e)
        {
            LoadPage();
            LoadData();
        }


        private void LoadPage()
        {
            this.anpageinfo.RecordCount = new Express.BLL.OrgOrder ().GetRecordCount(SearchCondition());
            this.anpageinfo.PageIndex = 1;
            int pageCount = anpageinfo.RecordCount / anpageinfo.PageSize;
            if (anpageinfo.RecordCount % anpageinfo.PageSize != 0)
            {
                pageCount++;
            }
            this.anpageinfo.Tag = pageCount;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchCondition()
        {
            string data = " 0=0 ";
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                data += string.Format(" and (pid like '%{0}%' or orderno like '%{0}%')",textBox1.Text);
            }
            if(checkBox1.Checked)
            {
                data += string.Format(" and imtime=#"+dtpReciveDate.Value.ToShortDateString()+"#");
            }
            return data;
        }

        private void LoadData()
        {
            this.anpageinfo.Refresh();
            gvInfo.Rows.Clear();
            int pagesize = PageSize;

            DataTable dt = new Express.BLL.OrgOrder().GetListByPage(SearchCondition(), "id", pagesize, anpageinfo.PageIndex).Tables[0];
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                gvInfo.Rows.Add(rowCount);
            }
            rowCount = 0;
            foreach (DataRow item in dt.Rows)
            {
                gvInfo.Rows[rowCount].Cells[0].Value = item["id"];
                gvInfo.Rows[rowCount].Cells[1].Value = (rowCount + 1);
                gvInfo.Rows[rowCount].Cells[2].Value = item["orderno"];
                gvInfo.Rows[rowCount].Cells[3].Value = item["pid"];
                gvInfo.Rows[rowCount].Cells[4].Value = item["imtime"];
                rowCount++;
            }
        }




        private int PageSize
        {
            get
            {
                int pagesize = anpageinfo.PageSize;
                int pageCount = Convert.ToInt32(anpageinfo.Tag);
                if (pageCount == anpageinfo.PageIndex)
                {
                    if (anpageinfo.RecordCount % anpageinfo.PageSize != 0)
                    {
                        pagesize = anpageinfo.RecordCount % anpageinfo.PageSize;
                    }
                }
                return pagesize;
            }
        }

        private void anpageinfo_PageIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(anpageinfo.Tag) > 0 && Convert.ToInt32(anpageinfo.Tag) >= anpageinfo.PageIndex)
            {
                LoadData();
            }
            else
            {
                anpageinfo.PageIndex--;
            }
        }

        private void 数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VipImport().ShowDialog();
        }

        private void 数据删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认要删除当前查询条件的所有记录吗？","系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
            {
                new Express.BLL.OrgOrder().DeleteByCondition(SearchCondition());
                LoadPage();
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadPage();
            LoadData();
        }
    }
}
