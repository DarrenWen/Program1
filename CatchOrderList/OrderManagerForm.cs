using CatchOrderList.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Express.Common;
using System.Threading;
using System.IO;
namespace CatchOrderList
{
    public partial class OrderManagerForm : Form
    {
        public OrderManagerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 处理的记录数
        /// </summary>
        private int TotalProcessRecord = 0;
        //开始处理时间
        private DateTime DtStart = DateTime.Now;
        

        private static OrderManagerForm thisForm;

        public static OrderManagerForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new OrderManagerForm();
                }
                return OrderManagerForm.thisForm; }
            set { OrderManagerForm.thisForm = value; }
        }


        int RowIndex = 0;

        /// <summary>
        /// 初始化数据信息
        /// </summary>
        private void InitialData()
        {
            List<Express.Model.CustomerInfo> infos = new Express.BLL.CustomerInfo().GetModelList("");
            TreeNode pnode = new TreeNode();
            pnode.Text = ClientInfo.SysSetInfo.cusname;
            pnode.Tag = 0;
            pnode.ImageIndex = 0;
            for (int i = 0; i < infos.Count; i++)
            {
                TreeNode cnode = new TreeNode();
                cnode.Text = infos[i].cusname;
                cnode.ImageIndex = 1;
                cnode.Tag = infos[i].cid;
                pnode.Nodes.Add(cnode);
            }

            tvCustomer.Nodes.Add(pnode);
            List<Express.Model.Sys_User> users = new Express.BLL.Sys_User().GetModelList(" UState=0 and issaleman=true");
            users.Insert(0, new Express.Model.Sys_User() {  UID=0, PerName="==请选择=="});
            this.ddlSaleMan.DisplayMember = "PerName";
            this.ddlSaleMan.ValueMember = "UID";
            this.ddlSaleMan.DataSource = users;
            cbOrderState.SelectedIndex = 0;
            cbCatchState.SelectedIndex = 0;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string SearchCondition()
        {
            if (!this.InvokeRequired)
            {
                string condition = " 0=0 ";
                if (cbChuidan.Checked)
                {
                    condition += " and orstate=1 ";
                }
                if (cbnoWeight.Checked)
                {
                    condition += " and Paream7=0 ";
                }
                if (!string.IsNullOrEmpty(txtKeyWord.Text))
                {
                    condition += string.Format(" and (Address like '%{0}%' or OrderNo like '%{0}%' or Paream4 like '%{0}%')", txtKeyWord.Text);
                }
                if (SelectedCid != "0")
                {
                    condition += " and CustomerID in(" + SelectedCid + ")";
                }
                if (ddlSaleMan.SelectedIndex > 0)
                {
                    condition += " and SalesmanID=" + ddlSaleMan.SelectedValue;
                }
                if (cbReciveDate.Checked)
                {
                    DateTime dtMiddle = DateTime.Now;

                    if (dtpEnd.Value < dtpReciveDate.Value)
                    {
                        dtMiddle = dtpEnd.Value;
                        dtpEnd.Value = dtpReciveDate.Value;
                        dtpReciveDate.Value = dtMiddle;

                    }

                    condition += " and Daterecived between #" + dtpReciveDate.Value.Date + "# and #" + dtpEnd.Value.AddHours(1) + "#";
                }

                switch (cbMessageState.SelectedIndex)
                {
                    case 1:
                        condition += " and len(Paream3)>30";
                        break;
                    case 2:
                        condition += " and len(Paream3)<=30";
                        break;
                    default:
                        break;
                }

                if (cbOrderState.SelectedIndex > 0)
                {
                    switch (cbOrderState.SelectedIndex)
                    {
                        case 2:
                            condition += " and OState <> 1";
                            break;
                        case 1:
                            condition += " and OState = 1";
                            break;
                        case 5:
                            condition += " and OState = 0";
                            break;
                        case 6:
                            condition += " and OState = 4";
                            break;
                        default:
                            condition += " and OState = " + (cbOrderState.SelectedIndex - 1);
                            break;
                    }
                }
                if (cbCatchState.SelectedIndex > 0)
                {
                    condition += " and Merchandiser = " + (cbCatchState.SelectedIndex);
                }

                if(cbReturn.Checked)
                {
                    condition += " and paream6 = " + 1;
                }

                //for (int i = 0; i < cblError.Items.Count; i++)
                //{
                //    if (cblError.GetItemChecked(i))
                //    {
                //        condition += " and mid(paream4,"+(i+1)+",1)='1'";
                //    }
                //}


                return condition;
            }
            else
            {
                this.Invoke(new NoneParamReturnDel(SearchCondition));
            }
            return "";
        }

        private delegate string NoneParamReturnDel();

        /// <summary>
        /// 选择的客户ID值
        /// </summary>
        private string SelectedCid
        {
            get
            {
                string ids = "0";
                for (int i = 0; i < tvCustomer.Nodes[0].Nodes.Count; i++)
                {
                    if(tvCustomer.Nodes[0].Nodes[i].Checked)
                    {
                        ids += ","+tvCustomer.Nodes[0].Nodes[i].Tag;
                    }
                }
                return ids;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPage();
            LoadData();
        }

        private void LoadPage()
        {
            this.anpageinfo.RecordCount = new Express.BLL.OrderView().GetRecordCount(SearchCondition());
            this.anpageinfo.PageIndex = 1;
            int pageCount = anpageinfo.RecordCount / anpageinfo.PageSize;
            if(anpageinfo.RecordCount%anpageinfo.PageSize!=0)
            {
                pageCount++;
            }
            this.anpageinfo.Tag = pageCount;
        }

        private void LoadData()
        {
            this.anpageinfo.Refresh();
            gvInfo.Rows.Clear();
            int pagesize = PageSize;
            
            DataTable dt = new Express.BLL.OrderView().GetListByPage(SearchCondition(), "id", pagesize, anpageinfo.PageIndex).Tables[0];
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                gvInfo.Rows.Add(rowCount);
            }
            rowCount = 0;
            foreach (DataRow item in dt.Rows)
            {
                gvInfo.Rows[rowCount].Cells[0].Value = item["id"];
                gvInfo.Rows[rowCount].Cells[1].Value = (rowCount + 1);
                gvInfo.Rows[rowCount].Cells[2].Value = item["orderno"];
                gvInfo.Rows[rowCount].Cells[3].Value = item["Daterecived"];
                gvInfo.Rows[rowCount].Cells[4].Value = item["pername"];
                gvInfo.Rows[rowCount].Cells[5].Value = item["cusname"];
                gvInfo.Rows[rowCount].Cells[6].Value = item["Reciver"];
                
                gvInfo.Rows[rowCount].Cells[7].Value = item["Tel"];
                gvInfo.Rows[rowCount].Cells[8].Value = item["Provice"];
                gvInfo.Rows[rowCount].Cells[9].Value = item["City"];
                gvInfo.Rows[rowCount].Cells[10].Value = item["Area"];
                gvInfo.Rows[rowCount].Cells[11].Value = item["Address"];
                
                gvInfo.Rows[rowCount].Cells[12].Value = item["Remark"];
                Color foreColor = Color.Black;
                gvInfo.Rows[rowCount].Cells[13].Value = ConvertOrderState(Convert.ToInt32(item["OState"]),ref foreColor);
                gvInfo.Rows[rowCount].Cells[14].Value = item["OState"];

                gvInfo.Rows[rowCount].Cells[15].Value = item["NewContractdate"];
                gvInfo.Rows[rowCount].Cells[16].Value = item["Contractor"];
                gvInfo.Rows[rowCount].Cells[17].Value = item["ORStateName"];
                gvInfo.Rows[rowCount].Cells[18].Value = item["Paream1"];
                gvInfo.Rows[rowCount].Cells[19].Value = item["Paream2"];
                if (!string.IsNullOrEmpty(item["Paream8"].ToString()))
                gvInfo.Rows[rowCount].Cells[20].Value = int.Parse(item["Paream8"].ToString())*1M/100M;
                this.gvInfo.Rows[rowCount].DefaultCellStyle.ForeColor = foreColor;
                gvInfo.Rows[rowCount].Cells[21].Value = item["Paream4"];//揽件员
                gvInfo.Rows[rowCount].Cells[22].Value = item["Paream6"].ToString()=="1"?"是":"否";//是否退回件
                gvInfo.Rows[rowCount].Cells[23].Value = string.IsNullOrEmpty(item["Paream7"].ToString()) ?0: int.Parse(item["Paream7"].ToString()) * 1d / 100d;//快件重量;
                gvInfo.Rows[rowCount].Cells[24].Value = item["Paream15"].ToString();
                gvInfo.Rows[rowCount].Cells[25].Value = item["Paream13"].ToString();
                gvInfo.Rows[rowCount].Cells[26].Value = item["Paream14"].ToString();
                gvInfo.Rows[rowCount].Cells[27].Value = item["Paream0"].ToString();
                gvInfo.Rows[rowCount].Cells[28].Value = item["Paream9"].ToString();
                gvInfo.Rows[rowCount].Cells[29].Value = item["Paream10"].ToString();
                gvInfo.Rows[rowCount].Cells[30].Value = item["Paream11"].ToString();
                gvInfo.Rows[rowCount].Cells[31].Value = item["Paream12"].ToString();

                if (item["Paream10"].ToString().Contains("("))
                {
                    gvInfo.Rows[rowCount].Cells[32].Value = item["Paream10"].ToString().Substring(0, item["Paream10"].ToString().IndexOf("("));
                }
                if (item["Paream11"].ToString().Contains("("))
                {
                    gvInfo.Rows[rowCount].Cells[33].Value = item["Paream11"].ToString().Substring(0, item["Paream11"].ToString().IndexOf("("));
                }

                rowCount++;
            }
        }


        private int PageSize
        {
            get
            {
                int pagesize = anpageinfo.PageSize;
                int pageCount = Convert.ToInt32(anpageinfo.Tag);
                if (pageCount == anpageinfo.PageIndex)
                {
                    if (anpageinfo.RecordCount % anpageinfo.PageSize != 0)
                    {
                        pagesize = anpageinfo.RecordCount % anpageinfo.PageSize;
                    }
                }
                return pagesize;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (ImportForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
        PageDataProcess processmodel = new PageDataProcess();
        private void OrderManagerForm_Load(object sender, EventArgs e)
        {
            anpageinfo.Enabled = UserValidation.IsRegister;

            //processmodel.dele_GetOrder += GetOrderInfo;
            //processmodel.dele_SetOrder += SetOrderInfo;
            anpageinfo.PageIndexChanged += anpageinfo_PageIndexChanged;
            anpageinfo.PageSize = ClientInfo.SysSetInfo.PageSize.Value;
            foreach (var item in anpageinfo.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox obj = (TextBox)item;
                    obj.KeyPress += obj_KeyPress;
                }
            }
            InitialData();
            LoadPage();
            LoadData();
        }

        DataGridViewRow preRow = null;

        private void SetOrderInfo(Express.Model.OrderInfo model)
        {
            //for (int i = 0; i < gvInfo.Rows.Count; i++)
            //{
            //    if(gvInfo.Rows[i].Cells[0].Value.ToString()==model.Id.ToString())
            //    {
            //        TotalProcessRecord++;
            //        gvInfo.Rows[i].Cells[6].Value = model.Reciver;
            //        gvInfo.Rows[i].Cells[7].Value = model.Tel;
            //        gvInfo.Rows[i].Cells[8].Value = model.Provice;
            //        gvInfo.Rows[i].Cells[9].Value = model.City;
            //        gvInfo.Rows[i].Cells[10].Value = model.Area;
            //        gvInfo.Rows[i].Cells[11].Value = model.Address;
            //        gvInfo.Rows[i].Cells[12].Value = model.Remark;
            //        Color foreColor = Color.Black;
            //        gvInfo.Rows[i].Cells[13].Value = ConvertOrderState(model.OState, ref foreColor);
            //        gvInfo.Rows[i].Cells[14].Value = model.OState;
            //        if (model.OState > 0 && model.OState < 3)
            //        {
            //            gvInfo.Rows[i].Cells[15].Value = model.Contractdate.Value;
            //            gvInfo.Rows[i].Cells[16].Value = model.Contractor;
            //        }
            //        gvInfo.Rows[i].Cells[17].Value = GetORSate(model.ORState);
            //        gvInfo.Rows[i].Cells[18].Value =model.Paream1;
            //        gvInfo.Rows[i].Cells[20].Value = model.Paream8 * 1m / 100M;

            //        this.gvInfo.Rows[i].DefaultCellStyle.ForeColor = foreColor;
            //        if (preRow != null)
            //            preRow.Selected = false;
            //        gvInfo.Rows[i].Selected = true;
            //        preRow = gvInfo.Rows[i];
            //        gvInfo.FirstDisplayedScrollingRowIndex = i;
            //        break;
            //    }
            //}
            //if (anpageinfo.PageIndex == int.Parse(anpageinfo.Tag.ToString()) && RowIndex == gvInfo.Rows.Count && btnQuickSearch.Tag.ToString() == "1")
            //{
            //    StopAutoCheck();
            //}
            //else
            //{
            //    processmodel.Process(GetOrderInfo());
            //}
        }

        private string GetORSate(int state)
        {
            switch (state)
            {
                case 0:
                    return "未处理";
                    break;

                case 1:
                    return "需要催单";
                    break;
                case 2:
                    return "正常";
                    break;
                default:
                    return "无扫描记录";
                    break;
                    
            }
        }

        /// <summary>
        /// 转换快件状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private string ConvertOrderState(int state,ref Color color)
        {
            switch (state)
            {
                case 1:
                    color = Color.Green;
                    return "正常签收";
                    
                    break;
                case 2:
                    color = Color.Red;
                    return "异常签收";
                   
                    break;
                case 0:
                    return "未处理";
                    break;
                case 4:
                    return "无物流信息";
                    break;
                case 5:
                    return "漏件补收";
                    break;
                default:
                    return "未签收";
                    break;
            }
            return "未签收";
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        private Express.Model.OrderInfo GetOrderInfo()
        {

            try
            {
                CheckSelectedRow();
                if (gvInfo.Rows.Count > RowIndex)//达到一页数据的最大
                {
                    Express.Model.OrderInfo model = new Express.Model.OrderInfo();
                    model.OrderNo = gvInfo.Rows[RowIndex].Cells[2].Value.ToString();
                    model.Id = Convert.ToInt32(gvInfo.Rows[RowIndex].Cells[0].Value);

                    RowIndex++;
                    return model;
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        private void CheckSelectedRow()
        {
            if (gvInfo.Rows.Count==RowIndex&&UserValidation.IsRegister&&ClientInfo.VIP_IsAutoCheck)//达到一页数据的最大必须是系统注册用户
            {
                if (anpageinfo.PageIndex < Convert.ToInt32(anpageinfo.Tag))//含有多页数据，执行翻页
                {
                    anpageinfo.PageIndex++;
                    LoadData();
                    RowIndex = 0;
                    preRow = gvInfo.Rows[0];
                }
            }
            if (gvInfo.Rows.Count>RowIndex)//达到一页数据的最大
            {
                if (null != gvInfo.Rows[RowIndex].Cells[14].Value)
                {
                    if (!string.IsNullOrEmpty(gvInfo.Rows[RowIndex].Cells[14].Value.ToString()))
                    {
                        if (!cbCheckCheck.Checked)
                        {
                            switch (gvInfo.Rows[RowIndex].Cells[14].Value.ToString())
                            {
                                case "1"://跳过正常件
                                    RowIndex++;
                                    CheckSelectedRow();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            if ( RowIndex>=gvInfo.Rows.Count)
            {
                if (ClientInfo.VIP_IsAutoCheck)
                {
                    if (anpageinfo.PageIndex == Convert.ToInt32(anpageinfo.Tag))
                    {
                        StopAutoCheck();
                    }
                }
                else
                {
                    StopAutoCheck();
                }
            }
        }

        void obj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        void anpageinfo_PageIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(anpageinfo.Tag)>0&&Convert.ToInt32(anpageinfo.Tag) >= anpageinfo.PageIndex)
            {
                LoadData();
            }
            else
            {
                anpageinfo.PageIndex--;
            }
        }


        private void cbReciveDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpReciveDate.Enabled = cbReciveDate.Checked;
        }

        private void tvCustomer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag.ToString()=="0")
            {
                for (int i = 0; i < tvCustomer.Nodes[0].Nodes.Count; i++)
                {
                    tvCustomer.Nodes[0].Nodes[i].Checked = e.Node.Checked;
                }
            }
        }


        private void tsmiQuickSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void gvInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0&&e.ColumnIndex>=0)
            {
                Express.Model.OrderInfo model = new Express.Model.OrderInfo();
                model.OrderNo = gvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                model.Id = Convert.ToInt32(gvInfo.Rows[e.RowIndex].Cells[0].Value);
                processmodel.Process(model);
                processmodel.OpenView(model);
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (gvInfo.SelectedCells.Count < 1)
                return;

            if (CusSelectForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool isUpdate = new Express.BLL.OrderInfo().UpdateOrderCusInfo(Convert.ToInt32(CusSelectForm.ThisForm.Tag), " id in(" + SeletedValues + ")");
                string msg = isUpdate ? "修改信息成功,成功更新("+SeletedValues.Split(',').Length+")条！":"修改信息失败！";
                MessageBox.Show(msg,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private string SeletedValues
        {
            get {
                string ids = "0";
                for (int i = 0; i < gvInfo.SelectedCells.Count; i++)
                {
                    string Id = gvInfo.Rows[gvInfo.SelectedCells[i].RowIndex].Cells[0].Value.ToString();
                    bool isExists = false;
                    if(ids.Contains(","))
                    {
                        string[] keys = ids.Split(',');
                        foreach (var item in keys)
                        {
                            if(item==Id)
                            {
                                isExists = true;
                                break;
                            }
                        }
                    }
                    if(!isExists)
                    ids += ","+Id;
                }
                return ids;
            }
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            if (gvInfo.SelectedCells.Count < 1)
                return;
            if(MessageBox.Show("确认要删除当前选中的单号吗？","系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.OK)
            {
               bool issuc =  new Express.BLL.OrderInfo().DeleteList(SeletedValues);
               string msg = issuc ? "删除信息成功！" : "删除信息失败！";
               MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
               LoadPage();
               LoadData();
            }
        }

        private void gvInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (gvInfo.Rows[e.RowIndex].Selected == false)
                    {
                        //gvInfo.ClearSelection();
                        //gvInfo.CurrentCell = gvInfo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        gvInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    //if (gvInfo.SelectedRows.Count == 1)
                    //{
                    //    gvInfo.CurrentCell = gvInfo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //}
                    //弹出操作菜单
                    cmsShowInfo.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void tsmicopyorderno_Click(object sender, EventArgs e)
        {
            string msg = "";
            for (int i = 0; i < gvInfo.SelectedCells.Count; i++)
            {
                msg += gvInfo.SelectedCells[i].Value.ToString()+",";
            }
            //MessageBox.Show(msg);
            //if (IsSeletedRow)
            Clipboard.SetText(msg);
        }

        private void tsmicopyaddress_Click(object sender, EventArgs e)
        {
            if (IsSeletedRow)
            Clipboard.SetText(gvInfo.SelectedRows[0].Cells[10].Value.ToString());
        }

        private bool IsSeletedRow
        {
            get
            {
                if (gvInfo.SelectedRows.Count > 0)
                    return true;
                return false;
            }
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            CatchInfoMethod();
        }

        private void CatchInfoMethod()
        {
            if (btnQuickSearch.Tag.ToString() == "0")
            {
                StartAutoCheck();
            }
            else
            {
                StopAutoCheck();
            }
            
           
        }

        string autosearch = "";
        private void StartAutoCheck()
        {
            pbTotal.Value = 0;
            autosearch = SearchCondition();
            if (!cbCheckCheck.Checked)
            autosearch  += " and OState<>1 order by id asc";
            TotalProcessRecord = 0;
            DtStart = DateTime.Now;
            RowIndex = 0;
            btnQuickSearch.Text = "停止查单";
            btnQuickSearch.Tag = 1;
            TdMain.Start();
        }

        private void ProcessData()
        {
            DataTable dt = new Express.BLL.OrderView().GetList(autosearch).Tables[0];
            TotalProcessRecord = dt.Rows.Count;
            foreach (DataRow item in dt.Rows)
            {
                 Express.Model.OrderInfo model = new Express.Model.OrderInfo();
                    model.OrderNo = item["orderno"].ToString();
                    model.Id = int.Parse(item["id"].ToString());
                    processmodel.Process(model);
                    SetprocessState();
            }
            StopAutoCheck();
        }

        /// <summary>
        /// 查看处理进度
        /// </summary>
        private void SetprocessState()
        {
            if (!this.InvokeRequired)
            {
                pbTotal.Maximum = TotalProcessRecord;
                pbTotal.Value++;
                lblTip.Text = pbTotal.Value + "/" + pbTotal.Maximum;
            }
            else
            {
                this.Invoke(new NoneParamDel(SetprocessState));
            }
        }

        private Thread tdMain;

        public Thread TdMain
        {
            get {
                if (null == tdMain || !tdMain.IsAlive)
                {
                    tdMain = new Thread(new ThreadStart(ProcessData));
                    tdMain.IsBackground = true;
                }
                return tdMain; }
            set { tdMain = value; }
        }

        private delegate void NoneParamDel();

        private void StopAutoCheck()
        {
            if (!this.InvokeRequired)
            {
                btnQuickSearch.Text = "开始查单";
                btnQuickSearch.Tag = 0;
                MessageBox.Show(string.Format("此次订单巡查已经完成,共更新记录{0}条,用时{1}分钟!", pbTotal.Value, (DateTime.Now - DtStart).TotalMinutes), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    TdMain.Abort();
                }
                catch (Exception)
                {
                    
                    
                }
            }
            else
            {
                this.Invoke(new NoneParamDel(StopAutoCheck));
            }
        }

        private void tsmiUpdateDate_Click(object sender, EventArgs e)
        {
            if (gvInfo.SelectedCells.Count < 1)
                return;
            if (DateSelectForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool isUpdate = new Express.BLL.OrderInfo().UpdateDateInfo(Convert.ToDateTime(DateSelectForm.ThisForm.Tag), " id in(" + SeletedValues + ")");
                string msg = isUpdate ? "修改信息成功！" : "修改信息失败！";
                MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //DataTable dt = ReportData;
            //if (null != dt)
            //    new DataToExcel().DataExcel(dt, "", "收件报表", ReportTitle);
            ExportManager.ExportDataGridViewToExcel(gvInfo, "收件单号查询");
        }

        #region 订单报表
         private DataTable ReportData
        {
            get
            {
                DataTable dtInfo = null;
                if (UserValidation.IsRegister)
                {
                    if (ReportSelectForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        switch (ReportSelectForm.ThisForm.Tag.ToString())
                        {
                            case "0":
                                dtInfo = new Express.BLL.OrderView().GetListByPage(ReportCondition, SearchCondition(), "id", PageSize, anpageinfo.PageIndex).Tables[0];
                                break;
                            case "1":
                                dtInfo = new Express.BLL.OrderView().GetList(ReportCondition, SearchCondition()).Tables[0];
                                break;
                            default:
                                return null;
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("您现在还不是VIP授权用户，只能导出第一页的记录！想使用全部功能,请升级正版软件。","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtInfo = new Express.BLL.OrderView().GetListByPage(ReportCondition, SearchCondition(), "id", anpageinfo.PageSize, 1).Tables[0];
                }
                return dtInfo;
            }
        }

        private string ReportCondition
        {
            get
            {
                return " Id,OrderNo,Daterecived,cusname,pername,Tel,Provice,City,Area,Address,Reciver,Remark,Paream2,OStateName,NewContractdate,Contractor,ORStateName ";
            }
        }

        private Hashtable ReportTitle
        {
            get
            {
                //生成列的中文对应表
                Hashtable nameList = new Hashtable();
                //写标题       
                nameList.Add("Id", "订单ID");
                nameList.Add("OrderNo", "订单编号");
                nameList.Add("Daterecived", "收件日期");
                nameList.Add("cusname", "客户名称");
                nameList.Add("pername", "业务员");
                nameList.Add("Tel", "电话");
                nameList.Add("Provice", "省");
                nameList.Add("City", "市");
                nameList.Add("Area", "区");
                nameList.Add("Address", "详细地址");
                nameList.Add("Reciver", "收件人");
                nameList.Add("Paream2", "用户备注");
                nameList.Add("Remark", "备注");
                nameList.Add("OStateName", "处理状态");
                nameList.Add("NewContractdate", "签收日期");
                nameList.Add("Contractor", "签收人");
                nameList.Add("ORStateName", "催单状态");
                nameList.Add("Paream8", "延误天数");
                return nameList;
            }
        }
        #endregion

        private void cbPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPoint.Checked)
            {
                OrderScanForm.ThisForm.DEL_PointOrderNo = PointOrderNo;
                OrderScanForm.ThisForm.ShowDialog();
            }
        }

        private void PointOrderNo(string orderNo)
        {
            for (int i = 0; i < gvInfo.Rows.Count; i++)
            {
                if (gvInfo.Rows[i].Cells[2].Value.ToString() == orderNo)
                {
                    gvInfo.Rows[i].Cells[2].Selected = true;
                    gvInfo.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void tsmiAddRemark_Click(object sender, EventArgs e)
        {
            if (gvInfo.SelectedCells.Count < 1)
                return;
            string Id = gvInfo.Rows[gvInfo.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
           RemarkForm thisForm =  new RemarkForm(int.Parse(Id));
           if (thisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               gvInfo.Rows[gvInfo.SelectedCells[0].RowIndex].Cells[19].Value = thisForm.textBox1.Text;
           }
        }

        private void tsmiMSG_Click(object sender, EventArgs e)
        {
            if (gvInfo.SelectedCells.Count < 1)
                return;
            string Id = gvInfo.Rows[gvInfo.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

            MsgForm thisForm = new MsgForm(int.Parse(Id));
            if (thisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //gvInfo.Rows[gvInfo.SelectedCells[0].RowIndex].Cells[19].Value = thisForm.textBox1.Text;
            }

        }

        private void tsmiopenimage_Click(object sender, EventArgs e)
        {
            if (gvInfo.SelectedCells.Count < 1)
                return;
            string orderno = gvInfo.Rows[gvInfo.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            string path = ClientInfo.SysSetInfo.Paream5 +orderno+ ".jpg";
            try
            {
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);  
                }
                else
                {
                    MessageBox.Show("文件不存在!" + path);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("不正确的文件路径!"+path);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new QuickSearchOrder().Show();
        }
    }
}
