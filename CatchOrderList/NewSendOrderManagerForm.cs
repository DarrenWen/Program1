using CatchOrderList.data;
using CatchOrderList.Data;
using Express.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class NewSendOrderManagerForm : Form
    {
        private NewSendOrderManagerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 处理的记录数
        /// </summary>
        private int TotalProcessRecord = 0;
        //开始处理时间
        private DateTime DtStart = DateTime.Now;


        private static NewSendOrderManagerForm thisForm;

        public static NewSendOrderManagerForm ThisForm
        {
            get { 
                if(null==thisForm||thisForm.IsDisposed)
                {
                    thisForm = new NewSendOrderManagerForm();
                }
                return NewSendOrderManagerForm.thisForm;
            }
            set { NewSendOrderManagerForm.thisForm = value; }
        }


        int RowIndex = 0;

        /// <summary>
        /// 初始化数据信息
        /// </summary>
        private void InitialData()
        {
            
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
        private string SearchCondition
        {
            get
            {
                string condition = " 0=0 ";
                if (cbChuidan.Checked)
                {
                    condition += " and orstate=1";
                }
                if(!string.IsNullOrEmpty(txtKeyWord.Text))
                {
                    condition += string.Format(" and Address like '%{0}%' or OrderNo like '%{0}%'",txtKeyWord.Text);
                }
                if(ddlSaleMan.SelectedIndex>0)
                {
                    condition += " and SalesmanID=" + ddlSaleMan.SelectedValue;
                }
                if(cbReciveDate.Checked)
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
                if(cbOrderState.SelectedIndex>0)
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
                        default:
                            condition += " and OState = "+(cbOrderState.SelectedIndex-1);
                            break;
                    }
                }
                if (cbCatchState.SelectedIndex > 0)
                {
                    condition += " and Merchandiser = " + (cbCatchState.SelectedIndex);
                }

                return condition;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(btnQuickSearch.Tag.ToString()=="1")
            {
                if (MessageBox.Show("正在进行自动查单，该操作将终止自动查单，是否继续?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    StopAutoCheck();
                }
                else
                {
                    return;
                }
            }
            LoadPage();
            LoadData();
        }

        private void LoadPage()
        {
            this.anpageinfo.RecordCount = new Express.BLL.SendOrderView().GetRecordCount(SearchCondition);
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
            DataTable dt = new Express.BLL.SendOrderView().GetListByPage(SearchCondition, "id", pagesize, anpageinfo.PageIndex).Tables[0];
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
                gvInfo.Rows[rowCount].Cells[13].Value = ConvertOrderState(Convert.ToInt32(item["OState"]), ref foreColor);
                gvInfo.Rows[rowCount].Cells[14].Value = item["OState"];

                gvInfo.Rows[rowCount].Cells[15].Value = item["NewContractdate"];
                gvInfo.Rows[rowCount].Cells[16].Value = item["Contractor"];
                gvInfo.Rows[rowCount].Cells[17].Value = item["ORStateName"];
                this.gvInfo.Rows[rowCount].DefaultCellStyle.ForeColor = foreColor;
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
            if (ExportForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void OrderManagerForm_Load(object sender, EventArgs e)
        {
            anpageinfo.Enabled = UserValidation.IsRegister;
            uc_CatchInfo1.dele_GetOrder += GetOrderInfo;
            uc_CatchInfo1.dele_SetOrder += SetOrderInfo;
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
            for (int i = 0; i < gvInfo.Rows.Count; i++)
            {
                if(gvInfo.Rows[i].Cells[0].Value.ToString()==model.Id.ToString())
                {
                    TotalProcessRecord++;
                    gvInfo.Rows[i].Cells[6].Value = model.Reciver;
                    gvInfo.Rows[i].Cells[7].Value = model.Tel;
                    gvInfo.Rows[i].Cells[8].Value = model.Provice;
                    gvInfo.Rows[i].Cells[9].Value = model.City;
                    gvInfo.Rows[i].Cells[10].Value = model.Area;
                    gvInfo.Rows[i].Cells[11].Value = model.Address;
                    gvInfo.Rows[i].Cells[12].Value = model.Remark;
                    Color foreColor = Color.Black;
                    gvInfo.Rows[i].Cells[13].Value = ConvertOrderState(model.OState, ref foreColor);
                    gvInfo.Rows[i].Cells[14].Value = model.OState;
                    if (model.OState > 0 && model.OState < 3)
                    {
                        gvInfo.Rows[i].Cells[15].Value = model.Contractdate.Value;
                        gvInfo.Rows[i].Cells[16].Value = model.Contractor;
                    }
                    gvInfo.Rows[i].Cells[17].Value = GetORSate(model.ORState);
                    this.gvInfo.Rows[i].DefaultCellStyle.ForeColor = foreColor;
                    if (preRow != null)
                        preRow.Selected = false;
                    gvInfo.Rows[i].Selected = true;
                    preRow = gvInfo.Rows[i];
                    gvInfo.FirstDisplayedScrollingRowIndex = i;

                    Express.Model.SendOrderInfo newModel = new Express.BLL.SendOrderInfo().GetModel(model.Id);
                    newModel.Tel = model.Tel;
                    newModel.Provice = model.Provice;
                    newModel.City = model.City;
                    newModel.Area = model.Area;
                    newModel.Address = model.Address;
                    newModel.Reciver = model.Reciver;
                    newModel.Remark = model.Remark;
                    newModel.OState = model.OState;
                    newModel.ORState = model.ORState;
                    newModel.Merchandiser = model.Merchandiser;

                    if (model.OState > 0 && model.OState < 3)
                    {
                        newModel.Contractor = model.Contractor;
                        newModel.Contractdate = model.Contractdate;
                    }
                    new Express.BLL.SendOrderInfo().Update(newModel);
                    break;
                }
            }
            if (anpageinfo.PageIndex == int.Parse(anpageinfo.Tag.ToString()) && RowIndex == gvInfo.Rows.Count && btnQuickSearch.Tag.ToString() == "1")
            {
                StopAutoCheck();
            }
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
            if (gvInfo.Rows.Count == RowIndex && UserValidation.IsRegister && ClientInfo.VIP_IsAutoCheck)//达到一页数据的最大
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
                                case "1":
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
            if (RowIndex >= gvInfo.Rows.Count)
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
            if (Convert.ToInt32(anpageinfo.Tag) > 0 && Convert.ToInt32(anpageinfo.Tag) >= anpageinfo.PageIndex)
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


        private void tsmiQuickSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void gvInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                Express.Model.OrderInfo model = new Express.Model.OrderInfo();
                model.OrderNo = gvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                model.Id = Convert.ToInt32(gvInfo.Rows[e.RowIndex].Cells[0].Value);
                OrderPageForm.ThisForm.uc_CatchInfo1.dele_SetOrder = SetOrderInfo;
                OrderPageForm.ThisForm.uc_CatchInfo1.InitialOrderPageInfo(model);
                OrderPageForm.ThisForm.Show();
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (CusSelectForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool isUpdate = new Express.BLL.OrderInfo().UpdateOrderCusInfo(Convert.ToInt32(CusSelectForm.ThisForm.Tag), " id in(" + SeletedValues + ")");
                string msg = isUpdate ? "修改信息成功！":"修改信息失败！";
                MessageBox.Show(msg,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private string SeletedValues
        {
            get
            {
                string ids = "0";
                for (int i = 0; i < gvInfo.SelectedCells.Count; i++)
                {
                    string Id = gvInfo.Rows[gvInfo.SelectedCells[i].RowIndex].Cells[0].Value.ToString();
                    bool isExists = false;
                    if (ids.Contains(","))
                    {
                        string[] keys = ids.Split(',');
                        foreach (var item in keys)
                        {
                            if (item == Id)
                            {
                                isExists = true;
                                break;
                            }
                        }
                    }
                    if (!isExists)
                        ids += "," + Id;
                }
                return ids;
            }
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认要删除当前选中的单号吗？","系统提升", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.OK)
            {
               bool issuc =  new Express.BLL.SendOrderInfo().DeleteList(SeletedValues);
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
                //if (e.RowIndex >= 0)
                //{
                // //若行已是选中状态就不再进行设置
                //if (gvInfo.Rows[e.RowIndex].Selected == false)
                // {
                //     gvInfo.ClearSelection();
                //     gvInfo.Rows[e.RowIndex].Selected = true;
                // }
                // //只选中一行时设置活动单元格
                //if (gvInfo.SelectedRows.Count == 1)
                // {
                //     gvInfo.CurrentCell = gvInfo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // }
                //弹出操作菜单
                cmsShowInfo.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void tsmicopyorderno_Click(object sender, EventArgs e)
        {
            if (IsSeletedRow)
            Clipboard.SetText(gvInfo.SelectedRows[0].Cells[2].Value.ToString());
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
            if (gvInfo.Rows.Count < 1)
            {
                return;
            }
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

        private void StartAutoCheck()
        {
            TotalProcessRecord = 0;
            DtStart = DateTime.Now;
            RowIndex = 0;
            gvInfo.Enabled = false;
            anpageinfo.Enabled = false;
            uc_CatchInfo1.RUN();
            btnQuickSearch.Text = "停止查单";
            btnQuickSearch.Tag = 1;
        }

        private void StopAutoCheck()
        {
            if (!gvInfo.Enabled)
            {
                gvInfo.Enabled = true;
                anpageinfo.Enabled = UserValidation.IsRegister;
                uc_CatchInfo1.Stop();
                btnQuickSearch.Text = "开始查单";
                btnQuickSearch.Tag = 0;
                MessageBox.Show(string.Format("此次订单巡查已经完成,共更新记录{0}条,用时{1}分钟!", TotalProcessRecord, (DateTime.Now - DtStart).TotalMinutes), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiUpdateDate_Click(object sender, EventArgs e)
        {
            if (DateSelectForm.ThisForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool isUpdate = new Express.BLL.SendOrderInfo().UpdateDateInfo(Convert.ToDateTime(DateSelectForm.ThisForm.Tag), " id in(" + SeletedValues + ")");
                string msg = isUpdate ? "修改信息成功！" : "修改信息失败！";
                MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void anpageinfo_PageIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = ReportData;
            if(null!=dt)
            new DataToExcel().DataExcel(dt, "", "派单报表", ReportTitle);
        }

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
                                dtInfo = new Express.BLL.SendOrderView().GetListByPage(ReportCondition, SearchCondition, "id", PageSize, anpageinfo.PageIndex).Tables[0];
                                break;
                            case "1":
                                dtInfo = new Express.BLL.SendOrderView().GetList(ReportCondition, SearchCondition).Tables[0];
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
                    dtInfo = new Express.BLL.SendOrderView().GetListByPage(ReportCondition, SearchCondition, "id", anpageinfo.PageSize, 1).Tables[0];
                }
                return dtInfo;
            }
        }

        private string ReportCondition
        {
            get
            {
                return " Id,OrderNo,Daterecived,pername,Tel,Provice,City,Area,Address,Reciver,Remark,OStateName,NewContractdate,Contractor,ORStateName";
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
                nameList.Add("Daterecived", "派件日期");
                nameList.Add("pername", "业务员");
                nameList.Add("Tel", "电话");
                nameList.Add("Provice", "省");
                nameList.Add("City", "市");
                nameList.Add("Area", "区");
                nameList.Add("Address", "详细地址");
                nameList.Add("Reciver", "收件人");
                nameList.Add("Remark", "备注");
                nameList.Add("OStateName", "处理状态");
                nameList.Add("NewContractdate", "签收日期");
                nameList.Add("Contractor", "签收人");
                nameList.Add("ORStateName", "催单状态");
                return nameList;
            }
        }

        private void cbPoint_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPoint.Checked)
            {
                OrderScanForm.ThisForm.DEL_PointOrderNo = PointOrderNo;
                OrderScanForm.ThisForm.ShowDialog();
            }
        }

        private void PointOrderNo(string orderNo)
        {
            for (int i = 0; i < gvInfo.Rows.Count; i++)
            {
                if(gvInfo.Rows[i].Cells[2].Value.ToString()==orderNo)
                {
                    gvInfo.Rows[i].Selected = true;
                    gvInfo.FirstDisplayedScrollingRowIndex = i;
                }
            }
        }
    }
}
