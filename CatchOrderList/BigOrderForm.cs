﻿using CatchOrderList.data;
using CatchOrderList.data.ProcessStr;
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
    public partial class BigOrderForm : Form
    {
        public BigOrderForm()
        {
            InitializeComponent();
            pageProcess.setSigleData = SetData;
            p.SetData = new Action<DataTable>(ShowChildData);
            //ExecutionContext.SuppressFlow();//取消流动
        }

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

        private void SetData(string data)
        {
            if (!this.InvokeRequired)
            {
                try
                {
                    DoneProcessWeightCount++;
                    progressBar1.Value = DoneProcessWeightCount;
                    double weight = double.Parse(data.Split(',')[1]);
                    int myrow = int.Parse(data.Split(',')[0]) - 1;
                    dataGridView1.Rows[myrow].Cells[7].Value = weight < 0 || weight > 2 ? 0 : weight;
                    if (weight > 0)
                    {
                        dataGridView1.Rows[myrow].Cells[8].Value = "已完成";
                    }
                    if (weight < 0 || weight > 2)
                    {
                        dataGridView1.Rows[myrow].Cells[8].Value = "需要人工处理";
                    }

                    if (weight != 0)
                    {
                        SucessProcessWeightCount++;
                    }

                    switch (dataGridView1.Rows[myrow].Cells[8].Value.ToString())
                    {
                        case "已完成":
                            this.dataGridView1.Rows[myrow].DefaultCellStyle.ForeColor = Color.Green;
                            break;
                        case "需要人工处理":
                            this.dataGridView1.Rows[myrow].DefaultCellStyle.ForeColor = Color.Red;
                            break;
                        default:
                            this.dataGridView1.Rows[myrow].DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
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
                    ///统计完成，更新记录
                    if (SucessProcessWeightCount == ReadyProcessWeightCount)
                    {
                        UpdateBigBagWeight();
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

        private bool CheckIsExistsOrder(List<string> infos,string d)
        {
            bool isE = false;
            for (int i = 0; i < infos.Count; i++)
            {
                if(d==infos[i])
                {
                    isE = true;
                    break;
                }
            }
            return isE;
        }

        private void AddBigData()
        {
            gvInfo.Rows.Clear();
            string[] infos = textBox1.Text.Trim().Split('\n');

            List<string> orders = new List<string>();
            for (int i = 0; i < infos.Length; i++)
            {
                if(!CheckIsExistsOrder(orders,infos[i]))
                {
                    orders.Add(infos[i]);
                }
            }

            gvInfo.Rows.Add(orders.Count);
            var rowcount = 0;
            foreach (var item in orders)
            {
                gvInfo.Rows[rowcount].Cells[1].Value = rowcount+1;
                gvInfo.Rows[rowcount].Cells[2].Value = item.Replace("\r","");
                gvInfo.Rows[rowcount].Cells[3].Value = "0";
                rowcount++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            gvInfo.Rows.Clear();
        }
        BigBagProcess p = new BigBagProcess();
        PageDataProcess pageProcess = new PageDataProcess();
        
       
        private void 采集数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetWeightParam();
            dataGridView1.Rows.Clear();
            rowCount = 0;
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (item.Cells[2].Value == null)
                    continue;

                string orderno = item.Cells[2].Value.ToString();
                ThreadPool.QueueUserWorkItem(state => p.Start(orderno));
            }
        }
        


        private void DataCatch(object d)
        {
            List<string> orders =  d as List<string>;
            foreach (var item in orders)
            {
                p.Start(item);
            }
        }
        int rowCount = 0;


        

        private void ShowChildData(DataTable dt)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action<DataTable>(ShowChildData),dt);
                return;
            }
            
            if (dt.Rows.Count < 1)
                return;
            
                dataGridView1.Rows.Add(dt.Rows.Count);
                foreach (DataRow item in dt.Rows)
                {
                    var i = 0;
                    dataGridView1.Rows[rowCount].Cells[0].Value = item[i];
                    i++;
                    dataGridView1.Rows[rowCount].Cells[1].Value = rowCount + 1;
                    dataGridView1.Rows[rowCount].Cells[2].Value = item[i++];
                    dataGridView1.Rows[rowCount].Cells[3].Value = item[6];
                    dataGridView1.Rows[rowCount].Cells[4].Value = item[i++];
                    i++;
                    dataGridView1.Rows[rowCount].Cells[5].Value = item[i++];
                    dataGridView1.Rows[rowCount].Cells[6].Value = item[i++].ToString().Trim();
                    dataGridView1.Rows[rowCount].Cells[7].Value = "0";
                    dataGridView1.Rows[rowCount].Cells[8].Value = "未纠正";

                    if (dataGridView1.Rows[rowCount].Cells[8].Value.ToString() == "未纠正")
                        this.dataGridView1.Rows[rowCount].DefaultCellStyle.ForeColor = Color.Black;
                    else
                        this.dataGridView1.Rows[rowCount].DefaultCellStyle.ForeColor = Color.Green;
                    rowCount++;
                }
        }

        private void 数据纠偏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetWeight();
        }

        private void GetWeight()
        {
            if(DoneProcessWeightCount!=ReadyProcessWeightCount)
            {
                return;
            }
            ResetWeightParam();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[2].Value != null && item.Cells[8].Value.ToString() == "未纠正")
                {
                    ReadyProcessWeightCount++;
                    progressBar1.Maximum++;
                    ThreadPool.QueueUserWorkItem(state => pageProcess.ProcessOrderWeight(item.Cells[2].Value.ToString() + "," + item.Cells[1].Value.ToString()));
                }
            }
        }


        private void UpdateBigBagWeight()
        {
            List<ChildOrderModel> infos = new List<ChildOrderModel>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[3].Value == null|| item.Cells[7].Value==null|| string.IsNullOrEmpty(item.Cells[7].Value.ToString()))
                    continue;
                ChildOrderModel m = new ChildOrderModel();
                m.PID = item.Cells[3].Value.ToString();
                m.weight = double.Parse(item.Cells[7].Value.ToString().Trim());
                infos.Add(m);
            }

            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (item.Cells[2].Value == null)
                    continue;
                string pid = item.Cells[2].Value.ToString().Trim();
                item.Cells[3].Value = infos.Where(u => u.PID == pid).Sum(u=>u.weight);
            }


            MessageBox.Show("处理完成,请导出数据!!!");
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

        private void button3_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(gvInfo, "集包单号");
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(dataGridView1, "集包子单号");
        }

        private void gvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (gvInfo.Rows[e.RowIndex].Cells[2].Value == null)
                    return;
                string url = "http://kjcx.yundasys.com/kjcx/dbdb.php?dbtxm=" + gvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                System.Diagnostics.Process.Start(url);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string orderno = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                pageProcess.RedirectUrl(orderno);
            }
        }

        private void BigOrderForm_Load(object sender, EventArgs e)
        {
            ///不允许排序
            foreach (DataGridViewColumn item in gvInfo.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            ///不允许排序
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddBigData();
        }

        private void 更新集包重量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    try
            //    {
            //        if (item.Cells[3].Value == null)
            //            continue;
            //        if (null == item.Cells[7].Value || string.IsNullOrEmpty(item.Cells[7].Value.ToString()) || double.Parse(item.Cells[7].Value.ToString().Trim()) <= 0 || double.Parse(item.Cells[7].Value.ToString().Trim()) > 2)
            //        {
            //            MessageBox.Show("检测到错误选项,行号"+(item.Index+1), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            item.Cells[7].Selected=true;
            //            return;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("检测到错误选项,行号"+(item.Index+1), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        break;
            //    }
            //}
            UpdateBigBagWeight();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }

    /// <summary>
    /// 子订单类
    /// </summary>
    public class ChildOrderModel
    {
        public string PID { get; set; }
        public double weight { get; set; }
    }
}
