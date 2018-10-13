using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
    /// <summary>
    /// OrgOrder
    /// </summary>
    public partial class OrgOrder
    {
        private readonly Express.DAL.OrgOrder dal = new Express.DAL.OrgOrder();
        public OrgOrder()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteByCondition(string where)
        {
            return dal.DeleteByCondition(where);
        }

            /// <summary>
            /// 增加一条数据
            /// </summary>
            public bool Add(Express.Model.OrgOrder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Express.Model.OrgOrder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.OrgOrder GetModel(int id)
        {

            return dal.GetModel(id);
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
        public List<Express.Model.OrgOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Express.Model.OrgOrder> DataTableToList(DataTable dt)
        {
            List<Express.Model.OrgOrder> modelList = new List<Express.Model.OrgOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Express.Model.OrgOrder model;
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

        public bool AddByGroup(DataTable dt1)
        {
            return dal.AddByGroup(dt1);
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

