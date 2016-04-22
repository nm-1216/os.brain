//-----------------------------------------------------------------------
// <copyright file="Methods.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>通用操作数据库函数</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Data
{
    using System.Data.Common;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// common methods
    /// </summary>
    public partial class Methods
    {
        /// <summary>
        /// Get Max Id
        /// </summary>
        /// <param name="conn">database connection</param>
        /// <param name="dataParams">Stored Procedures Parameters</param>
        /// <returns>Return Id</returns>
        public static string GetMaxId(string conn, params DbParameter[] dataParams)
        {
            Database db = null;
            if (string.IsNullOrEmpty(conn))
            {
                db = DatabaseFactory.CreateDatabase();
            }
            else
            {
                db = DatabaseFactory.CreateDatabase(conn);
            }

            DbCommand dbc = db.GetStoredProcCommand("proc_common_GetMaxId");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            db.ExecuteNonQuery(dbc);

            return dbc.Parameters["@NewRecord"].Value.ToString();
        }
    }
}
