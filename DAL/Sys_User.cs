using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:Sys_User
	/// </summary>
	public partial class Sys_User
	{
		public Sys_User()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("UID", "Sys_User"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_User");
			strSql.Append(" where UID=@UID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UID", OleDbType.Integer,4)
			};
			parameters[0].Value = UID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_User(");
			strSql.Append("username,pass,issaleman,isclerk,isfinance,isadmin,PerName,UState,OperUser4,UserDate4)");
			strSql.Append(" values (");
			strSql.Append("@username,@pass,@issaleman,@isclerk,@isfinance,@isadmin,@PerName,@UState,@OperUser4,@UserDate4)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@username", OleDbType.VarChar,20),
					new OleDbParameter("@pass", OleDbType.VarChar,100),
					new OleDbParameter("@issaleman", OleDbType.Boolean,1),
					new OleDbParameter("@isclerk", OleDbType.Boolean,1),
					new OleDbParameter("@isfinance", OleDbType.Boolean,1),
					new OleDbParameter("@isadmin", OleDbType.Boolean,1),
					new OleDbParameter("@PerName", OleDbType.VarChar,10),
					new OleDbParameter("@UState", OleDbType.Integer,4),
					new OleDbParameter("@OperUser4", OleDbType.VarChar,20),
					new OleDbParameter("@UserDate4", OleDbType.Date)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.pass;
			parameters[2].Value = model.issaleman;
			parameters[3].Value = model.isclerk;
			parameters[4].Value = model.isfinance;
			parameters[5].Value = model.isadmin;
			parameters[6].Value = model.PerName;
			parameters[7].Value = model.UState;
			parameters[8].Value = model.OperUser4;
			parameters[9].Value = model.UserDate4;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_User set ");
			strSql.Append("username=@username,");
			strSql.Append("pass=@pass,");
			strSql.Append("issaleman=@issaleman,");
			strSql.Append("isclerk=@isclerk,");
			strSql.Append("isfinance=@isfinance,");
			strSql.Append("isadmin=@isadmin,");
			strSql.Append("PerName=@PerName,");
			strSql.Append("UState=@UState,");
			strSql.Append("OperUser4=@OperUser4,");
			strSql.Append("UserDate4=@UserDate4");
			strSql.Append(" where UID=@UID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@username", OleDbType.VarChar,20),
					new OleDbParameter("@pass", OleDbType.VarChar,100),
					new OleDbParameter("@issaleman", OleDbType.Boolean,1),
					new OleDbParameter("@isclerk", OleDbType.Boolean,1),
					new OleDbParameter("@isfinance", OleDbType.Boolean,1),
					new OleDbParameter("@isadmin", OleDbType.Boolean,1),
					new OleDbParameter("@PerName", OleDbType.VarChar,10),
					new OleDbParameter("@UState", OleDbType.Integer,4),
					new OleDbParameter("@OperUser4", OleDbType.VarChar,20),
					new OleDbParameter("@UserDate4", OleDbType.Date),
					new OleDbParameter("@UID", OleDbType.Integer,4)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.pass;
			parameters[2].Value = model.issaleman;
			parameters[3].Value = model.isclerk;
			parameters[4].Value = model.isfinance;
			parameters[5].Value = model.isadmin;
			parameters[6].Value = model.PerName;
			parameters[7].Value = model.UState;
			parameters[8].Value = model.OperUser4;
			parameters[9].Value = model.UserDate4;
			parameters[10].Value = model.UID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
			strSql.Append(" where UID=@UID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UID", OleDbType.Integer,4)
			};
			parameters[0].Value = UID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string UIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
			strSql.Append(" where UID in ("+UIDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.Sys_User GetModel(int UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UID,username,pass,issaleman,isclerk,isfinance,isadmin,PerName,UState,OperUser4,UserDate4 from Sys_User ");
			strSql.Append(" where UID=@UID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UID", OleDbType.Integer,4)
			};
			parameters[0].Value = UID;

			Express.Model.Sys_User model=new Express.Model.Sys_User();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.Sys_User DataRowToModel(DataRow row)
		{
			Express.Model.Sys_User model=new Express.Model.Sys_User();
			if (row != null)
			{
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["pass"]!=null)
				{
					model.pass=row["pass"].ToString();
				}
				if(row["issaleman"]!=null && row["issaleman"].ToString()!="")
				{
					if((row["issaleman"].ToString()=="1")||(row["issaleman"].ToString().ToLower()=="true"))
					{
						model.issaleman=true;
					}
					else
					{
						model.issaleman=false;
					}
				}
				if(row["isclerk"]!=null && row["isclerk"].ToString()!="")
				{
					if((row["isclerk"].ToString()=="1")||(row["isclerk"].ToString().ToLower()=="true"))
					{
						model.isclerk=true;
					}
					else
					{
						model.isclerk=false;
					}
				}
				if(row["isfinance"]!=null && row["isfinance"].ToString()!="")
				{
					if((row["isfinance"].ToString()=="1")||(row["isfinance"].ToString().ToLower()=="true"))
					{
						model.isfinance=true;
					}
					else
					{
						model.isfinance=false;
					}
				}
				if(row["isadmin"]!=null && row["isadmin"].ToString()!="")
				{
					if((row["isadmin"].ToString()=="1")||(row["isadmin"].ToString().ToLower()=="true"))
					{
						model.isadmin=true;
					}
					else
					{
						model.isadmin=false;
					}
				}
				if(row["PerName"]!=null)
				{
					model.PerName=row["PerName"].ToString();
				}
				if(row["UState"]!=null && row["UState"].ToString()!="")
				{
					model.UState=int.Parse(row["UState"].ToString());
				}
				if(row["OperUser4"]!=null)
				{
					model.OperUser4=row["OperUser4"].ToString();
				}
				if(row["UserDate4"]!=null && row["UserDate4"].ToString()!="")
				{
					model.UserDate4=DateTime.Parse(row["UserDate4"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UID,username,pass,issaleman,isclerk,isfinance,isadmin,PerName,UState,OperUser4,UserDate4 ");
			strSql.Append(" FROM Sys_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Sys_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = DbHelperOleDb.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int pageSize, int pageCount)
		{
            string sql = string.Format("select top {0} * from (select top {1} * from Sys_User {2} order by uid desc) order by uid", pageSize, pageSize * pageCount, string.IsNullOrEmpty(strWhere) ? "" : " where " + strWhere);

            return DbHelperOleDb.Query(sql);

            //string sql = string.Format("SELECT top {0} * FROM Sys_User where 1=1 ",pageSize);
            //if(!string.IsNullOrEmpty(strWhere))
            //{
            //    sql += " and "+strWhere;
            //}
            //if (pageCount > 1)
            //{
            //    sql += string.Format(" and uid not in(select top {0} uid from sys_user where 1=1 ", pageSize * (pageCount - 1));
            //    if (!string.IsNullOrEmpty(strWhere))
            //    {
            //        sql += " and " + strWhere;
            //    }
            //    sql += ")";
            //}

            //return DbHelperOleDb.Query(sql);
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "Sys_User";
			parameters[1].Value = "UID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

