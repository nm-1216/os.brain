//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="News.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:23:22</datetime>
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
    /// News 实体类
    /// </summary>
    public partial class News:BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _news_Serial 自动编号
        /// </summary>
        private int _news_Serial;

        /// <summary>
        /// _news_ID 编号
        /// </summary>
        private string _news_ID = string.Empty;

        /// <summary>
        /// _news_Titel 标题
        /// </summary>
        private string _news_Titel = string.Empty;

        /// <summary>
        /// _news_Color 标题颜色
        /// </summary>
        private string _news_Color = "";

        /// <summary>
        /// _news_Summary 摘要
        /// </summary>
        private string _news_Summary = "";

        /// <summary>
        /// _news_Img 图片
        /// </summary>
        private string _news_Img = "";

        /// <summary>
        /// _news_IsEncode 
        /// </summary>
        private bool _news_IsEncode = false;

        /// <summary>
        /// _news_Price 
        /// </summary>
        private int _news_Price = 0;

        /// <summary>
        /// _news_Hits 
        /// </summary>
        private int _news_Hits = 0;

        /// <summary>
        /// _news_Content 内容
        /// </summary>
        private string _news_Content = "";

        /// <summary>
        /// _news_AddTime 添加时间
        /// </summary>
        private DateTime _news_AddTime =  DateTime.Now;

        /// <summary>
        /// _news_AddUser 添加人
        /// </summary>
        private string _news_AddUser = string.Empty;

        /// <summary>
        /// _news_Order 排序
        /// </summary>
        private int _news_Order = 100;

        /// <summary>
        /// _news_IsDel 伪删除
        /// </summary>
        private bool _news_IsDel = false;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets News_Serial 自动编号
        /// </summary>
        public int News_Serial
        {
            get {return this._news_Serial;}
            set {this._news_Serial = value;}
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
        /// Gets or sets News_Titel 标题
        /// </summary>
        public string News_Titel
        {
            get {return this._news_Titel;}
            set {this._news_Titel = value;}
        }


        /// <summary>
        /// Gets or sets News_Color 标题颜色
        /// </summary>
        public string News_Color
        {
            get {return this._news_Color;}
            set {this._news_Color = value;}
        }


        /// <summary>
        /// Gets or sets News_Summary 摘要
        /// </summary>
        public string News_Summary
        {
            get {return this._news_Summary;}
            set {this._news_Summary = value;}
        }


        /// <summary>
        /// Gets or sets News_Img 图片
        /// </summary>
        public string News_Img
        {
            get {return this._news_Img;}
            set {this._news_Img = value;}
        }


        /// <summary>
        /// Gets or sets News_IsEncode 
        /// </summary>
        public bool News_IsEncode
        {
            get {return this._news_IsEncode;}
            set {this._news_IsEncode = value;}
        }


        /// <summary>
        /// Gets or sets News_Price 
        /// </summary>
        public int News_Price
        {
            get {return this._news_Price;}
            set {this._news_Price = value;}
        }


        /// <summary>
        /// Gets or sets News_Hits 
        /// </summary>
        public int News_Hits
        {
            get {return this._news_Hits;}
            set {this._news_Hits = value;}
        }


        /// <summary>
        /// Gets or sets News_Content 内容
        /// </summary>
        public string News_Content
        {
            get {return this._news_Content;}
            set {this._news_Content = value;}
        }


        /// <summary>
        /// Gets or sets News_AddTime 添加时间
        /// </summary>
        public DateTime News_AddTime
        {
            get {return this._news_AddTime;}
            set {this._news_AddTime = value;}
        }


        /// <summary>
        /// Gets or sets News_AddUser 添加人
        /// </summary>
        public string News_AddUser
        {
            get {return this._news_AddUser;}
            set {this._news_AddUser = value;}
        }


        /// <summary>
        /// Gets or sets News_Order 排序
        /// </summary>
        public int News_Order
        {
            get {return this._news_Order;}
            set {this._news_Order = value;}
        }


        /// <summary>
        /// Gets or sets News_IsDel 伪删除
        /// </summary>
        public bool News_IsDel
        {
            get {return this._news_IsDel;}
            set {this._news_IsDel = value;}
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[News]", "[News_ID], [News_Titel], [News_Color], [News_Summary], [News_Img], [News_IsEncode], [News_Price], [News_Hits], [News_Content], [News_AddTime], [News_AddUser], [News_Order], [News_IsDel]" , "@News_ID, @News_Titel, @News_Color, @News_Summary, @News_Img, @News_IsEncode, @News_Price, @News_Hits, @News_Content, @News_AddTime, @News_AddUser, @News_Order, @News_IsDel"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion
            
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[News]", "[News_ID], [News_Titel], [News_Color], [News_Summary], [News_Img], [News_IsEncode], [News_Price], [News_Hits], [News_Content], [News_AddTime], [News_AddUser], [News_Order], [News_IsDel]" , "@News_ID, @News_Titel, @News_Color, @News_Summary, @News_Img, @News_IsEncode, @News_Price, @News_Hits, @News_Content, @News_AddTime, @News_AddUser, @News_Order, @News_IsDel"));

            db.AddInParameter(dbc, "@News_ID", DbType.AnsiString, this.News_ID);
            db.AddInParameter(dbc, "@News_Titel", DbType.String, this.News_Titel);
            db.AddInParameter(dbc, "@News_Color", DbType.AnsiString, this.News_Color);
            db.AddInParameter(dbc, "@News_Summary", DbType.String, this.News_Summary);
            db.AddInParameter(dbc, "@News_Img", DbType.AnsiString, this.News_Img);
            db.AddInParameter(dbc, "@News_IsEncode", DbType.Boolean, this.News_IsEncode);
            db.AddInParameter(dbc, "@News_Price", DbType.Int32, this.News_Price);
            db.AddInParameter(dbc, "@News_Hits", DbType.Int32, this.News_Hits);
            db.AddInParameter(dbc, "@News_Content", DbType.String, this.News_Content);
            db.AddInParameter(dbc, "@News_AddTime", DbType.DateTime, this.News_AddTime);
            db.AddInParameter(dbc, "@News_AddUser", DbType.AnsiString, this.News_AddUser);
            db.AddInParameter(dbc, "@News_Order", DbType.Int32, this.News_Order);
            db.AddInParameter(dbc, "@News_IsDel", DbType.Boolean, this.News_IsDel);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[News]","[News_ID] = @News_ID, [News_Titel] = @News_Titel, [News_Color] = @News_Color, [News_Summary] = @News_Summary, [News_Img] = @News_Img, [News_IsEncode] = @News_IsEncode, [News_Price] = @News_Price, [News_Hits] = @News_Hits, [News_Content] = @News_Content, [News_AddTime] = @News_AddTime, [News_AddUser] = @News_AddUser, [News_Order] = @News_Order, [News_IsDel] = @News_IsDel","News_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[News]","[News_ID] = @News_ID, [News_Titel] = @News_Titel, [News_Color] = @News_Color, [News_Summary] = @News_Summary, [News_Img] = @News_Img, [News_IsEncode] = @News_IsEncode, [News_Price] = @News_Price, [News_Hits] = @News_Hits, [News_Content] = @News_Content, [News_AddTime] = @News_AddTime, [News_AddUser] = @News_AddUser, [News_Order] = @News_Order, [News_IsDel] = @News_IsDel","News_Serial"));

            db.AddInParameter(dbc, "@News_Serial", DbType.Int32, this.News_Serial);
            db.AddInParameter(dbc, "@News_ID", DbType.AnsiString, this.News_ID);
            db.AddInParameter(dbc, "@News_Titel", DbType.String, this.News_Titel);
            db.AddInParameter(dbc, "@News_Color", DbType.AnsiString, this.News_Color);
            db.AddInParameter(dbc, "@News_Summary", DbType.String, this.News_Summary);
            db.AddInParameter(dbc, "@News_Img", DbType.AnsiString, this.News_Img);
            db.AddInParameter(dbc, "@News_IsEncode", DbType.Boolean, this.News_IsEncode);
            db.AddInParameter(dbc, "@News_Price", DbType.Int32, this.News_Price);
            db.AddInParameter(dbc, "@News_Hits", DbType.Int32, this.News_Hits);
            db.AddInParameter(dbc, "@News_Content", DbType.String, this.News_Content);
            db.AddInParameter(dbc, "@News_AddTime", DbType.DateTime, this.News_AddTime);
            db.AddInParameter(dbc, "@News_AddUser", DbType.AnsiString, this.News_AddUser);
            db.AddInParameter(dbc, "@News_Order", DbType.Int32, this.News_Order);
            db.AddInParameter(dbc, "@News_IsDel", DbType.Boolean, this.News_IsDel);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[News]", "[News_Serial]" ,"@News_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[News]", "[News_Serial]" ,"@News_Serial"));

            db.AddInParameter(dbc, "@News_Serial", DbType.Int32, this.News_Serial);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// News dal接口
    /// </summary>
    public interface INews : IBasicDal<Os.Brain.iBxg.Core.Entity.News>
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
    /// News dal数据处理层
    /// </summary>
    public partial class News:INews
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
		public object Edit(Os.Brain.iBxg.Core.Entity.News model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST,"[dbo].[News]","[News_Serial]","@News_Serial"));            
            Debug.WriteLine("@News_Serial="+"," + ids.Trim(',') + ",");            
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News.CONN);
            DbCommand dbc= db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST,"[dbo].[News]","[News_Serial]","@News_Serial"));

            db.AddInParameter(dbc, "@News_Serial", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
		public Os.Brain.iBxg.Core.Entity.News GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM,"[dbo].[News]","[News_Serial]","@News_Serial"));            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion
            
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.News _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM,"[dbo].[News]","[News_Serial]","@News_Serial"));

            db.AddInParameter(dbc, "@News_Serial", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.News();

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
        public IList<Os.Brain.iBxg.Core.Entity.News> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.News> returnList = new List<Os.Brain.iBxg.Core.Entity.News>();
            Os.Brain.iBxg.Core.Entity.News _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.News();

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
        public IList<Os.Brain.iBxg.Core.Entity.News> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.News> returnList = new List<Os.Brain.iBxg.Core.Entity.News>();
            Os.Brain.iBxg.Core.Entity.News _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.News();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News.CONN);
            DbCommand dbc = db.GetStoredProcCommand("News_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[News]", "News_ID", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.News.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }            

            var ds=db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr,Os.Brain.iBxg.Core.Entity.News model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
        		if (!dr.IsDBNull(0)) model.News_Serial = dr.GetInt32(0);
        		if (!dr.IsDBNull(1)) model.News_ID = dr.GetString(1);
        		if (!dr.IsDBNull(2)) model.News_Titel = dr.GetString(2);
        		if (!dr.IsDBNull(3)) model.News_Color = dr.GetString(3);
        		if (!dr.IsDBNull(4)) model.News_Summary = dr.GetString(4);
        		if (!dr.IsDBNull(5)) model.News_Img = dr.GetString(5);
        		if (!dr.IsDBNull(6)) model.News_IsEncode = dr.GetBoolean(6);
        		if (!dr.IsDBNull(7)) model.News_Price = dr.GetInt32(7);
        		if (!dr.IsDBNull(8)) model.News_Hits = dr.GetInt32(8);
        		if (!dr.IsDBNull(9)) model.News_Content = dr.GetString(9);
        		if (!dr.IsDBNull(10)) model.News_AddTime = dr.GetDateTime(10);
        		if (!dr.IsDBNull(11)) model.News_AddUser = dr.GetString(11);
        		if (!dr.IsDBNull(12)) model.News_Order = dr.GetInt32(12);
        		if (!dr.IsDBNull(13)) model.News_IsDel = dr.GetBoolean(13);
        	}
        }

        protected void LoadFromReader1(IDataReader dr,Os.Brain.iBxg.Core.Entity.News model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
                model.News_Serial = (int)dr["News_Serial"];
                model.News_ID = dr["News_ID"].ToString();
                model.News_Titel = dr["News_Titel"].ToString();
                model.News_Color = dr["News_Color"].ToString();
                model.News_Summary = dr["News_Summary"].ToString();
                model.News_Img = dr["News_Img"].ToString();
                model.News_IsEncode = (bool)dr["News_IsEncode"];
                model.News_Price = (int)dr["News_Price"];
                model.News_Hits = (int)dr["News_Hits"];
                model.News_Content = dr["News_Content"].ToString();
                model.News_AddTime = (DateTime)dr["News_AddTime"];
                model.News_AddUser = dr["News_AddUser"].ToString();
                model.News_Order = (int)dr["News_Order"];
                model.News_IsDel = (bool)dr["News_IsDel"];
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
    /// News 业务逻辑层
    /// </summary>
    public partial class News
    {
        /// <summary>
        /// dal 获取接口 INews
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.INews dal=DalFactory.CreateNews();

        /// <summary>
        /// Initializes a new instance of the <see cref="News"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public News(Os.Brain.Data.DataActions action)
        {
            this.dal.Action=action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
		public object Edit(Os.Brain.iBxg.Core.Entity.News model)
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
		public Os.Brain.iBxg.Core.Entity.News Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
		public IList<Os.Brain.iBxg.Core.Entity.News> GetList(DbParameter[] dataParams)
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
		public IList<Os.Brain.iBxg.Core.Entity.News> GetList(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
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
    /// News 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateNews 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.INews CreateNews()
        {
            return new Os.Brain.iBxg.Core.Dal.News();
        }
    }
}




