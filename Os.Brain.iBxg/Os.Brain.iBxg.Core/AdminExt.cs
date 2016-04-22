//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:19:33</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.iBxg.Core.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    using Os.Brain.Data;
    using Os.Brain.Data.MsSQL;

    /// <summary>
    /// Admin dal数据处理层
    /// </summary>
    public partial class Admin : IAdmin
    {
        
        

       

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
        public Os.Brain.iBxg.Core.Entity.Admin GetItemByUserID(string UserID)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM, "[dbo].[Admin]", "[Admin_Serial]", "@Admin_Serial"));
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion

            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.Admin _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM, "[dbo].[Admin]", "[Admin_UserID]", "@Admin_UserID"));

            db.AddInParameter(dbc, "@Admin_UserID", DbType.String, UserID);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Admin();

                    LoadFromReader(dr, _model);
                }
            }

            return _model;
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>

        public Os.Brain.iBxg.Core.Entity.Admin GetItemByID(string ID)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM, "[dbo].[Admin]", "[Admin_Serial]", "@Admin_Serial"));
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion

            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.Admin _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM, "[dbo].[Admin]", "[Admin_ID]", "@Admin_ID"));

            db.AddInParameter(dbc, "@Admin_ID", DbType.String, ID);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Admin();

                    LoadFromReader(dr, _model);
                }
            }

            return _model;
        }

    
    }
}




