using CatchOrderList.data;
using CatchOrderList.data.ProcessStr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    if (weight <= 0 || weight > 2)
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
            List<string> orders = d as List<string>;
            foreach (var item in orders)
            {
                p.Start(item);
            }
        }
        int rowCount = 0;




        private void ShowChildData(DataTable dt)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<DataTable>(ShowChildData), dt);
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
            if (DoneProcessWeightCount != ReadyProcessWeightCount)
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
                if (item.Cells[3].Value == null || item.Cells[7].Value == null || string.IsNullOrEmpty(item.Cells[7].Value.ToString()))
                    continue;
                ChildOrderModel m = new ChildOrderModel();
                m.PID = item.Cells[3].Value.ToString();
                m.weight = double.Parse(item.Cells[7].Value.ToString().Trim());
                if (item.Cells[8].Value.ToString() == "需要人工处理")
                {
                    m.OrderNo = item.Cells[2].Value.ToString();//收集异常单号
                }
                infos.Add(m);
            }

            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (item.Cells[2].Value == null)
                    continue;
                string pid = item.Cells[2].Value.ToString().Trim();
                item.Cells[3].Value = infos.Where(u => u.PID == pid).Sum(u => u.weight);
                var orders = infos.Where(u => u.PID == pid && !string.IsNullOrEmpty(u.OrderNo)).Select(u => u.OrderNo).ToArray();
                if (null != orders && orders.Length > 0)
                    item.Cells[7].Value = string.Join("|", orders);
                item.Cells[8].Value = orders.Count();
            }

            GetJbWeight();

            MessageBox.Show("处理完成,请导出数据!!!");
        }

        /// <summary>
        /// 更新集包重量
        /// </summary>
        private void GetJbWeight()
        {
            if (JBDoneProcessWeightCount != JBReadyProcessWeightCount)
            {
                return;
            }
            PageDataProcess process = new PageDataProcess();
            process.setSigleData = SetJBData;

            ResetJBWeightParam();
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (item.Cells[2].Value != null && item.Cells[4].Value == null)
                {
                    JBReadyProcessWeightCount++;
                    progressBar2.Maximum++;
                    ThreadPool.QueueUserWorkItem(state => process.ProcessOrderWeight(item.Cells[2].Value.ToString() + "," + item.Cells[1].Value.ToString(), true));
                }
            }
        }


        private void SetJBData(string data)
        {
            if (!this.InvokeRequired)
            {
                try
                {
                    JBDoneProcessWeightCount++;
                    progressBar2.Value = JBDoneProcessWeightCount;
                    var datas = data.Split(',');
                    double weight = double.Parse(datas[1]);
                    int myrow = int.Parse(datas[0]) - 1;
                    gvInfo.Rows[myrow].Cells[9].Value = datas[2];
                    if (weight > 0)
                    {
                        JBSucessProcessWeightCount++;
                        gvInfo.Rows[myrow].Cells[4].Value = weight;

                        if (gvInfo.Rows[myrow].Cells[4].Value != null && gvInfo.Rows[myrow].Cells[3].Value != null)//计算误差值
                        {
                            var value = double.Parse(gvInfo.Rows[myrow].Cells[4].Value.ToString()) - double.Parse(gvInfo.Rows[myrow].Cells[3].Value.ToString());
                            gvInfo.Rows[myrow].Cells[5].Value = value;
                            if (gvInfo.Rows[myrow].Cells[7].Value != null && gvInfo.Rows[myrow].Cells[7].Value.ToString().Length > 1)
                            {
                                gvInfo.Rows[myrow].Cells[6].Value = String.Format("{0:F}", (value / (gvInfo.Rows[myrow].Cells[7].Value.ToString().Split('|').Length * 1d)));
                            }
                            else
                            {
                                gvInfo.Rows[myrow].Cells[6].Value = 0;
                            }
                        }
                    }


                    if (JBReadyProcessWeightCount == JBDoneProcessWeightCount && JBSucessProcessWeightCount != JBReadyProcessWeightCount)
                    {
                        JBRepeatCount--;
                        if (JBRepeatCount < 0)
                        {
                            MessageBox.Show("查询时间过长，系统已经自动取消，请再次点击纠错进行查询!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetWeightParam();
                        }
                        else
                        {
                            GetJbWeight();
                        }
                    }
                    ///统计完成，更新记录
                    if (JBSucessProcessWeightCount == JBReadyProcessWeightCount)
                    {
                        ProcessErrorOrders();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.Invoke(new Action<string>(SetJBData), data);
            }
        }

        /// <summary>
        /// 处理问题单号
        /// </summary>
        private void ProcessErrorOrders()
        {
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (item.Cells[4].Value != null && item.Cells[3].Value != null)//计算误差值
                {
                    var value = double.Parse(item.Cells[4].Value.ToString()) - double.Parse(item.Cells[3].Value.ToString());
                    item.Cells[5].Value = value;
                    if (item.Cells[7].Value != null && item.Cells[7].Value.ToString().Length > 1)
                    {
                        item.Cells[6].Value = String.Format("{0:F}", (value / (item.Cells[7].Value.ToString().Split('|').Length * 1d)));
                    }
                    else
                    {
                        item.Cells[6].Value = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 待处理的重量矫正数量
        /// </summary>
        private int JBReadyProcessWeightCount = 0;
        /// <summary>
        /// 已处理完的数量
        /// </summary>
        private int JBDoneProcessWeightCount = 0;
        /// <summary>
        /// 处理成功的数量
        /// </summary>
        private int JBSucessProcessWeightCount = 0;

        private bool JBIsComplate = false;

        private int JBRepeatCount = 5;



        private void ResetJBWeightParam()
        {
            JBIsComplate = false;
            JBDoneProcessWeightCount = 0;
            JBSucessProcessWeightCount = 0;
            JBReadyProcessWeightCount = 0;
            progressBar2.Value = 0;
            progressBar2.Maximum = 0;
            JBRepeatCount = 5;

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
            UpdateBigBagWeight();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void 一键生成异常单号列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            var rowcount = 0;
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if ((item.Cells[6].Value != null && !string.IsNullOrEmpty(item.Cells[6].Value.ToString())) && (item.Cells[7].Value != null && !string.IsNullOrEmpty(item.Cells[7].Value.ToString())))
                {
                    var infos = item.Cells[7].Value.ToString().Split('|');
                    var weight = item.Cells[6].Value.ToString();
                    dataGridView2.Rows.Add(infos.Count());

                    foreach (var citem in infos)
                    {
                        dataGridView2.Rows[rowcount].Cells[1].Value = rowcount + 1;
                        dataGridView2.Rows[rowcount].Cells[2].Value = citem.Replace("\r", "");
                        dataGridView2.Rows[rowcount].Cells[3].Value = weight;
                        rowcount++;
                    }
                }
            }
            tabControl1.SelectedIndex = 1;
        }

        private void 导出ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(dataGridView2, "待处理重量的单号");
        }

        private void 保存集包单号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\OrderFile";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DateTime beginTime = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString() + " 12:00:00");
            DateTime endTime = DateTime.Parse(DateTime.Now.ToShortDateString() + " 12:00:00");
            var currentDay = DateTime.Now;
            if (beginTime <= DateTime.Now && DateTime.Now <= endTime)//按之前一天计算
            {
                currentDay = currentDay.AddDays(-1);
            }
            string fileName = currentDay.Year + "_" + currentDay.Month + "_" + currentDay.Day+".txt";
            MatchEvaluator me = delegate (Match m)
            {
                return "\r\n";
            };
            string rep = Regex.Replace(textBox1.Text, @"\n", me);
            Write(path+"\\"+fileName,rep+"\r\n");
        }

        public void Write(string path,string data)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write(data);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                if(MessageBox.Show("保存成功，是否打开文件保存目录?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\OrderFile");
                }
            }
            catch (Exception)
            {
                
            }
        }
    }

    /// <summary>
    /// 子订单类
    /// </summary>
    public class ChildOrderModel
    {
        public string PID { get; set; }
        public double weight { get; set; }//重量
        /// <summary>
        /// 问题单号
        /// </summary>
        public string OrderNo { get; set; }
    }
}
