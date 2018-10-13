using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class FormDataTrans : Form
    {
        public FormDataTrans()
        {
            InitializeComponent();

        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            string[] data = textBox1.Text.Split('\n');
            int maxlength = int.Parse(toolStripComboBox1.Text);
            List<string> orders = new List<string>();
            foreach (var item in data)
            {
                if (item.Length < maxlength)
                    continue;
                int maxlenth = item.Length > maxlength ? maxlength : item.Length;

                string d = item.Substring(0, maxlenth) + Environment.NewLine;
                if (!CheckIsExistsOrder(orders, d))
                {
                    textBox2.Text += d;
                    orders.Add(d);
                }
            }
        }


        private bool CheckIsExistsOrder(List<string> infos, string d)
        {
            bool isE = false;
            for (int i = 0; i < infos.Count; i++)
            {
                if (d == infos[i])
                {
                    isE = true;
                    break;
                }
            }
            return isE;
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = saveFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                //获得文件路径
                string path = saveFileDialog1.FileName.ToString();
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write(textBox2.Text.Replace("\n", "\r\n"));
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                rs = MessageBox.Show("文件导出成功，是否打开导出的文件？", "导出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    Process.Start(saveFileDialog1.FileName);
                }
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, textBox2.Text);
        }
    }
}
