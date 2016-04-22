//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsOrder.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:23:55</datetime>
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
    /// NewsOrder 实体类
    /// </summary>
    public partial class NewsOrder:BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _order_Serial 自动编号
        /// </summary>
        private int _order_Serial;

        /// <summary>
        /// _news_ID 
        /// </summary>
        private string _news_ID = string.Empty;

        /// <summary>
        /// _order_AddTime 
        /// </summary>
        private DateTime _order_AddTime =  DateTime.Now;

        /// <summary>
        /// _order_User 
        /// </summary>
        private int? _order_User;

        /// <summary>
        /// _order_Status 
        /// </summary>
        private int _order_Status;

        /// <summary>
        /// _order_Money 
        /// </summary>
        private decimal _order_Money = 0M;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Order_Serial 自动编号
        /// </summary>
        public int Order_Serial
        {
            get {return this._order_Serial;}
            set {this._order_Serial = value;}
        }


        /// <summary>
        /// Gets or sets News_ID 
        /// </summary>
        public string News_ID
        {
            get {return this._news_ID;}
            set {this._news_ID = value;}
        }


        /// <summary>
        /// Gets or sets Order_AddTime 
        /// </summary>
        public DateTime Order_AddTime
        {
            get {return this._order_AddTime;}
            set {this._order_AddTime = value;}
        }


        /// <summary>
        /// Gets or sets Order_User 
        /// </summary>
        public int? Order_User
        {
            get {return this._order_User;}
            set {this._order_User = value;}
        }


        /// <summary>
        /// Gets or sets Order_Status 
        /// </summary>
        public int Order_Status
        {
            get {return this._order_Status;}
            set {this._order_Status = value;}
        }


        /// <summary>
        /// Gets or sets Order_Money 
        /// </summary>
        public decimal Order_Money
        {
            get {return this._order_Money;}
            set {this._order_Money = value;}
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[NewsOrder]", "[News_ID], [Order_AddTime], [Order_User], [Order_Status], [Order_Money]" , "@News_ID, @Order_AddTime, @Order_User, @Order_Status, @Order_Money"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion
            
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[NewsOrder]", "[News_ID], [Order_AddTime], [Order_User], [Order_Status], [Order_Money]" , "@News_ID, @Order_AddTime, @Order_User, @Order_Status, @Order_Money"));

            db.AddInParameter(dbc, "@News_ID", DbType.AnsiString, this.News_ID);
            db.AddInParameter(dbc, "@Order_AddTime", DbType.DateTime, this.Order_AddTime);
            db.AddInParameter(dbc, "@Order_User", DbType.Int32, this.Order_User);
            db.AddInParameter(dbc, "@Order_Status", DbType.Int32, this.Order_Status);
            db.AddInParameter(dbc, "@Order_Money", DbType.Currency, this.Order_Money);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[NewsOrder]","[News_ID] = @News_ID, [Order_AddTime] = @Order_AddTime, [Order_User] = @Order_User, [Order_Status] = @Order_Status, [Order_Money] = @Order_Money","Order_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[NewsOrder]","[News_ID] = @News_ID, [Order_AddTime] = @Order_AddTime, [Order_User] = @Order_User, [Order_Status] = @Order_Status, [Order_Money] = @Order_Money","Order_Serial"));

            db.AddInParameter(dbc, "@Order_Serial", DbType.Int32, this.Order_Serial);
            db.AddInParameter(dbc, "@News_ID", DbType.AnsiString, this.News_ID);
            db.AddInParameter(dbc, "@Order_AddTime", DbType.DateTime, this.Order_AddTime);
            db.AddInParameter(dbc, "@Order_User", DbType.Int32, this.Order_User);
            db.AddInParameter(dbc, "@Order_Status", DbType.Int32, this.Order_Status);
            db.AddInParameter(dbc, "@Order_Money", DbType.Currency, this.Order_Money);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[NewsOrder]", "[Order_Serial]" ,"@Order_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[NewsOrder]", "[Order_Serial]" ,"@Order_Serial"));

            db.AddInParameter(dbc, "@Order_Serial", DbType.Int32, this.Order_Serial);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// NewsOrder dal接口
    /// </summary>
    public interface INewsOrder : IBasicDal<Os.Brain.iBxg.Core.Entity.NewsOrder>
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
    /// NewsOrder dal数据处理层
    /// </summary>
    public partial class NewsOrder:INewsOrder
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
		public object Edit(Os.Brain.iBxg.Core.Entity.NewsOrder model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST,"[dbo].[NewsOrder]","[Order_Serial]","@Order_Serial"));            
            Debug.WriteLine("@Order_Serial="+"," + ids.Trim(',') + ",");            
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.NewsOrder.CONN);
            DbCommand dbc= db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST,"[dbo].[NewsOrder]","[Order_Serial]","@Order_Serial"));

            db.AddInParameter(dbc, "@Order_Serial", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
		public Os.Brain.iBxg.Core.Entity.NewsOrder GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM,"[dbo].[NewsOrder]","[Order_Serial]","@Order_Serial"));            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion
            
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.NewsOrder _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.NewsOrder.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM,"[dbo].[NewsOrder]","[Order_Serial]","@Order_Serial"));

            db.AddInParameter(dbc, "@Order_Serial", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.NewsOrder();

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
        public IList<Os.Brain.iBxg.Core.Entity.NewsOrder> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.NewsOrder> returnList = new List<Os.Brain.iBxg.Core.Entity.NewsOrder>();
            Os.Brain.iBxg.Core.Entity.NewsOrder _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.NewsOrder.CONN);
            DbCommand dbc = db.GetStoredProcCommand("NewsOrder_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.NewsOrder();

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
        public IList<Os.Brain.iBxg.Core.Entity.NewsOrder> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.NewsOrder> returnList = new List<Os.Brain.iBxg.Core.Entity.NewsOrder>();
            Os.Brain.iBxg.Core.Entity.NewsOrder _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.NewsOrder.CONN);
            DbCommand dbc = db.GetStoredProcCommand("NewsOrder_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.NewsOrder();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.NewsOrder.CONN);
            DbCommand dbc = db.GetStoredProcCommand("NewsOrder_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.NewsOrder.CONN);
            DbCommand dbc = db.GetStoredProcCommand("NewsOrder_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[NewsOrder]", "Order_Serial", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.NewsOrder.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }            

            var ds=db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr,Os.Brain.iBxg.Core.Entity.NewsOrder model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
        		if (!dr.IsDBNull(0)) model.Order_Serial = dr.GetInt32(0);
        		if (!dr.IsDBNull(1)) model.News_ID = dr.GetString(1);
        		if (!dr.IsDBNull(2)) model.Order_AddTime = dr.GetDateTime(2);
        		if (!dr.IsDBNull(3)) model.Order_User = dr.GetInt32(3);
        		if (!dr.IsDBNull(4)) model.Order_Status = dr.GetInt32(4);
        		if (!dr.IsDBNull(5)) model.Order_Money = dr.GetDecimal(5);
        	}
        }

        protected void LoadFromReader1(IDataReader dr,Os.Brain.iBxg.Core.Entity.NewsOrder model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
                model.Order_Serial = (int)dr["Order_Serial"];
                model.News_ID = dr["News_ID"].ToString();
                model.Order_AddTime = (DateTime)dr["Order_AddTime"];
                if (DBNull.Value != dr["Order_User"])
					{
						model.Order_User = (int)dr["Order_User"];
					}

                model.Order_Status = (int)dr["Order_Status"];
                model.Order_Money = Convert.ToDecimal(dr["Order_Money"].ToString());
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
    /// NewsOrder 业务逻辑层
    /// </summary>
    public partial class NewsOrder
    {
        /// <summary>
        /// dal 获取接口 INewsOrder
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.INewsOrder dal=DalFactory.CreateNewsOrder();

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsOrder"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public NewsOrder(Os.Brain.Data.DataActions action)
        {
            this.dal.Action=action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
		public object Edit(Os.Brain.iBxg.Core.Entity.NewsOrder model)
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
		public Os.Brain.iBxg.Core.Entity.NewsOrder Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
		public IList<Os.Brain.iBxg.Core.Entity.NewsOrder> GetList(DbParameter[] dataParams)
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
		public IList<Os.Brain.iBxg.Core.Entity.NewsOrder> GetList(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
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
    /// NewsOrder 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateNewsOrder 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.INewsOrder CreateNewsOrder()
        {
            return new Os.Brain.iBxg.Core.Dal.NewsOrder();
        }
    }
}




