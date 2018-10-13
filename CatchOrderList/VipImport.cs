using CatchOrderList.data;
using NetUtilityLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class VipImport : Form
    {
        public VipImport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 读取指定路径的Excel内容到DataTable中
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable ImportToDataSet(string path, string sql)
        {
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(path))
                {
                    DataTable dt = excelHelper.ExcelToDataTable("order", true);
                    return dt;//PrintData(dt);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return null;

            //string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "Data Source=" + path + ";" + "Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";
            //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source=" + path + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {

                DataTable dt = new DataTable();
                if (conn.State != ConnectionState.Open)
                    conn.Open();


                DataTable dtDATAExcel = new System.Data.DataTable();
                DataTable dtDATA = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = dtDATA.Rows[0][2].ToString().Trim();


                string strExcel = "select  * from [" + sheetName + "]";
                if (sql == null)
                {
                    sql = strExcel;
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        /// <summary>
        /// 导入的数据信息
        /// </summary>
        private DataTable dtImportInfo;
        DateTime dtReciveDate;
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFile.Text))
            {
                try
                {
                    dtImportInfo = ImportToDataSet(txtFile.Text, null);
                    if (dtImportInfo.Rows.Count > 0)
                    {
                        if (ClientInfo.VIP_IsImportVal)
                        {
                            pbInfo.Maximum = dtImportInfo.Rows.Count - 1;
                            pbInfo.Value = 0;

                            dtReciveDate = DateTime.Parse(dtpReciveDate.Value.ToShortDateString());
                            btnImport.Enabled = false;
                            ProcessData();
                        }
                        else
                        {
                            pbInfo.Maximum = dtImportInfo.Rows.Count - 1;
                            pbInfo.Value = 0;

                            dtReciveDate = DateTime.Parse(dtpReciveDate.Value.ToShortDateString());
                            btnImport.Enabled = false;
                            ProcessData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入的记录存在异常数据，请检测修改后再进行导入操作！","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请选择有效的订单Excel文件!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private delegate void RefreshProcess();

        DataTable Import_dtInfo = null;
        private void ProcessData()
        {
            Import_dtInfo = new Express.BLL.OrgOrder().GetList(" 0=1").Tables[0];
            for (int i = 0; i < dtImportInfo.Rows.Count; i++)
            {
                ///过滤无用的单号信息
                //if (new Express.BLL.OrderInfo().GetRecordCount(string.Format(" orderno='{0}' and Daterecived=#{1}#", dtImportInfo.Rows[i][0].ToString(),dtReciveDate.Date)) <= 0)
                //{
                if (!string.IsNullOrEmpty(dtImportInfo.Rows[i][1].ToString()) && dtImportInfo.Rows[i][1].ToString().Length > 6)
                {
                    DataRow newrow = Import_dtInfo.NewRow();
                    newrow["orderno"] = dtImportInfo.Rows[i][0].ToString();
                    newrow["imtime"] = dtReciveDate.Date;
                    newrow["pid"] = dtImportInfo.Rows[i][1].ToString();
                    Import_dtInfo.Rows.Add(newrow);
                }
            }
            bool sucess = new Express.BLL.OrgOrder().AddByGroup(Import_dtInfo);
            MessageBox.Show("成功导入数据完成!共导入(" + (dtImportInfo.Rows.Count - 1) + ")票!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImport.Enabled = true;
        }

        private void RefreshClient()
        {
            if (!this.InvokeRequired)
            {
                pbInfo.Value++;
                if (pbInfo.Value == pbInfo.Maximum)
                {
                    bool sucess = new Express.BLL.OrderInfo().AddByGroup(Import_dtInfo);
                    MessageBox.Show("导入数据完成!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnImport.Enabled = true;
                }
            }
            else
            {
                this.Invoke(new RefreshProcess(RefreshClient));
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtFile.Text = OpenFile();
        }

        public static string OpenFile()
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = @"Excel文件(*.xls)|*.xls|所有文件(*.*)|*.xls";
            opd.FilterIndex = 1;
            //opd.InitialDirectory = @"c:\";
            DialogResult result = opd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return opd.FileName;
            }
            return String.Empty;
        }
    }
}
