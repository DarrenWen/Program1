using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
    /// <summary>
    /// 数据访问类:SysSetInfo
    /// </summary>
    public partial class SysSetInfo
    {
        public SysSetInfo()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sysId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysSetInfo");
            strSql.Append(" where sysId=@sysId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@sysId", OleDbType.Integer,4)
			};
            parameters[0].Value = sysId;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Express.Model.SysSetInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysSetInfo(");
            strSql.Append("cusname,Remark,RemPass,AutoLogin,Pass,UserName,PageSize,PageUrl,RRate,RInterver,Power,Paream0,Paream1,Paream2,Paream3,Paream4,Paream5)");
            strSql.Append(" values (");
            strSql.Append("@cusname,@Remark,@RemPass,@AutoLogin,@Pass,@UserName,@PageSize,@PageUrl,@RRate,@RInterver,@Power,@Paream0,@Paream1,@Paream2,@Paream3,@Paream4,@Paream5)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@cusname", OleDbType.VarChar,255),
					new OleDbParameter("@Remark", OleDbType.VarChar,100),
					new OleDbParameter("@RemPass", OleDbType.Boolean,1),
					new OleDbParameter("@AutoLogin", OleDbType.Boolean,1),
					new OleDbParameter("@Pass", OleDbType.VarChar,100),
					new OleDbParameter("@UserName", OleDbType.VarChar,20),
					new OleDbParameter("@PageSize", OleDbType.Integer,4),
					new OleDbParameter("@PageUrl", OleDbType.VarChar,255),
					new OleDbParameter("@RRate", OleDbType.Integer,4),
					new OleDbParameter("@RInterver", OleDbType.Integer,4),
					new OleDbParameter("@Power", OleDbType.VarChar,255),
					new OleDbParameter("@Paream0", OleDbType.VarChar,255),
					new OleDbParameter("@Paream1", OleDbType.VarChar,255),
					new OleDbParameter("@Paream2", OleDbType.VarChar,255),
					new OleDbParameter("@Paream3", OleDbType.VarChar,255),
					new OleDbParameter("@Paream4", OleDbType.VarChar,255),
					new OleDbParameter("@Paream5", OleDbType.VarChar,255)};
            parameters[0].Value = model.cusname;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.RemPass;
            parameters[3].Value = model.AutoLogin;
            parameters[4].Value = model.Pass;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.PageSize;
            parameters[7].Value = model.PageUrl;
            parameters[8].Value = model.RRate;
            parameters[9].Value = model.RInterver;
            parameters[10].Value = model.Power;
            parameters[11].Value = model.Paream0;
            parameters[12].Value = model.Paream1;
            parameters[13].Value = model.Paream2;
            parameters[14].Value = model.Paream3;
            parameters[15].Value = model.Paream4;
            parameters[16].Value = model.Paream5;

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
        public bool Update(Express.Model.SysSetInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysSetInfo set ");
            strSql.Append("cusname=@cusname,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("RemPass=@RemPass,");
            strSql.Append("AutoLogin=@AutoLogin,");
            strSql.Append("Pass=@Pass,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PageSize=@PageSize,");
            strSql.Append("PageUrl=@PageUrl,");
            strSql.Append("RRate=@RRate,");
            strSql.Append("RInterver=@RInterver,");
            strSql.Append("Power=@Power,");
            strSql.Append("Paream0=@Paream0,");
            strSql.Append("Paream1=@Paream1,");
            strSql.Append("Paream2=@Paream2,");
            strSql.Append("Paream3=@Paream3,");
            strSql.Append("Paream4=@Paream4,");
            strSql.Append("Paream5=@Paream5");
            strSql.Append(" where sysId=@sysId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@cusname", OleDbType.VarChar,255),
					new OleDbParameter("@Remark", OleDbType.VarChar,100),
					new OleDbParameter("@RemPass", OleDbType.Boolean,1),
					new OleDbParameter("@AutoLogin", OleDbType.Boolean,1),
					new OleDbParameter("@Pass", OleDbType.VarChar,100),
					new OleDbParameter("@UserName", OleDbType.VarChar,20),
					new OleDbParameter("@PageSize", OleDbType.Integer,4),
					new OleDbParameter("@PageUrl", OleDbType.VarChar,255),
					new OleDbParameter("@RRate", OleDbType.Integer,4),
					new OleDbParameter("@RInterver", OleDbType.Integer,4),
					new OleDbParameter("@Power", OleDbType.VarChar,255),
					new OleDbParameter("@Paream0", OleDbType.VarChar,255),
					new OleDbParameter("@Paream1", OleDbType.VarChar,255),
					new OleDbParameter("@Paream2", OleDbType.VarChar,255),
					new OleDbParameter("@Paream3", OleDbType.VarChar,255),
					new OleDbParameter("@Paream4", OleDbType.VarChar,255),
					new OleDbParameter("@Paream5", OleDbType.VarChar,255),
					new OleDbParameter("@sysId", OleDbType.Integer,4)};
            parameters[0].Value = model.cusname;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.RemPass;
            parameters[3].Value = model.AutoLogin;
            parameters[4].Value = model.Pass;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.PageSize;
            parameters[7].Value = model.PageUrl;
            parameters[8].Value = model.RRate;
            parameters[9].Value = model.RInterver;
            parameters[10].Value = model.Power;
            parameters[11].Value = model.Paream0;
            parameters[12].Value = model.Paream1;
            parameters[13].Value = model.Paream2;
            parameters[14].Value = model.Paream3;
            parameters[15].Value = model.Paream4;
            parameters[16].Value = model.Paream5;
            parameters[17].Value = model.sysId;

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
        public bool Delete(int sysId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysSetInfo ");
            strSql.Append(" where sysId=@sysId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@sysId", OleDbType.Integer,4)
			};
            parameters[0].Value = sysId;

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
        public bool DeleteList(string sysIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysSetInfo ");
            strSql.Append(" where sysId in (" + sysIdlist + ")  ");
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
        public Express.Model.SysSetInfo GetModel(int sysId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sysId,cusname,Remark,RemPass,AutoLogin,Pass,UserName,PageSize,PageUrl,RRate,RInterver,Power,Paream0,Paream1,Paream2,Paream3,Paream4,Paream5 from SysSetInfo ");
            strSql.Append(" where sysId=@sysId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@sysId", OleDbType.Integer,4)
			};
            parameters[0].Value = sysId;

            Express.Model.SysSetInfo model = new Express.Model.SysSetInfo();
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
        public Express.Model.SysSetInfo DataRowToModel(DataRow row)
        {
            Express.Model.SysSetInfo model = new Express.Model.SysSetInfo();
            if (row != null)
            {
                if (row["sysId"] != null && row["sysId"].ToString() != "")
                {
                    model.sysId = int.Parse(row["sysId"].ToString());
                }
                if (row["cusname"] != null)
                {
                    model.cusname = row["cusname"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["RemPass"] != null && row["RemPass"].ToString() != "")
                {
                    if ((row["RemPass"].ToString() == "1") || (row["RemPass"].ToString().ToLower() == "true"))
                    {
                        model.RemPass = true;
                    }
                    else
                    {
                        model.RemPass = false;
                    }
                }
                if (row["AutoLogin"] != null && row["AutoLogin"].ToString() != "")
                {
                    if ((row["AutoLogin"].ToString() == "1") || (row["AutoLogin"].ToString().ToLower() == "true"))
                    {
                        model.AutoLogin = true;
                    }
                    else
                    {
                        model.AutoLogin = false;
                    }
                }
                if (row["Pass"] != null)
                {
                    model.Pass = row["Pass"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["PageSize"] != null && row["PageSize"].ToString() != "")
                {
                    model.PageSize = int.Parse(row["PageSize"].ToString());
                }
                if (row["PageUrl"] != null)
                {
                    model.PageUrl = row["PageUrl"].ToString();
                }
                if (row["RRate"] != null && row["RRate"].ToString() != "")
                {
                    model.RRate = int.Parse(row["RRate"].ToString());
                }
                if (row["RInterver"] != null && row["RInterver"].ToString() != "")
                {
                    model.RInterver = int.Parse(row["RInterver"].ToString());
                }
                if (row["Power"] != null)
                {
                    model.Power = row["Power"].ToString();
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
                if (row["Paream5"] != null)
                {
                    model.Paream5 = row["Paream5"].ToString();
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
            strSql.Append("select sysId,cusname,Remark,RemPass,AutoLogin,Pass,UserName,PageSize,PageUrl,RRate,RInterver,Power,Paream0,Paream1,Paream2,Paream3,Paream4,Paream5 ");
            strSql.Append(" FROM SysSetInfo ");
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
            strSql.Append("select count(1) FROM SysSetInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.sysId desc");
            }
            strSql.Append(")AS Row, T.*  from SysSetInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOleDb.Query(strSql.ToString());
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
            parameters[0].Value = "SysSetInfo";
            parameters[1].Value = "sysId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 初始化记录
        /// </summary>
        public bool FormateData(string power)
        {
            bool isTrue = false;
            try
            {
                string sql = "";
                if(power.Substring(0,1)=="1")
                {
                    sql = "delete from Sys_User where username<>'admin'";
                    DbHelperOleDb.ExecuteSql(sql);
                }
                if (power.Substring(1, 1) == "1")
                {
                    sql = "delete from SysSetInfo";
                    DbHelperOleDb.ExecuteSql(sql);
                }
                if (power.Substring(3, 1) == "1")
                {
                    sql = "delete from OrderInfo";
                    DbHelperOleDb.ExecuteSql(sql);
                }
                if (power.Substring(4, 1) == "1")
                {
                    sql = "delete from SendOrderInfo";
                    DbHelperOleDb.ExecuteSql(sql);
                }
                if (power.Substring(2, 1) == "1")
                {
                    sql = "delete from CustomerInfo";
                    DbHelperOleDb.ExecuteSql(sql);
                }
                isTrue = true;
            }
            catch (Exception)
            {
                
            }
            return isTrue;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

