using CatchOrderList.data;
using NetUtilityLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class ImportForm : Form
    {
        private ImportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 导入的数据信息
        /// </summary>
        private DataTable dtImportInfo;

        private static ImportForm thisForm;

        int cid=0;
        int sid = 0;
        DateTime dtReciveDate=DateTime.Now;
        public static ImportForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new ImportForm();
                }
                return ImportForm.thisForm; }
            set { ImportForm.thisForm = value; }
        }

        /// <summary>
        /// 数据过滤，过滤当前相同单号的数据
        /// </summary>
        private void DataFilter()
        {

        }

        /// <summary>
        /// 初始化数据信息
        /// </summary>
        private void InitialData()
        {
            List<Express.Model.CustomerInfo> infos = new Express.BLL.CustomerInfo().GetModelList("");
            this.ddlCustomer.DisplayMember = "cusname";
            this.ddlCustomer.ValueMember = "cid";
            this.ddlCustomer.DataSource = infos;
            List<Express.Model.Sys_User> users = new Express.BLL.Sys_User().GetModelList(" UState=0 and issaleman=true");
            this.ddlSaleMan.DisplayMember = "PerName";
            this.ddlSaleMan.ValueMember = "UID";
            this.ddlSaleMan.DataSource = users;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (null != ddlCustomer.SelectedValue)
            {
                if (File.Exists(txtFile.Text))
                {
                    dtImportInfo = ImportToDataSet(txtFile.Text, null);
                    if (dtImportInfo.Rows.Count > 0)
                    {
                        string titile = dtImportInfo.Rows[0][0].ToString();
                        if (ClientInfo.VIP_IsImportVal)
                        {
                            //if (titile == "运单号码")
                            //{
                                pbInfo.Maximum = dtImportInfo.Rows.Count - 1;
                                pbInfo.Value = 0;
                                cid = null == ddlCustomer.SelectedValue ? 0 : Convert.ToInt32(ddlCustomer.SelectedValue);
                                sid = Convert.ToInt32(ddlSaleMan.SelectedValue);
                                dtReciveDate = dtpReciveDate.Value;
                                btnImport.Enabled = false;
                                //Thread tdMain = new Thread(new ThreadStart(ProcessData));
                                //tdMain.IsBackground = true;
                                //tdMain.Start();
                                ProcessData();
                            //}
                        }
                        else
                        {
                            pbInfo.Maximum = dtImportInfo.Rows.Count - 1;
                            pbInfo.Value = 0;
                            cid = null == ddlCustomer.SelectedValue ? 0 : Convert.ToInt32(ddlCustomer.SelectedValue);
                            sid = Convert.ToInt32(ddlSaleMan.SelectedValue);
                            dtReciveDate = dtpReciveDate.Value;
                            btnImport.Enabled = false;
                            //Thread tdMain = new Thread(new ThreadStart(ProcessData));
                            //tdMain.IsBackground = true;
                            //tdMain.Start();
                            ProcessData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选择有效的订单Excel文件!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请选择一个默认的收件客户!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private delegate void RefreshProcess();

        DataTable Import_dtInfo = null;
        private void ProcessData()
        {
            Import_dtInfo = new Express.BLL.OrderInfo().GetList(" 0=1").Tables[0];
            for (int i = 0; i < dtImportInfo.Rows.Count; i++)
            {
                ///过滤无用的单号信息
                //if (new Express.BLL.OrderInfo().GetRecordCount(string.Format(" orderno='{0}' and Daterecived=#{1}#", dtImportInfo.Rows[i][0].ToString(),dtReciveDate.Date)) <= 0)
                //{
                if (!string.IsNullOrEmpty(dtImportInfo.Rows[i][0].ToString()) && dtImportInfo.Rows[i][0].ToString().Length > 6)
                {
                    DataRow newrow = Import_dtInfo.NewRow();
                    newrow["OrderNo"] = dtImportInfo.Rows[i][0].ToString();
                    newrow["CustomerID"] = cid;
                    newrow["SalesmanID"] = sid;
                    newrow["Daterecived"] = dtReciveDate.Date;
                    newrow["Contractdate"] = dtReciveDate.Date;
                    newrow["OperUser"] = ClientInfo.Sys_UserInfo.username;
                    newrow["UserDate"] = DateTime.Now;

                    newrow["OState"] = 0;
                    newrow["ORState"] = 0;
                    Import_dtInfo.Rows.Add(newrow);
                }
                    //Express.Model.OrderInfo orderInfo = new Express.Model.OrderInfo();
                    //orderInfo.CustomerID = cid;
                    //orderInfo.SalesmanID = sid;
                    //orderInfo.OrderNo = dtImportInfo.Rows[i][0].ToString();
                    //orderInfo.Daterecived = dtReciveDate.Date;
                    //orderInfo.Contractdate = orderInfo.Daterecived;
                    //orderInfo.OperUser = ClientInfo.Sys_UserInfo.username;
                    //orderInfo.UserDate = DateTime.Now;
                    //new Express.BLL.OrderInfo().Add(orderInfo);
                //}
                //RefreshClient();
            }
            bool sucess = new Express.BLL.OrderInfo().AddByGroup(Import_dtInfo);
            MessageBox.Show("成功导入数据完成!共导入(" + (dtImportInfo.Rows.Count-1) + ")票!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImport.Enabled = true;
        }

        private void RefreshClient()
        {
            if (!this.InvokeRequired)
            {
                pbInfo.Value++;
                if(pbInfo.Value==pbInfo.Maximum)
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
            catch (Exception ex)
            {

                throw;
            }
            //return null ;
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


                string strExcel = "select  * from ["+sheetName+"]";
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

        private void ImportForm_Load(object sender, EventArgs e)
        {
            InitialData();
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
            opd.InitialDirectory = @"c:\";
            DialogResult result = opd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return opd.FileName;
            }
            return String.Empty;
        }
    }
}
