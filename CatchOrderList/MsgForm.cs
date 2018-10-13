using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class MsgForm : Form
    {
        public MsgForm(int id)
        {
            InitializeComponent();
            Express.Model.OrderInfo model = new Express.BLL.OrderInfo().GetModel(id);
            if(model!=null)
            {
                string filename = model.Id+".html";
                Write(filename, model.Paream3);

                string url = Application.StartupPath + @"\datamsg\" + filename;
                if(File.Exists(url))
                {
                    webBrowser1.Url = new Uri(url);
                }
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        public void Write(string fileName, string text)
        {
            if (!Directory.Exists(Application.StartupPath + @"\datamsg\"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\datamsg\");
            }
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream fs = new FileStream(Application.StartupPath + @"\datamsg\" + fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }

        private void MsgForm_Load(object sender, EventArgs e)
        {

        }
    }
}
