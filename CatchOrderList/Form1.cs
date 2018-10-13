using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void wbMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            richTextBox1.Text = wbMain.Document.Url.AbsoluteUri;
            string orgHtml = wbMain.Document.Body.OuterHtml;
            if (wbMain.Document.Title.ToLower().Contains("error"))
            {
                timer1.Stop();
                LoadPage();
                timer1.Start();
            }
            else
            {
                MatchCollection mc = Regex.Matches(orgHtml.ToLower(), @"<div {0,}id=dv_sm>.*?</div>", RegexOptions.Singleline);
                foreach (Match item in mc)
                {
                    richTextBox1.Text += item.Groups[0].Value;
                }
                if (mc.Count > 0)
                {
                    button1.Text = (DateTime.Now - startTime).TotalMilliseconds.ToString();
                    wbMain.Stop();
                }
            }
        }

        private void Test()
        {
            string orginText = @"<TABLE class=tbl cellSpacing=0 cellPadding=2 width='100%' align=center border=1>
<TBODY class=dtl>
<TR bgColor=#e3e3e3>
<TH colSpan=2>单号 <FONT color=red><SPAN id=txm_fplb>1900597415652<SPAN></FONT> 所属公司查询结果</SPAN></SPAN></TH></TR>
<TR>
<TD width=160>所分配的网点为:</TD>
<TD>
<DIV id=dv_fp1>&nbsp;</DIV></TD></TR>
<TR>
<TD>分配给的分公司或业务员:</TD>
<TD>
<DIV id=dv_fp2></DIV></TD></TR>
<TR>
<TD>分配给的客户:</TD>
<TD>
<DIV id=dv_fp3></DIV></TD></TR>
<TR>
<TD>电子条码信息:</TD>
<TD>
<DIV id=dv_fp4></DIV></TD></TR></TBODY></TABLE></DIV></TD></TR>
<TR>
<TD>&nbsp;</TD></TR>
<TR>
<TD class=ttl bgColor=#fdbe04 align=center>请输入运单号或大包号: <INPUT id=txm_sm maxLength=13 size=16 value=1900597415652><INPUT id=sm_btn type=button value=查询快件> </TD></TR>
<TR>
<TD class=ttl>扫描跟踪记录(红色信息表示可单击打开相关信息)</TD></TR>
<TR>
<TD class=dtl>
<DIV                id=dv_sm>
<TABLE class=tbl cellSpacing=0 cellPadding=2 width='100%' align=center border=1>
<TBODY class=dtl>
<TR bgColor=#e3e3e3>
<TH>扫描时间</TH>
<TH>入库时间</TH>
<TH>扫描类型</TH>
<TH>跟踪记录(红色信息可显示详细信息)</TH>
<TH>扫描单号</TH>
<TH>业务员姓名(电话)</TH>
<TH>货样类型</TH>
<TH>重量(千克)</TH></TR>
<TR>
<TD>2013-12-15 23:34:13</TD>
<TD>2013-12-15 23:34:48</TD>
<TD>揽件扫描</TD>
<TD>到达：<SPAN id=792107 class=wltz>广东广州越秀区新大公司榨粉街便民服务分部(792107)</SPAN> 上级站点：<SPAN id=792107 class=wltz>广东广州越秀区新大公司榨粉街便民服务分部(792107)</SPAN> 发往：<SPAN id='class='wltz''>()</SPAN> 揽件人员：广东广州越秀区新大公司榨粉街便民服务分部</TD>
<TD></TD>
<TD></TD>
<TD>货样</TD>
<TD>0.48</TD></TR>
<TR>
<TD>2013-12-16 04:18:05</TD>
<TD>2013-12-16 04:19:03</TD>
<TD>网点集包扫描</TD>
<TD>到达：<SPAN id=510020 class=wltz>广东广州越秀区新大公司(510020)</SPAN> 装入大包 <SPAN id=9000146642188 class=dbcx>9000146642188</SPAN> 发往：<SPAN color='red'>北京网点包(100470)</SPAN></TD>
<TD></TD>
<TD></TD>
<TD>非货样</TD>
<TD></TD></TR>
<TR>
<TD>2013-12-16 09:28:44</TD>
<TD>2013-12-16 09:30:44</TD>
<TD>称重扫描</TD>
<TD>到达：<SPAN id=510001 class=wltz>广东广州分拨中心(510001)</SPAN> 上级站点：<SPAN id='class='wltz''>()</SPAN> 体积：0 计泡重量：0.0</TD>
<TD>9000146642188</TD>
<TD></TD>
<TD>非货样</TD>
<TD>24.74</TD></TR>
<TR>
<TD>2013-12-16 13:30:34</TD>
<TD>2013-12-16 13:42:22</TD>
<TD>装车</TD>
<TD>到达：<SPAN id=510001 class=wltz>广东广州分拨中心(510001)</SPAN> 装上发车凭证：31000914577 发往：<SPAN id=100088 class=wltz>北京分拨中心(100088)</SPAN> </TD>
<TD>9000146642188</TD>
<TD>郑木莲</TD>
<TD>非货样</TD>
<TD></TD></TR>
<TR>
<TD>2013-12-18 15:18:58</TD>
<TD>2013-12-18 15:21:10</TD>
<TD>卸车</TD>
<TD>到达：<SPAN id=100088 class=wltz>北京分拨中心(100088)</SPAN> 发车凭证：<FONT color=red>31000914577</FONT> 上级地点：<SPAN id=0 class=wltz>(0)</SPAN></TD>
<TD>9000146642188</TD>
<TD></TD>
<TD>货样</TD>
<TD></TD></TR>
<TR>
<TD>2013-12-18 15:35:09</TD>
<TD>2013-12-18 15:38:27</TD>
<TD>入中转公司扫描</TD>
<TD>到达：<SPAN id=100088 class=wltz>北京分拨中心(100088)</SPAN> 上级地点：<SPAN id='class='wltz''>()</SPAN></TD>
<TD></TD>
<TD></TD>
<TD>货样</TD>
<TD></TD></TR>
<TR>
<TD>2013-12-18 16:03:34</TD>
<TD>2013-12-18 16:07:35</TD>
<TD>出中转公司扫描</TD>
<TD>到达：<SPAN id=100088 class=wltz>北京分拨中心(100088)</SPAN> 格口号：GK046 发往：<SPAN id=100228 class=wltz>北京朝阳区奥体公司(100228)</SPAN></TD>
<TD></TD>
<TD></TD>
<TD>非货样</TD>
<TD></TD></TR>
<TR>
<TD>2013-12-19 07:41:07</TD>
<TD>2013-12-19 07:42:20</TD>
<TD>派送扫描</TD>
<TD>到达<SPAN id=100228 class=wltz> 北京朝阳区奥体公司(100228)</SPAN> 上级站点：<SPAN id=100088 class=wltz>北京分拨中心(100088)</SPAN> 发往：<SPAN id='class='wltz''>()</SPAN></TD>
<TD></TD>
<TD>红姐</TD>
<TD>货样</TD>
<TD></TD></TR>
<TR>
<TD>2013-12-19 08:47:42</TD>
<TD>2013-12-19 08:49:53</TD>
<TD>快件分发扫描</TD>
<TD>到达：<SPAN id=100228 class=wltz>北京朝阳区奥体公司(100228)</SPAN> 指定：冯常志(13121426163)派送</TD>
<TD></TD>
<TD>冯常志(13121426163)</TD>
<TD>货样</TD>
<TD></TD></TR>
<TR>
<TD>2013-12-19 18:02:33</TD>
<TD>2013-12-19 18:13:17</TD>
<TD>签收</TD>
<TD>到达：<SPAN id=100228 class=wltz>北京朝阳区奥体公司(100228)</SPAN> 由 图片签收 签收。</TD>
<TD></TD>
<TD>冯常志(13121426163)</TD>
<TD>非货样</TD>
<TD></TD></TR></TBODY></TABLE></div>测试数据过滤机制";
            MatchCollection mc = Regex.Matches(orginText.ToLower(), @"<div {0,}id=dv_sm>.*?</div>", RegexOptions.Singleline);
            foreach (Match item in mc)
            {
                richTextBox1.Text += item.Groups[0].Value;
            }
        }

        /// <summary>
        /// 最原始的快件查询单
        /// </summary>
        string orginPath = @"http://qz.yundasys.com:18090/wsd/kjcx/cxend.jsp?wen=59423c58ec489c5d90043502ef&jmm=59423c58ec489c5d90043500ed";

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadPage();
        }

        private void LoadPage()
        {
            this.wbMain.Url = new Uri(orginPath);
        }

        DateTime startTime = DateTime.Now;

        private void CommiteInfo()
        {
            HtmlDocument doc = wbMain.Document;
            HtmlElement txtOrderNo = doc.All["txm_sm"];
            HtmlElement btnSubmit = doc.All["sm_btn"];
            if (null != txtOrderNo && null != btnSubmit)
            {
                txtOrderNo.SetAttribute("value", txtACode.Text);
                btnSubmit.InvokeMember("click");
                startTime = DateTime.Now;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long num = Convert.ToInt64(txtACode.Text) + 1;
            txtACode.Text = num.ToString();
            CommiteInfo();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
                timer1.Start();
            }
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

    }
}
