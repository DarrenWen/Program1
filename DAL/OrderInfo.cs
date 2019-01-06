using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:OrderInfo
	/// </summary>
	public partial class OrderInfo
	{
		public OrderInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("Id", "OrderInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OrderInfo");
			strSql.Append(" where Id=@Id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
			parameters[0].Value = Id;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Express.Model.OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderInfo(");
            strSql.Append("OrderNo,Daterecived,SalesmanID,CustomerID,Tel,Provice,City,Area,Address,Reciver,Remark,Contractor,Contractdate,OState,Merchandiser,UserDate,OperUser,ORState,Paream0,Paream1,Paream2,Paream3,Paream4,Paream5,Paream6,Paream7,Paream8,Paream9,Paream10,Paream11,Paream12,Paream13,Paream14,Paream15,Paream16,Paream17,Paream18,Paream19,Paream20)");
            strSql.Append(" values (");
            strSql.Append("@OrderNo,@Daterecived,@SalesmanID,@CustomerID,@Tel,@Provice,@City,@Area,@Address,@Reciver,@Remark,@Contractor,@Contractdate,@OState,@Merchandiser,@UserDate,@OperUser,@ORState,@Paream0,@Paream1,@Paream2,@Paream3,@Paream4,@Paream5,@Paream6,@Paream7,@Paream8,@Paream9,@Paream10,@Paream11,@Paream12,@Paream13,@Paream14,@Paream15,@Paream16,@Paream17,@Paream18,@Paream19,@Paream20)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@OrderNo", OleDbType.VarChar,30),
                    new OleDbParameter("@Daterecived", OleDbType.Date),
                    new OleDbParameter("@SalesmanID", OleDbType.Integer,4),
                    new OleDbParameter("@CustomerID", OleDbType.Integer,4),
                    new OleDbParameter("@Tel", OleDbType.VarChar,30),
                    new OleDbParameter("@Provice", OleDbType.VarChar,30),
                    new OleDbParameter("@City", OleDbType.VarChar,30),
                    new OleDbParameter("@Area", OleDbType.VarChar,30),
                    new OleDbParameter("@Address", OleDbType.VarChar,200),
                    new OleDbParameter("@Reciver", OleDbType.VarChar,10),
                    new OleDbParameter("@Remark", OleDbType.VarChar,100),
                    new OleDbParameter("@Contractor", OleDbType.VarChar,20),
                    new OleDbParameter("@Contractdate", OleDbType.Date),
                    new OleDbParameter("@OState", OleDbType.Integer,4),
                    new OleDbParameter("@Merchandiser", OleDbType.Integer,4),
                    new OleDbParameter("@UserDate", OleDbType.Date),
                    new OleDbParameter("@OperUser", OleDbType.VarChar,20),
                    new OleDbParameter("@ORState", OleDbType.Integer,4),
                    new OleDbParameter("@Paream0", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream1", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream2", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream3", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream4", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream5", OleDbType.Integer,4),
                    new OleDbParameter("@Paream6", OleDbType.Integer,4),
                    new OleDbParameter("@Paream7", OleDbType.Integer,4),
                    new OleDbParameter("@Paream8", OleDbType.Integer,4),
                    new OleDbParameter("@Paream9", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream10", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream11", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream12", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream13", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream14", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream15", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream16", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream17", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream18", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream19", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream20", OleDbType.VarChar,0)};
            parameters[0].Value = model.OrderNo;
            parameters[1].Value = model.Daterecived;
            parameters[2].Value = model.SalesmanID;
            parameters[3].Value = model.CustomerID;
            parameters[4].Value = model.Tel;
            parameters[5].Value = model.Provice;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Area;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.Reciver;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.Contractor;
            parameters[12].Value = model.Contractdate;
            parameters[13].Value = model.OState;
            parameters[14].Value = model.Merchandiser;
            parameters[15].Value = model.UserDate;
            parameters[16].Value = model.OperUser;
            parameters[17].Value = model.ORState;
            parameters[18].Value = model.Paream0;
            parameters[19].Value = model.Paream1;
            parameters[20].Value = model.Paream2;
            parameters[21].Value = model.Paream3;
            parameters[22].Value = model.Paream4;
            parameters[23].Value = model.Paream5;
            parameters[24].Value = model.Paream6;
            parameters[25].Value = model.Paream7;
            parameters[26].Value = model.Paream8;
            parameters[27].Value = model.Paream9;
            parameters[28].Value = model.Paream10;
            parameters[29].Value = model.Paream11;
            parameters[30].Value = model.Paream12;
            parameters[31].Value = model.Paream13;
            parameters[32].Value = model.Paream14;
            parameters[33].Value = model.Paream15;
            parameters[34].Value = model.Paream16;
            parameters[35].Value = model.Paream17;
            parameters[36].Value = model.Paream18;
            parameters[37].Value = model.Paream19;
            parameters[38].Value = model.Paream20;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Express.Model.OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderInfo set ");
            strSql.Append("OrderNo=@OrderNo,");
            strSql.Append("Daterecived=@Daterecived,");
            strSql.Append("SalesmanID=@SalesmanID,");
            strSql.Append("CustomerID=@CustomerID,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Provice=@Provice,");
            strSql.Append("City=@City,");
            strSql.Append("Area=@Area,");
            strSql.Append("Address=@Address,");
            strSql.Append("Reciver=@Reciver,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Contractor=@Contractor,");
            strSql.Append("Contractdate=@Contractdate,");
            strSql.Append("OState=@OState,");
            strSql.Append("Merchandiser=@Merchandiser,");
            strSql.Append("UserDate=@UserDate,");
            strSql.Append("OperUser=@OperUser,");
            strSql.Append("ORState=@ORState,");
            strSql.Append("Paream0=@Paream0,");
            strSql.Append("Paream1=@Paream1,");
            strSql.Append("Paream2=@Paream2,");
            strSql.Append("Paream3=@Paream3,");
            strSql.Append("Paream4=@Paream4,");
            strSql.Append("Paream5=@Paream5,");
            strSql.Append("Paream6=@Paream6,");
            strSql.Append("Paream7=@Paream7,");
            strSql.Append("Paream8=@Paream8,");
            strSql.Append("Paream9=@Paream9,");
            strSql.Append("Paream10=@Paream10,");
            strSql.Append("Paream11=@Paream11,");
            strSql.Append("Paream12=@Paream12,");
            strSql.Append("Paream13=@Paream13,");
            strSql.Append("Paream14=@Paream14,");
            strSql.Append("Paream15=@Paream15,");
            strSql.Append("Paream16=@Paream16,");
            strSql.Append("Paream17=@Paream17,");
            strSql.Append("Paream18=@Paream18,");
            strSql.Append("Paream19=@Paream19,");
            strSql.Append("Paream20=@Paream20");
            strSql.Append(" where Id=@Id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@OrderNo", OleDbType.VarChar,30),
                    new OleDbParameter("@Daterecived", OleDbType.Date),
                    new OleDbParameter("@SalesmanID", OleDbType.Integer,4),
                    new OleDbParameter("@CustomerID", OleDbType.Integer,4),
                    new OleDbParameter("@Tel", OleDbType.VarChar,30),
                    new OleDbParameter("@Provice", OleDbType.VarChar,30),
                    new OleDbParameter("@City", OleDbType.VarChar,30),
                    new OleDbParameter("@Area", OleDbType.VarChar,30),
                    new OleDbParameter("@Address", OleDbType.VarChar,200),
                    new OleDbParameter("@Reciver", OleDbType.VarChar,10),
                    new OleDbParameter("@Remark", OleDbType.VarChar,100),
                    new OleDbParameter("@Contractor", OleDbType.VarChar,20),
                    new OleDbParameter("@Contractdate", OleDbType.Date),
                    new OleDbParameter("@OState", OleDbType.Integer,4),
                    new OleDbParameter("@Merchandiser", OleDbType.Integer,4),
                    new OleDbParameter("@UserDate", OleDbType.Date),
                    new OleDbParameter("@OperUser", OleDbType.VarChar,20),
                    new OleDbParameter("@ORState", OleDbType.Integer,4),
                    new OleDbParameter("@Paream0", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream1", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream2", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream3", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream4", OleDbType.VarChar,255),
                    new OleDbParameter("@Paream5", OleDbType.Integer,4),
                    new OleDbParameter("@Paream6", OleDbType.Integer,4),
                    new OleDbParameter("@Paream7", OleDbType.Integer,4),
                    new OleDbParameter("@Paream8", OleDbType.Integer,4),
                    new OleDbParameter("@Paream9", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream10", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream11", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream12", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream13", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream14", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream15", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream16", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream17", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream18", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream19", OleDbType.VarChar,0),
                    new OleDbParameter("@Paream20", OleDbType.VarChar,0),
                    new OleDbParameter("@Id", OleDbType.Integer,4)};
            parameters[0].Value = model.OrderNo;
            parameters[1].Value = model.Daterecived;
            parameters[2].Value = model.SalesmanID;
            parameters[3].Value = model.CustomerID;
            parameters[4].Value = model.Tel;
            parameters[5].Value = model.Provice;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Area;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.Reciver;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.Contractor;
            parameters[12].Value = model.Contractdate;
            parameters[13].Value = model.OState;
            parameters[14].Value = model.Merchandiser;
            parameters[15].Value = model.UserDate;
            parameters[16].Value = model.OperUser;
            parameters[17].Value = model.ORState;
            parameters[18].Value = model.Paream0;
            parameters[19].Value = model.Paream1;
            parameters[20].Value = model.Paream2;
            parameters[21].Value = model.Paream3;
            parameters[22].Value = model.Paream4;
            parameters[23].Value = model.Paream5;
            parameters[24].Value = model.Paream6;
            parameters[25].Value = model.Paream7;
            parameters[26].Value = model.Paream8;
            parameters[27].Value = model.Paream9;
            parameters[28].Value = model.Paream10;
            parameters[29].Value = model.Paream11;
            parameters[30].Value = model.Paream12;
            parameters[31].Value = model.Paream13;
            parameters[32].Value = model.Paream14;
            parameters[33].Value = model.Paream15;
            parameters[34].Value = model.Paream16;
            parameters[35].Value = model.Paream17;
            parameters[36].Value = model.Paream18;
            parameters[37].Value = model.Paream19;
            parameters[38].Value = model.Paream20;
            parameters[39].Value = model.Id;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新客户信息
        /// </summary>
        /// <param name="cusId"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool UpdateOrderCusInfo(int cusId, string condition)
        {
            string sql = string.Format("update OrderInfo set CustomerID={0}", cusId);
            if (!string.IsNullOrEmpty(condition))
            {
                sql += " where " + condition;
            }
            int rows = DbHelperOleDb.ExecuteSql(sql);
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
        /// 更新时间信息
        /// </summary>
        /// <param name="cusId"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool UpdateDateInfo(DateTime dt, string condition)
        {
            string sql = string.Format("update OrderInfo set Daterecived='{0}'", dt.ToShortDateString());
            if (!string.IsNullOrEmpty(condition))
            {
                sql += " where " + condition;
            }
            int rows = DbHelperOleDb.ExecuteSql(sql);
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderInfo ");
			strSql.Append(" where Id=@Id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderInfo ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteByCondition(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderInfo ");
            if(!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where "+where);
            }
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
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
		public Express.Model.OrderInfo GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from OrderInfo ");
			strSql.Append(" where Id=@Id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
			parameters[0].Value = Id;

			Express.Model.OrderInfo model=new Express.Model.OrderInfo();
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
		public Express.Model.OrderInfo DataRowToModel(DataRow row)
        {
            Express.Model.OrderInfo model = new Express.Model.OrderInfo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["OrderNo"] != null)
                {
                    model.OrderNo = row["OrderNo"].ToString();
                }
                if (row["Daterecived"] != null && row["Daterecived"].ToString() != "")
                {
                    model.Daterecived = DateTime.Parse(row["Daterecived"].ToString());
                }
                if (row["SalesmanID"] != null && row["SalesmanID"].ToString() != "")
                {
                    model.SalesmanID = int.Parse(row["SalesmanID"].ToString());
                }
                if (row["CustomerID"] != null && row["CustomerID"].ToString() != "")
                {
                    model.CustomerID = int.Parse(row["CustomerID"].ToString());
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Provice"] != null)
                {
                    model.Provice = row["Provice"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Reciver"] != null)
                {
                    model.Reciver = row["Reciver"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Contractor"] != null)
                {
                    model.Contractor = row["Contractor"].ToString();
                }
                if (row["Contractdate"] != null && row["Contractdate"].ToString() != "")
                {
                    model.Contractdate = DateTime.Parse(row["Contractdate"].ToString());
                }
                if (row["OState"] != null && row["OState"].ToString() != "")
                {
                    model.OState = int.Parse(row["OState"].ToString());
                }
                if (row["Merchandiser"] != null && row["Merchandiser"].ToString() != "")
                {
                    model.Merchandiser = int.Parse(row["Merchandiser"].ToString());
                }
                if (row["UserDate"] != null && row["UserDate"].ToString() != "")
                {
                    model.UserDate = DateTime.Parse(row["UserDate"].ToString());
                }
                if (row["OperUser"] != null)
                {
                    model.OperUser = row["OperUser"].ToString();
                }
                if (row["ORState"] != null && row["ORState"].ToString() != "")
                {
                    model.ORState = int.Parse(row["ORState"].ToString());
                }
                if (row["Paream0"] != null)
                {
                    model.Paream0 = row["Paream0"].ToString();
                }
                if (row["Paream1"] != null)
                {
                    model.Paream1 = row["Paream1"].ToString();
                }
                if (row["Paream2"] != null)
                {
                    model.Paream2 = row["Paream2"].ToString();
                }
                if (row["Paream3"] != null)
                {
                    model.Paream3 = row["Paream3"].ToString();
                }
                if (row["Paream4"] != null)
                {
                    model.Paream4 = row["Paream4"].ToString();
                }
                if (row["Paream5"] != null && row["Paream5"].ToString() != "")
                {
                    model.Paream5 = int.Parse(row["Paream5"].ToString());
                }
                if (row["Paream6"] != null && row["Paream6"].ToString() != "")
                {
                    model.Paream6 = int.Parse(row["Paream6"].ToString());
                }
                if (row["Paream7"] != null && row["Paream7"].ToString() != "")
                {
                    model.Paream7 = int.Parse(row["Paream7"].ToString());
                }
                if (row["Paream8"] != null && row["Paream8"].ToString() != "")
                {
                    model.Paream8 = int.Parse(row["Paream8"].ToString());
                }
                if (row["Paream9"] != null)
                {
                    model.Paream9 = row["Paream9"].ToString();
                }
                if (row["Paream10"] != null)
                {
                    model.Paream10 = row["Paream10"].ToString();
                }
                if (row["Paream11"] != null)
                {
                    model.Paream11 = row["Paream11"].ToString();
                }
                if (row["Paream12"] != null)
                {
                    model.Paream12 = row["Paream12"].ToString();
                }
                if (row["Paream13"] != null)
                {
                    model.Paream13 = row["Paream13"].ToString();
                }
                if (row["Paream14"] != null)
                {
                    model.Paream14 = row["Paream14"].ToString();
                }
                if (row["Paream15"] != null)
                {
                    model.Paream15 = row["Paream15"].ToString();
                }
                if (row["Paream16"] != null)
                {
                    model.Paream16 = row["Paream16"].ToString();
                }
                if (row["Paream17"] != null)
                {
                    model.Paream17 = row["Paream17"].ToString();
                }
                if (row["Paream18"] != null)
                {
                    model.Paream18 = row["Paream18"].ToString();
                }
                if (row["Paream19"] != null)
                {
                    model.Paream19 = row["Paream19"].ToString();
                }
                if (row["Paream20"] != null)
                {
                    model.Paream20 = row["Paream20"].ToString();
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
			strSql.Append("select * ");
			strSql.Append(" FROM OrderInfo ");
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
			strSql.Append("select count(1) FROM OrderInfo ");
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
            string sql = string.Format("select top {0} * from (select top {1} * from OrderInfo {2} order by id desc) order by id",pageSize,pageSize*pageCount,string.IsNullOrEmpty(strWhere)?"":" where "+strWhere);

            return DbHelperOleDb.Query(sql);

            //string sql = string.Format("SELECT top {0} * FROM OrderInfo where 1=1 ", pageSize);
            //if (!string.IsNullOrEmpty(strWhere))
            //{
            //    sql += " and " + strWhere;
            //}
            //if (pageCount > 1)
            //{
            //    sql += string.Format(" and id not in(select top {0} id from OrderInfo where 1=1 ", pageSize * (pageCount - 1));
            //    if (!string.IsNullOrEmpty(strWhere))
            //    {
            //        sql += " and " + strWhere;
            //    }
            //    sql += ")";
            //}

            //return DbHelperOleDb.Query(sql);
		}


        public bool AddByGroup(DataTable dt1)
        {
            using (OleDbConnection connection = new OleDbConnection(DbHelperOleDb.connectionString))
            {
                try
                {
                    OleDbCommand cmd2 = new OleDbCommand("insert into OrderInfo(OrderNo,Daterecived,SalesmanID,CustomerID,Tel,Provice,City,Area,Address,Reciver,Remark,Contractor,Contractdate,OState,Merchandiser,UserDate,OperUser,ORState,Paream0,Paream1,Paream2,Paream3,Paream4,Paream5,Paream6,Paream7,Paream8) values (@OrderNo,@Daterecived,@SalesmanID,@CustomerID,@Tel,@Provice,@City,@Area,@Address,@Reciver,@Remark,@Contractor,@Contractdate,@OState,@Merchandiser,@UserDate,@OperUser,@ORState,@Paream0,@Paream1,@Paream2,@Paream3,@Paream4,@Paream5,@Paream6,@Paream7,@Paream8)");

                    OleDbDataAdapter adapt = new OleDbDataAdapter("select * from OrderInfo", connection);

                    OleDbCommandBuilder OleDbCmdBud = new OleDbCommandBuilder(adapt);

                    OleDbParameter[] parameters = {
					new OleDbParameter("@OrderNo", OleDbType.VarChar,30),
					new OleDbParameter("@Daterecived", OleDbType.Date),
					new OleDbParameter("@SalesmanID", OleDbType.Integer,4),
					new OleDbParameter("@CustomerID", OleDbType.Integer,4),
					new OleDbParameter("@Tel", OleDbType.VarChar,30),
					new OleDbParameter("@Provice", OleDbType.VarChar,30),
					new OleDbParameter("@City", OleDbType.VarChar,30),
					new OleDbParameter("@Area", OleDbType.VarChar,30),
					new OleDbParameter("@Address", OleDbType.VarChar,200),
					new OleDbParameter("@Reciver", OleDbType.VarChar,10),
					new OleDbParameter("@Remark", OleDbType.VarChar,100),
					new OleDbParameter("@Contractor", OleDbType.VarChar,20),
					new OleDbParameter("@Contractdate", OleDbType.Date),
					new OleDbParameter("@OState", OleDbType.Integer,4),
					new OleDbParameter("@Merchandiser", OleDbType.Integer,4),
					new OleDbParameter("@UserDate", OleDbType.Date),
					new OleDbParameter("@OperUser", OleDbType.VarChar,20),
					new OleDbParameter("@ORState", OleDbType.Integer,4),
					new OleDbParameter("@Paream0", OleDbType.VarChar,255),
					new OleDbParameter("@Paream1", OleDbType.VarChar,255),
					new OleDbParameter("@Paream2", OleDbType.VarChar,255),
					new OleDbParameter("@Paream3", OleDbType.VarChar,255),
					new OleDbParameter("@Paream4", OleDbType.VarChar,255),
					new OleDbParameter("@Paream5", OleDbType.Integer,4),
					new OleDbParameter("@Paream6", OleDbType.Integer,4),
					new OleDbParameter("@Paream7", OleDbType.Integer,4),
					new OleDbParameter("@Paream8", OleDbType.Integer,4)};

                    adapt.Fill(dt1);
                    adapt.SelectCommand.Parameters.AddRange(parameters);


                    adapt.SelectCommand.Parameters["@OrderNo"].SourceColumn = "OrderNo";
                    adapt.SelectCommand.Parameters["@Daterecived"].SourceColumn = "Daterecived";
                    adapt.SelectCommand.Parameters["@SalesmanID"].SourceColumn = "SalesmanID";
                    adapt.SelectCommand.Parameters["@CustomerID"].SourceColumn = "CustomerID";
                    adapt.SelectCommand.Parameters["@Tel"].SourceColumn = "Tel";
                    adapt.SelectCommand.Parameters["@Provice"].SourceColumn = "Provice";
                    adapt.SelectCommand.Parameters["@City"].SourceColumn = "City";
                    adapt.SelectCommand.Parameters["@Area"].SourceColumn = "Area";
                    adapt.SelectCommand.Parameters["@Address"].SourceColumn = "Address";
                    adapt.SelectCommand.Parameters["@Reciver"].SourceColumn = "Reciver";
                    adapt.SelectCommand.Parameters["@Remark"].SourceColumn = "Remark";
                    adapt.SelectCommand.Parameters["@Contractdate"].SourceColumn = "Contractdate";
                    adapt.SelectCommand.Parameters["@OState"].SourceColumn = "OState";
                    adapt.SelectCommand.Parameters["@Merchandiser"].SourceColumn = "Merchandiser";
                    adapt.SelectCommand.Parameters["@UserDate"].SourceColumn = "UserDate";
                    adapt.SelectCommand.Parameters["@OperUser"].SourceColumn = "OperUser";

                    adapt.SelectCommand.Parameters["@ORState"].SourceColumn = "ORState";
                    adapt.SelectCommand.Parameters["@Paream0"].SourceColumn = "Paream0";
                    adapt.SelectCommand.Parameters["@Paream1"].SourceColumn = "Paream1";
                    adapt.SelectCommand.Parameters["@Paream2"].SourceColumn = "Paream2";
                    adapt.SelectCommand.Parameters["@Paream3"].SourceColumn = "Paream3";
                    adapt.SelectCommand.Parameters["@Paream4"].SourceColumn = "Paream4";
                    adapt.SelectCommand.Parameters["@Paream5"].SourceColumn = "Paream5";
                    adapt.SelectCommand.Parameters["@Paream6"].SourceColumn = "Paream6";
                    adapt.SelectCommand.Parameters["@Paream7"].SourceColumn = "Paream7";
                    adapt.SelectCommand.Parameters["@Paream8"].SourceColumn = "Paream8";

                    adapt.UpdateCommand = OleDbCmdBud.GetUpdateCommand();
                    if (dt1 != null)
                    {
                        adapt.Update(dt1);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
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
			parameters[0].Value = "OrderInfo";
			parameters[1].Value = "Id";
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

