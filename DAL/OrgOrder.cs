using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
    /// <summary>
    /// 数据访问类:OrgOrder
    /// </summary>
    public partial class OrgOrder
    {
        public OrgOrder()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgOrder");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@id", OleDbType.Integer,4)
            };
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteByCondition(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgOrder ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
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
        /// 增加一条数据
        /// </summary>
        public bool Add(Express.Model.OrgOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgOrder(");
            strSql.Append("orderno,pid,temp0,temp1,temp2,remark,imtime)");
            strSql.Append(" values (");
            strSql.Append("@orderno,@pid,@temp0,@temp1,@temp2,@remark,@imtime)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@orderno", OleDbType.VarChar,30),
                    new OleDbParameter("@pid", OleDbType.VarChar,30),
                    new OleDbParameter("@temp0", OleDbType.VarChar,30),
                    new OleDbParameter("@temp1", OleDbType.VarChar,30),
                    new OleDbParameter("@temp2", OleDbType.VarChar,30),
                    new OleDbParameter("@remark", OleDbType.VarChar,100),
                    new OleDbParameter("@imtime", OleDbType.Date)};
            parameters[0].Value = model.orderno;
            parameters[1].Value = model.pid;
            parameters[2].Value = model.temp0;
            parameters[3].Value = model.temp1;
            parameters[4].Value = model.temp2;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.imtime;

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
        public bool Update(Express.Model.OrgOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgOrder set ");
            strSql.Append("orderno=@orderno,");
            strSql.Append("pid=@pid,");
            strSql.Append("temp0=@temp0,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("remark=@remark,");
            strSql.Append("imtime=@imtime");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@orderno", OleDbType.VarChar,30),
                    new OleDbParameter("@pid", OleDbType.VarChar,30),
                    new OleDbParameter("@temp0", OleDbType.VarChar,30),
                    new OleDbParameter("@temp1", OleDbType.VarChar,30),
                    new OleDbParameter("@temp2", OleDbType.VarChar,30),
                    new OleDbParameter("@remark", OleDbType.VarChar,100),
                    new OleDbParameter("@imtime", OleDbType.Date),
                    new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.orderno;
            parameters[1].Value = model.pid;
            parameters[2].Value = model.temp0;
            parameters[3].Value = model.temp1;
            parameters[4].Value = model.temp2;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.imtime;
            parameters[7].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgOrder ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@id", OleDbType.Integer,4)
            };
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgOrder ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Express.Model.OrgOrder GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderno,pid,temp0,temp1,temp2,remark,imtime from OrgOrder ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@id", OleDbType.Integer,4)
            };
            parameters[0].Value = id;

            Express.Model.OrgOrder model = new Express.Model.OrgOrder();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Express.Model.OrgOrder DataRowToModel(DataRow row)
        {
            Express.Model.OrgOrder model = new Express.Model.OrgOrder();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["orderno"] != null)
                {
                    model.orderno = row["orderno"].ToString();
                }
                if (row["pid"] != null)
                {
                    model.pid = row["pid"].ToString();
                }
                if (row["temp0"] != null)
                {
                    model.temp0 = row["temp0"].ToString();
                }
                if (row["temp1"] != null)
                {
                    model.temp1 = row["temp1"].ToString();
                }
                if (row["temp2"] != null)
                {
                    model.temp2 = row["temp2"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["imtime"] != null && row["imtime"].ToString() != "")
                {
                    model.imtime = DateTime.Parse(row["imtime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderno,pid,temp0,temp1,temp2,remark,imtime ");
            strSql.Append(" FROM OrgOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM OrgOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            string sql = string.Format("select top {0} * from (select top {1} * from OrgOrder {2} order by id desc) order by id", pageSize, pageSize * pageCount, string.IsNullOrEmpty(strWhere) ? "" : " where " + strWhere);

            return DbHelperOleDb.Query(sql);
        }



        public bool AddByGroup(DataTable dt1)
        {
            using (OleDbConnection connection = new OleDbConnection(DbHelperOleDb.connectionString))
            {
                try
                {
                    OleDbCommand cmd2 = new OleDbCommand("insert into OrgOrder(orderno,pid,imtime,temp0,temp1,temp2,remark) values (@orderno,@pid,@imtime,@temp0,@temp1,@temp2,@remark)");

                    OleDbDataAdapter adapt = new OleDbDataAdapter("select * from OrgOrder", connection);

                    OleDbCommandBuilder OleDbCmdBud = new OleDbCommandBuilder(adapt);

                    OleDbParameter[] parameters = {
                    new OleDbParameter("@orderno", OleDbType.VarChar,30),
                    new OleDbParameter("@pid", OleDbType.VarChar,30),
                    new OleDbParameter("@imtime", OleDbType.Date),
                    new OleDbParameter("@temp0", OleDbType.VarChar,50),
                    new OleDbParameter("@temp1", OleDbType.VarChar,50),
                    new OleDbParameter("@temp2", OleDbType.VarChar,50),
                    new OleDbParameter("@remark", OleDbType.VarChar,100),
                    };

                    adapt.Fill(dt1);
                    adapt.SelectCommand.Parameters.AddRange(parameters);


                    adapt.SelectCommand.Parameters["@orderno"].SourceColumn = "orderno";
                    adapt.SelectCommand.Parameters["@pid"].SourceColumn = "pid";
                    adapt.SelectCommand.Parameters["@imtime"].SourceColumn = "imtime";
                    adapt.SelectCommand.Parameters["@temp0"].SourceColumn = "temp0";
                    adapt.SelectCommand.Parameters["@temp1"].SourceColumn = "temp1";
                    adapt.SelectCommand.Parameters["@temp2"].SourceColumn = "temp2";
                    adapt.SelectCommand.Parameters["@remark"].SourceColumn = "remark";


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
			parameters[0].Value = "OrgOrder";
			parameters[1].Value = "id";
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

