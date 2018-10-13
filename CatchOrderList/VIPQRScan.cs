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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class VIPQRScan : Form
    {
        public VIPQRScan()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            gvInfo.Rows.Clear();
            string[] infos = textBox1.Text.Trim().Replace(" ","").Replace("\r", "").Split('\n');

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

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            gvInfo.Rows.Clear();
        }

        List<OrgOrder> orgSource = new List<OrgOrder>();
        List<CusInfo> cusSource = new List<CusInfo>();

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orgSource.Count < 1)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                Task<List<OrgOrder>> t = new Task<List<OrgOrder>>(n => new Express.BLL.OrgOrder().GetModelList(""), cts.Token);
                t.ContinueWith(task => ShowData(task.Result));
                t.Start();
            }
            else
            {
                ShowData(orgSource);
            }
        }

        private void ShowData(List<OrgOrder> infos)
        {
            if(orgSource.Count<1)
            orgSource = infos;
            foreach (DataGridViewRow item in gvInfo.Rows)
            {
                if (null == item.Cells[2].Value)
                    continue;
                string order = item.Cells[2].Value.ToString();
                List<string> pid = (from u in infos where u.pid == order select u.orderno).ToList();
                string oid = pid.Count > 0 ? pid[0] : "";
                item.Cells[3].Value = oid;
                List<string> pname = (from u in cusSource where u.cid == oid select u.name).ToList(); 
                item.Cells[4].Value = pname.Count > 0 ? pname[0] : "";
                item.Cells[5].Value = "已处理";
            }
        }

        private void VIPQRScan_Load(object sender, EventArgs e)
        {
            string data = new TextHelper().StaticRead("cusdata");
            foreach (var item in data.Split('\n'))
            {
                if (item.Contains(','))
                {
                    if (string.IsNullOrEmpty(item.Split(',')[0]))
                    {
                        continue;
                    }
                    CusInfo m = new CusInfo();
                    m.cid = item.Split(',')[0];
                    m.name = item.Split(',')[1];
                    cusSource.Add(m);
                }
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(gvInfo, "VIP反向查单");
        }

        private void 统计数量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
           var query = from d in tempDatas group d by new { d.cid,d.name } into s select new { cid=s.Key.cid,cname=s.Key.name,total=s.Sum(m=>1)};
            dataGridView1.Rows.Add(query.Count());
            int rowcount = 0;
            foreach (var item in query)
            {
                dataGridView1.Rows[rowcount].Cells[1].Value = rowcount + 1;
                dataGridView1.Rows[rowcount].Cells[2].Value = item.cid;
                dataGridView1.Rows[rowcount].Cells[3].Value = item.cname;
                dataGridView1.Rows[rowcount].Cells[4].Value = item.total;
                rowcount++;
            }
        }
        /// <summary>
        /// 取出记录中的数据
        /// </summary>
        List<CusInfo> tempDatas
        {
            get
            {
                List<CusInfo> infos = new List<CusInfo>();
                foreach (DataGridViewRow item in gvInfo.Rows)
                {
                    if (null == item.Cells[2].Value)
                        continue;
                    string order = item.Cells[2].Value.ToString();

                    CusInfo info = new CusInfo();

                    info.cid = item.Cells[3].Value.ToString();
                    info.name = item.Cells[4].Value.ToString();

                    infos.Add(info);
                }
                return infos;
            }
        }

        private void 导出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExportManager.ExportDataGridViewToExcel(dataGridView1, "VIP反向查单汇总表");
        }
    }



    /// <summary>
    /// 用户信息
    /// </summary>
    public class CusInfo
    {
        public string cid { get; set; }
        public string name { get; set; }
    }
}
