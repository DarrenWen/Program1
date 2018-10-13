using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CatchOrderList.data.ProcessStr
{
    public class BigBagProcess
    {

        public Action<DataTable> SetData;

        /// <summary>
        /// 目标内容
        /// </summary>
        //private string DesHtml { get; set; }
        //private string OrderNo;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Start(string orderno)
        {
            string DesHtml = new HttpHelper().Get(@"http://kjcx.yundasys.com/kjcx/dbdb.php?dbtxm="+orderno, Encoding.GetEncoding("GB2312")).ToLower();
             Process(DesHtml,orderno);
        }

        /// <summary>
        /// 分析收件人的信息,返回datatable
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private void Process(string DesHtml,string OrderNo)
        {
            DataTable dt = new Strategy().Dt_Reciver.Clone();
            try
            {
                HtmlDocument document = new HtmlDocument();
                if (!string.IsNullOrEmpty(DesHtml) && DesHtml.Length > 10)
                {
                    document.LoadHtml(DesHtml);
                    HtmlNode rootNode = document.DocumentNode;
                    HtmlNodeCollection categoryNodeList = rootNode.SelectNodes(Strategy.Mark_BigBag);
                    HtmlNode temp = null;
                    foreach (HtmlNode categoryNode in categoryNodeList)
                    {
                        temp = HtmlNode.CreateNode(categoryNode.OuterHtml);

                        HtmlNodeCollection hnc = temp.SelectNodes(Strategy.Mark_Xpath);
                        foreach (var item in hnc)
                        {
                            temp = HtmlNode.CreateNode(item.OuterHtml);
                            if (!item.OuterHtml.Contains("th"))
                            {
                                temp = HtmlNode.CreateNode(item.OuterHtml);

                                DataRow dtRow = dt.NewRow();
                                dtRow[0] = ConvertData(temp.SelectSingleNode("//td[1]").InnerText);
                                dtRow[1] = ConvertData(temp.SelectSingleNode("//td[2]").InnerText);
                                dtRow[2] = ConvertData(temp.SelectSingleNode("//td[3]").InnerText);
                                dtRow[3] = ConvertData(temp.SelectSingleNode("//td[4]").InnerText);
                                dtRow[4] = ConvertData(temp.SelectSingleNode("//td[5]").InnerText);
                                dtRow[5] = ConvertData(temp.SelectSingleNode("//td[6]").InnerText);
                                dtRow[6] = OrderNo;
                                dt.Rows.Add(dtRow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            if(SetData!=null)
            SetData(dt);
        }

        /// <summary>
        /// 过滤无效记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string ConvertData(string data)
        {
            if (data.ToLower().Contains("undefined") || data.ToLower().Contains("&nbsp"))
            {
                return "无";
            }
            return data;
        }
    }
}
