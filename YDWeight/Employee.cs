
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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("编号不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("姓名不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckNoIsExists(textBox1.Text))
            {
                MessageBox.Show("用户编号已经存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CollectorModel m = new CollectorModel() {  UserName=textBox2.Text, Code=textBox1.Text};
            
            AddNewRow(m);
            textBox1.Text = textBox2.Text = "";
        }




        private bool CheckNoIsExists(string no)
        {
            if (gvInfo.Rows.Count > 1)
            {
                foreach (DataGridViewRow item in gvInfo.Rows)
                {

                    if (item.Cells[2].Value!=null&&item.Cells[2].Value.ToString() == no)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private void VipUser_Load(object sender, EventArgs e)
        {
            gvInfo.Rows.Clear();
            var data = ConfigManager.CollectorModels;
            if (null!=data)
            {
                foreach (var item in data)
                {
                    AddNewRow(item);
                }

            }
        }

        private void AddNewRow(CollectorModel item)
        {
            gvInfo.Rows.Add(1);
            var rowcount = gvInfo.Rows.Count - 2;
            gvInfo.Rows[rowcount].Cells[0].Value = rowcount + 1;
            gvInfo.Rows[rowcount].Cells[1].Value = rowcount + 1;
            gvInfo.Rows[rowcount].Cells[2].Value = item.Code;
            gvInfo.Rows[rowcount].Cells[3].Value = item.UserName;
        }

        private void VipUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ConfigManager.CollectorModels!=null)
            ConfigManager.CollectorModels=new List<CollectorModel>();
            List<CollectorModel> infos = new List<CollectorModel>();
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (item.Cells[2].Value == null || item.Cells[3].Value == null)
                    continue;
                infos.Add(new CollectorModel() { Code= item.Cells[2].Value.ToString(), UserName= item.Cells[3].Value.ToString() });
            }
            ConfigManager.CollectorModels = infos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(gvInfo.SelectedRows.Count<1|| gvInfo.SelectedRows[0].Cells[0].Value==null)
            {
                MessageBox.Show("请选择一行要删除的数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("确认要删除吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                gvInfo.Rows.Remove(gvInfo.SelectedRows[0]);
            }
        }

        private void gvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public CollectorModel selectedModel = new CollectorModel();
        private void gvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item = gvInfo.Rows[e.RowIndex];
                if (item.Cells[2].Value == null || item.Cells[3].Value == null)
                {
                    return;
                }
                selectedModel.Code = item.Cells[2].Value.ToString();
                selectedModel.UserName = item.Cells[3].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
