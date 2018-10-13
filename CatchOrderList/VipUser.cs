using CatchOrderList.data;
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
    public partial class VipUser : Form
    {
        public VipUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("用户编号不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("用户名称不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckNoIsExists(textBox1.Text))
            {
                MessageBox.Show("用户编号已经存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               AddRow(textBox1.Text, textBox2.Text);
            textBox1.Text = textBox2.Text = "";
            //new TextHelper().StaticSave(textBox1.Text,"cusdata");
        }


        int rowcount = 1;
        private void AddRow(string no,string name)
        {
            gvInfo.Rows.Add(1);
            gvInfo.Rows[gvInfo.Rows.Count - 2].Cells[0].Value = rowcount;
            gvInfo.Rows[gvInfo.Rows.Count - 2].Cells[1].Value = rowcount;
            gvInfo.Rows[gvInfo.Rows.Count - 2].Cells[2].Value = no;
            gvInfo.Rows[gvInfo.Rows.Count - 2].Cells[3].Value = name;
            rowcount++;
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
            string data = new TextHelper().StaticRead("cusdata");
            foreach (var item in data.Split('\n'))
            {
                if(item.Contains(','))
                {
                    if(string.IsNullOrEmpty(item.Split(',')[0]))
                    {
                        continue;
                    }
                    AddRow(item.Split(',')[0],item.Split(',')[1]);
                }
            }
        }



        private void VipUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            string content = "";
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                content += item.Cells[2].Value+","+item.Cells[3].Value+"\n";
            }
            new TextHelper().StaticSave(content,"cusdata");
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
    }
}
