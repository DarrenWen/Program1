using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
	/// <summary>
	/// SysSetInfo
	/// </summary>
	public partial class SysSetInfo
	{
		private readonly Express.DAL.SysSetInfo dal=new Express.DAL.SysSetInfo();
		public SysSetInfo()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sysId)
		{
			return dal.Exists(sysId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.SysSetInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.SysSetInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int sysId)
		{
			
			return dal.Delete(sysId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sysIdlist )
		{
			return dal.DeleteList(sysIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.SysSetInfo GetModel(int sysId)
		{
			
			return dal.GetModel(sysId);
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
		public List<Express.Model.SysSetInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.SysSetInfo> DataTableToList(DataTable dt)
		{
			List<Express.Model.SysSetInfo> modelList = new List<Express.Model.SysSetInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Express.Model.SysSetInfo model;
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


        /// <summary>
        /// 初始化记录
        /// </summary>
        public bool FormateData(string power)
        {
            return dal.FormateData(power);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

