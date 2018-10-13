using System;
namespace Express.Model
{
	/// <summary>
	/// Sys_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_User
	{
		public Sys_User()
		{}
		#region Model
		private int _uid;
		private string _username;
		private string _pass;
		private bool _issaleman;
		private bool _isclerk;
		private bool _isfinance;
		private bool _isadmin;
		private string _pername;
		private int? _ustate;
		private string _operuser4;
		private DateTime? _userdate4;
		/// <summary>
		/// 
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pass
		{
			set{ _pass=value;}
			get{return _pass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool issaleman
		{
			set{ _issaleman=value;}
			get{return _issaleman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isclerk
		{
			set{ _isclerk=value;}
			get{return _isclerk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isfinance
		{
			set{ _isfinance=value;}
			get{return _isfinance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isadmin
		{
			set{ _isadmin=value;}
			get{return _isadmin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PerName
		{
			set{ _pername=value;}
			get{return _pername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UState
		{
			set{ _ustate=value;}
			get{return _ustate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperUser4
		{
			set{ _operuser4=value;}
			get{return _operuser4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UserDate4
		{
			set{ _userdate4=value;}
			get{return _userdate4;}
		}
		#endregion Model

	}
}

