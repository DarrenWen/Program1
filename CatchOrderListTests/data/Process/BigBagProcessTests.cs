using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CatchOrderList.data.ProcessStr;
using System.Data;

namespace CatchOrderList.data.Process.Tests
{
    [TestClass()]
    public class BigBagProcessTests
    {
        [TestMethod()]
        public void ProcessReciverInfoTest()
        {
            string data = "到达：< span id = 518942 class=\"wltz\">广东深圳公司龙华区上雪集包分部(518942)</span> 上级站点：<span id = 518123 class=\"wltz\">广东深圳公司国际部(518123)</span> 发往：<span id = 0 class=\"wltz\">(0)</span> 揽件人员：付文军";

            string name = data.Substring(data.IndexOf("揽件人员")+5);
        }

        private string ReadFiel()
        {
            StreamReader sr = new StreamReader("a.txt", Encoding.Default);
            String line;
            string content = "";
            while ((line = sr.ReadLine()) != null)
            {
                content += line;
            }
            sr.Close();
            sr.Dispose();
            return content;
        }
    }
}