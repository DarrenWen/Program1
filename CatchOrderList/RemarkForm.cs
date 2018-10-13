using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class RemarkForm : Form
    {
        public RemarkForm(int id)
        {
            InitializeComponent();
            btnSave.Tag = id.ToString();
            Express.Model.OrderInfo info = new Express.BLL.OrderInfo().GetModel(id);
            if(null!=info)
            {
                textBox1.Text = info.Paream2;//显示备注信息
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(null!=btnSave.Tag)
            {
                int id = int.Parse(btnSave.Tag.ToString());
                Express.Model.OrderInfo info = new Express.BLL.OrderInfo().GetModel(id);
                info.Paream2 = textBox1.Text;
                new Express.BLL.OrderInfo().Update(info);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
