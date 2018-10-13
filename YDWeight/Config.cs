using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDWeight.data;

namespace YDWeight
{
    public partial class Config : Form
    {
        //定义端口类
        private SerialPort ComDevice = new SerialPort();
        public Config()
        {
            InitializeComponent();
            InitalPort();
        }

        private void InitalPort()
        {
            //查询主机上存在的串口
            comboBox_Port.Items.AddRange(SerialPort.GetPortNames());

            if (comboBox_Port.Items.Count > 0)
            {
                comboBox_Port.SelectedIndex = 0;
            }
            else
            {
                comboBox_Port.Text = "未检测到串口";
            }


            for (int i = 1; i <= 4; i++)
            {
                cbBtl.Items.Add(i*1200);
            }
            cbBtl.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SysSetModel m = new SysSetModel();
            m.Com = comboBox_Port.Text;
            m.Rate = cbBtl.Text;
            ConfigManager.MyConfig = m;
            this.DialogResult = DialogResult.OK;
        }

        private void Config_Load(object sender, EventArgs e)
        {
            SysSetModel m = ConfigManager.MyConfig;

            if (m!=null)
            {
                comboBox_Port.Text = m.Com;
                cbBtl.Text = m.Rate;
            }
        }
    }
}
