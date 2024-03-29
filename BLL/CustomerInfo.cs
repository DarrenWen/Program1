﻿using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
	/// <summary>
	/// CustomerInfo
	/// </summary>
	public partial class CustomerInfo
	{
		private readonly Express.DAL.CustomerInfo dal=new Express.DAL.CustomerInfo();
		public CustomerInfo()
		{}
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
		public bool Exists(int cid)
		{
			return dal.Exists(cid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.CustomerInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.CustomerInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cid)
		{
			
			return dal.Delete(cid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string cidlist )
		{
			return dal.DeleteList(cidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.CustomerInfo GetModel(int cid)
		{
			
			return dal.GetModel(cid);
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
		public List<Express.Model.CustomerInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.CustomerInfo> DataTableToList(DataTable dt)
		{
			List<Express.Model.CustomerInfo> modelList = new List<Express.Model.CustomerInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Express.Model.CustomerInfo model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

