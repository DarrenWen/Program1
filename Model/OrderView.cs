using System;
namespace Express.Model
{
    /// <summary>
    /// OrderView:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OrderView
    {
        public OrderView()
        { }
        #region Model
        private int _id;
        private string _orderno;
        private DateTime? _daterecived;
        private int? _salesmanid;
        private int? _customerid;
        private string _tel;
        private string _provice;
        private string _city;
        private string _area;
        private string _address;
        private string _reciver;
        private string _remark;
        private string _contractor;
        private DateTime? _contractdate;
        private int? _ostate;
        private int? _merchandiser;
        private DateTime? _userdate;
        private string _operuser;
        private int? _orstate;
        private string _paream0;
        private string _paream1;
        private string _paream2;
        private string _paream3;
        private string _paream4;
        private int? _paream5;
        private int? _paream6;
        private int? _paream7;
        private int? _paream8;
        private string _paream9;
        private string _paream10;
        private string _paream11;
        private string _paream12;
        private string _paream13;
        private string _paream14;
        private string _paream15;
        private string _paream16;
        private string _paream17;
        private string _paream18;
        private string _paream19;
        private string _paream20;
        private string _newcontractdate;
        private string _ostatename;
        private string _orstatename;
        private string _cusname;
        private string _pername;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Daterecived
        {
            set { _daterecived = value; }
            get { return _daterecived; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SalesmanID
        {
            set { _salesmanid = value; }
            get { return _salesmanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CustomerID
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Provice
        {
            set { _provice = value; }
            get { return _provice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reciver
        {
            set { _reciver = value; }
            get { return _reciver; }
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
        public string Contractor
        {
            set { _contractor = value; }
            get { return _contractor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Contractdate
        {
            set { _contractdate = value; }
            get { return _contractdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OState
        {
            set { _ostate = value; }
            get { return _ostate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Merchandiser
        {
            set { _merchandiser = value; }
            get { return _merchandiser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UserDate
        {
            set { _userdate = value; }
            get { return _userdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperUser
        {
            set { _operuser = value; }
            get { return _operuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ORState
        {
            set { _orstate = value; }
            get { return _orstate; }
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
        public int? Paream5
        {
            set { _paream5 = value; }
            get { return _paream5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Paream6
        {
            set { _paream6 = value; }
            get { return _paream6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Paream7
        {
            set { _paream7 = value; }
            get { return _paream7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Paream8
        {
            set { _paream8 = value; }
            get { return _paream8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream9
        {
            set { _paream9 = value; }
            get { return _paream9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream10
        {
            set { _paream10 = value; }
            get { return _paream10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream11
        {
            set { _paream11 = value; }
            get { return _paream11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream12
        {
            set { _paream12 = value; }
            get { return _paream12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream13
        {
            set { _paream13 = value; }
            get { return _paream13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream14
        {
            set { _paream14 = value; }
            get { return _paream14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream15
        {
            set { _paream15 = value; }
            get { return _paream15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream16
        {
            set { _paream16 = value; }
            get { return _paream16; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream17
        {
            set { _paream17 = value; }
            get { return _paream17; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream18
        {
            set { _paream18 = value; }
            get { return _paream18; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream19
        {
            set { _paream19 = value; }
            get { return _paream19; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Paream20
        {
            set { _paream20 = value; }
            get { return _paream20; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewContractdate
        {
            set { _newcontractdate = value; }
            get { return _newcontractdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OStateName
        {
            set { _ostatename = value; }
            get { return _ostatename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ORStateName
        {
            set { _orstatename = value; }
            get { return _orstatename; }
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
        public string pername
        {
            set { _pername = value; }
            get { return _pername; }
        }
        #endregion Model

    }
}

