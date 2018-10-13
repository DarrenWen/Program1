using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YDWeight.data
{
    public class TextHelper
    {
        public void Save(string text)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            DialogResult rs = saveFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                //获得文件路径
                string path = saveFileDialog1.FileName.ToString();
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                
                //开始写入
                sw.Write(text);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                rs = MessageBox.Show("文件导出成功，是否打开导出的文件？", "导出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    Process.Start(saveFileDialog1.FileName);
                }
            }
        }

        byte[] byData = new byte[100];
        char[] charData = new char[1000];

        public void StaticSave(string text,string filename)
        {

            //获得文件路径
            string path = filename + ".txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(text);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        public string StaticRead(string filename)
        {
            string path = filename + ".txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            
            sr.Close();
            fs.Close();
            return content;
        }

    }
}
