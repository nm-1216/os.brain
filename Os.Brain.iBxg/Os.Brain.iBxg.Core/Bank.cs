//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bank.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:31:27</datetime>
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
    /// Bank 实体类
    /// </summary>
    public partial class Bank : BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _bank_UserId 用户编号
        /// </summary>
        private string _bank_UserId = string.Empty;

        /// <summary>
        /// _bank_Balance 总金额
        /// </summary>
        private decimal _bank_Balance = 0M;

        /// <summary>
        /// _bank_AvailAmount 可用金额
        /// </summary>
        private decimal _bank_AvailAmount = 0M;

        /// <summary>
        /// _bank_FrozenAmount 冻结金额
        /// </summary>
        private decimal _bank_FrozenAmount = 0M;

        /// <summary>
        /// _bank_LastChangeTime 最后变动日期
        /// </summary>
        private DateTime _bank_LastChangeTime = DateTime.Now;

        /// <summary>
        /// _bank_AddTime 开户日期
        /// </summary>
        private DateTime _bank_AddTime = DateTime.Now;

        /// <summary>
        /// _bank_Field1 备用一
        /// </summary>
        private string _bank_Field1 = string.Empty;

        /// <summary>
        /// _bank_Field2 备用二
        /// </summary>
        private string _bank_Field2 = string.Empty;

        /// <summary>
        /// _bank_Field3 备用三
        /// </summary>
        private string _bank_Field3 = string.Empty;

        /// <summary>
        /// _bank_Field4 备用四
        /// </summary>
        private string _bank_Field4 = string.Empty;

        /// <summary>
        /// _bank_Field5 备用五
        /// </summary>
        private string _bank_Field5 = string.Empty;

        /// <summary>
        /// _bank_Field6 备用六
        /// </summary>
        private string _bank_Field6 = string.Empty;

        /// <summary>
        /// _bank_Field7 备用七
        /// </summary>
        private string _bank_Field7 = string.Empty;

        /// <summary>
        /// _bank_Field8 备用八
        /// </summary>
        private string _bank_Field8 = string.Empty;

        /// <summary>
        /// _bank_Field9 备用九
        /// </summary>
        private string _bank_Field9 = string.Empty;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Bank_UserId 用户编号
        /// </summary>
        public string Bank_UserId
        {
            get { return this._bank_UserId; }
            set { this._bank_UserId = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Balance 总金额
        /// </summary>
        public decimal Bank_Balance
        {
            get { return this._bank_Balance; }
            set { this._bank_Balance = value; }
        }


        /// <summary>
        /// Gets or sets Bank_AvailAmount 可用金额
        /// </summary>
        public decimal Bank_AvailAmount
        {
            get { return this._bank_AvailAmount; }
            set { this._bank_AvailAmount = value; }
        }


        /// <summary>
        /// Gets or sets Bank_FrozenAmount 冻结金额
        /// </summary>
        public decimal Bank_FrozenAmount
        {
            get { return this._bank_FrozenAmount; }
            set { this._bank_FrozenAmount = value; }
        }


        /// <summary>
        /// Gets or sets Bank_LastChangeTime 最后变动日期
        /// </summary>
        public DateTime Bank_LastChangeTime
        {
            get { return this._bank_LastChangeTime; }
            set { this._bank_LastChangeTime = value; }
        }


        /// <summary>
        /// Gets or sets Bank_AddTime 开户日期
        /// </summary>
        public DateTime Bank_AddTime
        {
            get { return this._bank_AddTime; }
            set { this._bank_AddTime = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field1 备用一
        /// </summary>
        public string Bank_Field1
        {
            get { return this._bank_Field1; }
            set { this._bank_Field1 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field2 备用二
        /// </summary>
        public string Bank_Field2
        {
            get { return this._bank_Field2; }
            set { this._bank_Field2 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field3 备用三
        /// </summary>
        public string Bank_Field3
        {
            get { return this._bank_Field3; }
            set { this._bank_Field3 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field4 备用四
        /// </summary>
        public string Bank_Field4
        {
            get { return this._bank_Field4; }
            set { this._bank_Field4 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field5 备用五
        /// </summary>
        public string Bank_Field5
        {
            get { return this._bank_Field5; }
            set { this._bank_Field5 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field6 备用六
        /// </summary>
        public string Bank_Field6
        {
            get { return this._bank_Field6; }
            set { this._bank_Field6 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field7 备用七
        /// </summary>
        public string Bank_Field7
        {
            get { return this._bank_Field7; }
            set { this._bank_Field7 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field8 备用八
        /// </summary>
        public string Bank_Field8
        {
            get { return this._bank_Field8; }
            set { this._bank_Field8 = value; }
        }


        /// <summary>
        /// Gets or sets Bank_Field9 备用九
        /// </summary>
        public string Bank_Field9
        {
            get { return this._bank_Field9; }
            set { this._bank_Field9 = value; }
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[Bank]", "[Bank_Balance], [Bank_AvailAmount], [Bank_FrozenAmount], [Bank_LastChangeTime], [Bank_AddTime], [Bank_Field1], [Bank_Field2], [Bank_Field3], [Bank_Field4], [Bank_Field5], [Bank_Field6], [Bank_Field7], [Bank_Field8], [Bank_Field9]", "@Bank_Balance, @Bank_AvailAmount, @Bank_FrozenAmount, @Bank_LastChangeTime, @Bank_AddTime, @Bank_Field1, @Bank_Field2, @Bank_Field3, @Bank_Field4, @Bank_Field5, @Bank_Field6, @Bank_Field7, @Bank_Field8, @Bank_Field9"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[Bank]", "[Bank_Balance], [Bank_AvailAmount], [Bank_FrozenAmount], [Bank_LastChangeTime], [Bank_AddTime], [Bank_Field1], [Bank_Field2], [Bank_Field3], [Bank_Field4], [Bank_Field5], [Bank_Field6], [Bank_Field7], [Bank_Field8], [Bank_Field9]", "@Bank_Balance, @Bank_AvailAmount, @Bank_FrozenAmount, @Bank_LastChangeTime, @Bank_AddTime, @Bank_Field1, @Bank_Field2, @Bank_Field3, @Bank_Field4, @Bank_Field5, @Bank_Field6, @Bank_Field7, @Bank_Field8, @Bank_Field9"));

            db.AddInParameter(dbc, "@Bank_Balance", DbType.Currency, this.Bank_Balance);
            db.AddInParameter(dbc, "@Bank_AvailAmount", DbType.Currency, this.Bank_AvailAmount);
            db.AddInParameter(dbc, "@Bank_FrozenAmount", DbType.Currency, this.Bank_FrozenAmount);
            db.AddInParameter(dbc, "@Bank_LastChangeTime", DbType.DateTime, this.Bank_LastChangeTime);
            db.AddInParameter(dbc, "@Bank_AddTime", DbType.DateTime, this.Bank_AddTime);
            db.AddInParameter(dbc, "@Bank_Field1", DbType.AnsiString, this.Bank_Field1);
            db.AddInParameter(dbc, "@Bank_Field2", DbType.AnsiString, this.Bank_Field2);
            db.AddInParameter(dbc, "@Bank_Field3", DbType.AnsiString, this.Bank_Field3);
            db.AddInParameter(dbc, "@Bank_Field4", DbType.AnsiString, this.Bank_Field4);
            db.AddInParameter(dbc, "@Bank_Field5", DbType.AnsiString, this.Bank_Field5);
            db.AddInParameter(dbc, "@Bank_Field6", DbType.AnsiString, this.Bank_Field6);
            db.AddInParameter(dbc, "@Bank_Field7", DbType.AnsiString, this.Bank_Field7);
            db.AddInParameter(dbc, "@Bank_Field8", DbType.AnsiString, this.Bank_Field8);
            db.AddInParameter(dbc, "@Bank_Field9", DbType.AnsiString, this.Bank_Field9);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[Bank]", "[Bank_Balance] = @Bank_Balance, [Bank_AvailAmount] = @Bank_AvailAmount, [Bank_FrozenAmount] = @Bank_FrozenAmount, [Bank_LastChangeTime] = @Bank_LastChangeTime, [Bank_AddTime] = @Bank_AddTime, [Bank_Field1] = @Bank_Field1, [Bank_Field2] = @Bank_Field2, [Bank_Field3] = @Bank_Field3, [Bank_Field4] = @Bank_Field4, [Bank_Field5] = @Bank_Field5, [Bank_Field6] = @Bank_Field6, [Bank_Field7] = @Bank_Field7, [Bank_Field8] = @Bank_Field8, [Bank_Field9] = @Bank_Field9", "Bank_UserId"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[Bank]", "[Bank_Balance] = @Bank_Balance, [Bank_AvailAmount] = @Bank_AvailAmount, [Bank_FrozenAmount] = @Bank_FrozenAmount, [Bank_LastChangeTime] = @Bank_LastChangeTime, [Bank_AddTime] = @Bank_AddTime, [Bank_Field1] = @Bank_Field1, [Bank_Field2] = @Bank_Field2, [Bank_Field3] = @Bank_Field3, [Bank_Field4] = @Bank_Field4, [Bank_Field5] = @Bank_Field5, [Bank_Field6] = @Bank_Field6, [Bank_Field7] = @Bank_Field7, [Bank_Field8] = @Bank_Field8, [Bank_Field9] = @Bank_Field9", "Bank_UserId"));

            db.AddInParameter(dbc, "@Bank_UserId", DbType.AnsiString, this.Bank_UserId);
            db.AddInParameter(dbc, "@Bank_Balance", DbType.Currency, this.Bank_Balance);
            db.AddInParameter(dbc, "@Bank_AvailAmount", DbType.Currency, this.Bank_AvailAmount);
            db.AddInParameter(dbc, "@Bank_FrozenAmount", DbType.Currency, this.Bank_FrozenAmount);
            db.AddInParameter(dbc, "@Bank_LastChangeTime", DbType.DateTime, this.Bank_LastChangeTime);
            db.AddInParameter(dbc, "@Bank_AddTime", DbType.DateTime, this.Bank_AddTime);
            db.AddInParameter(dbc, "@Bank_Field1", DbType.AnsiString, this.Bank_Field1);
            db.AddInParameter(dbc, "@Bank_Field2", DbType.AnsiString, this.Bank_Field2);
            db.AddInParameter(dbc, "@Bank_Field3", DbType.AnsiString, this.Bank_Field3);
            db.AddInParameter(dbc, "@Bank_Field4", DbType.AnsiString, this.Bank_Field4);
            db.AddInParameter(dbc, "@Bank_Field5", DbType.AnsiString, this.Bank_Field5);
            db.AddInParameter(dbc, "@Bank_Field6", DbType.AnsiString, this.Bank_Field6);
            db.AddInParameter(dbc, "@Bank_Field7", DbType.AnsiString, this.Bank_Field7);
            db.AddInParameter(dbc, "@Bank_Field8", DbType.AnsiString, this.Bank_Field8);
            db.AddInParameter(dbc, "@Bank_Field9", DbType.AnsiString, this.Bank_Field9);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[Bank]", "[Bank_UserId]", "@Bank_UserId"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[Bank]", "[Bank_UserId]", "@Bank_UserId"));

            db.AddInParameter(dbc, "@Bank_UserId", DbType.AnsiString, this.Bank_UserId);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// Bank dal接口
    /// </summary>
    public interface IBank : IBasicDal<Os.Brain.iBxg.Core.Entity.Bank>
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
    /// Bank dal数据处理层
    /// </summary>
    public partial class Bank : IBank
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
        public object Edit(Os.Brain.iBxg.Core.Entity.Bank model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST, "[dbo].[Bank]", "[Bank_UserId]", "@Bank_UserId"));
            Debug.WriteLine("@Bank_UserId=" + "," + ids.Trim(',') + ",");
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Bank.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST, "[dbo].[Bank]", "[Bank_UserId]", "@Bank_UserId"));

            db.AddInParameter(dbc, "@Bank_UserId", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
        public Os.Brain.iBxg.Core.Entity.Bank GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM, "[dbo].[Bank]", "[Bank_UserId]", "@Bank_UserId"));
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion

            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.Bank _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Bank.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM, "[dbo].[Bank]", "[Bank_UserId]", "@Bank_UserId"));

            db.AddInParameter(dbc, "@Bank_UserId", DbType.AnsiString, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Bank();

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
        public IList<Os.Brain.iBxg.Core.Entity.Bank> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.Bank> returnList = new List<Os.Brain.iBxg.Core.Entity.Bank>();
            Os.Brain.iBxg.Core.Entity.Bank _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Bank.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Bank_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Bank();

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
        public IList<Os.Brain.iBxg.Core.Entity.Bank> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount = 0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.Bank> returnList = new List<Os.Brain.iBxg.Core.Entity.Bank>();
            Os.Brain.iBxg.Core.Entity.Bank _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Bank.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Bank_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.Bank();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Bank.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Bank_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Bank.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Bank_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[Bank]", "Bank_UserId", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Bank.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            var ds = db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr, Os.Brain.iBxg.Core.Entity.Bank model)
        {
            if (dr != null && !dr.IsClosed)
            {
                if (!dr.IsDBNull(0)) model.Bank_UserId = dr.GetString(0);
                if (!dr.IsDBNull(1)) model.Bank_Balance = dr.GetDecimal(1);
                if (!dr.IsDBNull(2)) model.Bank_AvailAmount = dr.GetDecimal(2);
                if (!dr.IsDBNull(3)) model.Bank_FrozenAmount = dr.GetDecimal(3);
                if (!dr.IsDBNull(4)) model.Bank_LastChangeTime = dr.GetDateTime(4);
                if (!dr.IsDBNull(5)) model.Bank_AddTime = dr.GetDateTime(5);
                if (!dr.IsDBNull(6)) model.Bank_Field1 = dr.GetString(6);
                if (!dr.IsDBNull(7)) model.Bank_Field2 = dr.GetString(7);
                if (!dr.IsDBNull(8)) model.Bank_Field3 = dr.GetString(8);
                if (!dr.IsDBNull(9)) model.Bank_Field4 = dr.GetString(9);
                if (!dr.IsDBNull(10)) model.Bank_Field5 = dr.GetString(10);
                if (!dr.IsDBNull(11)) model.Bank_Field6 = dr.GetString(11);
                if (!dr.IsDBNull(12)) model.Bank_Field7 = dr.GetString(12);
                if (!dr.IsDBNull(13)) model.Bank_Field8 = dr.GetString(13);
                if (!dr.IsDBNull(14)) model.Bank_Field9 = dr.GetString(14);
            }
        }

        protected void LoadFromReader1(IDataReader dr, Os.Brain.iBxg.Core.Entity.Bank model)
        {
            if (dr != null && !dr.IsClosed)
            {
                model.Bank_UserId = dr["Bank_UserId"].ToString();
                model.Bank_Balance = Convert.ToDecimal(dr["Bank_Balance"]);
                model.Bank_AvailAmount = Convert.ToDecimal(dr["Bank_AvailAmount"]);
                model.Bank_FrozenAmount = Convert.ToDecimal(dr["Bank_FrozenAmount"]);
                model.Bank_LastChangeTime = (DateTime)dr["Bank_LastChangeTime"];
                model.Bank_AddTime = (DateTime)dr["Bank_AddTime"];
                model.Bank_Field1 = dr["Bank_Field1"].ToString();
                model.Bank_Field2 = dr["Bank_Field2"].ToString();
                model.Bank_Field3 = dr["Bank_Field3"].ToString();
                model.Bank_Field4 = dr["Bank_Field4"].ToString();
                model.Bank_Field5 = dr["Bank_Field5"].ToString();
                model.Bank_Field6 = dr["Bank_Field6"].ToString();
                model.Bank_Field7 = dr["Bank_Field7"].ToString();
                model.Bank_Field8 = dr["Bank_Field8"].ToString();
                model.Bank_Field9 = dr["Bank_Field9"].ToString();
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
    /// Bank 业务逻辑层
    /// </summary>
    public partial class Bank
    {
        /// <summary>
        /// dal 获取接口 IBank
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.IBank dal = DalFactory.CreateBank();

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public Bank(Os.Brain.Data.DataActions action)
        {
            this.dal.Action = action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
        public object Edit(Os.Brain.iBxg.Core.Entity.Bank model)
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
        public Os.Brain.iBxg.Core.Entity.Bank Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.Bank> GetList(DbParameter[] dataParams)
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
        public IList<Os.Brain.iBxg.Core.Entity.Bank> GetList(int pageSize, int currPage, out int recordCount, DbParameter[] dataParams)
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
    /// Bank 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateBank 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.IBank CreateBank()
        {
            return new Os.Brain.iBxg.Core.Dal.Bank();
        }
    }
}




