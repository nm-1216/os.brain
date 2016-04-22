﻿//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="BankIn.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:21:12</datetime>
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
    /// BankIn 实体类
    /// </summary>
    public partial class BankIn : BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _po_IDS 订单编号
        /// </summary>
        private int _po_IDS;

        /// <summary>
        /// _po_Code 订单编码
        /// </summary>
        private string _po_Code = string.Empty;

        /// <summary>
        /// _po_Name 订单名称
        /// </summary>
        private string _po_Name = string.Empty;

        /// <summary>
        /// _po_Money 订单金额
        /// </summary>
        private int _po_Money;

        /// <summary>
        /// _po_Status 订单状态
        /// </summary>
        private int _po_Status;

        /// <summary>
        /// _po_Finance 财务流水
        /// </summary>
        private string _po_Finance = "";

        /// <summary>
        /// _po_AddTime 添加时间
        /// </summary>
        private DateTime _po_AddTime = DateTime.Now;

        /// <summary>
        /// _po_AddUser 所有人
        /// </summary>
        private string _po_AddUser = string.Empty;

        /// <summary>
        /// _po_EditTime 处理时间
        /// </summary>
        private DateTime _po_EditTime = DateTime.Now;

        /// <summary>
        /// _po_EditUser 处理人
        /// </summary>
        private string _po_EditUser = "";

        /// <summary>
        /// _po_Alipay 支付宝流水
        /// </summary>
        private string _po_Alipay = string.Empty;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Po_IDS 订单编号
        /// </summary>
        public int Po_IDS
        {
            get { return this._po_IDS; }
            set { this._po_IDS = value; }
        }


        /// <summary>
        /// Gets or sets Po_Code 订单编码
        /// </summary>
        public string Po_Code
        {
            get { return this._po_Code; }
            set { this._po_Code = value; }
        }


        /// <summary>
        /// Gets or sets Po_Name 订单名称
        /// </summary>
        public string Po_Name
        {
            get { return this._po_Name; }
            set { this._po_Name = value; }
        }


        /// <summary>
        /// Gets or sets Po_Money 订单金额
        /// </summary>
        public int Po_Money
        {
            get { return this._po_Money; }
            set { this._po_Money = value; }
        }


        /// <summary>
        /// Gets or sets Po_Status 订单状态
        /// </summary>
        public int Po_Status
        {
            get { return this._po_Status; }
            set { this._po_Status = value; }
        }


        /// <summary>
        /// Gets or sets Po_Finance 财务流水
        /// </summary>
        public string Po_Finance
        {
            get { return this._po_Finance; }
            set { this._po_Finance = value; }
        }


        /// <summary>
        /// Gets or sets Po_AddTime 添加时间
        /// </summary>
        public DateTime Po_AddTime
        {
            get { return this._po_AddTime; }
            set { this._po_AddTime = value; }
        }


        /// <summary>
        /// Gets or sets Po_AddUser 所有人
        /// </summary>
        public string Po_AddUser
        {
            get { return this._po_AddUser; }
            set { this._po_AddUser = value; }
        }


        /// <summary>
        /// Gets or sets Po_EditTime 处理时间
        /// </summary>
        public DateTime Po_EditTime
        {
            get { return this._po_EditTime; }
            set { this._po_EditTime = value; }
        }


        /// <summary>
        /// Gets or sets Po_EditUser 处理人
        /// </summary>
        public string Po_EditUser
        {
            get { return this._po_EditUser; }
            set { this._po_EditUser = value; }
        }


        /// <summary>
        /// Gets or sets Po_Alipay 支付宝流水
        /// </summary>
        public string Po_Alipay
        {
            get { return this._po_Alipay; }
            set { this._po_Alipay = value; }
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankIn]", "[Po_Code], [Po_Name], [Po_Money], [Po_Status], [Po_Finance], [Po_AddTime], [Po_AddUser], [Po_EditTime], [Po_EditUser], [Po_Alipay]", "@Po_Code, @Po_Name, @Po_Money, @Po_Status, @Po_Finance, @Po_AddTime, @Po_AddUser, @Po_EditTime, @Po_EditUser, @Po_Alipay"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankIn]", "[Po_Code], [Po_Name], [Po_Money], [Po_Status], [Po_Finance], [Po_AddTime], [Po_AddUser], [Po_EditTime], [Po_EditUser], [Po_Alipay]", "@Po_Code, @Po_Name, @Po_Money, @Po_Status, @Po_Finance, @Po_AddTime, @Po_AddUser, @Po_EditTime, @Po_EditUser, @Po_Alipay"));

            db.AddInParameter(dbc, "@Po_Code", DbType.AnsiString, this.Po_Code);
            db.AddInParameter(dbc, "@Po_Name", DbType.String, this.Po_Name);
            db.AddInParameter(dbc, "@Po_Money", DbType.Int32, this.Po_Money);
            db.AddInParameter(dbc, "@Po_Status", DbType.Int32, this.Po_Status);
            db.AddInParameter(dbc, "@Po_Finance", DbType.AnsiString, this.Po_Finance);
            db.AddInParameter(dbc, "@Po_AddTime", DbType.DateTime, this.Po_AddTime);
            db.AddInParameter(dbc, "@Po_AddUser", DbType.String, this.Po_AddUser);
            db.AddInParameter(dbc, "@Po_EditTime", DbType.DateTime, this.Po_EditTime);
            db.AddInParameter(dbc, "@Po_EditUser", DbType.String, this.Po_EditUser);
            db.AddInParameter(dbc, "@Po_Alipay", DbType.AnsiString, this.Po_Alipay);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[BankIn]", "[Po_Code] = @Po_Code, [Po_Name] = @Po_Name, [Po_Money] = @Po_Money, [Po_Status] = @Po_Status, [Po_Finance] = @Po_Finance, [Po_AddTime] = @Po_AddTime, [Po_AddUser] = @Po_AddUser, [Po_EditTime] = @Po_EditTime, [Po_EditUser] = @Po_EditUser, [Po_Alipay] = @Po_Alipay", "Po_IDS"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[BankIn]", "[Po_Code] = @Po_Code, [Po_Name] = @Po_Name, [Po_Money] = @Po_Money, [Po_Status] = @Po_Status, [Po_Finance] = @Po_Finance, [Po_AddTime] = @Po_AddTime, [Po_AddUser] = @Po_AddUser, [Po_EditTime] = @Po_EditTime, [Po_EditUser] = @Po_EditUser, [Po_Alipay] = @Po_Alipay", "Po_IDS"));

            db.AddInParameter(dbc, "@Po_IDS", DbType.Int32, this.Po_IDS);
            db.AddInParameter(dbc, "@Po_Code", DbType.AnsiString, this.Po_Code);
            db.AddInParameter(dbc, "@Po_Name", DbType.String, this.Po_Name);
            db.AddInParameter(dbc, "@Po_Money", DbType.Int32, this.Po_Money);
            db.AddInParameter(dbc, "@Po_Status", DbType.Int32, this.Po_Status);
            db.AddInParameter(dbc, "@Po_Finance", DbType.AnsiString, this.Po_Finance);
            db.AddInParameter(dbc, "@Po_AddTime", DbType.DateTime, this.Po_AddTime);
            db.AddInParameter(dbc, "@Po_AddUser", DbType.String, this.Po_AddUser);
            db.AddInParameter(dbc, "@Po_EditTime", DbType.DateTime, this.Po_EditTime);
            db.AddInParameter(dbc, "@Po_EditUser", DbType.String, this.Po_EditUser);
            db.AddInParameter(dbc, "@Po_Alipay", DbType.AnsiString, this.Po_Alipay);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankIn]", "[Po_IDS]", "@Po_IDS"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankIn]", "[Po_IDS]", "@Po_IDS"));

            db.AddInParameter(dbc, "@Po_IDS", DbType.Int32, this.Po_IDS);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// BankIn dal接口
    /// </summary>
    public interface IBankIn : IBasicDal<Os.Brain.iBxg.Core.Entity.BankIn>
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
    /// BankIn dal数据处理层
    /// </summary>
    public partial class BankIn : IBankIn
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
        public object Edit(Os.Brain.iBxg.Core.Entity.BankIn model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST, "[dbo].[BankIn]", "[Po_IDS]", "@Po_IDS"));
            Debug.WriteLine("@Po_IDS=" + "," + ids.Trim(',') + ",");
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankIn.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST, "[dbo].[BankIn]", "[Po_IDS]", "@Po_IDS"));

            db.AddInParameter(dbc, "@Po_IDS", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
        public Os.Brain.iBxg.Core.Entity.BankIn GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM, "[dbo].[BankIn]", "[Po_IDS]", "@Po_IDS"));
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion

            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.BankIn _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankIn.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM, "[dbo].[BankIn]", "[Po_IDS]", "@Po_IDS"));

            db.AddInParameter(dbc, "@Po_IDS", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankIn();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankIn> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankIn> returnList = new List<Os.Brain.iBxg.Core.Entity.BankIn>();
            Os.Brain.iBxg.Core.Entity.BankIn _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankIn.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankIn_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankIn();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankIn> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount = 0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankIn> returnList = new List<Os.Brain.iBxg.Core.Entity.BankIn>();
            Os.Brain.iBxg.Core.Entity.BankIn _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankIn.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankIn_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.BankIn();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankIn.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankIn_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankIn.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankIn_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[BankIn]", "Po_IDS", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankIn.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            var ds = db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr, Os.Brain.iBxg.Core.Entity.BankIn model)
        {
            if (dr != null && !dr.IsClosed)
            {
                if (!dr.IsDBNull(0)) model.Po_IDS = dr.GetInt32(0);
                if (!dr.IsDBNull(1)) model.Po_Code = dr.GetString(1);
                if (!dr.IsDBNull(2)) model.Po_Name = dr.GetString(2);
                if (!dr.IsDBNull(3)) model.Po_Money = dr.GetInt32(3);
                if (!dr.IsDBNull(4)) model.Po_Status = dr.GetInt32(4);
                if (!dr.IsDBNull(5)) model.Po_Finance = dr.GetString(5);
                if (!dr.IsDBNull(6)) model.Po_AddTime = dr.GetDateTime(6);
                if (!dr.IsDBNull(7)) model.Po_AddUser = dr.GetString(7);
                if (!dr.IsDBNull(8)) model.Po_EditTime = dr.GetDateTime(8);
                if (!dr.IsDBNull(9)) model.Po_EditUser = dr.GetString(9);
                if (!dr.IsDBNull(10)) model.Po_Alipay = dr.GetString(10);
            }
        }

        protected void LoadFromReader1(IDataReader dr, Os.Brain.iBxg.Core.Entity.BankIn model)
        {
            if (dr != null && !dr.IsClosed)
            {
                model.Po_IDS = (int)dr["Po_IDS"];
                model.Po_Code = dr["Po_Code"].ToString();
                model.Po_Name = dr["Po_Name"].ToString();
                model.Po_Money = (int)dr["Po_Money"];
                model.Po_Status = (int)dr["Po_Status"];
                model.Po_Finance = dr["Po_Finance"].ToString();
                model.Po_AddTime = (DateTime)dr["Po_AddTime"];
                model.Po_AddUser = dr["Po_AddUser"].ToString();
                model.Po_EditTime = (DateTime)dr["Po_EditTime"];
                model.Po_EditUser = dr["Po_EditUser"].ToString();
                model.Po_Alipay = dr["Po_Alipay"].ToString();
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
    /// BankIn 业务逻辑层
    /// </summary>
    public partial class BankIn
    {
        /// <summary>
        /// dal 获取接口 IBankIn
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.IBankIn dal = DalFactory.CreateBankIn();

        /// <summary>
        /// Initializes a new instance of the <see cref="BankIn"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public BankIn(Os.Brain.Data.DataActions action)
        {
            this.dal.Action = action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
        public object Edit(Os.Brain.iBxg.Core.Entity.BankIn model)
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
        public Os.Brain.iBxg.Core.Entity.BankIn Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.BankIn> GetList(DbParameter[] dataParams)
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
        public IList<Os.Brain.iBxg.Core.Entity.BankIn> GetList(int pageSize, int currPage, out int recordCount, DbParameter[] dataParams)
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
    /// BankIn 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateBankIn 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.IBankIn CreateBankIn()
        {
            return new Os.Brain.iBxg.Core.Dal.BankIn();
        }
    }
}




