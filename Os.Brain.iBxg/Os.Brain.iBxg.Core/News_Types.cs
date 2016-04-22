//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="News_Types.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:23:39</datetime>
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
    /// News_Types 实体类
    /// </summary>
    public partial class News_Types:BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _nT_Serial 自动编号
        /// </summary>
        private int _nT_Serial;

        /// <summary>
        /// _types_ID 编号
        /// </summary>
        private string _types_ID = string.Empty;

        /// <summary>
        /// _news_ID 编号
        /// </summary>
        private string _news_ID = string.Empty;

        /// <summary>
        /// _nT_AddTime 添加时间
        /// </summary>
        private DateTime _nT_AddTime =  DateTime.Now;

        /// <summary>
        /// _nT_AddUser 添加人
        /// </summary>
        private string _nT_AddUser = string.Empty;

        /// <summary>
        /// _nT_IsDel 伪删除
        /// </summary>
        private bool _nT_IsDel = false;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets NT_Serial 自动编号
        /// </summary>
        public int NT_Serial
        {
            get {return this._nT_Serial;}
            set {this._nT_Serial = value;}
        }


        /// <summary>
        /// Gets or sets Types_ID 编号
        /// </summary>
        public string Types_ID
        {
            get {return this._types_ID;}
            set {this._types_ID = value;}
        }


        /// <summary>
        /// Gets or sets News_ID 编号
        /// </summary>
        public string News_ID
        {
            get {return this._news_ID;}
            set {this._news_ID = value;}
        }


        /// <summary>
        /// Gets or sets NT_AddTime 添加时间
        /// </summary>
        public DateTime NT_AddTime
        {
            get {return this._nT_AddTime;}
            set {this._nT_AddTime = value;}
        }


        /// <summary>
        /// Gets or sets NT_AddUser 添加人
        /// </summary>
        public string NT_AddUser
        {
            get {return this._nT_AddUser;}
            set {this._nT_AddUser = value;}
        }


        /// <summary>
        /// Gets or sets NT_IsDel 伪删除
        /// </summary>
        public bool NT_IsDel
        {
            get {return this._nT_IsDel;}
            set {this._nT_IsDel = value;}
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
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Entity.Insert START"));
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[News_Types]", "[Types_ID], [News_ID], [NT_AddTime], [NT_AddUser], [NT_IsDel]" , "@Types_ID, @News_ID, @NT_AddTime, @NT_AddUser, @NT_IsDel"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion
            
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[News_Types]", "[Types_ID], [News_ID], [NT_AddTime], [NT_AddUser], [NT_IsDel]" , "@Types_ID, @News_ID, @NT_AddTime, @NT_AddUser, @NT_IsDel"));

            db.AddInParameter(dbc, "@Types_ID", DbType.AnsiString, this.Types_ID);
            db.AddInParameter(dbc, "@News_ID", DbType.AnsiString, this.News_ID);
            db.AddInParameter(dbc, "@NT_AddTime", DbType.DateTime, this.NT_AddTime);
            db.AddInParameter(dbc, "@NT_AddUser", DbType.AnsiString, this.NT_AddUser);
            db.AddInParameter(dbc, "@NT_IsDel", DbType.Boolean, this.NT_IsDel);

            return db.ExecuteScalar(dbc);
        }

        /// <summary>
        /// Update 更新实体
        /// </summary>
        /// <returns>返回 IDENTITY</returns>
        public override object Update()
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Entity.Update START"));
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[News_Types]","[Types_ID] = @Types_ID, [News_ID] = @News_ID, [NT_AddTime] = @NT_AddTime, [NT_AddUser] = @NT_AddUser, [NT_IsDel] = @NT_IsDel","NT_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[News_Types]","[Types_ID] = @Types_ID, [News_ID] = @News_ID, [NT_AddTime] = @NT_AddTime, [NT_AddUser] = @NT_AddUser, [NT_IsDel] = @NT_IsDel","NT_Serial"));

            db.AddInParameter(dbc, "@NT_Serial", DbType.Int32, this.NT_Serial);
            db.AddInParameter(dbc, "@Types_ID", DbType.AnsiString, this.Types_ID);
            db.AddInParameter(dbc, "@News_ID", DbType.AnsiString, this.News_ID);
            db.AddInParameter(dbc, "@NT_AddTime", DbType.DateTime, this.NT_AddTime);
            db.AddInParameter(dbc, "@NT_AddUser", DbType.AnsiString, this.NT_AddUser);
            db.AddInParameter(dbc, "@NT_IsDel", DbType.Boolean, this.NT_IsDel);

            return db.ExecuteScalar(dbc);
        }

        /// <summary>
        /// Delete 删除实体
        /// </summary>
        /// <returns>返回 受影响行数</returns>
        public override int Delete()
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Entity.Delete START"));
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[News_Types]", "[NT_Serial]" ,"@NT_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[News_Types]", "[NT_Serial]" ,"@NT_Serial"));

            db.AddInParameter(dbc, "@NT_Serial", DbType.Int32, this.NT_Serial);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// News_Types dal接口
    /// </summary>
    public interface INews_Types : IBasicDal<Os.Brain.iBxg.Core.Entity.News_Types>
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
    /// News_Types dal数据处理层
    /// </summary>
    public partial class News_Types:INews_Types
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
		public object Edit(Os.Brain.iBxg.Core.Entity.News_Types model)
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
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.Delete START"));
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST,"[dbo].[News_Types]","[NT_Serial]","@NT_Serial"));            
            Debug.WriteLine("@NT_Serial="+"," + ids.Trim(',') + ",");            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.Delete END"));
            #endregion
        
            if (DataActions.delete != this.Action)
            {
                return 0;
            }

            if (ids.Length <= 0)
            {
                return 0;
            }

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News_Types.CONN);
            DbCommand dbc= db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST,"[dbo].[News_Types]","[NT_Serial]","@NT_Serial"));

            db.AddInParameter(dbc, "@NT_Serial", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
		public Os.Brain.iBxg.Core.Entity.News_Types GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM,"[dbo].[News_Types]","[NT_Serial]","@NT_Serial"));            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion
            
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.News_Types _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News_Types.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM,"[dbo].[News_Types]","[NT_Serial]","@NT_Serial"));

            db.AddInParameter(dbc, "@NT_Serial", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.News_Types();

                    LoadFromReader(dr,_model);
                }
            }

            return _model;
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>返回 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.News_Types> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.News_Types> returnList = new List<Os.Brain.iBxg.Core.Entity.News_Types>();
            Os.Brain.iBxg.Core.Entity.News_Types _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News_Types.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Types_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.News_Types();

                    LoadFromReader(dr,_model);

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
        public IList<Os.Brain.iBxg.Core.Entity.News_Types> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.News_Types> returnList = new List<Os.Brain.iBxg.Core.Entity.News_Types>();
            Os.Brain.iBxg.Core.Entity.News_Types _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News_Types.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Types_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.News_Types();

                    LoadFromReader(dr,_model);

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News_Types.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Types_Get");

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
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News_Types.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Types_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            db.AddInParameter(dbc, "@PageIndex", DbType.Int32, currPage);
            db.AddInParameter(dbc, "@PageSize", DbType.Int32, pageSize);
            db.AddOutParameter(dbc, "@RecordCount", DbType.Int32, 4);

            var ds=db.ExecuteDataSet(dbc);

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
        public DataSet GetDataSet(int pageSize, int currPage, out int recordCount,string strWhere, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[News_Types]", "NT_Serial", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News_Types.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }            

            var ds=db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr,Os.Brain.iBxg.Core.Entity.News_Types model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
        		if (!dr.IsDBNull(0)) model.NT_Serial = dr.GetInt32(0);
        		if (!dr.IsDBNull(1)) model.Types_ID = dr.GetString(1);
        		if (!dr.IsDBNull(2)) model.News_ID = dr.GetString(2);
        		if (!dr.IsDBNull(3)) model.NT_AddTime = dr.GetDateTime(3);
        		if (!dr.IsDBNull(4)) model.NT_AddUser = dr.GetString(4);
        		if (!dr.IsDBNull(5)) model.NT_IsDel = dr.GetBoolean(5);
        	}
        }

        protected void LoadFromReader1(IDataReader dr,Os.Brain.iBxg.Core.Entity.News_Types model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
                model.NT_Serial = (int)dr["NT_Serial"];
                model.Types_ID = dr["Types_ID"].ToString();
                model.News_ID = dr["News_ID"].ToString();
                model.NT_AddTime = (DateTime)dr["NT_AddTime"];
                model.NT_AddUser = dr["NT_AddUser"].ToString();
                model.NT_IsDel = (bool)dr["NT_IsDel"];
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
    /// News_Types 业务逻辑层
    /// </summary>
    public partial class News_Types
    {
        /// <summary>
        /// dal 获取接口 INews_Types
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.INews_Types dal=DalFactory.CreateNews_Types();

        /// <summary>
        /// Initializes a new instance of the <see cref="News_Types"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public News_Types(Os.Brain.Data.DataActions action)
        {
            this.dal.Action=action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
		public object Edit(Os.Brain.iBxg.Core.Entity.News_Types model)
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
		public Os.Brain.iBxg.Core.Entity.News_Types Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
		public IList<Os.Brain.iBxg.Core.Entity.News_Types> GetList(DbParameter[] dataParams)
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
		public IList<Os.Brain.iBxg.Core.Entity.News_Types> GetList(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
        {
            return this.dal.GetList(pageSize, currPage,out recordCount,dataParams);
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
		public DataSet GetDataSet(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
        {
            return this.dal.GetDataSet(pageSize, currPage,out recordCount,dataParams);
        }
    }
}
namespace Os.Brain.iBxg.Core
{
    /// <summary>
    /// News_Types 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateNews_Types 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.INews_Types CreateNews_Types()
        {
            return new Os.Brain.iBxg.Core.Dal.News_Types();
        }
    }
}




