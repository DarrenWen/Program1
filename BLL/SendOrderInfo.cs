using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
    /// <summary>
    /// OrderInfo
    /// </summary>
    public partial class SendOrderInfo
    {
        private readonly Express.DAL.SendOrderInfo dal = new Express.DAL.SendOrderInfo();
        public SendOrderInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Express.Model.SendOrderInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Express.Model.SendOrderInfo model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="cusId"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool UpdateOrderCusInfo(int cusId, string condition)
        {
            return dal.UpdateOrderCusInfo(cusId, condition);
        }

        /// <summary>
        /// 更新时间信息
        /// </summary>
        /// <param name="cusId"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool UpdateDateInfo(DateTime dt, string condition)
        {
            return dal.UpdateDateInfo(dt, condition);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteByCondition(string where)
        {
            return dal.DeleteByCondition(where);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.SendOrderInfo GetModel(int Id)
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
        public List<Express.Model.SendOrderInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Express.Model.SendOrderInfo> DataTableToList(DataTable dt)
        {
            List<Express.Model.SendOrderInfo> modelList = new List<Express.Model.SendOrderInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Express.Model.SendOrderInfo model;
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

