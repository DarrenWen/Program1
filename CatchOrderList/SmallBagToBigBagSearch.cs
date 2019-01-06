using CatchOrderList.data;
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
    public partial class SmallBagToBigBagSearch : Form
    {
        PageDataProcess pageProcess = new PageDataProcess();
        /// <summary>
        /// 待处理的重量矫正数量
        /// </summary>
        private int ReadyProcessWeightCount = 0;
        /// <summary>
        /// 已处理完的数量
        /// </summary>
        private int DoneProcessWeightCount = 0;
        /// <summary>
        /// 处理成功的数量
        /// </summary>
        private int SucessProcessWeightCount = 0;

        private bool IsComplate = false;

        private int RepeatCount = 5;


        public SmallBagToBigBagSearch()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddBigData();
        }


        private void AddBigData()
        {
            gvInfo.Rows.Clear();
            string[] infos = textBox1.Text.Trim().Split('\n');

            List<string> orders = new List<string>();
            for (int i = 0; i < infos.Length; i++)
            {
                if (!CheckIsExistsOrder(orders, infos[i]))
                {
                    orders.Add(infos[i]);
                }
            }

            gvInfo.Rows.Add(orders.Count);
            var rowcount = 0;
            foreach (var item in orders)
            {
                gvInfo.Rows[rowcount].Cells[1].Value = rowcount + 1;
                gvInfo.Rows[rowcount].Cells[2].Value = item.Replace("\r", "");
                gvInfo.Rows[rowcount].Cells[3].Value = "";
                rowcount++;
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

        private void 快速查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetWeight();
        }

        private void GetWeight()
        {
            if (DoneProcessWeightCount != ReadyProcessWeightCount)
            {
                return;
            }
            ResetWeightParam();
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (item.Cells[1].Value == null)
                    continue;
                if (item.Cells[3].Value == null || string.IsNullOrEmpty(item.Cells[3].Value.ToString()))
                {
                    ReadyProcessWeightCount++;
                    progressBar1.Maximum++;
                    ThreadPool.QueueUserWorkItem(state => pageProcess.GetOrderBigOrder(item.Cells[2].Value.ToString() + "," + item.Cells[1].Value.ToString()));
                }
            }
        }

        private void ResetWeightParam()
        {
            IsComplate = false;
            DoneProcessWeightCount = 0;
            SucessProcessWeightCount = 0;
            ReadyProcessWeightCount = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = 0;
            RepeatCount = 5;

        }

        private void SmallBagToBigBagSearch_Load(object sender, EventArgs e)
        {
            pageProcess.GetBigOrderInfo = SetData;
        }


        private void SetData(string data)
        {
            if (!this.InvokeRequired)
            {
                try
                {
                    DoneProcessWeightCount++;
                    progressBar1.Value = DoneProcessWeightCount;
                    string order = data.Split(',')[1];
                    int myrow = int.Parse(data.Split(',')[0]) - 1;

                    if (!string.IsNullOrEmpty(order))
                    {
                        SucessProcessWeightCount++;
                    }
                    gvInfo.Rows[myrow].Cells[3].Value = order;

                    if (ReadyProcessWeightCount == DoneProcessWeightCount && SucessProcessWeightCount != ReadyProcessWeightCount)
                    {
                        RepeatCount--;
                        if (RepeatCount < 0)
                        {
                            MessageBox.Show("查询时间过长，系统已经自动取消，请再次点击纠错进行查询!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetWeightParam();
                        }
                        else
                        {
                            GetWeight();
                        }
                    }
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

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(gvInfo, "小包单号-->集包单号");
        }

        private void gvInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string orderno = gvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                pageProcess.RedirectUrl(orderno);
            }
        }
    }
}
