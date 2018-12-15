using CatchOrderList.data;
using Express.Model;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class QuickWeightSearchOrder : Form
    {
        public QuickWeightSearchOrder()
        {
            InitializeComponent();
            pageProcess.setSigleData = SetData;
        }


        private void SetData(string data)
        {
            if (!this.InvokeRequired)
            {
                try
                {
                    var datas = data.Split(',');
                    double weight = double.Parse(datas[1]);
                    int myrow = int.Parse(datas[0]) - 1;
                    gvInfo.Rows[myrow].Cells[3].Value = weight < 0  ? 0 : weight;
                    gvInfo.Rows[myrow].Cells[4].Value = datas[3];
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                this.Invoke(new Action<string>(SetData), data);
            }
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
                gvInfo.Rows[i].Cells[3].Value ="--";
            }
        }

        private void 查单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalRecordCount = gvInfo.Rows.Count;
            GetWeight();
        }


        int TotalRecordCount = 0;//总行数
        int NowIndex = 0;

        private void GetWeight()
        {
                foreach (DataGridViewRow item in gvInfo.Rows)
                {
                    if (item.Cells[2].Value != null && item.Cells[3].Value.ToString() == "--")
                    {
                        ThreadPool.QueueUserWorkItem(state => pageProcess.ProcessOrderWeight(item.Cells[2].Value.ToString() + "," + item.Cells[1].Value.ToString()));
                    }
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
                //if (NowIndex>0&&NowIndex<TotalRecordCount)
                //{
                //    var item = gvInfo.Rows[NowIndex];
                //    NowIndex++;
                //    if (item.Cells[2].Value != null && item.Cells[3].Value.ToString() == "--")
                //    {
                //        ThreadPool.QueueUserWorkItem(state => pageProcess.ProcessOrderWeight(item.Cells[2].Value.ToString() + "," + item.Cells[1].Value.ToString()));
                //    }
                //}

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








        /// <summary>
        /// 转换快件状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
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
