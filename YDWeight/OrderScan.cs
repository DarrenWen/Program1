using MainContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using YDWeight.data;

namespace YDWeight
{
    public partial class OrderScan : Form
    {
        MainDataContext db = new MainDataContext();
        private SerialPort ComDevice = new SerialPort();
        SoundPlayer p = new SoundPlayer();
        public OrderScan()
        {
            InitializeComponent();
            //向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }

        private void OrderScan_Load(object sender, EventArgs e)
        {
            ddlSerLength.SelectedIndex = 0;
            cbCount.SelectedIndex = 0;
            var a = from t in db.OrderWeights where Convert.ToDateTime(t.ScanTime) < DateTime.Now select t;

            var b = a.ToList();


            p.SoundLocation = Application.StartupPath + "//1.wav";
            p.Load();
            //byte[] bts = HexStrTobyte("0A 77 6E 30 30 30 30 2E 31 32 6B 67 0D");

            SysSetModel config = ConfigManager.MyConfig;
            if (config == null)
            {
                MessageBox.Show("未检测到串口设置信息，请先设置串口信息!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // this.Close();
            }
            else
            {

                //设置串口相关属性
                ComDevice.PortName = config.Com;
                ComDevice.BaudRate = int.Parse(config.Rate);
                ComDevice.Parity = (Parity)0;
                ComDevice.DataBits = 8;
                ComDevice.StopBits = (StopBits)1;
                try
                {
                    //开启串口
                    ComDevice.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // MessageBox.Show(data);
        }

        /// <summary>
        /// 一旦ComDevice.DataReceived事件发生，就将从串口接收到的数据显示到接收端对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private List<byte> buffer = new List<byte>(4096);
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                //开辟接收缓冲区
                byte[] ReDatas = new byte[ComDevice.BytesToRead];
                //从串口读取数据
                ComDevice.Read(ReDatas, 0, ReDatas.Length);

                buffer.AddRange(ReDatas);
                if (buffer.Count > 12 && buffer[12] != 0x0d)
                {
                    buffer.Clear();
                }
                if (buffer.Count > 0 && buffer[0] != 0x0a)
                {
                    buffer.Clear();
                }

                if (buffer.Count > 12)
                {
                    //实现数据的解码与显示
                    if (buffer[0] == 0x0a && buffer[12] == 0x0d)
                    {
                        byte[] nowbyte = buffer.ToArray();
                        lock (this)
                        {
                            
                            try
                            {
                                BeginInvoke(new MethodInvoker(delegate
                                {
                                    string data = Encoding.ASCII.GetString(nowbyte, 0, 13);
                                    double weight = 0d;
                                    if (double.TryParse(Encoding.ASCII.GetString(nowbyte, 3, 7), out weight))
                                    {
                                        txtWeight.Text = weight + Encoding.ASCII.GetString(nowbyte, 10, 2);
                                    }
                                    buffer.Clear();
                                }));
                            }
                            catch (Exception ex)
                            {
                                // buffer.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        // 16进制字符串转字节数组   格式为 string sendMessage = "00 01 00 00 00 06 FF 05 00 64 00 00";
        private static byte[] HexStrTobyte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);
            return returnBytes;
        }
        /// <summary>
        /// 新增一行记录信息
        /// </summary>
        private void AddRow(OrderWeight m)
        {
            gvInfo.Rows.Add(1);
            int rowindex = gvInfo.Rows.Count-2;
            gvInfo.Rows[rowindex].Cells[1].Value = (rowindex + 1).ToString();
            gvInfo.Rows[rowindex].Cells[2].Value =  m.OrderId;
            gvInfo.Rows[rowindex].Cells[3].Value = m.ScanTime;

            gvInfo.Rows[rowindex].Cells[4].Value = m.EmName;

            gvInfo.Rows[rowindex].Cells[5].Value = m.Weight.ToString();
            gvInfo.Rows[rowindex].Cells[6].Value = m.Count.ToString();
           
        }
        SpeechSynthesizer synth = new SpeechSynthesizer();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSerno.Text))
                {
                    NoticeInfo("快递单号不能为空!");
                    txtSerno.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtWeight.Text))
                {
                    NoticeInfo("货物重量不能为空!");
                    txtSerno.Focus();
                    return;
                }
                if(txtSerno.Text.Length!=Convert.ToInt32(ddlSerLength.Text))
                {
                    
                    NoticeInfo("单号长度有误，请重新扫描!");
                    txtSerno.Focus();
                    txtSerno.SelectAll();
                    return;
                }
                if (db.ExecuteQuery<OrderWeight>("select * from OrderWeight where OrderId='"+txtSerno.Text.Trim()+"'").Count()>0)
                {
                    NoticeInfo("该单号在数据库中已经存在，不用再重新扫描!");
                    txtSerno.Focus();
                    txtSerno.SelectAll();
                    return;
                }
                OrderWeight orderWeight = new OrderWeight();
                orderWeight.CreateOn = DateTime.Now.ToString();
                orderWeight.CreateBy = 1;
                orderWeight.OrderId = txtSerno.Text.Trim();
                orderWeight.Weight = double.Parse(txtWeight.Text.ToLower().Replace("kg", ""));
                orderWeight.ScanTime = DateTime.Now.ToString();
                orderWeight.Count = int.Parse(cbCount.Text);
                orderWeight.EmName = txtCollector.Text;
                orderWeight.EmNo = txtCollector.Tag.ToString();
                db.OrderWeights.InsertOnSubmit(orderWeight);
                AddRow(orderWeight);
                db.SubmitChanges();
                Clear();
                p.Play();
            }
            catch (Exception)
            {
                
            }
        }

        private void NoticeInfo(string msg)
        {
            synth.SpeakAsync(msg);
            MessageBox.Show(msg, "系统提示");
        }

       

        private void Clear()
        {
            try
            {
                txtSerno.Clear();
                txtWeight.Text = "0.00";
            }
            catch (Exception)
            {
                
            }
            
        }

        Employee EmployeeForm = new Employee();
        private void btn01_Click(object sender, EventArgs e)
        {
            if (EmployeeForm.ShowDialog()== DialogResult.OK)
            {
                txtCollector.Text = EmployeeForm.selectedModel.UserName;
                txtCollector.Tag = EmployeeForm.selectedModel.Code;
            }
        }

        private void OrderScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                ComDevice.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(gvInfo, "快件称重订单查询");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除以后的数据将无法恢复，确认要这样操作吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string sql = "delete FROM OrderWeight where 1>0 ";
                //sql = GetCondition(sql);
                int result = db.ExecuteCommand(sql);
                gvInfo.Rows.Clear();
            }
        }
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string GetCondition(string sql)
        {
            string sernos = "'0'";
            foreach (DataGridViewRow item in gvInfo.SelectedRows)
            {
                sernos += ",'"+item.Cells[2].Value+"'";
            }
            if (sernos.Contains(","))
            {
                string[] dts = sernos.Replace("'", "").Split(',');
                for (int i = 0; i < dts.Length; i++)
                {
                    foreach (DataGridViewRow item in gvInfo.SelectedRows)
                    {
                        if (item.Cells[2].Value.ToString()==dts[i])
                        {
                            gvInfo.Rows.Remove(item);
                            break;
                        }
                    }
                }
            }
            sql += " and OrderId in("+sernos+")";
         
            return sql;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除以后的数据将无法恢复，确认要这样操作吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string sql = "delete FROM OrderWeight where 1>0";
                sql = GetCondition(sql);
                int result = db.ExecuteCommand(sql);
            }
        }
    }
}
