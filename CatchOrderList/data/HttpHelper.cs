using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CatchOrderList.data
{
    public class HttpHelper
    {
        #region 网络操作层
        /// <summary>
        /// post提交数据
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="paramData"></param>
        /// <param name="dataEncode"></param>
        /// <returns></returns>
        public string Post(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Timeout = 3000;
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream(), dataEncode);

                ret = sr.ReadToEnd();

                sr.Close();
                response.Close();
            }
            catch (Exception ex)
            {

            }
            return ret;
        }

        /// <summary>
        /// get 获取数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            return Get(url,Encoding.UTF8);
        }


        /// <summary>
        /// get 获取数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url,Encoding encode)
        {
            string rl = "";
            try
            {
                WebRequest Request = WebRequest.Create(url.Trim());
                Request.Timeout = 3000;
                WebResponse Response = Request.GetResponse();

                Stream resStream = Response.GetResponseStream();

                StreamReader sr = new StreamReader(resStream, encode);

                rl = sr.ReadToEnd();

                resStream.Close();
                sr.Close();
                Response.Close();
            }
            catch (Exception)
            {

            }
            return rl;
        }

        #endregion
    }
}
