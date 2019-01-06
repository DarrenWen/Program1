using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
    /// <summary>
    /// 数据访问类:OrderView
    /// </summary>
    public partial class OrderView
    {
        public OrderView()
        { }
        #region  BasicMethod


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.OrderView GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from OrderView ");
            strSql.Append(" where Id=@Id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)			};
            parameters[0].Value = Id;

            Express.Model.OrderView model = new Express.Model.OrderView();
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
        public Express.Model.OrderView DataRowToModel(DataRow row)
        {
            Express.Model.OrderView model = new Express.Model.OrderView();
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
                if (row["NewContractdate"] != null)
                {
                    model.NewContractdate = row["NewContractdate"].ToString();
                }
                if (row["OStateName"] != null)
                {
                    model.OStateName = row["OStateName"].ToString();
                }
                if (row["ORStateName"] != null)
                {
                    model.ORStateName = row["ORStateName"].ToString();
                }
                if (row["cusname"] != null)
                {
                    model.cusname = row["cusname"].ToString();
                }
                if (row["pername"] != null)
                {
                    model.pername = row["pername"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM OrderView ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string condition,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ").Append(condition);
            strSql.Append(" FROM OrderView ");
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
            strSql.Append("select count(1) FROM OrderView ");
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

            string sql = string.Format("select top {0} * from (select top {1} * from OrderView {2} order by id desc) order by id", pageSize, pageSize * pageCount, string.IsNullOrEmpty(strWhere) ? "" : " where " + strWhere);

            return DbHelperOleDb.Query(sql);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string condition, string strWhere, string orderby, int pageSize, int pageCount)
        {

            string sql = string.Format("select top {0} {3} from (select top {1} {3} from OrderView {2} order by id desc) order by id", pageSize, pageSize * pageCount, string.IsNullOrEmpty(strWhere) ? "" : " where " + strWhere, condition);

            return DbHelperOleDb.Query(sql);
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
            parameters[0].Value = "OrderView";
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

