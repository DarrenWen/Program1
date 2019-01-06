using CatchOrderList.data;
using Express.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class QuickSearchOrder : Form
    {
        public QuickSearchOrder()
        {
            InitializeComponent();
        }
        PageDataProcess pageProcess = new PageDataProcess();

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            gvInfo.Rows.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            gvInfo.Rows.Clear();
            string[] data = textBox1.Text.Trim().Split('\n');
            if (data.Length > 0)
                gvInfo.Rows.Add(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                gvInfo.Rows[i].Cells[0].Value = i;
                gvInfo.Rows[i].Cells[1].Value = i+1;
                gvInfo.Rows[i].Cells[2].Value = data[i];
            }
        }

        private void 查单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                OrderInfo m = new OrderInfo();
                if (item.Cells[2].Value==null|| item.Cells[4].Value!=null)
                    continue;
                m.Id = int.Parse(item.Cells[0].Value.ToString());
                m.OrderNo = item.Cells[2].Value.ToString().Replace("\r","");
                ThreadPool.QueueUserWorkItem(state => pageProcess.ProcessV2(m));
            }
            
        }

        private void QuickSearchOrder_Load(object sender, EventArgs e)
        {
            pageProcess.PrintOrderInfo = PrintOrderInfo;
            ///不允许排序
            foreach (DataGridViewColumn item in gvInfo.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void PrintOrderInfo(OrderInfo m)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<OrderInfo>(PrintOrderInfo), m);
            }
            else
            {
                if (null != m)
                {
                    Color foreColor = Color.Black;

                    gvInfo.Rows[m.Id].Cells[3].Value = m.Daterecived;
                    gvInfo.Rows[m.Id].Cells[4].Value = "***";
                    gvInfo.Rows[m.Id].Cells[5].Value = "***";
                    gvInfo.Rows[m.Id].Cells[6].Value = m.Reciver;
                    gvInfo.Rows[m.Id].Cells[7].Value = m.Tel;
                    gvInfo.Rows[m.Id].Cells[8].Value = m.Provice;
                    gvInfo.Rows[m.Id].Cells[9].Value = m.City;
                    gvInfo.Rows[m.Id].Cells[10].Value = m.Area;
                    gvInfo.Rows[m.Id].Cells[11].Value = m.Address;
                    gvInfo.Rows[m.Id].Cells[12].Value = m.Remark;
                    gvInfo.Rows[m.Id].Cells[13].Value = ConvertOrderState(m.OState, ref foreColor);
                    gvInfo.Rows[m.Id].Cells[14].Value = m.OState;
                    gvInfo.Rows[m.Id].Cells[15].Value = "***";
                    gvInfo.Rows[m.Id].Cells[16].Value = m.Contractor;


                    gvInfo.Rows[m.Id].Cells[17].Value = GetOState(m.ORState);
                    gvInfo.Rows[m.Id].Cells[18].Value = m.Paream1;
                    gvInfo.Rows[m.Id].Cells[19].Value = m.Paream2;
                    if (!string.IsNullOrEmpty(m.Paream8.ToString()))
                        gvInfo.Rows[m.Id].Cells[20].Value = m.Paream8.Value * 1M / 100M;
                    this.gvInfo.Rows[m.Id].DefaultCellStyle.ForeColor = foreColor;
                    gvInfo.Rows[m.Id].Cells[21].Value = m.Paream4;
                    gvInfo.Rows[m.Id].Cells[22].Value = m.Paream6.ToString() == "1" ? "是" : "否";//是否退回件;
                    gvInfo.Rows[m.Id].Cells[23].Value = m.Paream7.Value*1d/100d;//快件重量;
                    gvInfo.Rows[m.Id].Cells[24].Value = m.Paream0;//条码信息
                    gvInfo.Rows[m.Id].Cells[25].Value = m.Paream9;//三段码信息
                    gvInfo.Rows[m.Id].Cells[26].Value = m.Paream10;//三段码信息
                    gvInfo.Rows[m.Id].Cells[27].Value = m.Paream11;//三段码信息
                    gvInfo.Rows[m.Id].Cells[28].Value = m.Paream12;//三段码信息
                    gvInfo.Rows[m.Id].Cells[29].Value = m.Paream15;
                    gvInfo.Rows[m.Id].Cells[30].Value = m.Paream13;
                    gvInfo.Rows[m.Id].Cells[31].Value = m.Paream14;
                }
            }
        }





        private string GetOState(int id)
        {
            switch (id)
            {
                case 0:
                    return "未处理";
                    break;
                case 1:
                    return "需要催单";
                    break;
                case 2:
                    return "正常";
                    break;
                case 3:
                    return "未处理";
                       
                default:
                    return id.ToString();
                    break;
            }
        }








        private string ConvertOrderState(int state, ref Color color)
        {
            switch (state)
            {
                case 1:
                    color = Color.Green;
                    return "正常签收";

                    break;
                case 2:
                    color = Color.Red;
                    return "异常签收";

                    break;
                case 0:
                    return "未处理";
                    break;
                case 4:
                    return "无物流信息";
                    break;
                case 5:
                    return "漏件补收";
                    break;
                default:
                    return "未签收";
                    break;
            }
            return "未签收";
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(gvInfo, "收件单号查询");
        }

        private void gvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string orderno = gvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                pageProcess.RedirectUrl(orderno);
            }
        }
    }
}
