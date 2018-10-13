using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CatchOrderList.data
{
    /// <summary>
    /// 抓取信息策略类
    /// </summary>
    public class Strategy
    {
        /// <summary>
        /// 单号信息抓取标识
        /// </summary>
        public const string Mark_Order = @"<div {0,}id=dv_sm>.*?</div>";
        /// <summary>
        /// 收件人抓取标识
        /// </summary>
        public const string Mark_Reciver = @"<div {0,}id=dv_ld>.*?</div>";

        /// <summary>
        /// 收件人留言标识
        /// </summary>
        public const string Mark_Msg = @"<div {0,}id=dv_ly>.*?</div>";

        /// <summary>
        /// 数据分析标识符
        /// </summary>
        public const string Mark_Xpath = @"//tr";
        /// <summary>
        /// 数据分析头标识符
        /// </summary>
        public const string Mark_Xhead = @"//div/table[1]//tbody";

        public const string Mark_BigBag = @"//html//body//div[2]/div[6]/table/tbody";

        public const string Mark_BigBagItem = @"//tr";


        private  DataTable dt_Reciver;
        /// <summary>
        /// 收件人员表结构
        /// </summary>
        internal  DataTable Dt_Reciver
        {
            get
            {
                if (dt_Reciver == null)
                {
                    dt_Reciver = new DataTable();
                    dt_Reciver.Columns.Add("c1");
                    dt_Reciver.Columns.Add("c2");
                    dt_Reciver.Columns.Add("c3");
                    dt_Reciver.Columns.Add("c4");
                    dt_Reciver.Columns.Add("c5");
                    dt_Reciver.Columns.Add("c6");
                    dt_Reciver.Columns.Add("c7");
                    dt_Reciver.Columns.Add("c8");
                    dt_Reciver.Columns.Add("c9");
                    dt_Reciver.Columns.Add("c10");
                    dt_Reciver.Columns.Add("c11");
                    dt_Reciver.Columns.Add("c12");
                    dt_Reciver.Columns.Add("c13");
                }
                return dt_Reciver;
            }
        }

        private  DataTable dt_Order;
        /// <summary>
        /// 快件表结构
        /// </summary>
        public  DataTable Dt_Order
        {
            get
            {
                if (dt_Order == null)
                {
                    dt_Order = new DataTable();
                    dt_Order.Columns.Add("c1");
                    dt_Order.Columns.Add("c2");
                    dt_Order.Columns.Add("c3");
                    dt_Order.Columns.Add("c4");
                    dt_Order.Columns.Add("c5");
                    dt_Order.Columns.Add("c6");
                    dt_Order.Columns.Add("c7");
                    dt_Order.Columns.Add("c8");
                }
                return dt_Order;
            }
        }
    }
}
