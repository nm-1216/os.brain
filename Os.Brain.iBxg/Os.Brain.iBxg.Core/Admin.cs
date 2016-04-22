//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:19:33</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.iBxg.Core.Entity
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    using Os.Brain.Data;
    using Os.Brain.Data.Entity;
    using Os.Brain.Data.MsSQL;
    /// <summary>
    /// Admin 实体类
    /// </summary>
    public partial class Admin : BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _admin_Serial 自动编号
        /// </summary>
        private int _admin_Serial;

        /// <summary>
        /// _admin_ID 编号
        /// </summary>
        private string _admin_ID = string.Empty;

        /// <summary>
        /// _admin_UserID 登录名
        /// </summary>
        private string _admin_UserID = string.Empty;

        /// <summary>
        /// _admin_Pwd 密码
        /// </summary>
        private string _admin_Pwd = string.Empty;

        /// <summary>
        /// _admin_Name 管理员名称
        /// </summary>
        private string _admin_Name = string.Empty;

        /// <summary>
        /// _admin_AddTime 添加时间
        /// </summary>
        private DateTime _admin_AddTime = DateTime.Now;

        /// <summary>
        /// _admin_Roles 
        /// </summary>
        private string _admin_Roles = "admin";

        /// <summary>
        /// _admin_AddUser 添加人
        /// </summary>
        private string _admin_AddUser = string.Empty;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Admin_Serial 自动编号
        /// </summary>
        public int Admin_Serial
        {
            get { return this._admin_Serial; }
            set { this._admin_Serial = value; }
        }


        /// <summary>
        /// Gets or sets Admin_ID 编号
        /// </summary>
        public string Admin_ID
        {
            get { return this._admin_ID; }
            set { this._admin_ID = value; }
        }


        /// <summary>
        /// Gets or sets Admin_UserID 登录名
        /// </summary>
        public string Admin_UserID
        {
            get { return this._admin_UserID; }
            set { this._admin_UserID = value; }
        }


        /// <summary>
        /// Gets or sets Admin_Pwd 密码
        /// </summary>
        public string Admin_Pwd
        {
            get { return this._admin_Pwd; }
            set { this._admin_Pwd = value; }
        }


        /// <summary>
        /// Gets or sets Admin_Name 管理员名称
        /// </summary>
        public string Admin_Name
        {
            get { return this._admin_Name; }
            set { this._admin_Name = value; }
        }


        /// <summary>
        /// Gets or sets Admin_AddTime 添加时间
        /// </summary>
        public DateTime Admin_AddTime
        {
            get { return this._admin_AddTime; }
            set { this._admin_AddTime = value; }
        }


        /// <summary>
        /// Gets or sets Admin_Roles 
        /// </summary>
        public string Admin_Roles
        {
            get { return this._admin_Roles; }
            set { this._admin_Roles = value; }
        }


        /// <summary>
        /// Gets or sets Admin_AddUser 添加人
        /// </summary>
        public string Admin_AddUser
        {
            get { return this._admin_AddUser; }
            set { this._admin_AddUser = value; }
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Insert 新增实体
        /// </summary>
        /// <returns>返回 IDENTITY</returns>
        public override object Insert()
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Entity.Insert START"));
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[Admin]", "[Admin_ID], [Admin_UserID], [Admin_Pwd], [Admin_Name], [Admin_AddTime], [Admin_Roles], [Admin_AddUser]", "@Admin_ID, @Admin_UserID, @Admin_Pwd, @Admin_Name, @Admin_AddTime, @Admin_Roles, @Admin_AddUser"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[Admin]", "[Admin_UserID], [Admin_Pwd], [Admin_Name], [Admin_AddTime], [Admin_Roles], [Admin_AddUser]", "@Admin_UserID, @Admin_Pwd, @Admin_Name, @Admin_AddTime, @Admin_Roles, @Admin_AddUser"));

            db.AddInParameter(dbc, "@Admin_UserID", DbType.AnsiString, this.Admin_UserID);
            db.AddInParameter(dbc, "@Admin_Pwd", DbType.AnsiString, this.Admin_Pwd);
            db.AddInParameter(dbc, "@Admin_Name", DbType.String, this.Admin_Name);
            db.AddInParameter(dbc, "@Admin_AddTime", DbType.DateTime, this.Admin_AddTime);
            db.AddInParameter(dbc, "@Admin_Roles", DbType.AnsiString, this.Admin_Roles);
            db.AddInParameter(dbc, "@Admin_AddUser", DbType.AnsiString, this.Admin_AddUser);

            return db.ExecuteScalar(dbc);
        }

        /// <summary>
        /// Update 更新实体
        /// </summary>
        /// <returns>返回 IDENTITY</returns>
        public override object Update()
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Entity.Update START"));
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[Admin]", "[Admin_ID] = @Admin_ID, [Admin_UserID] = @Admin_UserID, [Admin_Pwd] = @Admin_Pwd, [Admin_Name] = @Admin_Name, [Admin_AddTime] = @Admin_AddTime, [Admin_Roles] = @Admin_Roles, [Admin_AddUser] = @Admin_AddUser", "Admin_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[Admin]", " [Admin_UserID] = @Admin_UserID, [Admin_Pwd] = @Admin_Pwd, [Admin_Name] = @Admin_Name, [Admin_AddTime] = @Admin_AddTime, [Admin_Roles] = @Admin_Roles, [Admin_AddUser] = @Admin_AddUser", "Admin_Serial"));

            db.AddInParameter(dbc, "@Admin_Serial", DbType.Int32, this.Admin_Serial);
            db.AddInParameter(dbc, "@Admin_UserID", DbType.AnsiString, this.Admin_UserID);
            db.AddInParameter(dbc, "@Admin_Pwd", DbType.AnsiString, this.Admin_Pwd);
            db.AddInParameter(dbc, "@Admin_Name", DbType.String, this.Admin_Name);
            db.AddInParameter(dbc, "@Admin_AddTime", DbType.DateTime, this.Admin_AddTime);
            db.AddInParameter(dbc, "@Admin_Roles", DbType.AnsiString, this.Admin_Roles);
            db.AddInParameter(dbc, "@Admin_AddUser", DbType.AnsiString, this.Admin_AddUser);

            return db.ExecuteScalar(dbc);
        }

        /// <summary>
        /// Delete 删除实体
        /// </summary>
        /// <returns>返回 受影响行数</returns>
        public override int Delete()
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Entity.Delete START"));
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[Admin]", "[Admin_Serial]", "@Admin_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[Admin]", "[Admin_Serial]", "@Admin_Serial"));

            db.AddInParameter(dbc, "@Admin_Serial", DbType.Int32, this.Admin_Serial);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// Admin dal接口
    /// </summary>
    public interface IAdmin : IBasicDal<Os.Brain.iBxg.Core.Entity.Admin>
    {
        /// <summary>
        /// Gets or sets Action 操作
        /// </summary>
        Os.Brain.Data.DataActions Action
        {
            get;
            set;
        }
    }
}
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
        /// 私有 数据操作行为
        /// </summary>
        private DataActions _action;

        /// <summary>
        /// Gets or sets Action 数据操作行为
        /// </summary>
        public DataActions Action
        {
            get { return this._action; }
            set { this._action = value; }
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>返回 实体主键</returns>
        public object Edit(Os.Brain.iBxg.Core.Entity.Admin model)
        {
            if (DataActions.insert == this.Action)
            {
                return model.Insert();
            }

            if (DataActions.update == this.Action)
            {
                return model.Update();
            }

            if (DataActions.delete == this.Action)
            {
                return model.Delete();
            }

            return null;
        }

        /// <summary>
        /// Delete 删除记录集
        /// </summary>
        /// <param name="ids">ids 编号集</param>
        /// <returns>返回 受影响条数</returns>
        public int Delete(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Dal.Delete START"));
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST, "[dbo].[Admin]", "[Admin_Serial]", "@Admin_Serial"));
            Debug.WriteLine("@Admin_Serial=" + "," + ids.Trim(',') + ",");
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Dal.Delete END"));
            #endregion

            if (DataActions.delete != this.Action)
            {
                return 0;
            }

            if (ids.Length <= 0)
            {
                return 0;
            }

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST, "[dbo].[Admin]", "[Admin_Serial]", "@Admin_Serial"));

            db.AddInParameter(dbc, "@Admin_Serial", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
        public Os.Brain.iBxg.Core.Entity.Admin GetItem(string ids)
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
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM, "[dbo].[Admin]", "[Admin_Serial]", "@Admin_Serial"));

            db.AddInParameter(dbc, "@Admin_Serial", DbType.Int32, ids);

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
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>返回 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.Admin> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.Admin> returnList = new List<Os.Brain.iBxg.Core.Entity.Admin>();
            Os.Brain.iBxg.Core.Entity.Admin _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Admin_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Admin();

                    LoadFromReader(dr, _model);

                    returnList.Add(_model);
                }
            }

            return returnList;
        }

        /// <summary>
        /// GetList 获取分页数据集
        /// </summary>
        /// <param name="pageSize">pageSize 每页条数</param>
        /// <param name="currPage">currPage 当前页码</param>
        /// <param name="recordCount">recordCount 总记录数</param>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>返回 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.Admin> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount = 0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.Admin> returnList = new List<Os.Brain.iBxg.Core.Entity.Admin>();
            Os.Brain.iBxg.Core.Entity.Admin _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Admin_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            db.AddInParameter(dbc, "@PageIndex", DbType.Int32, currPage);
            db.AddInParameter(dbc, "@PageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbc, "@RecordCount", DbType.Int32, 4);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Admin();

                    LoadFromReader(dr, _model);

                    returnList.Add(_model);
                }
            }

            recordCount = (int)dbc.Parameters["@RecordCount"].Value;

            return returnList;
        }

        /// <summary>
        /// DataSet 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>返回 数据集</returns>
        public DataSet GetDataSet(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Admin_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            return db.ExecuteDataSet(dbc);
        }

        /// <summary>
        /// GetDataSet 获取分页数据集
        /// </summary>
        /// <param name="pageSize">pageSize 每页条数</param>
        /// <param name="currPage">currPage 当前页码</param>
        /// <param name="recordCount">recordCount 总记录数</param>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>返回 数据集</returns>
        public DataSet GetDataSet(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount = 0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Admin_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            db.AddInParameter(dbc, "@PageIndex", DbType.Int32, currPage);
            db.AddInParameter(dbc, "@PageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbc, "@RecordCount", DbType.Int32, 4);

            var ds = db.ExecuteDataSet(dbc);

            recordCount = (int)dbc.Parameters["@RecordCount"].Value;

            return ds;
        }

        /// <summary>
        /// GetDataSet 获取分页数据集
        /// </summary>
        /// <param name="pageSize">pageSize 每页条数</param>
        /// <param name="currPage">currPage 当前页码</param>
        /// <param name="recordCount">recordCount 总记录数</param>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>返回 数据集</returns>
        public DataSet GetDataSet(int pageSize, int currPage, out int recordCount, string strWhere, params DbParameter[] dataParams)
        {
            recordCount = 0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[Admin]", "Admin_Serial", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Admin.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            var ds = db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr, Os.Brain.iBxg.Core.Entity.Admin model)
        {
            if (dr != null && !dr.IsClosed)
            {
                if (!dr.IsDBNull(0)) model.Admin_Serial = dr.GetInt32(0);
                if (!dr.IsDBNull(1)) model.Admin_ID = dr.GetString(1);
                if (!dr.IsDBNull(2)) model.Admin_UserID = dr.GetString(2);
                if (!dr.IsDBNull(3)) model.Admin_Pwd = dr.GetString(3);
                if (!dr.IsDBNull(4)) model.Admin_Name = dr.GetString(4);
                if (!dr.IsDBNull(5)) model.Admin_AddTime = dr.GetDateTime(5);
                if (!dr.IsDBNull(6)) model.Admin_Roles = dr.GetString(6);
                if (!dr.IsDBNull(7)) model.Admin_AddUser = dr.GetString(7);
            }
        }

        protected void LoadFromReader1(IDataReader dr, Os.Brain.iBxg.Core.Entity.Admin model)
        {
            if (dr != null && !dr.IsClosed)
            {
                model.Admin_Serial = (int)dr["Admin_Serial"];
                model.Admin_ID = dr["Admin_ID"].ToString();
                model.Admin_UserID = dr["Admin_UserID"].ToString();
                model.Admin_Pwd = dr["Admin_Pwd"].ToString();
                model.Admin_Name = dr["Admin_Name"].ToString();
                model.Admin_AddTime = (DateTime)dr["Admin_AddTime"];
                model.Admin_Roles = dr["Admin_Roles"].ToString();
                model.Admin_AddUser = dr["Admin_AddUser"].ToString();
            }
        }
    }
}
namespace Os.Brain.iBxg.Core.Bll
{
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data;
    using System.Xml;

    /// <summary>
    /// Admin 业务逻辑层
    /// </summary>
    public partial class Admin
    {
        /// <summary>
        /// dal 获取接口 IAdmin
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.IAdmin dal = DalFactory.CreateAdmin();

        /// <summary>
        /// Initializes a new instance of the <see cref="Admin"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public Admin(Os.Brain.Data.DataActions action)
        {
            this.dal.Action = action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
        public object Edit(Os.Brain.iBxg.Core.Entity.Admin model)
        {
            return this.dal.Edit(model);
        }

        /// <summary>
        /// Delete 删除记录集
        /// </summary>
        /// <param name="ids">ids 编号集</param>
        /// <returns>returns 受影响条数</returns>
        public int Delete(string ids)
        {
            return this.dal.Delete(ids);
        }

        /// <summary>
        /// Read 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>returns 空或实体</returns>
        public Os.Brain.iBxg.Core.Entity.Admin Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.Admin> GetList(DbParameter[] dataParams)
        {
            return this.dal.GetList(dataParams);
        }

        /// <summary>
        /// GetList 获取分页数据集
        /// </summary>
        /// <param name="pageSize">pageSize 每页条数</param>
        /// <param name="currPage">currPage 当前页码</param>
        /// <param name="recordCount">recordCount 总记录数</param>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.Admin> GetList(int pageSize, int currPage, out int recordCount, DbParameter[] dataParams)
        {
            return this.dal.GetList(pageSize, currPage, out recordCount, dataParams);
        }

        /// <summary>
        /// GetDataSet 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
        public DataSet GetDataSet(DbParameter[] dataParams)
        {
            return this.dal.GetDataSet(dataParams);
        }

        /// <summary>
        /// GetDataSet 获取分页数据集
        /// </summary>
        /// <param name="pageSize">pageSize 每页条数</param>
        /// <param name="currPage">currPage 当前页码</param>
        /// <param name="recordCount">recordCount 总记录数</param>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
        public DataSet GetDataSet(int pageSize, int currPage, out int recordCount, DbParameter[] dataParams)
        {
            return this.dal.GetDataSet(pageSize, currPage, out recordCount, dataParams);
        }
    }
}
namespace Os.Brain.iBxg.Core
{
    /// <summary>
    /// Admin 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateAdmin 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.IAdmin CreateAdmin()
        {
            return new Os.Brain.iBxg.Core.Dal.Admin();
        }
    }
}




