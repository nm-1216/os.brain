//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="BankList.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:32:02</datetime>
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
    /// BankList 实体类
    /// </summary>
    public partial class BankList : BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _bankList_Ids 
        /// </summary>
        private int _bankList_Ids;

        /// <summary>
        /// _bankList_UserId 用户编号
        /// </summary>
        private string _bankList_UserId = string.Empty;

        /// <summary>
        /// _bankList_Orders 订单交易流水号
        /// </summary>
        private string _bankList_Orders = string.Empty;

        /// <summary>
        /// _bankList_Balance1 变动前总金额
        /// </summary>
        private decimal _bankList_Balance1;

        /// <summary>
        /// _bankList_AvailAmount1 变动前可用金额
        /// </summary>
        private decimal _bankList_AvailAmount1;

        /// <summary>
        /// _bankList_FrozenAmount1 变动前冻结金额
        /// </summary>
        private decimal _bankList_FrozenAmount1;

        /// <summary>
        /// _bankList_Balance2 变动后总金额
        /// </summary>
        private decimal _bankList_Balance2;

        /// <summary>
        /// _bankList_AvailAmount2 变动后可用金额
        /// </summary>
        private decimal _bankList_AvailAmount2;

        /// <summary>
        /// _bankList_FrozenAmount2 变动后冻结金额
        /// </summary>
        private decimal _bankList_FrozenAmount2;

        /// <summary>
        /// _bankList_Money 资金增量
        /// </summary>
        private decimal _bankList_Money = 0M;

        /// <summary>
        /// _bankList_InMoney 入金资金增量
        /// </summary>
        private decimal _bankList_InMoney = 0M;

        /// <summary>
        /// _bankList_OutMoney 出金资金增量
        /// </summary>
        private decimal _bankList_OutMoney = 0M;

        /// <summary>
        /// _bankList_IntFrozenMoney 冻结金额增量
        /// </summary>
        private decimal _bankList_IntFrozenMoney = 0M;

        /// <summary>
        /// _bankList_OutFrozenMoney 冻结金额增量
        /// </summary>
        private decimal _bankList_OutFrozenMoney = 0M;

        /// <summary>
        /// _bankList_DaiLianMoney 交易金额增量
        /// </summary>
        private decimal _bankList_DaiLianMoney = 0M;

        /// <summary>
        /// _bankList_Types 资金变动类型
        /// </summary>
        private int _bankList_Types;

        /// <summary>
        /// _bankList_DoUser 处理人
        /// </summary>
        private string _bankList_DoUser = string.Empty;

        /// <summary>
        /// _bankList_AddTime 处理时间
        /// </summary>
        private DateTime _bankList_AddTime = DateTime.Now;

        /// <summary>
        /// _bankList_Remark 备注说明
        /// </summary>
        private string _bankList_Remark = string.Empty;

        /// <summary>
        /// _bankList_Field1 备用一
        /// </summary>
        private string _bankList_Field1 = string.Empty;

        /// <summary>
        /// _bankList_Field2 备用二
        /// </summary>
        private string _bankList_Field2 = string.Empty;

        /// <summary>
        /// _bankList_Field3 备用三
        /// </summary>
        private string _bankList_Field3 = string.Empty;

        /// <summary>
        /// _bankList_Field4 备用四
        /// </summary>
        private string _bankList_Field4 = string.Empty;

        /// <summary>
        /// _bankList_Field5 备用五
        /// </summary>
        private string _bankList_Field5 = string.Empty;

        /// <summary>
        /// _bankList_Field6 备用六
        /// </summary>
        private string _bankList_Field6 = string.Empty;

        /// <summary>
        /// _bankList_Field7 备用七
        /// </summary>
        private string _bankList_Field7 = string.Empty;

        /// <summary>
        /// _bankList_Field8 备用八
        /// </summary>
        private string _bankList_Field8 = string.Empty;

        /// <summary>
        /// _bankList_Field9 备用九
        /// </summary>
        private string _bankList_Field9 = string.Empty;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets BankList_Ids 
        /// </summary>
        public int BankList_Ids
        {
            get { return this._bankList_Ids; }
            set { this._bankList_Ids = value; }
        }


        /// <summary>
        /// Gets or sets BankList_UserId 用户编号
        /// </summary>
        public string BankList_UserId
        {
            get { return this._bankList_UserId; }
            set { this._bankList_UserId = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Orders 订单交易流水号
        /// </summary>
        public string BankList_Orders
        {
            get { return this._bankList_Orders; }
            set { this._bankList_Orders = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Balance1 变动前总金额
        /// </summary>
        public decimal BankList_Balance1
        {
            get { return this._bankList_Balance1; }
            set { this._bankList_Balance1 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_AvailAmount1 变动前可用金额
        /// </summary>
        public decimal BankList_AvailAmount1
        {
            get { return this._bankList_AvailAmount1; }
            set { this._bankList_AvailAmount1 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_FrozenAmount1 变动前冻结金额
        /// </summary>
        public decimal BankList_FrozenAmount1
        {
            get { return this._bankList_FrozenAmount1; }
            set { this._bankList_FrozenAmount1 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Balance2 变动后总金额
        /// </summary>
        public decimal BankList_Balance2
        {
            get { return this._bankList_Balance2; }
            set { this._bankList_Balance2 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_AvailAmount2 变动后可用金额
        /// </summary>
        public decimal BankList_AvailAmount2
        {
            get { return this._bankList_AvailAmount2; }
            set { this._bankList_AvailAmount2 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_FrozenAmount2 变动后冻结金额
        /// </summary>
        public decimal BankList_FrozenAmount2
        {
            get { return this._bankList_FrozenAmount2; }
            set { this._bankList_FrozenAmount2 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Money 资金增量
        /// </summary>
        public decimal BankList_Money
        {
            get { return this._bankList_Money; }
            set { this._bankList_Money = value; }
        }


        /// <summary>
        /// Gets or sets BankList_InMoney 入金资金增量
        /// </summary>
        public decimal BankList_InMoney
        {
            get { return this._bankList_InMoney; }
            set { this._bankList_InMoney = value; }
        }


        /// <summary>
        /// Gets or sets BankList_OutMoney 出金资金增量
        /// </summary>
        public decimal BankList_OutMoney
        {
            get { return this._bankList_OutMoney; }
            set { this._bankList_OutMoney = value; }
        }


        /// <summary>
        /// Gets or sets BankList_IntFrozenMoney 冻结金额增量
        /// </summary>
        public decimal BankList_IntFrozenMoney
        {
            get { return this._bankList_IntFrozenMoney; }
            set { this._bankList_IntFrozenMoney = value; }
        }


        /// <summary>
        /// Gets or sets BankList_OutFrozenMoney 冻结金额增量
        /// </summary>
        public decimal BankList_OutFrozenMoney
        {
            get { return this._bankList_OutFrozenMoney; }
            set { this._bankList_OutFrozenMoney = value; }
        }


        /// <summary>
        /// Gets or sets BankList_DaiLianMoney 交易金额增量
        /// </summary>
        public decimal BankList_DaiLianMoney
        {
            get { return this._bankList_DaiLianMoney; }
            set { this._bankList_DaiLianMoney = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Types 资金变动类型
        /// </summary>
        public int BankList_Types
        {
            get { return this._bankList_Types; }
            set { this._bankList_Types = value; }
        }


        /// <summary>
        /// Gets or sets BankList_DoUser 处理人
        /// </summary>
        public string BankList_DoUser
        {
            get { return this._bankList_DoUser; }
            set { this._bankList_DoUser = value; }
        }


        /// <summary>
        /// Gets or sets BankList_AddTime 处理时间
        /// </summary>
        public DateTime BankList_AddTime
        {
            get { return this._bankList_AddTime; }
            set { this._bankList_AddTime = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Remark 备注说明
        /// </summary>
        public string BankList_Remark
        {
            get { return this._bankList_Remark; }
            set { this._bankList_Remark = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field1 备用一
        /// </summary>
        public string BankList_Field1
        {
            get { return this._bankList_Field1; }
            set { this._bankList_Field1 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field2 备用二
        /// </summary>
        public string BankList_Field2
        {
            get { return this._bankList_Field2; }
            set { this._bankList_Field2 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field3 备用三
        /// </summary>
        public string BankList_Field3
        {
            get { return this._bankList_Field3; }
            set { this._bankList_Field3 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field4 备用四
        /// </summary>
        public string BankList_Field4
        {
            get { return this._bankList_Field4; }
            set { this._bankList_Field4 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field5 备用五
        /// </summary>
        public string BankList_Field5
        {
            get { return this._bankList_Field5; }
            set { this._bankList_Field5 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field6 备用六
        /// </summary>
        public string BankList_Field6
        {
            get { return this._bankList_Field6; }
            set { this._bankList_Field6 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field7 备用七
        /// </summary>
        public string BankList_Field7
        {
            get { return this._bankList_Field7; }
            set { this._bankList_Field7 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field8 备用八
        /// </summary>
        public string BankList_Field8
        {
            get { return this._bankList_Field8; }
            set { this._bankList_Field8 = value; }
        }


        /// <summary>
        /// Gets or sets BankList_Field9 备用九
        /// </summary>
        public string BankList_Field9
        {
            get { return this._bankList_Field9; }
            set { this._bankList_Field9 = value; }
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankList]", "[BankList_UserId], [BankList_Orders], [BankList_Balance1], [BankList_AvailAmount1], [BankList_FrozenAmount1], [BankList_Balance2], [BankList_AvailAmount2], [BankList_FrozenAmount2], [BankList_Money], [BankList_InMoney], [BankList_OutMoney], [BankList_IntFrozenMoney], [BankList_OutFrozenMoney], [BankList_DaiLianMoney], [BankList_Types], [BankList_DoUser], [BankList_AddTime], [BankList_Remark], [BankList_Field1], [BankList_Field2], [BankList_Field3], [BankList_Field4], [BankList_Field5], [BankList_Field6], [BankList_Field7], [BankList_Field8], [BankList_Field9]", "@BankList_UserId, @BankList_Orders, @BankList_Balance1, @BankList_AvailAmount1, @BankList_FrozenAmount1, @BankList_Balance2, @BankList_AvailAmount2, @BankList_FrozenAmount2, @BankList_Money, @BankList_InMoney, @BankList_OutMoney, @BankList_IntFrozenMoney, @BankList_OutFrozenMoney, @BankList_DaiLianMoney, @BankList_Types, @BankList_DoUser, @BankList_AddTime, @BankList_Remark, @BankList_Field1, @BankList_Field2, @BankList_Field3, @BankList_Field4, @BankList_Field5, @BankList_Field6, @BankList_Field7, @BankList_Field8, @BankList_Field9"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankList]", "[BankList_UserId], [BankList_Orders], [BankList_Balance1], [BankList_AvailAmount1], [BankList_FrozenAmount1], [BankList_Balance2], [BankList_AvailAmount2], [BankList_FrozenAmount2], [BankList_Money], [BankList_InMoney], [BankList_OutMoney], [BankList_IntFrozenMoney], [BankList_OutFrozenMoney], [BankList_DaiLianMoney], [BankList_Types], [BankList_DoUser], [BankList_AddTime], [BankList_Remark], [BankList_Field1], [BankList_Field2], [BankList_Field3], [BankList_Field4], [BankList_Field5], [BankList_Field6], [BankList_Field7], [BankList_Field8], [BankList_Field9]", "@BankList_UserId, @BankList_Orders, @BankList_Balance1, @BankList_AvailAmount1, @BankList_FrozenAmount1, @BankList_Balance2, @BankList_AvailAmount2, @BankList_FrozenAmount2, @BankList_Money, @BankList_InMoney, @BankList_OutMoney, @BankList_IntFrozenMoney, @BankList_OutFrozenMoney, @BankList_DaiLianMoney, @BankList_Types, @BankList_DoUser, @BankList_AddTime, @BankList_Remark, @BankList_Field1, @BankList_Field2, @BankList_Field3, @BankList_Field4, @BankList_Field5, @BankList_Field6, @BankList_Field7, @BankList_Field8, @BankList_Field9"));

            db.AddInParameter(dbc, "@BankList_UserId", DbType.AnsiString, this.BankList_UserId);
            db.AddInParameter(dbc, "@BankList_Orders", DbType.AnsiString, this.BankList_Orders);
            db.AddInParameter(dbc, "@BankList_Balance1", DbType.Currency, this.BankList_Balance1);
            db.AddInParameter(dbc, "@BankList_AvailAmount1", DbType.Currency, this.BankList_AvailAmount1);
            db.AddInParameter(dbc, "@BankList_FrozenAmount1", DbType.Currency, this.BankList_FrozenAmount1);
            db.AddInParameter(dbc, "@BankList_Balance2", DbType.Currency, this.BankList_Balance2);
            db.AddInParameter(dbc, "@BankList_AvailAmount2", DbType.Currency, this.BankList_AvailAmount2);
            db.AddInParameter(dbc, "@BankList_FrozenAmount2", DbType.Currency, this.BankList_FrozenAmount2);
            db.AddInParameter(dbc, "@BankList_Money", DbType.Currency, this.BankList_Money);
            db.AddInParameter(dbc, "@BankList_InMoney", DbType.Currency, this.BankList_InMoney);
            db.AddInParameter(dbc, "@BankList_OutMoney", DbType.Currency, this.BankList_OutMoney);
            db.AddInParameter(dbc, "@BankList_IntFrozenMoney", DbType.Currency, this.BankList_IntFrozenMoney);
            db.AddInParameter(dbc, "@BankList_OutFrozenMoney", DbType.Currency, this.BankList_OutFrozenMoney);
            db.AddInParameter(dbc, "@BankList_DaiLianMoney", DbType.Currency, this.BankList_DaiLianMoney);
            db.AddInParameter(dbc, "@BankList_Types", DbType.Int32, this.BankList_Types);
            db.AddInParameter(dbc, "@BankList_DoUser", DbType.AnsiString, this.BankList_DoUser);
            db.AddInParameter(dbc, "@BankList_AddTime", DbType.DateTime, this.BankList_AddTime);
            db.AddInParameter(dbc, "@BankList_Remark", DbType.String, this.BankList_Remark);
            db.AddInParameter(dbc, "@BankList_Field1", DbType.AnsiString, this.BankList_Field1);
            db.AddInParameter(dbc, "@BankList_Field2", DbType.AnsiString, this.BankList_Field2);
            db.AddInParameter(dbc, "@BankList_Field3", DbType.AnsiString, this.BankList_Field3);
            db.AddInParameter(dbc, "@BankList_Field4", DbType.AnsiString, this.BankList_Field4);
            db.AddInParameter(dbc, "@BankList_Field5", DbType.AnsiString, this.BankList_Field5);
            db.AddInParameter(dbc, "@BankList_Field6", DbType.AnsiString, this.BankList_Field6);
            db.AddInParameter(dbc, "@BankList_Field7", DbType.AnsiString, this.BankList_Field7);
            db.AddInParameter(dbc, "@BankList_Field8", DbType.AnsiString, this.BankList_Field8);
            db.AddInParameter(dbc, "@BankList_Field9", DbType.AnsiString, this.BankList_Field9);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[BankList]", "[BankList_UserId] = @BankList_UserId, [BankList_Orders] = @BankList_Orders, [BankList_Balance1] = @BankList_Balance1, [BankList_AvailAmount1] = @BankList_AvailAmount1, [BankList_FrozenAmount1] = @BankList_FrozenAmount1, [BankList_Balance2] = @BankList_Balance2, [BankList_AvailAmount2] = @BankList_AvailAmount2, [BankList_FrozenAmount2] = @BankList_FrozenAmount2, [BankList_Money] = @BankList_Money, [BankList_InMoney] = @BankList_InMoney, [BankList_OutMoney] = @BankList_OutMoney, [BankList_IntFrozenMoney] = @BankList_IntFrozenMoney, [BankList_OutFrozenMoney] = @BankList_OutFrozenMoney, [BankList_DaiLianMoney] = @BankList_DaiLianMoney, [BankList_Types] = @BankList_Types, [BankList_DoUser] = @BankList_DoUser, [BankList_AddTime] = @BankList_AddTime, [BankList_Remark] = @BankList_Remark, [BankList_Field1] = @BankList_Field1, [BankList_Field2] = @BankList_Field2, [BankList_Field3] = @BankList_Field3, [BankList_Field4] = @BankList_Field4, [BankList_Field5] = @BankList_Field5, [BankList_Field6] = @BankList_Field6, [BankList_Field7] = @BankList_Field7, [BankList_Field8] = @BankList_Field8, [BankList_Field9] = @BankList_Field9", "BankList_Ids"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY, "[dbo].[BankList]", "[BankList_UserId] = @BankList_UserId, [BankList_Orders] = @BankList_Orders, [BankList_Balance1] = @BankList_Balance1, [BankList_AvailAmount1] = @BankList_AvailAmount1, [BankList_FrozenAmount1] = @BankList_FrozenAmount1, [BankList_Balance2] = @BankList_Balance2, [BankList_AvailAmount2] = @BankList_AvailAmount2, [BankList_FrozenAmount2] = @BankList_FrozenAmount2, [BankList_Money] = @BankList_Money, [BankList_InMoney] = @BankList_InMoney, [BankList_OutMoney] = @BankList_OutMoney, [BankList_IntFrozenMoney] = @BankList_IntFrozenMoney, [BankList_OutFrozenMoney] = @BankList_OutFrozenMoney, [BankList_DaiLianMoney] = @BankList_DaiLianMoney, [BankList_Types] = @BankList_Types, [BankList_DoUser] = @BankList_DoUser, [BankList_AddTime] = @BankList_AddTime, [BankList_Remark] = @BankList_Remark, [BankList_Field1] = @BankList_Field1, [BankList_Field2] = @BankList_Field2, [BankList_Field3] = @BankList_Field3, [BankList_Field4] = @BankList_Field4, [BankList_Field5] = @BankList_Field5, [BankList_Field6] = @BankList_Field6, [BankList_Field7] = @BankList_Field7, [BankList_Field8] = @BankList_Field8, [BankList_Field9] = @BankList_Field9", "BankList_Ids"));

            db.AddInParameter(dbc, "@BankList_Ids", DbType.Int32, this.BankList_Ids);
            db.AddInParameter(dbc, "@BankList_UserId", DbType.AnsiString, this.BankList_UserId);
            db.AddInParameter(dbc, "@BankList_Orders", DbType.AnsiString, this.BankList_Orders);
            db.AddInParameter(dbc, "@BankList_Balance1", DbType.Currency, this.BankList_Balance1);
            db.AddInParameter(dbc, "@BankList_AvailAmount1", DbType.Currency, this.BankList_AvailAmount1);
            db.AddInParameter(dbc, "@BankList_FrozenAmount1", DbType.Currency, this.BankList_FrozenAmount1);
            db.AddInParameter(dbc, "@BankList_Balance2", DbType.Currency, this.BankList_Balance2);
            db.AddInParameter(dbc, "@BankList_AvailAmount2", DbType.Currency, this.BankList_AvailAmount2);
            db.AddInParameter(dbc, "@BankList_FrozenAmount2", DbType.Currency, this.BankList_FrozenAmount2);
            db.AddInParameter(dbc, "@BankList_Money", DbType.Currency, this.BankList_Money);
            db.AddInParameter(dbc, "@BankList_InMoney", DbType.Currency, this.BankList_InMoney);
            db.AddInParameter(dbc, "@BankList_OutMoney", DbType.Currency, this.BankList_OutMoney);
            db.AddInParameter(dbc, "@BankList_IntFrozenMoney", DbType.Currency, this.BankList_IntFrozenMoney);
            db.AddInParameter(dbc, "@BankList_OutFrozenMoney", DbType.Currency, this.BankList_OutFrozenMoney);
            db.AddInParameter(dbc, "@BankList_DaiLianMoney", DbType.Currency, this.BankList_DaiLianMoney);
            db.AddInParameter(dbc, "@BankList_Types", DbType.Int32, this.BankList_Types);
            db.AddInParameter(dbc, "@BankList_DoUser", DbType.AnsiString, this.BankList_DoUser);
            db.AddInParameter(dbc, "@BankList_AddTime", DbType.DateTime, this.BankList_AddTime);
            db.AddInParameter(dbc, "@BankList_Remark", DbType.String, this.BankList_Remark);
            db.AddInParameter(dbc, "@BankList_Field1", DbType.AnsiString, this.BankList_Field1);
            db.AddInParameter(dbc, "@BankList_Field2", DbType.AnsiString, this.BankList_Field2);
            db.AddInParameter(dbc, "@BankList_Field3", DbType.AnsiString, this.BankList_Field3);
            db.AddInParameter(dbc, "@BankList_Field4", DbType.AnsiString, this.BankList_Field4);
            db.AddInParameter(dbc, "@BankList_Field5", DbType.AnsiString, this.BankList_Field5);
            db.AddInParameter(dbc, "@BankList_Field6", DbType.AnsiString, this.BankList_Field6);
            db.AddInParameter(dbc, "@BankList_Field7", DbType.AnsiString, this.BankList_Field7);
            db.AddInParameter(dbc, "@BankList_Field8", DbType.AnsiString, this.BankList_Field8);
            db.AddInParameter(dbc, "@BankList_Field9", DbType.AnsiString, this.BankList_Field9);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankList]", "[BankList_Ids]", "@BankList_Ids"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion

            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankList]", "[BankList_Ids]", "@BankList_Ids"));

            db.AddInParameter(dbc, "@BankList_Ids", DbType.Int32, this.BankList_Ids);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// BankList dal接口
    /// </summary>
    public interface IBankList : IBasicDal<Os.Brain.iBxg.Core.Entity.BankList>
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
    /// BankList dal数据处理层
    /// </summary>
    public partial class BankList : IBankList
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
        public object Edit(Os.Brain.iBxg.Core.Entity.BankList model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST, "[dbo].[BankList]", "[BankList_Ids]", "@BankList_Ids"));
            Debug.WriteLine("@BankList_Ids=" + "," + ids.Trim(',') + ",");
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankList.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST, "[dbo].[BankList]", "[BankList_Ids]", "@BankList_Ids"));

            db.AddInParameter(dbc, "@BankList_Ids", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
        public Os.Brain.iBxg.Core.Entity.BankList GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE, "Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM, "[dbo].[BankList]", "[BankList_Ids]", "@BankList_Ids"));
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE, "Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion

            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.BankList _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankList.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM, "[dbo].[BankList]", "[BankList_Ids]", "@BankList_Ids"));

            db.AddInParameter(dbc, "@BankList_Ids", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankList();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankList> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankList> returnList = new List<Os.Brain.iBxg.Core.Entity.BankList>();
            Os.Brain.iBxg.Core.Entity.BankList _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankList.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankList_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankList();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankList> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount = 0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankList> returnList = new List<Os.Brain.iBxg.Core.Entity.BankList>();
            Os.Brain.iBxg.Core.Entity.BankList _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankList.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankList_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.BankList();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankList.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankList_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankList.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankList_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[BankList]", "BankList_Ids", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankList.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            var ds = db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr, Os.Brain.iBxg.Core.Entity.BankList model)
        {
            if (dr != null && !dr.IsClosed)
            {
                if (!dr.IsDBNull(0)) model.BankList_Ids = dr.GetInt32(0);
                if (!dr.IsDBNull(1)) model.BankList_UserId = dr.GetString(1);
                if (!dr.IsDBNull(2)) model.BankList_Orders = dr.GetString(2);
                if (!dr.IsDBNull(3)) model.BankList_Balance1 = dr.GetDecimal(3);
                if (!dr.IsDBNull(4)) model.BankList_AvailAmount1 = dr.GetDecimal(4);
                if (!dr.IsDBNull(5)) model.BankList_FrozenAmount1 = dr.GetDecimal(5);
                if (!dr.IsDBNull(6)) model.BankList_Balance2 = dr.GetDecimal(6);
                if (!dr.IsDBNull(7)) model.BankList_AvailAmount2 = dr.GetDecimal(7);
                if (!dr.IsDBNull(8)) model.BankList_FrozenAmount2 = dr.GetDecimal(8);
                if (!dr.IsDBNull(9)) model.BankList_Money = dr.GetDecimal(9);
                if (!dr.IsDBNull(10)) model.BankList_InMoney = dr.GetDecimal(10);
                if (!dr.IsDBNull(11)) model.BankList_OutMoney = dr.GetDecimal(11);
                if (!dr.IsDBNull(12)) model.BankList_IntFrozenMoney = dr.GetDecimal(12);
                if (!dr.IsDBNull(13)) model.BankList_OutFrozenMoney = dr.GetDecimal(13);
                if (!dr.IsDBNull(14)) model.BankList_DaiLianMoney = dr.GetDecimal(14);
                if (!dr.IsDBNull(15)) model.BankList_Types = dr.GetInt32(15);
                if (!dr.IsDBNull(16)) model.BankList_DoUser = dr.GetString(16);
                if (!dr.IsDBNull(17)) model.BankList_AddTime = dr.GetDateTime(17);
                if (!dr.IsDBNull(18)) model.BankList_Remark = dr.GetString(18);
                if (!dr.IsDBNull(19)) model.BankList_Field1 = dr.GetString(19);
                if (!dr.IsDBNull(20)) model.BankList_Field2 = dr.GetString(20);
                if (!dr.IsDBNull(21)) model.BankList_Field3 = dr.GetString(21);
                if (!dr.IsDBNull(22)) model.BankList_Field4 = dr.GetString(22);
                if (!dr.IsDBNull(23)) model.BankList_Field5 = dr.GetString(23);
                if (!dr.IsDBNull(24)) model.BankList_Field6 = dr.GetString(24);
                if (!dr.IsDBNull(25)) model.BankList_Field7 = dr.GetString(25);
                if (!dr.IsDBNull(26)) model.BankList_Field8 = dr.GetString(26);
                if (!dr.IsDBNull(27)) model.BankList_Field9 = dr.GetString(27);
            }
        }

        protected void LoadFromReader1(IDataReader dr, Os.Brain.iBxg.Core.Entity.BankList model)
        {
            if (dr != null && !dr.IsClosed)
            {
                model.BankList_Ids = (int)dr["BankList_Ids"];
                model.BankList_UserId = dr["BankList_UserId"].ToString();
                model.BankList_Orders = dr["BankList_Orders"].ToString();
                model.BankList_Balance1 = Convert.ToDecimal(dr["BankList_Balance1"]);
                model.BankList_AvailAmount1 = Convert.ToDecimal(dr["BankList_AvailAmount1"]);
                model.BankList_FrozenAmount1 = Convert.ToDecimal(dr["BankList_FrozenAmount1"]);
                model.BankList_Balance2 = Convert.ToDecimal(dr["BankList_Balance2"]);
                model.BankList_AvailAmount2 = Convert.ToDecimal(dr["BankList_AvailAmount2"]);
                model.BankList_FrozenAmount2 = Convert.ToDecimal(dr["BankList_FrozenAmount2"]);
                model.BankList_Money = Convert.ToDecimal(dr["BankList_Money"]);
                model.BankList_InMoney = Convert.ToDecimal(dr["BankList_InMoney"]);
                model.BankList_OutMoney = Convert.ToDecimal(dr["BankList_OutMoney"]);
                model.BankList_IntFrozenMoney = Convert.ToDecimal(dr["BankList_IntFrozenMoney"]);
                model.BankList_OutFrozenMoney = Convert.ToDecimal(dr["BankList_OutFrozenMoney"]);
                model.BankList_DaiLianMoney = Convert.ToDecimal(dr["BankList_DaiLianMoney"]);
                model.BankList_Types = (int)dr["BankList_Types"];
                model.BankList_DoUser = dr["BankList_DoUser"].ToString();
                model.BankList_AddTime = (DateTime)dr["BankList_AddTime"];
                model.BankList_Remark = dr["BankList_Remark"].ToString();
                model.BankList_Field1 = dr["BankList_Field1"].ToString();
                model.BankList_Field2 = dr["BankList_Field2"].ToString();
                model.BankList_Field3 = dr["BankList_Field3"].ToString();
                model.BankList_Field4 = dr["BankList_Field4"].ToString();
                model.BankList_Field5 = dr["BankList_Field5"].ToString();
                model.BankList_Field6 = dr["BankList_Field6"].ToString();
                model.BankList_Field7 = dr["BankList_Field7"].ToString();
                model.BankList_Field8 = dr["BankList_Field8"].ToString();
                model.BankList_Field9 = dr["BankList_Field9"].ToString();
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
    /// BankList 业务逻辑层
    /// </summary>
    public partial class BankList
    {
        /// <summary>
        /// dal 获取接口 IBankList
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.IBankList dal = DalFactory.CreateBankList();

        /// <summary>
        /// Initializes a new instance of the <see cref="BankList"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public BankList(Os.Brain.Data.DataActions action)
        {
            this.dal.Action = action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
        public object Edit(Os.Brain.iBxg.Core.Entity.BankList model)
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
        public Os.Brain.iBxg.Core.Entity.BankList Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
        public IList<Os.Brain.iBxg.Core.Entity.BankList> GetList(DbParameter[] dataParams)
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
        public IList<Os.Brain.iBxg.Core.Entity.BankList> GetList(int pageSize, int currPage, out int recordCount, DbParameter[] dataParams)
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
    /// BankList 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateBankList 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.IBankList CreateBankList()
        {
            return new Os.Brain.iBxg.Core.Dal.BankList();
        }
    }
}




