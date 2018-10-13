using System;
namespace Express.Model
{
    /// <summary>
    /// OrgOrder:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OrgOrder
    {
        public OrgOrder()
        { }
        #region Model
        private int _id;
        private string _orderno;
        private string _pid;
        private string _temp0;
        private string _temp1;
        private string _temp2;
        private string _remark;
        private DateTime? _imtime;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string orderno
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp0
        {
            set { _temp0 = value; }
            get { return _temp0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp1
        {
            set { _temp1 = value; }
            get { return _temp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp2
        {
            set { _temp2 = value; }
            get { return _temp2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? imtime
        {
            set { _imtime = value; }
            get { return _imtime; }
        }
        #endregion Model

    }
}

