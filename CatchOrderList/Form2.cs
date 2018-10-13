using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string CategoryListXPath = "//div/table[1]";
        string xpath = "//tr";
        private void button1_Click(object sender, EventArgs e)
        {
            string orginText = @"<DIV id=dv_ld>
<TABLE id=tb_ld class=tbl cellSpacing=0 cellPadding=2 width='100%' align=center border=1>
<TBODY class=dtl>
<TR bgColor=#e3e3e3>
<TH colSpan=2>发件城市</TH>
<TH>录单网点</TH>
<TH>录单时间</TH>
<TH colSpan=2>收件城市</TH>
<TH>收件人</TH>
<TH>收件人电话</TH>
<TH>收件人地址</TH>
<TH>物品重量</TH></TR>
<TR>
<TD id=td_ld0>广东省</TD>
<TD id=td_ld1>深圳市</TD>
<TD id=td_ld2>广东深圳公司</TD>
<TD id=td_ld3>2014-04-03 17:10:12</TD>
<TD id=td_ld4>江苏省</TD>
<TD id=td_ld5>扬州市</TD>
<TD id=td_ld6>居华</TD>
<TD id=td_ld7>13625206478</TD>
<TD id=td_ld8>长征西路14号(瘦西湖路 银都大酒店向东)</TD>
<TD id=td_ld9></TD></TR></TBODY></TABLE></DIV>

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
<TD></TD></TR></TBODY></TABLE>";
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(orginText);
            HtmlNode rootNode = document.DocumentNode;
            HtmlNodeCollection categoryNodeList = rootNode.SelectNodes(CategoryListXPath);
            HtmlNode temp = null;  
            foreach (HtmlNode categoryNode in categoryNodeList)
            {
                temp = HtmlNode.CreateNode(categoryNode.OuterHtml);

                HtmlNodeCollection hnc = temp.SelectNodes(xpath);
                foreach (var item in hnc)
                {
                    temp = HtmlNode.CreateNode(item.OuterHtml);
                    if (!item.OuterHtml.Contains("th"))
                    {
                        MessageBox.Show(temp.SelectSingleNode("//td[4]").InnerText);
                    }
                }
                
            }
        }
    }
}