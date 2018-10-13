using System;
namespace Express.Model
{
	/// <summary>
	/// CustomerInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CustomerInfo
	{
		public CustomerInfo()
		{}
		#region Model
		private int _cid;
		private string _cusname;
		private string _departmentname;
		private string _address;
		private string _contactperson;
		private string _contactphone;
		private string _remark;
		private string _operuser3;
		private DateTime? _userdate3;
		private int? _cstate;
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cusname
		{
			set{ _cusname=value;}
			get{return _cusname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string departmentname
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contactperson
		{
			set{ _contactperson=value;}
			get{return _contactperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contactphone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperUser3
		{
			set{ _operuser3=value;}
			get{return _operuser3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UserDate3
		{
			set{ _userdate3=value;}
			get{return _userdate3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CState
		{
			set{ _cstate=value;}
			get{return _cstate;}
		}
		#endregion Model

	}
}

