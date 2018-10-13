using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
	/// <summary>
	/// Sys_User
	/// </summary>
	public partial class Sys_User
	{
		private readonly Express.DAL.Sys_User dal=new Express.DAL.Sys_User();
		public Sys_User()
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
		public bool Exists(int UID)
		{
			return dal.Exists(UID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.Sys_User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.Sys_User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UID)
		{
			
			return dal.Delete(UID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UIDlist )
		{
			return dal.DeleteList(UIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.Sys_User GetModel(int UID)
		{
			
			return dal.GetModel(UID);
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
		public List<Express.Model.Sys_User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.Sys_User> DataTableToList(DataTable dt)
		{
			List<Express.Model.Sys_User> modelList = new List<Express.Model.Sys_User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Express.Model.Sys_User model;
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

