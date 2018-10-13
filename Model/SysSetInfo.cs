using System;
namespace Express.Model
{
    /// <summary>
    /// SysSetInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysSetInfo
    {
        public SysSetInfo()
        { }
        #region Model
        private int _sysid;
        private string _cusname;
        private string _remark;
        private bool _rempass = false;
        private bool _autologin = false;
        private string _pass;
        private string _username;
        private int? _pagesize;
        private string _pageurl;
        private int? _rrate;
        private int? _rinterver;
        private string _power;
        private string _paream0;
        private string _paream1;
        private string _paream2;
        private string _paream3;
        private string _paream4;
        private string _paream5;


        /// <summary>
        /// 
        /// </summary>
        public int sysId
        {
            set { _sysid = value; }
            get { return _sysid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cusname
        {
            set { _cusname = value; }
            get { return _cusname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool RemPass
        {
            set { _rempass = value; }
            get { return _rempass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AutoLogin
        {
            set { _autologin = value; }
            get { return _autologin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pass
        {
            set { _pass = value; }
            get { return _pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PageSize
        {
            set { _pagesize = value; }
            get { return _pagesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PageUrl
        {
            set { _pageurl = value; }
            get { return _pageurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RRate
        {
            set { _rrate = value; }
            get { return _rrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RInterver
        {
            set { _rinterver = value; }
            get { return _rinterver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Power
        {
            set { _power = value; }
            get { return _power; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream0
        {
            set { _paream0 = value; }
            get { return _paream0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream1
        {
            set { _paream1 = value; }
            get { return _paream1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream2
        {
            set { _paream2 = value; }
            get { return _paream2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream3
        {
            set { _paream3 = value; }
            get { return _paream3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream4
        {
            set { _paream4 = value; }
            get { return _paream4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream5
        {
            set { _paream5 = value; }
            get { return _paream5; }
        }
        #endregion Model

    }
}

