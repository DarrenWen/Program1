using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
    /// <summary>
    /// OrderView
    /// </summary>
    public partial class OrderView
    {
        private readonly Express.DAL.OrderView dal = new Express.DAL.OrderView();
        public OrderView()
        { }
        #region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.OrderView GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

         /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string condition, string strWhere)
        {
            return dal.GetList(condition, strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Express.Model.OrderView> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Express.Model.OrderView> DataTableToList(DataTable dt)
        {
            List<Express.Model.OrderView> modelList = new List<Express.Model.OrderView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Express.Model.OrderView model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string condition, string strWhere, string orderby, int pageSize, int pageCount)
        {
            return dal.GetListByPage(condition, strWhere, orderby, pageSize, pageCount);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

