//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="BankOut.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:22:45</datetime>
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
    /// BankOut 实体类
    /// </summary>
    public partial class BankOut:BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _withdrawMoney_Ids 自动编号
        /// </summary>
        private int _withdrawMoney_Ids;

        /// <summary>
        /// _withdrawMoney_UserId 用户编号
        /// </summary>
        private int _withdrawMoney_UserId;

        /// <summary>
        /// _withdrawMoney_No 业务编号
        /// </summary>
        private string _withdrawMoney_No = string.Empty;

        /// <summary>
        /// _withdrawMoney_Money 取现金额
        /// </summary>
        private int _withdrawMoney_Money;

        /// <summary>
        /// _withdrawMoney_AddTime 取现时间
        /// </summary>
        private DateTime _withdrawMoney_AddTime =  DateTime.Now;

        /// <summary>
        /// _withdrawMoney_DoTime 处理时间
        /// </summary>
        private DateTime _withdrawMoney_DoTime =  DateTime.Now;

        /// <summary>
        /// _withdrawMoney_DoUser 处理人
        /// </summary>
        private string _withdrawMoney_DoUser = string.Empty;

        /// <summary>
        /// _withdrawMoney_Status 状态
        /// </summary>
        private int _withdrawMoney_Status;

        /// <summary>
        /// _withdrawMoney_isDel 是否删除
        /// </summary>
        private int _withdrawMoney_isDel;

        /// <summary>
        /// _withdrawMoney_Remark 备注
        /// </summary>
        private string _withdrawMoney_Remark = string.Empty;

        /// <summary>
        /// _withdrawMoney_Finance 财务流水
        /// </summary>
        private string _withdrawMoney_Finance = string.Empty;

        /// <summary>
        /// _withdrawMoney_Bank 开户信息
        /// </summary>
        private string _withdrawMoney_Bank = string.Empty;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets WithdrawMoney_Ids 自动编号
        /// </summary>
        public int WithdrawMoney_Ids
        {
            get {return this._withdrawMoney_Ids;}
            set {this._withdrawMoney_Ids = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_UserId 用户编号
        /// </summary>
        public int WithdrawMoney_UserId
        {
            get {return this._withdrawMoney_UserId;}
            set {this._withdrawMoney_UserId = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_No 业务编号
        /// </summary>
        public string WithdrawMoney_No
        {
            get {return this._withdrawMoney_No;}
            set {this._withdrawMoney_No = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_Money 取现金额
        /// </summary>
        public int WithdrawMoney_Money
        {
            get {return this._withdrawMoney_Money;}
            set {this._withdrawMoney_Money = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_AddTime 取现时间
        /// </summary>
        public DateTime WithdrawMoney_AddTime
        {
            get {return this._withdrawMoney_AddTime;}
            set {this._withdrawMoney_AddTime = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_DoTime 处理时间
        /// </summary>
        public DateTime WithdrawMoney_DoTime
        {
            get {return this._withdrawMoney_DoTime;}
            set {this._withdrawMoney_DoTime = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_DoUser 处理人
        /// </summary>
        public string WithdrawMoney_DoUser
        {
            get {return this._withdrawMoney_DoUser;}
            set {this._withdrawMoney_DoUser = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_Status 状态
        /// </summary>
        public int WithdrawMoney_Status
        {
            get {return this._withdrawMoney_Status;}
            set {this._withdrawMoney_Status = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_isDel 是否删除
        /// </summary>
        public int WithdrawMoney_isDel
        {
            get {return this._withdrawMoney_isDel;}
            set {this._withdrawMoney_isDel = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_Remark 备注
        /// </summary>
        public string WithdrawMoney_Remark
        {
            get {return this._withdrawMoney_Remark;}
            set {this._withdrawMoney_Remark = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_Finance 财务流水
        /// </summary>
        public string WithdrawMoney_Finance
        {
            get {return this._withdrawMoney_Finance;}
            set {this._withdrawMoney_Finance = value;}
        }


        /// <summary>
        /// Gets or sets WithdrawMoney_Bank 开户信息
        /// </summary>
        public string WithdrawMoney_Bank
        {
            get {return this._withdrawMoney_Bank;}
            set {this._withdrawMoney_Bank = value;}
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankOut]", "[WithdrawMoney_UserId], [WithdrawMoney_No], [WithdrawMoney_Money], [WithdrawMoney_AddTime], [WithdrawMoney_DoTime], [WithdrawMoney_DoUser], [WithdrawMoney_Status], [WithdrawMoney_isDel], [WithdrawMoney_Remark], [WithdrawMoney_Finance], [WithdrawMoney_Bank]" , "@WithdrawMoney_UserId, @WithdrawMoney_No, @WithdrawMoney_Money, @WithdrawMoney_AddTime, @WithdrawMoney_DoTime, @WithdrawMoney_DoUser, @WithdrawMoney_Status, @WithdrawMoney_isDel, @WithdrawMoney_Remark, @WithdrawMoney_Finance, @WithdrawMoney_Bank"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion
            
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankOut]", "[WithdrawMoney_UserId], [WithdrawMoney_No], [WithdrawMoney_Money], [WithdrawMoney_AddTime], [WithdrawMoney_DoTime], [WithdrawMoney_DoUser], [WithdrawMoney_Status], [WithdrawMoney_isDel], [WithdrawMoney_Remark], [WithdrawMoney_Finance], [WithdrawMoney_Bank]" , "@WithdrawMoney_UserId, @WithdrawMoney_No, @WithdrawMoney_Money, @WithdrawMoney_AddTime, @WithdrawMoney_DoTime, @WithdrawMoney_DoUser, @WithdrawMoney_Status, @WithdrawMoney_isDel, @WithdrawMoney_Remark, @WithdrawMoney_Finance, @WithdrawMoney_Bank"));

            db.AddInParameter(dbc, "@WithdrawMoney_UserId", DbType.Int32, this.WithdrawMoney_UserId);
            db.AddInParameter(dbc, "@WithdrawMoney_No", DbType.AnsiString, this.WithdrawMoney_No);
            db.AddInParameter(dbc, "@WithdrawMoney_Money", DbType.Int32, this.WithdrawMoney_Money);
            db.AddInParameter(dbc, "@WithdrawMoney_AddTime", DbType.DateTime, this.WithdrawMoney_AddTime);
            db.AddInParameter(dbc, "@WithdrawMoney_DoTime", DbType.DateTime, this.WithdrawMoney_DoTime);
            db.AddInParameter(dbc, "@WithdrawMoney_DoUser", DbType.AnsiString, this.WithdrawMoney_DoUser);
            db.AddInParameter(dbc, "@WithdrawMoney_Status", DbType.Int32, this.WithdrawMoney_Status);
            db.AddInParameter(dbc, "@WithdrawMoney_isDel", DbType.Int32, this.WithdrawMoney_isDel);
            db.AddInParameter(dbc, "@WithdrawMoney_Remark", DbType.AnsiString, this.WithdrawMoney_Remark);
            db.AddInParameter(dbc, "@WithdrawMoney_Finance", DbType.AnsiString, this.WithdrawMoney_Finance);
            db.AddInParameter(dbc, "@WithdrawMoney_Bank", DbType.AnsiString, this.WithdrawMoney_Bank);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[BankOut]","[WithdrawMoney_UserId] = @WithdrawMoney_UserId, [WithdrawMoney_No] = @WithdrawMoney_No, [WithdrawMoney_Money] = @WithdrawMoney_Money, [WithdrawMoney_AddTime] = @WithdrawMoney_AddTime, [WithdrawMoney_DoTime] = @WithdrawMoney_DoTime, [WithdrawMoney_DoUser] = @WithdrawMoney_DoUser, [WithdrawMoney_Status] = @WithdrawMoney_Status, [WithdrawMoney_isDel] = @WithdrawMoney_isDel, [WithdrawMoney_Remark] = @WithdrawMoney_Remark, [WithdrawMoney_Finance] = @WithdrawMoney_Finance, [WithdrawMoney_Bank] = @WithdrawMoney_Bank","WithdrawMoney_Ids"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[BankOut]","[WithdrawMoney_UserId] = @WithdrawMoney_UserId, [WithdrawMoney_No] = @WithdrawMoney_No, [WithdrawMoney_Money] = @WithdrawMoney_Money, [WithdrawMoney_AddTime] = @WithdrawMoney_AddTime, [WithdrawMoney_DoTime] = @WithdrawMoney_DoTime, [WithdrawMoney_DoUser] = @WithdrawMoney_DoUser, [WithdrawMoney_Status] = @WithdrawMoney_Status, [WithdrawMoney_isDel] = @WithdrawMoney_isDel, [WithdrawMoney_Remark] = @WithdrawMoney_Remark, [WithdrawMoney_Finance] = @WithdrawMoney_Finance, [WithdrawMoney_Bank] = @WithdrawMoney_Bank","WithdrawMoney_Ids"));

            db.AddInParameter(dbc, "@WithdrawMoney_Ids", DbType.Int32, this.WithdrawMoney_Ids);
            db.AddInParameter(dbc, "@WithdrawMoney_UserId", DbType.Int32, this.WithdrawMoney_UserId);
            db.AddInParameter(dbc, "@WithdrawMoney_No", DbType.AnsiString, this.WithdrawMoney_No);
            db.AddInParameter(dbc, "@WithdrawMoney_Money", DbType.Int32, this.WithdrawMoney_Money);
            db.AddInParameter(dbc, "@WithdrawMoney_AddTime", DbType.DateTime, this.WithdrawMoney_AddTime);
            db.AddInParameter(dbc, "@WithdrawMoney_DoTime", DbType.DateTime, this.WithdrawMoney_DoTime);
            db.AddInParameter(dbc, "@WithdrawMoney_DoUser", DbType.AnsiString, this.WithdrawMoney_DoUser);
            db.AddInParameter(dbc, "@WithdrawMoney_Status", DbType.Int32, this.WithdrawMoney_Status);
            db.AddInParameter(dbc, "@WithdrawMoney_isDel", DbType.Int32, this.WithdrawMoney_isDel);
            db.AddInParameter(dbc, "@WithdrawMoney_Remark", DbType.AnsiString, this.WithdrawMoney_Remark);
            db.AddInParameter(dbc, "@WithdrawMoney_Finance", DbType.AnsiString, this.WithdrawMoney_Finance);
            db.AddInParameter(dbc, "@WithdrawMoney_Bank", DbType.AnsiString, this.WithdrawMoney_Bank);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankOut]", "[WithdrawMoney_Ids]" ,"@WithdrawMoney_Ids"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankOut]", "[WithdrawMoney_Ids]" ,"@WithdrawMoney_Ids"));

            db.AddInParameter(dbc, "@WithdrawMoney_Ids", DbType.Int32, this.WithdrawMoney_Ids);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// BankOut dal接口
    /// </summary>
    public interface IBankOut : IBasicDal<Os.Brain.iBxg.Core.Entity.BankOut>
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
    /// BankOut dal数据处理层
    /// </summary>
    public partial class BankOut:IBankOut
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
		public object Edit(Os.Brain.iBxg.Core.Entity.BankOut model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST,"[dbo].[BankOut]","[WithdrawMoney_Ids]","@WithdrawMoney_Ids"));            
            Debug.WriteLine("@WithdrawMoney_Ids="+"," + ids.Trim(',') + ",");            
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankOut.CONN);
            DbCommand dbc= db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST,"[dbo].[BankOut]","[WithdrawMoney_Ids]","@WithdrawMoney_Ids"));

            db.AddInParameter(dbc, "@WithdrawMoney_Ids", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
		public Os.Brain.iBxg.Core.Entity.BankOut GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM,"[dbo].[BankOut]","[WithdrawMoney_Ids]","@WithdrawMoney_Ids"));            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion
            
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.BankOut _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankOut.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM,"[dbo].[BankOut]","[WithdrawMoney_Ids]","@WithdrawMoney_Ids"));

            db.AddInParameter(dbc, "@WithdrawMoney_Ids", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankOut();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankOut> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankOut> returnList = new List<Os.Brain.iBxg.Core.Entity.BankOut>();
            Os.Brain.iBxg.Core.Entity.BankOut _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankOut.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankOut_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankOut();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankOut> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankOut> returnList = new List<Os.Brain.iBxg.Core.Entity.BankOut>();
            Os.Brain.iBxg.Core.Entity.BankOut _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankOut.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankOut_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.BankOut();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankOut.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankOut_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankOut.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankOut_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[BankOut]", "WithdrawMoney_Ids", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankOut.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }            

            var ds=db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr,Os.Brain.iBxg.Core.Entity.BankOut model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
        		if (!dr.IsDBNull(0)) model.WithdrawMoney_Ids = dr.GetInt32(0);
        		if (!dr.IsDBNull(1)) model.WithdrawMoney_UserId = dr.GetInt32(1);
        		if (!dr.IsDBNull(2)) model.WithdrawMoney_No = dr.GetString(2);
        		if (!dr.IsDBNull(3)) model.WithdrawMoney_Money = dr.GetInt32(3);
        		if (!dr.IsDBNull(4)) model.WithdrawMoney_AddTime = dr.GetDateTime(4);
        		if (!dr.IsDBNull(5)) model.WithdrawMoney_DoTime = dr.GetDateTime(5);
        		if (!dr.IsDBNull(6)) model.WithdrawMoney_DoUser = dr.GetString(6);
        		if (!dr.IsDBNull(7)) model.WithdrawMoney_Status = dr.GetInt32(7);
        		if (!dr.IsDBNull(8)) model.WithdrawMoney_isDel = dr.GetInt32(8);
        		if (!dr.IsDBNull(9)) model.WithdrawMoney_Remark = dr.GetString(9);
        		if (!dr.IsDBNull(10)) model.WithdrawMoney_Finance = dr.GetString(10);
        		if (!dr.IsDBNull(11)) model.WithdrawMoney_Bank = dr.GetString(11);
        	}
        }

        protected void LoadFromReader1(IDataReader dr,Os.Brain.iBxg.Core.Entity.BankOut model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
                model.WithdrawMoney_Ids = (int)dr["WithdrawMoney_Ids"];
                model.WithdrawMoney_UserId = (int)dr["WithdrawMoney_UserId"];
                model.WithdrawMoney_No = dr["WithdrawMoney_No"].ToString();
                model.WithdrawMoney_Money = (int)dr["WithdrawMoney_Money"];
                model.WithdrawMoney_AddTime = (DateTime)dr["WithdrawMoney_AddTime"];
                model.WithdrawMoney_DoTime = (DateTime)dr["WithdrawMoney_DoTime"];
                model.WithdrawMoney_DoUser = dr["WithdrawMoney_DoUser"].ToString();
                model.WithdrawMoney_Status = (int)dr["WithdrawMoney_Status"];
                model.WithdrawMoney_isDel = (int)dr["WithdrawMoney_isDel"];
                model.WithdrawMoney_Remark = dr["WithdrawMoney_Remark"].ToString();
                model.WithdrawMoney_Finance = dr["WithdrawMoney_Finance"].ToString();
                model.WithdrawMoney_Bank = dr["WithdrawMoney_Bank"].ToString();
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
    /// BankOut 业务逻辑层
    /// </summary>
    public partial class BankOut
    {
        /// <summary>
        /// dal 获取接口 IBankOut
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.IBankOut dal=DalFactory.CreateBankOut();

        /// <summary>
        /// Initializes a new instance of the <see cref="BankOut"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public BankOut(Os.Brain.Data.DataActions action)
        {
            this.dal.Action=action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
		public object Edit(Os.Brain.iBxg.Core.Entity.BankOut model)
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
		public Os.Brain.iBxg.Core.Entity.BankOut Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
		public IList<Os.Brain.iBxg.Core.Entity.BankOut> GetList(DbParameter[] dataParams)
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
		public IList<Os.Brain.iBxg.Core.Entity.BankOut> GetList(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
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
    /// BankOut 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateBankOut 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.IBankOut CreateBankOut()
        {
            return new Os.Brain.iBxg.Core.Dal.BankOut();
        }
    }
}




