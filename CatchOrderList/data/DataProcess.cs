using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace CatchOrderList.data
{
    public class DataProcess
    {
        private string orginHtml;
        /// <summary>
        /// 原始的HTML记录
        /// </summary>
        public string OrginHtml
        {
            get { return orginHtml.ToLower(); }
            set { orginHtml = value; }
        }

        private string desHtml;
        /// <summary>
        /// 处理后的HTML记录
        /// </summary>
        public string DesHtml
        {
            get { return desHtml; }
            set { desHtml = value; }
        }

        /// <summary>
        /// 分析收件人的信息,返回datatable
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public DataTable ProcessReciverInfo()
        {
            MatchCollection mc = Regex.Matches(OrginHtml, Strategy.Mark_Reciver, RegexOptions.Singleline);
            foreach (Match item in mc)
            {
                DesHtml = item.Groups[0].Value;
            }


            DataTable dt = new Strategy().Dt_Reciver.Clone();
            try
            {
                HtmlDocument document = new HtmlDocument();
                if (!string.IsNullOrEmpty(DesHtml) && DesHtml.Length > 10)
                {
                    document.LoadHtml(DesHtml);
                    HtmlNode rootNode = document.DocumentNode;
                    HtmlNodeCollection categoryNodeList = rootNode.SelectNodes(Strategy.Mark_Xhead);
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
                                dtRow[6] = ConvertData(temp.SelectSingleNode("//td[7]").InnerText);
                                dtRow[7] = ConvertData(temp.SelectSingleNode("//td[8]").InnerText);
                                dtRow[8] = ConvertData(temp.SelectSingleNode("//td[9]").InnerText);
                                dtRow[9] = ConvertData(temp.SelectSingleNode("//td[10]").InnerText);
                                dtRow[10] = ConvertData(temp.SelectSingleNode("//td[11]").InnerText);
                                dtRow[11] = ConvertData(temp.SelectSingleNode("//td[12]").InnerText);
                                dtRow[12] = ConvertData(temp.SelectSingleNode("//td[13]").InnerText);
                                dt.Rows.Add(dtRow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
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

        /// <summary>
        /// 分析单号信息
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public DataTable ProcessOrderInfo()
        {
            MatchCollection mc = Regex.Matches(OrginHtml, Strategy.Mark_Order, RegexOptions.Singleline);
            foreach (Match item in mc)
            {
                DesHtml = item.Groups[0].Value;
            }
            DataTable dt = new Strategy().Dt_Order.Clone();
            try
            {
                HtmlDocument document = new HtmlDocument();
                if (!string.IsNullOrEmpty(DesHtml) && DesHtml.Length > 10)
                {
                    document.LoadHtml(DesHtml);
                    HtmlNode rootNode = document.DocumentNode;
                    HtmlNodeCollection categoryNodeList = rootNode.SelectNodes(Strategy.Mark_Xhead);
                    HtmlNode temp = null;
                    foreach (HtmlNode categoryNode in categoryNodeList)
                    {
                        temp = HtmlNode.CreateNode(categoryNode.OuterHtml);

                        HtmlNodeCollection hnc = temp.SelectNodes(Strategy.Mark_Xpath);

                        foreach (var item in hnc)
                        {
                            //temp = HtmlNode.CreateNode(item.OuterHtml);
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
                                dtRow[6] = ConvertData(temp.SelectSingleNode("//td[7]").InnerText);
                                dtRow[7] = ConvertData(temp.SelectSingleNode("//td[8]").InnerText);
                                dt.Rows.Add(dtRow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        /// <summary>
        /// 分析留言信息
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public DataTable ProcessMessageInfo()
        {
            MatchCollection mc = Regex.Matches(OrginHtml, Strategy.Mark_Msg, RegexOptions.Singleline);
            foreach (Match item in mc)
            {
                DesHtml = item.Groups[0].Value;
            }
            DataTable dt = new Strategy().Dt_Order.Clone();
            try
            {
                HtmlDocument document = new HtmlDocument();
                if (!string.IsNullOrEmpty(DesHtml) && DesHtml.Length > 10)
                {
                    document.LoadHtml(DesHtml);
                    HtmlNode rootNode = document.DocumentNode;
                    HtmlNodeCollection categoryNodeList = rootNode.SelectNodes(Strategy.Mark_Xhead);
                    HtmlNode temp = null;
                    foreach (HtmlNode categoryNode in categoryNodeList)
                    {
                        temp = HtmlNode.CreateNode(categoryNode.OuterHtml);

                        HtmlNodeCollection hnc = temp.SelectNodes(Strategy.Mark_Xpath);

                        foreach (var item in hnc)
                        {
                            //temp = HtmlNode.CreateNode(item.OuterHtml);
                            if (!item.OuterHtml.Contains("th"))
                            {
                                temp = HtmlNode.CreateNode(item.OuterHtml);

                                DataRow dtRow = dt.NewRow();
                                dtRow[0] = ConvertData(temp.SelectSingleNode("//td[1]").InnerText);
                                dtRow[1] = ConvertData(temp.SelectSingleNode("//td[2]").InnerText);
                                dtRow[2] = ConvertData(temp.SelectSingleNode("//td[3]").InnerText);
                                dtRow[3] = ConvertData(temp.SelectSingleNode("//td[4]").InnerText);
                                dtRow[4] = ConvertData(temp.SelectSingleNode("//td[5]").InnerText);
                                dt.Rows.Add(dtRow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}