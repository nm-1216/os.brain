//-----------------------------------------------------------------------
// <copyright file="IBasicDal.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>DAO接口层 基础接口
// Discription:
//       DAO接口层：
//           命名规则：类名称 = 类前缀 + Object + 类后缀，其中类前缀为I，后缀为 Dao，如：ISalesOrderDao
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Data.Dal
{
    using System.Collections.Generic;
    using System.Data.Common;
using System.Data;

    /// <summary>
    /// Basic dal Interface
    /// </summary>
    /// <typeparam name="T">T is Entity</typeparam>
    public interface IBasicDal<T>
    {
        /// <summary>
        /// Edit entity include insert.update.delete
        /// </summary>
        /// <param name="t">T is Entity</param>
        /// <returns>Return object</returns>
        object Edit(T t);

        /// <summary>
        /// Delete data record set
        /// </summary>
        /// <param name="ids">Id list</param>
        /// <returns>Affected by the number of</returns>
        int Delete(string ids);

        /// <summary>
        /// Get One Entity
        /// </summary>
        /// <param name="id">Id Card</param>
        /// <returns>Return Entity</returns>
        T GetItem(string id);

        /// <summary>
        /// Get Entity List
        /// </summary>
        /// <param name="dataParams">Parameter List</param>
        /// <returns>Return Entity List</returns>
        IList<T> GetList(params DbParameter[] dataParams);

        /// <summary>
        /// Get Entity List By Page
        /// </summary>
        /// <param name="pageSize">The maximum number of records by one page</param>
        /// <param name="currPage">Current Page</param>
        /// <param name="recordCount">The number of records</param>
        /// <param name="dataParams">Parameter List</param>
        /// <returns>Return Entity List</returns>
        IList<T> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams);

        /// <summary>
        /// Get DataSet
        /// </summary>
        /// <param name="dataParams">Parameter List</param>
        /// <returns>Return DataSet</returns>
        DataSet GetDataSet(params DbParameter[] dataParams);

        /// <summary>
        /// Get DataSet By Page
        /// </summary>
        /// <param name="pageSize">The maximum number of records by one page</param>
        /// <param name="currPage">Current Page</param>
        /// <param name="recordCount">The number of records</param>
        /// <param name="dataParams">Parameter List</param>
        /// <returns>Return DataSet</returns>
        DataSet GetDataSet(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams);
    }
}
