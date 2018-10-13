using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:CustomerInfo
	/// </summary>
	public partial class CustomerInfo
	{
		public CustomerInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("cid", "CustomerInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CustomerInfo");
			strSql.Append(" where cid=@cid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@cid", OleDbType.Integer,4)
			};
			parameters[0].Value = cid;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.CustomerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CustomerInfo(");
			strSql.Append("cusname,departmentname,Address,contactperson,contactphone,Remark,OperUser3,UserDate3,CState)");
			strSql.Append(" values (");
			strSql.Append("@cusname,@departmentname,@Address,@contactperson,@contactphone,@Remark,@OperUser3,@UserDate3,@CState)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@cusname", OleDbType.VarChar,10),
					new OleDbParameter("@departmentname", OleDbType.VarChar,20),
					new OleDbParameter("@Address", OleDbType.VarChar,200),
					new OleDbParameter("@contactperson", OleDbType.VarChar,10),
					new OleDbParameter("@contactphone", OleDbType.VarChar,30),
					new OleDbParameter("@Remark", OleDbType.VarChar,100),
					new OleDbParameter("@OperUser3", OleDbType.VarChar,20),
					new OleDbParameter("@UserDate3", OleDbType.Date),
					new OleDbParameter("@CState", OleDbType.Integer,4)};
			parameters[0].Value = model.cusname;
			parameters[1].Value = model.departmentname;
			parameters[2].Value = model.Address;
			parameters[3].Value = model.contactperson;
			parameters[4].Value = model.contactphone;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.OperUser3;
			parameters[7].Value = model.UserDate3;
			parameters[8].Value = model.CState;

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
		public bool Update(Express.Model.CustomerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CustomerInfo set ");
			strSql.Append("cusname=@cusname,");
			strSql.Append("departmentname=@departmentname,");
			strSql.Append("Address=@Address,");
			strSql.Append("contactperson=@contactperson,");
			strSql.Append("contactphone=@contactphone,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("OperUser3=@OperUser3,");
			strSql.Append("UserDate3=@UserDate3,");
			strSql.Append("CState=@CState");
			strSql.Append(" where cid=@cid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@cusname", OleDbType.VarChar,10),
					new OleDbParameter("@departmentname", OleDbType.VarChar,20),
					new OleDbParameter("@Address", OleDbType.VarChar,200),
					new OleDbParameter("@contactperson", OleDbType.VarChar,10),
					new OleDbParameter("@contactphone", OleDbType.VarChar,30),
					new OleDbParameter("@Remark", OleDbType.VarChar,100),
					new OleDbParameter("@OperUser3", OleDbType.VarChar,20),
					new OleDbParameter("@UserDate3", OleDbType.Date),
					new OleDbParameter("@CState", OleDbType.Integer,4),
					new OleDbParameter("@cid", OleDbType.Integer,4)};
			parameters[0].Value = model.cusname;
			parameters[1].Value = model.departmentname;
			parameters[2].Value = model.Address;
			parameters[3].Value = model.contactperson;
			parameters[4].Value = model.contactphone;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.OperUser3;
			parameters[7].Value = model.UserDate3;
			parameters[8].Value = model.CState;
			parameters[9].Value = model.cid;

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
		public bool Delete(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CustomerInfo ");
			strSql.Append(" where cid=@cid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@cid", OleDbType.Integer,4)
			};
			parameters[0].Value = cid;

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
		public bool DeleteList(string cidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CustomerInfo ");
			strSql.Append(" where cid in ("+cidlist + ")  ");
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
		public Express.Model.CustomerInfo GetModel(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select cid,cusname,departmentname,Address,contactperson,contactphone,Remark,OperUser3,UserDate3,CState from CustomerInfo ");
			strSql.Append(" where cid=@cid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@cid", OleDbType.Integer,4)
			};
			parameters[0].Value = cid;

			Express.Model.CustomerInfo model=new Express.Model.CustomerInfo();
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
		public Express.Model.CustomerInfo DataRowToModel(DataRow row)
		{
			Express.Model.CustomerInfo model=new Express.Model.CustomerInfo();
			if (row != null)
			{
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["cusname"]!=null)
				{
					model.cusname=row["cusname"].ToString();
				}
				if(row["departmentname"]!=null)
				{
					model.departmentname=row["departmentname"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["contactperson"]!=null)
				{
					model.contactperson=row["contactperson"].ToString();
				}
				if(row["contactphone"]!=null)
				{
					model.contactphone=row["contactphone"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["OperUser3"]!=null)
				{
					model.OperUser3=row["OperUser3"].ToString();
				}
				if(row["UserDate3"]!=null && row["UserDate3"].ToString()!="")
				{
					model.UserDate3=DateTime.Parse(row["UserDate3"].ToString());
				}
				if(row["CState"]!=null && row["CState"].ToString()!="")
				{
					model.CState=int.Parse(row["CState"].ToString());
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
			strSql.Append("select cid,cusname,departmentname,Address,contactperson,contactphone,Remark,OperUser3,UserDate3,CState ");
			strSql.Append(" FROM CustomerInfo ");
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
			strSql.Append("select count(1) FROM CustomerInfo ");
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

            string sql = string.Format("select top {0} * from (select top {1} * from CustomerInfo {2} order by cid desc) order by cid", pageSize, pageSize * pageCount, string.IsNullOrEmpty(strWhere) ? "" : " where " + strWhere);

            return DbHelperOleDb.Query(sql);
            //string sql = string.Format("SELECT top {0} * FROM CustomerInfo where 1=1 ", pageSize);
            //if (!string.IsNullOrEmpty(strWhere))
            //{
            //    sql += " and " + strWhere;
            //}
            //if (pageCount > 1)
            //{
            //    sql += string.Format(" and cid not in(select top {0} cid from CustomerInfo where 1=1 ", pageSize * (pageCount - 1));
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
			parameters[0].Value = "CustomerInfo";
			parameters[1].Value = "cid";
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

