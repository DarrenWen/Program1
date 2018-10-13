using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CatchOrderList.data;
using System.Threading;
using System.IO;

namespace CatchOrderList
{
    public partial class uc_CatchInfo : UserControl
    {
        public uc_CatchInfo()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        public delegate Express.Model.OrderInfo DELE_GetOrder();
        public DELE_GetOrder dele_GetOrder;

        /// <summary>
        /// 设置订单
        /// </summary>
        /// <param name="model"></param>
        public delegate void DELE_SetOrder(Express.Model.OrderInfo model);

        public DELE_SetOrder dele_SetOrder;
        /// <summary>
        /// 表示当前页面是否初始化
        /// </summary>
        private bool IsInitial = false;
        /// <summary>
        /// 标记当前获取到的订单信息
        /// </summary>
        private Express.Model.OrderInfo nowOrder;
        /// <summary>
        /// 页面加载次数
        /// </summary>
        private int LoadCount = 3;

        /// <summary>
        /// 标记是否处理完成
        /// </summary>
        bool IsProcess = true;
        #endregion


        private void tmTakeRecord_Tick(object sender, EventArgs e)
        {
            if (IsProcess)
            {
                
                CommiteInfo();
            }
        }

        private void CommiteInfo()
        {
            if (null != dele_GetOrder)
            {
                nowOrder = dele_GetOrder();
                if(nowOrder!=null)
                InitialOrderPageInfo(nowOrder);
            }
        }

        /// <summary>
        /// 初始化订单信息
        /// </summary>
        /// <param name="model"></param>
        public void InitialOrderPageInfo(Express.Model.OrderInfo model)
        {
            try
            {
                nowOrder = model;
               
            }
            catch (Exception)
            {
                
            }
        }

        public void RUN()
        {
           
        }

        public void Stop()
        {
           
        }



        private void ProcessRecordTwo(string data)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(data))
            //    {
            //        string orgHtml = wbMain.Document.Body.OuterHtml;
            //        DataProcess dp = new DataProcess();
            //        dp.OrginHtml = orgHtml;
                    
            //        DataTable dtReciver = dp.ProcessReciverInfo();
            //        DataTable dtOrder = dp.ProcessOrderInfo();
            //        DataTable dtMessage = dp.ProcessMessageInfo();//分析留言信息
            //        string msgData = dp.DesHtml;//获取留言信息
            //        //string filename = nowOrder.OrderNo + "-" + nowOrder + ".html";
            //        //Write(filename, msgData);
            //        if (null == dtReciver || dtReciver.Rows.Count < 1)
            //        {
            //            IsProcess = true;
            //            return;
            //        }
            //        if (null == dtOrder || dtOrder.Rows.Count < 1)
            //        {
            //            IsProcess = true;
            //            return;
            //        }
            //        if (null != dele_SetOrder && nowOrder != null)
            //        {
            //            nowOrder.Tel = dtReciver.Rows[0][9].ToString();
            //            nowOrder.Provice = dtReciver.Rows[0][5].ToString();
            //            nowOrder.City = dtReciver.Rows[0][6].ToString();
            //            nowOrder.Area = dtReciver.Rows[0][7].ToString();
            //            nowOrder.Address = dtReciver.Rows[0][10].ToString();
            //            nowOrder.Remark = "";
            //            nowOrder.Reciver = dtReciver.Rows[0][8].ToString();

            //            nowOrder.OState = GetOrderState(dtOrder, ref nowOrder);
            //            nowOrder.ORState = GetRemindState(dtOrder);
            //            double layoutDays = 0;
            //            nowOrder.Merchandiser = OrderState(dtOrder, ref layoutDays);
            //            nowOrder.Paream8 = (int)(layoutDays * 100);
            //            nowOrder.Paream1 = GetCompCode(dtOrder);//作为揽件扫描编码
            //            nowOrder.Paream3 = msgData;//保存留言信息
            //            if (nowOrder.OState > 0 && nowOrder.OState < 3)
            //            {
            //                nowOrder.Contractdate = DateTime.Parse(dtOrder.Rows[dtOrder.Rows.Count - 1][1].ToString());
            //                string reciver = dtOrder.Rows[dtOrder.Rows.Count - 1][3].ToString();
            //                int startIndex = reciver.IndexOf(" 由") + 2;
            //                int length = reciver.LastIndexOf(" 签收。");
            //                if (length > startIndex)
            //                    nowOrder.Contractor = reciver.Substring(startIndex, length - startIndex);
            //                //取得最后地址
            //                int a = reciver.IndexOf("到达：") + 3;
            //                string lastAddress = reciver.Substring(a, reciver.IndexOf("(") - a - 2);
            //                if (nowOrder.Provice == "无" && nowOrder.Area == "无")
            //                {
            //                    nowOrder.Area = lastAddress;
            //                    nowOrder.Address = lastAddress;
            //                }
            //            }

            //            HtmlDocument doc = wbMain.Document;
            //            HtmlElement txtOrderNo = doc.All[ClientInfo.SysSetInfo.Paream0];

            //            if (null != txtOrderNo && nowOrder.OrderNo == txtOrderNo.GetAttribute("value"))
            //            {
                           
            //                dele_SetOrder(nowOrder);
            //            }
            //        }
            //        IsProcess = true;
            //    }
            //}
            //catch (Exception ex)
            //{
               
            //}
            //finally
            //{
            //    IsProcess = true;
            //}
           
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        public void Write(string fileName,string text)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\datamsg\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\datamsg\");
                }
                FileStream fs = new FileStream(Application.StartupPath + @"\datamsg\" + fileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(text);
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {

            }
        }


        /// <summary>
        /// 获取公司揽件编码
        /// </summary>
        private string GetCompCode(DataTable dt)
        {
            string code = "";
            try
            {
                 for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i][2].ToString())
                {
                    case "揽件扫描":
                        string msg = dt.Rows[i][3].ToString();
                        if (msg.Contains("上级站点：")&&msg.Contains("发往："))
                        {
                            msg = msg.Substring(msg.IndexOf("上级站点"));
                            if (msg.Contains("518537"))
                            {
                                code = "518537";
                                break;
                            }
                            else
                            {
                                int startIndex = msg.IndexOf('(')+1;
                                int endIndex = msg.IndexOf(')');
                                code = msg.Substring(startIndex,endIndex-startIndex);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            }
            catch (Exception ex)
            {

            }
            return code;
        }

        /// <summary>
        /// 更新快件状态
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetOrderState(DataTable dt,ref Express.Model.OrderInfo model)
        {
            if(null==dt||dt.Rows.Count<1)
            {
                 model.Remark = "未签收";
                return 3;//未签收
            }
            switch (dt.Rows[dt.Rows.Count-1][2].ToString())
            {
                case "签收":
                case "代签收扫描":
                    return 1;
                    break;
                case "异常签收":
                    string exmsg = dt.Rows[dt.Rows.Count - 1][3].ToString();
                    if(exmsg.IndexOf("备注：")>0)
                    model.Remark = exmsg.Substring(exmsg.IndexOf("备注：")+3);
                    return 2;
                    break;
                default:
                    break;
            }
            return 3;
        }
        /// <summary>
        /// 收件异常
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int CatchOrderState(DataTable dt)
        {
            if (null == dt || dt.Rows.Count < 1)
            {
                return 3;//未签收
            }
            switch (dt.Rows[dt.Rows.Count - 1][2].ToString())
            {
                case "签收":
                case "代签收扫描":
                    return 1;
                    break;
                case "异常签收":
                    return 2;
                    break;
                default:
                    break;
            }

            return 3;
        }

        private int OrderState(DataTable dt,ref double layoutdays)
        {
            int state = 0;
            ///没有记录，表示无效记录标志100
            if (null == dt || dt.Rows.Count < 1)
            {
                return 100;//
            }

            try
            {


                #region 判断是否未装车
                //所有记录中没有装车记录
                bool isAddCar = false;
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i][2].ToString() == "装车")
                    {
                        isAddCar = true;
                    }
                }
                if (!isAddCar)
                {
                    return 1;
                }

                #endregion

                #region 判断是否是错分件
                //最终状态签收或异常签收
                //中途出现过异常签收项
                //备注中包括错发件关键字
                if (dt.Rows[dt.Rows.Count - 1][2].ToString() == "签收" || dt.Rows[dt.Rows.Count - 1][2].ToString() == "异常签收")
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        string remark = dt.Rows[i][3].ToString();
                        if (dt.Rows[i][2].ToString() == "异常签收" && remark.Substring(remark.IndexOf("备注：")).Contains("错发件"))
                        {
                            return 2;
                        }
                    }
                }
                #endregion

                #region 网点延误件
                 //中途卸车和装车时间超过12个小时
                DateTime dtStart = DateTime.Now;
                DateTime dtEnd = DateTime.Now;
                bool isSendSearch = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == "派送扫描")
                    {
                        dtStart = DateTime.Parse(dt.Rows[i][1].ToString());
                        isSendSearch = true;
                    }
                    else if (dt.Rows[i][2].ToString() == "签收")
                    {
                        dtEnd = DateTime.Parse(dt.Rows[i][1].ToString());
                    }
                }
                if(isSendSearch)
                {
                    layoutdays = (dtEnd - dtStart).TotalDays;
                }
                #endregion

                #region 中转延误件
                //中途卸车和装车时间超过12个小时
                 dtStart = DateTime.Now;
                 dtEnd = DateTime.Now;
                bool isOffCar = false;//标识是否卸车
                string orgAdddress = "";
                string desAddress = "";
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {

                    if (orgAdddress != "" && !dt.Rows[i][3].ToString().Contains(orgAdddress))
                    {
                        isOffCar = false;//重置状态
                    }
                    if (dt.Rows[i][2].ToString() == "卸车" || dt.Rows[i][2].ToString() == "入中转公司扫描" && !isOffCar)
                    {
                        dtStart = DateTime.Parse(dt.Rows[i][1].ToString());
                        orgAdddress = dt.Rows[i][3].ToString();
                        int a = orgAdddress.IndexOf("到达：") + 3;
                        int endIndex = orgAdddress.IndexOf("(") - a;
                        orgAdddress = orgAdddress.Substring(a, endIndex);
                        isOffCar = true;
                    }
                    if (isOffCar)
                    {
                        desAddress = dt.Rows[i][3].ToString();
                        if ((dt.Rows[i][2].ToString() == "装车" || dt.Rows[i][2].ToString() == "出中转公司扫描") && desAddress.Contains(orgAdddress))
                        {
                            dtEnd = DateTime.Parse(dt.Rows[i][1].ToString());
                            if ((dtEnd - dtStart).TotalHours >= 48)
                            {
                               
                                return 3;
                            }
                        }
                    }
                }
                #endregion


                #region 遗失件
                ///最后一条记录距离处理时间大于2天没有记录
                if (dt.Rows[dt.Rows.Count - 1][2].ToString() != "签收" || dt.Rows[dt.Rows.Count - 1][2].ToString() != "异常签收")
                {
                    if ((DateTime.Parse(dt.Rows[dt.Rows.Count - 1][1].ToString()) - DateTime.Now).TotalDays >= 2)
                    {
                        return 4;
                    }
                }
                #endregion


                #region 需要催单件
                //最终状态签收或异常签收
                //中途出现过异常签收项
                //备注中不包括错发件关键字
                //派送扫描和分发扫描 距离查单大于1天
                if (dt.Rows[dt.Rows.Count - 1][2].ToString() == "签收" || dt.Rows[dt.Rows.Count - 1][2].ToString() == "异常签收")
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        string remark = dt.Rows[i][3].ToString();
                        if (remark.IndexOf("备注：") != -1)
                        {
                            string remarkdata = remark.Substring(remark.IndexOf("备注："));
                            if (dt.Rows[i][2].ToString() == "异常签收" && (!remarkdata.Contains("错发件") || remarkdata.Length >= 5))
                            {
                                return 5;
                            }
                        }
                    }
                }
                else if (dt.Rows[dt.Rows.Count - 1][2].ToString() == "派送扫描" || dt.Rows[dt.Rows.Count - 1][2].ToString() == "快件分发扫描")
                {
                    if ((DateTime.Parse(dt.Rows[dt.Rows.Count - 1][1].ToString()) - DateTime.Now).TotalDays >= 1)
                    {
                        return 5;
                    }
                }
                #endregion
            }
            catch (Exception)
            {

            }
            return state;
        }

        /// <summary>
        /// 获取催单件状态
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetRemindState(DataTable dt)
        {
            int state = 3;
            if(dt.Rows.Count<=0)
            {
                return 3;
            }
            ///分两种情况,已经签收的件
            ///只进行派单和签收的时间是不是同一天判断
            ///不是同一天  返回1  是同一天返回2
            if (dt.Rows[dt.Rows.Count - 1][2].ToString() == "签收" || dt.Rows[dt.Rows.Count - 1][2].ToString() == "异常签收")
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item[2].ToString() == "派送扫描")//定位到派单扫描件
                    {
                        DateTime dtsm = DateTime.Parse(item[0].ToString());//扫描时间
                        DateTime dtqs = DateTime.Parse(dt.Rows[dt.Rows.Count - 1][0].ToString());//签收时间
                        if (dtsm.Date == dtqs.Date)//两个时间已经，说明是当天派送
                        {
                            state = 2;
                        }
                        else
                        {
                            state = 1;
                        }
                        break;
                    }
                }
            }
            else
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item[2].ToString() == "派送扫描")//定位到派单扫描件
                    {
                        DateTime dtsm = DateTime.Parse(item[0].ToString());//扫描时间
                        DateTime dtqs = DateTime.Now;//签收时间
                        if (dtsm.Date == dtqs.Date)//两个时间已经，说明是当天派送
                        {
                            state = 2;
                        }
                        else
                        {
                            state = 1;
                        }
                        break;
                    }
                }
            }
            return state;
        }
    }
}
