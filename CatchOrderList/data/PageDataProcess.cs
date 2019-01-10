using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using Express.Model;
using System.Text.RegularExpressions;
using System.Configuration;

namespace CatchOrderList.data
{
    public class PageDataProcess
    {
        private static string[] _compCode;
        public static string[] CompCode
        {
            get
            {
                if(_compCode==null)
                {
                    _compCode = ConfigurationManager.AppSettings["ComCode"].Split(',');
                }
                return _compCode;
            }
        }

        /// <summary>
        /// 获取认证码
        /// </summary>
        private string url1 = "http://n2cx.yundasys.com:18090/wsd/kjcx/cxendhh.jsp?wen=";
        /// <summary>
        /// 提交单号页  http://n1cx.yundasys.com/nbsw/gox.php
        /// </summary>
        private string url2 = "http://n1cx.yundasys.com/nbsw/gox.php?wen=";
        /// <summary>
        ///  留言URL
        /// </summary>
        private string url3 = "http://n2cx.yundasys.com:18090/wsd/kjcx/email.jsp?wen=";

        /// <summary>
        /// 查询条码分配信息
        /// </summary>
        private string url4 = "http://n2cx.yundasys.com:18090/wsd/kjcx/cxtxm.jsp?wen=";

        private const string g_jmm = "59423c58ef4d9e5198083505e7";

        HttpHelper httpHelper = new HttpHelper();

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


        public delegate void SetSigleData(string data);
        public SetSigleData setSigleData;

        public Action<OrderInfo> PrintOrderInfo;

        public Action<string> GetBigOrderInfo;


        public void OpenView(OrderInfo nowOrder)
        {
            string order = nowOrder.OrderNo;
            RedirectUrl(order);
        }

        public void RedirectUrl(string orderno)
        {
            try
            {
                //获取授权码
                string hh = httpHelper.Get(url1 + orderno);
                string url = url2 + orderno + "&jmm=" + g_jmm + "&hh=" + hh;
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {

            }
        }


        /// <summary>
        /// 获取快件重量
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public void ProcessOrderWeightV1(string d, bool isBigOrder = false)
        {
            string order = d.Split(',')[0];
            string orderInfo = "";//订单信息
            string userInfo = "";//收件人信息
            string replyInfo = "";//留言信息
            string barCodeInfo = "";//条码扫描信息

            double weight = 0d;
            try
            {
                HtmlProcess(order, ref orderInfo, ref userInfo, ref replyInfo, ref barCodeInfo);
                orderInfo = B64Decode(orderInfo);
                userInfo = B64Decode(userInfo);
                if (orderInfo.Length < 10)
                {
                    setSigleData(d.Split(',')[1] + "," + "" + "," + "" + "," + "");
                    return;
                }
                if (order.Substring(0, 1).Trim() != "9")//小包不能大于2公斤
                {
                    isBigOrder = false;
                }
                weight = QuiciGetWeight(orderInfo, isBigOrder);
               
            }
            catch (Exception ex)
            {

            }
            string address = "";
            string[] userDatas = userInfo.Split(',');
            if (userDatas.Length > 6)
            {
                address = userDatas[5] +":"+ userDatas[6]+":"+userDatas[7];
            }
            if (setSigleData != null)
            {
                setSigleData(d.Split(',')[1] + "," + weight + "," + GetRepeatPack(order, orderInfo) + "," + address);
            }
        }

        /// <summary>
        /// 获取快件重量
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public void ProcessOrderWeight(string d,bool isBigOrder=false)
        {
            string order = d.Split(',')[0];
            string orderInfo = "";//订单信息
            string userInfo = "";//收件人信息
            string replyInfo = "";//留言信息
            string barCodeInfo = "";//条码扫描信息
           
            double weight = 0d;
            try
            {
                HtmlProcess(order, ref orderInfo, ref userInfo, ref replyInfo, ref barCodeInfo);
                orderInfo = B64Decode(orderInfo);
                userInfo = B64Decode(userInfo);
               
                if (order.Substring(0, 1).Trim() != "9")//小包不能大于2公斤
                {
                    isBigOrder = false;
                }
                    weight = QuiciGetWeight(orderInfo,isBigOrder);
                if (order.Substring(0, 1).Trim() != "9" && weight > 2)//小包不能大于2公斤
                {
                    weight = 0;
                }
            }
            catch (Exception ex)
            {
                
            }
            string address="";
            string[] userDatas = userInfo.Split(',');
            if (userDatas.Length>6)
            {
                address = userDatas[5] + userDatas[6];
            }
            if (setSigleData != null)
            {
                if (orderInfo.Length < 10)
                {
                    setSigleData(d.Split(',')[1] + "," + "0" + "," + GetRepeatPack(order, orderInfo) + "," + address);
                    return;
                }
                setSigleData(d.Split(',')[1] + "," + weight+","+ GetRepeatPack(order,orderInfo)+","+address);
            }
        }

        /// <summary>
        /// 获取小件大包单号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public void GetOrderBigOrder(string d, bool isBigOrder = false)
        {
            string order = d.Split(',')[0];
            string orderInfo = "";//订单信息
            string userInfo = "";//收件人信息
            string replyInfo = "";//留言信息
            string barCodeInfo = "";//条码扫描信息

            string orderno = "";
            try
            {
                HtmlProcess(order, ref orderInfo, ref userInfo, ref replyInfo, ref barCodeInfo);
                orderInfo = B64Decode(orderInfo);
                userInfo = B64Decode(userInfo);

                orderno = GetBigOrderNo(orderInfo);
               
            }
            catch (Exception ex)
            {

            }

            if (orderInfo.Length<10)
            {
                GetBigOrderInfo(d.Split(',')[1] + "," + "" + "," + ""+ "," + "");
            }

            string address = "";
            string[] userDatas = userInfo.Split(',');
            if (userDatas.Length > 6)
            {
                address = userDatas[5] + userDatas[6];
            }
            if (GetBigOrderInfo != null)
            {
                GetBigOrderInfo(d.Split(',')[1] + "," + orderno + "," + GetRepeatPack(order, orderInfo) + "," + address);
            }
        }
        /// <summary>
        /// 获取大包订单号
        /// </summary>
        /// <returns></returns>
        private string GetBigOrderNo(string orderInfo)
        {
            string data="";
            string[] array = orderInfo.Split(';');
            Array.Sort(array);

            foreach (var item in array)//小包
            {
                if (!string.IsNullOrEmpty(item) && item.Length > 10)
                {
                    string[] darray = item.Split(',');
                    if (darray[2] == "网点集包扫描")
                    {
                        if (darray[3].Contains("装入大包"))
                        {
                            string info = Html2Text(darray[3].Trim());
                            data =info.Substring(info.IndexOf("装入大包")+4,13);
                            break;
                        }
                    }
                }
            }
            if (array.Length>1&&string.IsNullOrEmpty(data))
            {
                data = "无集包信息";
            }
            return data;
        }


        public static string Html2Text(string htmlStr)

        {

            if (String.IsNullOrEmpty(htmlStr))

            {

                return "";

            }

            string regEx_style = "<style[^>]*?>[\\s\\S]*?<\\/style>"; //定义style的正则表达式 

            string regEx_script = "<script[^>]*?>[\\s\\S]*?<\\/script>"; //定义script的正则表达式   

            string regEx_html = "<[^>]+>"; //定义HTML标签的正则表达式   

            htmlStr = Regex.Replace(htmlStr, regEx_style, "");//删除css

            htmlStr = Regex.Replace(htmlStr, regEx_script, "");//删除js

            htmlStr = Regex.Replace(htmlStr, regEx_html, "");//删除html标记

            htmlStr = Regex.Replace(htmlStr, "\\s*|\t|\r|\n", "");//去除tab、空格、空行

            htmlStr = htmlStr.Replace(" ", "");

            htmlStr = htmlStr.Replace("\"", "");//去除异常的引号" " "
        

            htmlStr = htmlStr.Replace("\"", "");

    return htmlStr.Trim();

        }



        /// <summary>
        /// 获取是否重复使用大包
        /// </summary>
        /// <returns></returns>
        private string GetRepeatPack(string orderno, string orderInfo)
        {
            if (orderno.Substring(0, 1).Trim() != "9")//小包不能大于2公斤
            {
                return "否";
            }
                string data = "否";
            string[] array = orderInfo.Split(';');
            Array.Sort(array);
            int repeatCount = 0;
            foreach (var item in array)
            {
                if (!string.IsNullOrEmpty(item) && item.Length > 10)
                {
                    string[] darray = item.Split(',');
                    if (darray[2] == "揽件扫描")
                    {
                        repeatCount+=1;
                    }
                }
            }
            if (repeatCount >= 3)
                data = "是";
            return data;
        }


        /// <summary>
        /// 获取重量
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        private double QuiciGetWeight(string orderInfo, bool IsbigOrder = false)
        {
            double weight = 0d;
            string[] array = orderInfo.Split(';');
            Array.Sort(array);


            foreach (var item in array)//小包
            {
                if (!string.IsNullOrEmpty(item) && item.Length > 10)
                {
                    string[] darray = item.Split(',');
                    if (darray[2] == "揽件扫描")
                    {
                        if (darray[3].Contains("集包分部") && darray[3].Contains("518123") && darray[4].Trim().Length <= 2 && !string.IsNullOrEmpty(darray[7].Trim()))
                        {
                            weight = double.Parse(darray[7].Trim());
                            if (weight < 2)
                                break;
                            else
                                weight = 0;
                        }
                    }
                }
            }
            if (weight > 0)
            {
                return weight;
            }

            foreach (var item in array)
            {
                if (!string.IsNullOrEmpty(item) && item.Length > 10)
                {
                    string[] darray = item.Split(',');
                    if (!string.IsNullOrEmpty(darray[7].Trim()))
                    {

                        weight = double.Parse(darray[7].Trim());

                        break;
                    }
                }
            }

            return weight;

        }

        /// <summary>
        /// 获取重量
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        private double GetWeight(string orderInfo,bool IsbigOrder=false)
        {
            double weight = 0d;
            string[] array = orderInfo.Split(';');
            Array.Sort(array);

            if (!IsbigOrder)
            {
                foreach (var item in array)//小包
                {
                    if (!string.IsNullOrEmpty(item) && item.Length > 10)
                    {
                        string[] darray = item.Split(',');
                        if (darray[2] == "揽件扫描")
                        {
                            if (darray[3].Contains("集包分部") && darray[3].Contains("518123") && darray[4].Trim().Length <= 2 && !string.IsNullOrEmpty(darray[7].Trim()))
                            {
                                weight = double.Parse(darray[7].Trim());
                                if (weight < 2)
                                    break;
                                else
                                    weight = 0;
                            }
                        }
                    }
                }
                if (weight > 0)
                {
                    return weight;
                }
            }
            else
            {
                foreach (var item in array) //大包
                {
                    if (!string.IsNullOrEmpty(item) && item.Length > 10)
                    {
                        string[] darray = item.Split(',');
                        if (darray[3].Contains("518000") && darray[3].Contains("518123") && !string.IsNullOrEmpty(darray[7].Trim()))
                        {
                            weight = double.Parse(darray[7].Trim());
                        }
                    }
                }
                if (weight > 0)
                {
                    return weight;
                }
            }

            return 0;


            //foreach (var item in array)
            //{
            //    if (!string.IsNullOrEmpty(item) && item.Length > 10)
            //    {
            //        string[] darray = item.Split(',');
            //        if (!string.IsNullOrEmpty(darray[7].Trim()))
            //        {

            //            weight = double.Parse(darray[7].Trim());

            //            break;
            //        }
            //    }
            //}

            //if (array.Length > 2 && weight <= 0)
            //{
            //    weight = 0;//如果有记录但没数据，默认未需要人工介入修改的
            //}
            //return weight;


        }


        public void ProcessV2(OrderInfo nowOrder)
        {
            nowOrder = ProcessBase(nowOrder,false);
            if(null!=PrintOrderInfo)
            {
                PrintOrderInfo(nowOrder);
            }
        }


        /// <summary>
        /// 单号
        /// </summary>
        /// <param name="order"></param>
        public void Process(OrderInfo nowOrder)
        {
            nowOrder = ProcessBase(nowOrder);
            if(null!=nowOrder)
            new Express.BLL.OrderInfo().Update(nowOrder);
        }


        private OrderInfo ProcessBase(OrderInfo nowOrder,bool isSearch=true)
        {
            try
            {
                string order = nowOrder.OrderNo;
                string orderInfo = "";//订单信息
                string userInfo = "";//收件人信息
                string replyInfo = "";//留言信息
                string barCodeInfo = "";//条码扫描信息
                HtmlProcess(order, ref orderInfo, ref userInfo, ref replyInfo,ref barCodeInfo);

                orderInfo = B64Decode(orderInfo);
                userInfo = B64Decode(userInfo);
                replyInfo = B64Decode(replyInfo);
                barCodeInfo = B64Decode(barCodeInfo);

                if (string.IsNullOrEmpty(orderInfo) || !orderInfo.Contains(',') || !orderInfo.Contains(';'))
                {
                    return null;
                }

                if (!string.IsNullOrEmpty(orderInfo) && orderInfo.Contains(";"))
                    orderInfo = orderInfo.Remove(orderInfo.LastIndexOf(';'));
                if (isSearch)
                    nowOrder = new Express.BLL.OrderInfo().GetModel(nowOrder.Id);

                nowOrder.Provice = GetIndexData(userInfo, 5);
                nowOrder.City = GetIndexData(userInfo, 6);
                nowOrder.Area = GetIndexData(userInfo, 7);
                nowOrder.Address = GetIndexData(userInfo, 10);
                nowOrder.Remark = GetSaleTelphone(orderInfo);
                nowOrder.Reciver = GetIndexData(userInfo, 8);

                nowOrder.OState = GetOrderState(orderInfo, ref nowOrder);
                nowOrder.ORState = GetRemindState(orderInfo);
                double layoutDays = 0;
                nowOrder.Merchandiser = OrderState(orderInfo, ref layoutDays);
                nowOrder.Paream8 = (int)(layoutDays * 100);
                nowOrder.Paream1 = GetCompCode(orderInfo);//作为揽件扫描编码
                


                nowOrder.Paream3 = replyInfo;//保存留言信息
                
                nowOrder.Paream6 = GetReturnState(orderInfo);
                var weight = QuiciGetWeight(orderInfo);
                //if (order.Substring(0, 1).Trim() != "9" && weight > 2)//小包不能大于2公斤
                //{
                //    weight = 0;
                //}
                nowOrder.Paream7 = (int)(weight*100);

                nowOrder.Paream4 = GetPickPerson(orderInfo);//获取揽件员信息


                nowOrder.Paream0 = GetBarCodeInfo(barCodeInfo,2);
                if (nowOrder.Paream0.Contains("("))
                {
                    nowOrder.Paream0 = nowOrder.Paream0.Substring(0,nowOrder.Paream0.IndexOf("("));
                }
                nowOrder.Paream9 = GetBarCodeInfo(barCodeInfo, 4);
                if (!string.IsNullOrEmpty(nowOrder.Paream9) && nowOrder.Paream9.Contains(" "))
                {
                    string[] thredInfo = nowOrder.Paream9.Split(' ');
                    nowOrder.Paream10 = thredInfo[0];//三段码信息
                    if (thredInfo.Length > 2)
                       nowOrder.Paream11 = thredInfo[2];//三段码信息
                    if (thredInfo.Length > 4)
                        nowOrder.Paream12 = thredInfo[4];//三段码信息
                }

                string p13 = GetBarCodeInfo(barCodeInfo, 1);
                if (p13.Contains("("))
                {
                    nowOrder.Paream13 = p13.Substring(0,p13.IndexOf("("));//所属分部
                }
                if (p13.Contains(")"))
                {
                    nowOrder.Paream14 = p13.Substring(p13.IndexOf(")")+2,6);//分部编码
                }

                if (!string.IsNullOrEmpty(userInfo) && userInfo.Contains(";"))
                {
                    string[] rowDatas = userInfo.Split(';');
                    string[] userDatas = rowDatas[rowDatas.Length - 2].Split(',');//取最后一条数据为数据来源

                    nowOrder.Paream15 = userDatas[14];//订单来源
                }

                //20170911取消该功能
                //nowOrder.Paream4 = GetSameCity(orderInfo, ref layoutDays).ToString() + GetJiBaoError(orderInfo, ref layoutDays) + GetDiffFengBu(orderInfo, ref layoutDays) + GetDiffComp(orderInfo, ref layoutDays);

                if (nowOrder.OState > 0 && nowOrder.OState < 3)
                {
                    string[] dts = orderInfo.Split(';');
                    Array.Sort(dts);
                    nowOrder.Contractdate = DateTime.Parse(dts[dts.Length - 1].Split(',')[1].ToString());
                    string reciver = dts[dts.Length - 1].Split(',')[3].ToString();
                    int startIndex = reciver.IndexOf(" 由") + 2;
                    int length = reciver.LastIndexOf(" 签收。");
                    if (length > startIndex)
                        nowOrder.Contractor = reciver.Substring(startIndex, length - startIndex);
                    //取得最后地址
                    int a = reciver.IndexOf("到达：") + 3;
                    string lastAddress = a > 2 ? reciver.Substring(a, reciver.IndexOf("(") - a - 2) : "";
                    if (nowOrder.Provice == "无" && nowOrder.Area == "无")
                    {
                        nowOrder.Area = lastAddress;
                        nowOrder.Address = lastAddress;
                    }
                }
                return nowOrder;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取电子面单信息
        /// </summary>
        /// <returns></returns>
        private string GetBarCodeInfo(string data,int index)
        {
            string[] dts = data.Split(',');
            try
            {
                if(dts.Length>index)
                return dts[index];
            }
            catch (Exception)
            {

                
            }
            return "";
        }


        private string GetSaleTelphone(string data)
        {
            string phone = "";
            string[] dts = data.Split(';');
            Array.Sort(dts);
            foreach (var item in dts)
            {
                string type = item.Split(',')[2];
                switch (type)
                {
                    case "快件分发扫描":
                        if(item.Split(',')[3].Contains("指定")&& item.Split(',')[3].Contains("派送"))
                        {
                            Regex reg = new Regex(@"\d{3,4}[-]?\d{7,8}(-\d{2,5})?|1\d{10}");
                            foreach (Match m in reg.Matches(item.Split(',')[3]))
                            {
                                phone += m.Value + "  ,";
                                break;
                            }
                        }
                       
                        break;
                    default:

                        break;
                }
                if (!string.IsNullOrEmpty(phone))
                    break;
            }
            return phone;
        }

        /// <summary>
        /// 获取退回件状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int GetReturnState(string data)
        {
            int num = 0;
            string[] dts = data.Split(';');
            Array.Sort(dts);
            foreach (var item in dts)
            {
                string type = item.Split(',')[3];
                if(type.IndexOf("退回件")>0)
                {
                    num = 1;
                    break;
                }
            }
            return num;
        }

        /// <summary>
        /// 获取揽件人员姓名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetPickPerson(string data)
        {
            string name = "";
            string[] dts = data.Split(';');
            Array.Sort(dts);
            foreach (var item in dts)
            {
                string[] md = item.Split(',');
                bool isExist = false;
                for (int i = 0; i < CompCode.Length; i++)
                {
                    if(md[3].Contains(CompCode[i])&&md[3].Contains("揽件人员"))
                    {
                        isExist = true;
                        break;
                    }
                }
                if(isExist)
                {
                    name = md[3].Substring(md[3].IndexOf("揽件人员")+5);
                    break;
                }
            }
            return name;
        }

        #region 快件状态信息
          /// <summary>
        /// 获取公司揽件编码
        /// </summary>
        private string GetCompCode(string data)
        {
            string code = "";
            try
            {
                if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
                {
                    return code;
                }
                else
                {
                    string[] dts = data.Split(';');
                    Array.Sort(dts);
                    for (int i = 0; i < dts.Length; i++)
                    {
                        switch (dts[i].Split(',')[2].ToString())
                        {
                            case "揽件扫描":
                                string msg = dts[i].Split(',')[3].ToString();
                                if (msg.Contains("上级站点：") && msg.Contains("发往："))
                                {
                                    msg = msg.Substring(msg.IndexOf("上级站点"));
                                    if (msg.Contains("518537"))
                                    {
                                        code = "518537";
                                        break;
                                    }
                                    else
                                    {
                                        int startIndex = msg.IndexOf('(') + 1;
                                        int endIndex = msg.IndexOf(')');
                                        code = msg.Substring(startIndex, endIndex - startIndex);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
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
        private int GetOrderState(string data,ref Express.Model.OrderInfo model)
        {
            if(string.IsNullOrEmpty(data)||data.Length<5)
            {
                 model.Remark = "查件失败";
                return 3;//未签收
            }
            string[] dts = data.Split(';');
            Array.Sort(dts);
            ////如果只有一条信息并且处于“揽件扫描”，则说明无物流信息
            if (dts.Length == 1 && dts[0].Split(',')[2] == "揽件扫描")
                return 4;
            bool isNoAct = true;

            foreach (var item in dts)
            {
                string[] mydata = item.Split(',');
                if (mydata[2].Contains("扫描")&&mydata[3].Contains("深圳"))
                {
                    isNoAct = false;
                    break;
                }
            }
            if (isNoAct)
            {
                return 5;//漏件补收
            }

            if (dts.Length > 1)
            {
                if (dts[dts.Length - 2].Split(',')[2] == "签收")
                    return 1;
            }
            switch (dts[dts.Length-1].Split(',')[2])
            {
                case "签收":
                case "代签收扫描":
                    return 1;
                    break;
                case "异常签收":
                    string exmsg = dts[dts.Length-1].Split(',')[3].ToString();
                    if(exmsg.IndexOf("备注：")>0)
                    model.Remark += exmsg.Substring(exmsg.IndexOf("备注：")+3);
                    return 2;
                    break;
                case "揽件扫描"://最后一条揽件状态为揽件扫描如果上一条时签收状态，则认为快件为正常状态
                    if (dts.Length > 1)
                    {
                        if (dts[dts.Length - 2].Split(',')[2].Contains("签收"))
                        {
                            return 1;
                        }
                    }
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
        private int CatchOrderState(string data)
        {
            if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
            {
                return 3;//未签收
            }
            string[] dts = data.Split(';');
            Array.Sort(dts);
            switch (dts[2].ToString())
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

        private int GetSameCity(string data, ref double layoutdays)
        {
            int state = 0;
            ///没有记录，表示无效记录标志100
            if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
            {
                return 0;//
            }
            try
            {
                data = NoHTML(data);
                string[] dts = data.Split(';');
                Array.Sort(dts);
                bool isExists = false;
                List<string> processdates = new List<string>();
                string firstDate = "";
                #region 同城件
                if (dts[dts.Length - 1].Split(',')[2] == "签收" && dts[dts.Length - 1].Split(',')[3].Substring(3, 2) == "深圳" || dts[dts.Length - 1].Split(',')[3].Substring(3, 4)=="广东深圳")
                {
                    return 1;
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        private int GetJiBaoError(string data, ref double layoutdays)
        {
            int state = 0;
            ///没有记录，表示无效记录标志100
            if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
            {
                return 0;//
            }
            try
            {

                string[] dts = data.Split(';');
                Array.Sort(dts);
                bool isExists = false;
                List<string> processdates = new List<string>();
                string firstDate = "";
                #region 集包错误
                foreach (var item in dts)
                {
                    if (item.Split(',')[2] == "网点集包扫描")
                    {
                        isExists = true;
                    }
                    if (isExists)
                        processdates.Add(NoHTML(item));
                }

                foreach (var item in processdates)
                {
                    if (item.Split(',')[2] == "网点集包扫描")
                    {
                        firstDate = item.Split(',')[3].Substring(item.Split(',')[3].IndexOf("发往：") + 3, 2);
                    }
                    else if (item.Split(',')[2] == "卸车" || item.Split(',')[2] == "签收")
                    {
                        if (firstDate != item.Split(',')[3].Substring(3, 2))
                        {
                            return 1;
                        }
                    }
                    ///如果有集包扫描又有中转集包扫描，认为非法件
                   // if (!string.IsNullOrEmpty(firstDate) && item.Split(',')[2] == "中转集包扫描")
                       // return 1;

                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return 0;
        }


        private int GetDiffFengBu(string data, ref double layoutdays)
        {
            int state = 0;
            ///没有记录，表示无效记录标志100
            if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
            {
                return 0;//
            }
            try
            {
                string[] dts = data.Split(';');
                Array.Sort(dts);
                bool isExists = false;
                List<string> processdates = new List<string>();
                string firstDate = "";
                #region 不同分部
                processdates.Clear();
                firstDate = "";
                isExists = false;
                foreach (var item in dts)
                {
                    if (item.Split(',')[2] == "出中转公司扫描")
                    {
                        isExists = true;
                    }
                    if (isExists)
                        processdates.Add(NoHTML(item));
                }

                if (isExists)
                {
                    foreach (var item in processdates)
                    {
                        string[] mydates = item.Split(',');
                        if (mydates[3].Contains("分部"))
                        {
                            int index = mydates[3].IndexOf("分部");
                            string nowdts = mydates[3].Substring(index - 5, 7);

                            if (string.IsNullOrEmpty(firstDate))
                            {
                                firstDate = nowdts;
                            }
                            else
                            {
                                if (firstDate != nowdts)
                                    return 1;
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        private int GetDiffComp(string data, ref double layoutdays)
        {
            int state = 0;
            ///没有记录，表示无效记录标志100
            if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
            {
                return 0;//
            }
            try
            {

                string[] dts = data.Split(';');
                Array.Sort(dts);
                bool isExists = false;
                List<string> processdates = new List<string>();
                string firstDate = "";
                #region 不同公司
                foreach (var item in dts)
                {
                    if (item.Split(',')[2] == "出中转公司扫描")
                    {
                        isExists = true;
                    }
                    if (isExists)
                        processdates.Add(NoHTML(item));
                }
                bool isfirst = false;
                foreach (var item in processdates)
                {
                    if (!isfirst)
                    {
                        isfirst = true;
                        continue;
                    }
                    string[] mydates = item.Split(',');
                    if (mydates[3].Contains("公司"))
                    {
                        string nowdts = mydates[3].Substring(3, mydates[3].IndexOf("公司") - 3);

                        if (string.IsNullOrEmpty(firstDate))
                        {
                            firstDate = nowdts;
                        }
                        else
                        {
                            if (firstDate != nowdts)
                                return 1;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        

        private int OrderState(string data, ref double layoutdays)
        {
            int state = 0;
            ///没有记录，表示无效记录标志100
            if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
            {
                return 100;//
            }
            try
            {

                string[] dts = data.Split(';');
                Array.Sort(dts);
                bool isExists = false;
                List<string> processdates = new List<string>();
                string firstDate = "";


                #region 未称重
                //所有记录中没有装车记录
                bool isSetWeight = false;
                int dlength = dts.Length > 5 ? 5 : dts.Length;
                for (int i = 0; i < dlength; i++)
                {
                    if (dts[i].Split(',')[2].ToString().Contains("签收"))
                    {
                        break;
                    }
                    if (dts[i].Split(',')[2].ToString() == "揽件扫描" || dts[i].Split(',')[2].ToString() == "网点集包扫描")
                    {
                        isSetWeight = true;
                    }
                }
                if (!isSetWeight)
                {
                    return 6;
                }
                #endregion

                #region 判断是否未装车
                //所有记录中没有装车记录
                bool isAddCar = false;
                for (int i = 0; i < dts.Length; i++)
                {
                    if (dts[i].Split(',')[2].ToString() == "装车")
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
                if (dts[dts.Length - 1].Split(',')[2].ToString() == "签收" || dts[dts.Length - 1].Split(',')[2].ToString() == "异常签收")
                {
                    for (int i = 0; i < dts.Length; i++)
                    {
                        string remark = dts[i].Split(',')[3].ToString();
                        if (dts[i].Split(',')[2].ToString() == "异常签收" && remark.Substring(remark.IndexOf("备注：")).Contains("错发件"))
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
                for (int i = 0; i < dts.Length; i++)
                {
                    if (dts[i].Split(',')[2].ToString() == "派送扫描")
                    {
                        dtStart = DateTime.Parse(dts[i].Split(',')[1].ToString());
                        isSendSearch = true;
                    }
                    else if (dts[i].Split(',')[2].ToString() == "签收")
                    {
                        dtEnd = DateTime.Parse(dts[i].Split(',')[1].ToString());
                    }
                }
                if (isSendSearch)
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
                for (int i = 0; i < dts.Length - 1; i++)
                {

                    if (orgAdddress != "" && !dts[i].Split(',')[3].ToString().Contains(orgAdddress))
                    {
                        isOffCar = false;//重置状态
                    }
                    if (dts[i].Split(',')[2].ToString() == "卸车" || dts[i].Split(',')[2].ToString() == "入中转公司扫描" && !isOffCar)
                    {
                        dtStart = DateTime.Parse(dts[i].Split(',')[1].ToString());
                        orgAdddress = dts[i].Split(',')[3].ToString();
                        int a = orgAdddress.IndexOf("到达：") + 3;
                        int endIndex = orgAdddress.IndexOf("(") - a;
                        orgAdddress = orgAdddress.Substring(a, endIndex);
                        isOffCar = true;
                    }
                    if (isOffCar)
                    {
                        desAddress = dts[i].Split(',')[3].ToString();
                        if ((dts[i].Split(',')[2].ToString() == "装车" || dts[i].Split(',')[2].ToString() == "出中转公司扫描") && desAddress.Contains(orgAdddress))
                        {
                            dtEnd = DateTime.Parse(dts[i].Split(',')[1].ToString());
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
                if (dts[dts.Length - 1].Split(',')[2].ToString() != "签收" || dts[dts.Length - 1].Split(',')[2].ToString() != "异常签收")
                {
                    if ((DateTime.Parse(dts[dts.Length - 1].Split(',')[1].ToString()) - DateTime.Now).TotalDays >= 2)
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
                if (dts[dts.Length - 1].Split(',')[2].ToString() == "签收" || dts[dts.Length - 1].Split(',')[2].ToString() == "异常签收")
                {
                    for (int i = 0; i < dts.Length - 1; i++)
                    {
                        string remark = dts[i].Split(',')[3].ToString();
                        if (remark.IndexOf("备注：") != -1)
                        {
                            string remarkdata = remark.Substring(remark.IndexOf("备注："));
                            if (dts[i].Split(',')[2].ToString() == "异常签收" && (!remarkdata.Contains("错发件") || remarkdata.Length >= 5))
                            {
                                return 5;
                            }
                        }
                    }
                }
                else if (dts[dts.Length - 1].Split(',')[2].ToString() == "派送扫描" || dts[dts.Length-1].Split(',')[2].ToString() == "快件分发扫描")
                {
                    if ((DateTime.Parse(dts[dts.Length-1].Split(',')[1].ToString()) - DateTime.Now).TotalDays >= 1)
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

        public  string NoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
          

            return Htmlstring;
        }

        /// <summary>
        /// 获取催单件状态
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetRemindState(string data)
        {
            int state = 3;
            if (string.IsNullOrEmpty(data) || data.IndexOf(';') == -1)
            {
                return 3;
            }
            string[] dts = data.Split(';');
            Array.Sort(dts);
            ///分两种情况,已经签收的件
            ///只进行派单和签收的时间是不是同一天判断
            ///不是同一天  返回1  是同一天返回2
            if (dts[dts.Length - 1].Split(',')[2].ToString() == "签收" || dts[dts.Length - 1].Split(',')[2].ToString() == "异常签收")
            {
                foreach (var item in dts)
                {
                    if (item.Split(',')[2].ToString() == "派送扫描")//定位到派单扫描件
                    {
                        DateTime dtsm = DateTime.Parse(item.Split(',')[0].ToString());//扫描时间
                        DateTime dtqs = DateTime.Parse(dts[dts.Length-1].Split(',')[0].ToString());//签收时间
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
                foreach (var item in dts)
                {
                    if (item.Split(',').ToString() == "派送扫描")//定位到派单扫描件
                    {
                        DateTime dtsm = DateTime.Parse(item.Split(',')[0].ToString());//扫描时间
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
        #endregion

        /// <summary>
        /// 根据索引获取相关值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetIndexData(string data,int index)
        {
            string[] dts = data.Split(','); 
            if(dts.Length>0&&dts.Length>index)
            {
                return dts[index];
            }
            return "";
        }

        /// <summary>
        /// html代码解析提供准备数据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdata"></param>
        /// <param name="userdata"></param>
        /// <param name="replydata"></param>
        private void HtmlProcess(string order, ref string orderdata, ref string userdata, ref string replydata,ref string barCodeInfo)
        {
            //获取授权码
            string hh = httpHelper.Get(url1 + order);
            //获取中间层数据
            string midddata = httpHelper.Get(url2 + order + "&jmm=" + g_jmm + "&hh=" + hh);
            if (!string.IsNullOrEmpty(midddata) && midddata.IndexOf("form")>0)
            {
                HtmlDocument htmldoc = new HtmlDocument();
                htmldoc.LoadHtml(midddata.ToLower());
                HtmlNodeCollection hnc = htmldoc.DocumentNode.SelectNodes("//form");
                string url = hnc[0].Attributes["action"].Value;

                ///采集订单页面的数据
                string data = httpHelper.Post(url, "", Encoding.UTF8);
                if (!string.IsNullOrEmpty(data))
                {
                    htmldoc = new HtmlDocument();
                    htmldoc.LoadHtml(data);

                    hnc = htmldoc.DocumentNode.SelectNodes("//script");
                    if (hnc!=null&&hnc.Count > 0)
                    {
                        string jsdata = hnc[hnc.Count-2].InnerText;

                        if (jsdata.IndexOf("var g_ssm=") != -1 && jsdata.IndexOf("var g_sld=") != -1)
                        {
                            //快件信息
                            orderdata = jsdata;
                            orderdata = orderdata.Substring(orderdata.IndexOf("var g_ssm=") + 11);
                            orderdata = orderdata.Substring(0, orderdata.IndexOf('"'));

                            userdata = jsdata;//收件人信息
                            userdata = userdata.Substring(userdata.IndexOf("var g_sld=") + 11);
                            userdata = userdata.Substring(0, userdata.IndexOf('"'));

                            replydata = httpHelper.Get(url3 + order + "&s=" + new Random().Next());//留言信息

                            barCodeInfo = httpHelper.Get(url4 + order + "&s=" + new Random().Next());//条码分配信息
                        }
                    }
                }
            }
        }

        


        #region 字符处理层
        private string B64Decode(string data)
        {
            string str = "";
            if (!string.IsNullOrEmpty(data)&&data.Substring(0, 1) != "!")
            {
               byte[] bts = Convert.FromBase64String(data);//
                str = Encoding.UTF8.GetString(bts); ;
            }
            return str;
        }
        #endregion
    }
}
