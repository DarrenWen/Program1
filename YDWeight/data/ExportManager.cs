using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace YDWeight.data
{
    public class ExportManager
    {
        
        /// <summary>
        /// 新控件导出数据
        /// </summary>
        /// <param name="gvInfo"></param>
        /// <param name="fileName"></param>
        public static void ExportDataGridViewToExcel(DataGridView gvInfo, string fileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl  files  (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "导出Excel文件到";
            DateTime now = DateTime.Now;
            saveFileDialog.FileName = fileName +DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day+ "(" + DateTime.Now.ToFileTime() + ")";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
                string str = "";
                try
                {
                    //写标题       
                    for (int i = 0; i < gvInfo.Columns.Count; i++)
                    {

                        if (gvInfo.Columns[i].Visible && gvInfo.Columns[i].HeaderText!="")
                        {
                            if (i > 1)
                            {
                                str += "\t";
                            }
                            str += gvInfo.Columns[i].HeaderText;
                        }
                    }
                    sw.WriteLine(str);
                    //写内容    
                    for (int j = 0; j < gvInfo.RowCount; j++)
                    {
                        string tempStr = "";
                        for (int k = 0; k < gvInfo.Columns.Count; k++)
                        {

                            if (gvInfo.Columns[k].Visible && gvInfo.Columns[k].HeaderText != "")
                            {
                                if (k > 1)
                                {
                                    tempStr += "\t";
                                }
                                if(gvInfo.Rows[j].Cells[k].Value != null)
                                {
                                    tempStr += gvInfo.Rows[j].Cells[k].Value.ToString().Replace("\r","");
                                }
                                else
                                {
                                    tempStr += "无";
                                }
                            }
                        }
                        sw.WriteLine(tempStr);
                    }
                    sw.Close();
                    myStream.Close();
                    DialogResult rs = MessageBox.Show("文件导出成功，是否打开导出的文件？","导出提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                    if(rs== DialogResult.OK)
                    {
                        Process.Start(saveFileDialog.FileName);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
    }
}
