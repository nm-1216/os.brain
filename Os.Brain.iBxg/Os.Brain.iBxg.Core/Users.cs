//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Users.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:24:54</datetime>
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
    /// Users 实体类
    /// </summary>
    public partial class Users:BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _id 
        /// </summary>
        private int _id;

        /// <summary>
        /// _numberId 
        /// </summary>
        private string _numberId = string.Empty;

        /// <summary>
        /// _letterId 
        /// </summary>
        private string _letterId = string.Empty;

        /// <summary>
        /// _mobileId 
        /// </summary>
        private string _mobileId = string.Empty;

        /// <summary>
        /// _emailId 
        /// </summary>
        private string _emailId = string.Empty;

        /// <summary>
        /// _password 
        /// </summary>
        private string _password = string.Empty;

        /// <summary>
        /// _nick 
        /// </summary>
        private string _nick = string.Empty;

        /// <summary>
        /// _qQ 
        /// </summary>
        private string _qQ = string.Empty;

        /// <summary>
        /// _dPassword 
        /// </summary>
        private string _dPassword = string.Empty;

        /// <summary>
        /// _dPasswordCreateTime 
        /// </summary>
        private DateTime? _dPasswordCreateTime;

        /// <summary>
        /// _isOnline 
        /// </summary>
        private int? _isOnline = 0;

        /// <summary>
        /// _lastOnlineTime 
        /// </summary>
        private DateTime? _lastOnlineTime;

        /// <summary>
        /// _status 
        /// </summary>
        private int? _status;

        /// <summary>
        /// _createTime 
        /// </summary>
        private DateTime? _createTime;

        /// <summary>
        /// _lastTime 
        /// </summary>
        private DateTime? _lastTime;

        /// <summary>
        /// _isVerifyMobile 
        /// </summary>
        private int? _isVerifyMobile;

        /// <summary>
        /// _remark 
        /// </summary>
        private string _remark = string.Empty;

        /// <summary>
        /// _revokeRate 
        /// </summary>
        private int? _revokeRate;

        /// <summary>
        /// _finishAvg 
        /// </summary>
        private int? _finishAvg;

        /// <summary>
        /// _isDailian 
        /// </summary>
        private bool _isDailian = false;

        /// <summary>
        /// _onlineDuration 
        /// </summary>
        private int _onlineDuration = 0;

        /// <summary>
        /// _avatar 
        /// </summary>
        private string _avatar = string.Empty;

        /// <summary>
        /// _payPassword 
        /// </summary>
        private string _payPassword = string.Empty;

        /// <summary>
        /// _cashPassword 
        /// </summary>
        private string _cashPassword = string.Empty;

        /// <summary>
        /// _postRate 
        /// </summary>
        private int? _postRate;

        /// <summary>
        /// _receiveRate 
        /// </summary>
        private int? _receiveRate;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Id 
        /// </summary>
        public int Id
        {
            get {return this._id;}
            set {this._id = value;}
        }


        /// <summary>
        /// Gets or sets NumberId 
        /// </summary>
        public string NumberId
        {
            get {return this._numberId;}
            set {this._numberId = value;}
        }


        /// <summary>
        /// Gets or sets LetterId 
        /// </summary>
        public string LetterId
        {
            get {return this._letterId;}
            set {this._letterId = value;}
        }


        /// <summary>
        /// Gets or sets MobileId 
        /// </summary>
        public string MobileId
        {
            get {return this._mobileId;}
            set {this._mobileId = value;}
        }


        /// <summary>
        /// Gets or sets EmailId 
        /// </summary>
        public string EmailId
        {
            get {return this._emailId;}
            set {this._emailId = value;}
        }


        /// <summary>
        /// Gets or sets Password 
        /// </summary>
        public string Password
        {
            get {return this._password;}
            set {this._password = value;}
        }


        /// <summary>
        /// Gets or sets Nick 
        /// </summary>
        public string Nick
        {
            get {return this._nick;}
            set {this._nick = value;}
        }


        /// <summary>
        /// Gets or sets QQ 
        /// </summary>
        public string QQ
        {
            get {return this._qQ;}
            set {this._qQ = value;}
        }


        /// <summary>
        /// Gets or sets DPassword 
        /// </summary>
        public string DPassword
        {
            get {return this._dPassword;}
            set {this._dPassword = value;}
        }


        /// <summary>
        /// Gets or sets DPasswordCreateTime 
        /// </summary>
        public DateTime? DPasswordCreateTime
        {
            get {return this._dPasswordCreateTime;}
            set {this._dPasswordCreateTime = value;}
        }


        /// <summary>
        /// Gets or sets IsOnline 
        /// </summary>
        public int? IsOnline
        {
            get {return this._isOnline;}
            set {this._isOnline = value;}
        }


        /// <summary>
        /// Gets or sets LastOnlineTime 
        /// </summary>
        public DateTime? LastOnlineTime
        {
            get {return this._lastOnlineTime;}
            set {this._lastOnlineTime = value;}
        }


        /// <summary>
        /// Gets or sets Status 
        /// </summary>
        public int? Status
        {
            get {return this._status;}
            set {this._status = value;}
        }


        /// <summary>
        /// Gets or sets CreateTime 
        /// </summary>
        public DateTime? CreateTime
        {
            get {return this._createTime;}
            set {this._createTime = value;}
        }


        /// <summary>
        /// Gets or sets LastTime 
        /// </summary>
        public DateTime? LastTime
        {
            get {return this._lastTime;}
            set {this._lastTime = value;}
        }


        /// <summary>
        /// Gets or sets IsVerifyMobile 
        /// </summary>
        public int? IsVerifyMobile
        {
            get {return this._isVerifyMobile;}
            set {this._isVerifyMobile = value;}
        }


        /// <summary>
        /// Gets or sets Remark 
        /// </summary>
        public string Remark
        {
            get {return this._remark;}
            set {this._remark = value;}
        }


        /// <summary>
        /// Gets or sets RevokeRate 
        /// </summary>
        public int? RevokeRate
        {
            get {return this._revokeRate;}
            set {this._revokeRate = value;}
        }


        /// <summary>
        /// Gets or sets FinishAvg 
        /// </summary>
        public int? FinishAvg
        {
            get {return this._finishAvg;}
            set {this._finishAvg = value;}
        }


        /// <summary>
        /// Gets or sets IsDailian 
        /// </summary>
        public bool IsDailian
        {
            get {return this._isDailian;}
            set {this._isDailian = value;}
        }


        /// <summary>
        /// Gets or sets OnlineDuration 
        /// </summary>
        public int OnlineDuration
        {
            get {return this._onlineDuration;}
            set {this._onlineDuration = value;}
        }


        /// <summary>
        /// Gets or sets Avatar 
        /// </summary>
        public string Avatar
        {
            get {return this._avatar;}
            set {this._avatar = value;}
        }


        /// <summary>
        /// Gets or sets PayPassword 
        /// </summary>
        public string PayPassword
        {
            get {return this._payPassword;}
            set {this._payPassword = value;}
        }


        /// <summary>
        /// Gets or sets CashPassword 
        /// </summary>
        public string CashPassword
        {
            get {return this._cashPassword;}
            set {this._cashPassword = value;}
        }


        /// <summary>
        /// Gets or sets PostRate 
        /// </summary>
        public int? PostRate
        {
            get {return this._postRate;}
            set {this._postRate = value;}
        }


        /// <summary>
        /// Gets or sets ReceiveRate 
        /// </summary>
        public int? ReceiveRate
        {
            get {return this._receiveRate;}
            set {this._receiveRate = value;}
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[Users]", "[NumberId], [LetterId], [MobileId], [EmailId], [Password], [Nick], [QQ], [DPassword], [DPasswordCreateTime], [IsOnline], [LastOnlineTime], [Status], [CreateTime], [LastTime], [IsVerifyMobile], [Remark], [RevokeRate], [FinishAvg], [IsDailian], [OnlineDuration], [Avatar], [PayPassword], [CashPassword], [PostRate], [ReceiveRate]" , "@NumberId, @LetterId, @MobileId, @EmailId, @Password, @Nick, @QQ, @DPassword, @DPasswordCreateTime, @IsOnline, @LastOnlineTime, @Status, @CreateTime, @LastTime, @IsVerifyMobile, @Remark, @RevokeRate, @FinishAvg, @IsDailian, @OnlineDuration, @Avatar, @PayPassword, @CashPassword, @PostRate, @ReceiveRate"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion
            
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[Users]", "[NumberId], [LetterId], [MobileId], [EmailId], [Password], [Nick], [QQ], [DPassword], [DPasswordCreateTime], [IsOnline], [LastOnlineTime], [Status], [CreateTime], [LastTime], [IsVerifyMobile], [Remark], [RevokeRate], [FinishAvg], [IsDailian], [OnlineDuration], [Avatar], [PayPassword], [CashPassword], [PostRate], [ReceiveRate]" , "@NumberId, @LetterId, @MobileId, @EmailId, @Password, @Nick, @QQ, @DPassword, @DPasswordCreateTime, @IsOnline, @LastOnlineTime, @Status, @CreateTime, @LastTime, @IsVerifyMobile, @Remark, @RevokeRate, @FinishAvg, @IsDailian, @OnlineDuration, @Avatar, @PayPassword, @CashPassword, @PostRate, @ReceiveRate"));

            db.AddInParameter(dbc, "@NumberId", DbType.AnsiString, this.NumberId);
            db.AddInParameter(dbc, "@LetterId", DbType.String, this.LetterId);
            db.AddInParameter(dbc, "@MobileId", DbType.AnsiString, this.MobileId);
            db.AddInParameter(dbc, "@EmailId", DbType.AnsiString, this.EmailId);
            db.AddInParameter(dbc, "@Password", DbType.AnsiString, this.Password);
            db.AddInParameter(dbc, "@Nick", DbType.AnsiString, this.Nick);
            db.AddInParameter(dbc, "@QQ", DbType.AnsiString, this.QQ);
            db.AddInParameter(dbc, "@DPassword", DbType.AnsiString, this.DPassword);
            db.AddInParameter(dbc, "@DPasswordCreateTime", DbType.DateTime, this.DPasswordCreateTime);
            db.AddInParameter(dbc, "@IsOnline", DbType.Int32, this.IsOnline);
            db.AddInParameter(dbc, "@LastOnlineTime", DbType.DateTime, this.LastOnlineTime);
            db.AddInParameter(dbc, "@Status", DbType.Int32, this.Status);
            db.AddInParameter(dbc, "@CreateTime", DbType.DateTime, this.CreateTime);
            db.AddInParameter(dbc, "@LastTime", DbType.DateTime, this.LastTime);
            db.AddInParameter(dbc, "@IsVerifyMobile", DbType.Int32, this.IsVerifyMobile);
            db.AddInParameter(dbc, "@Remark", DbType.String, this.Remark);
            db.AddInParameter(dbc, "@RevokeRate", DbType.Int32, this.RevokeRate);
            db.AddInParameter(dbc, "@FinishAvg", DbType.Int32, this.FinishAvg);
            db.AddInParameter(dbc, "@IsDailian", DbType.Boolean, this.IsDailian);
            db.AddInParameter(dbc, "@OnlineDuration", DbType.Int32, this.OnlineDuration);
            db.AddInParameter(dbc, "@Avatar", DbType.AnsiString, this.Avatar);
            db.AddInParameter(dbc, "@PayPassword", DbType.AnsiString, this.PayPassword);
            db.AddInParameter(dbc, "@CashPassword", DbType.AnsiString, this.CashPassword);
            db.AddInParameter(dbc, "@PostRate", DbType.Int32, this.PostRate);
            db.AddInParameter(dbc, "@ReceiveRate", DbType.Int32, this.ReceiveRate);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[Users]","[NumberId] = @NumberId, [LetterId] = @LetterId, [MobileId] = @MobileId, [EmailId] = @EmailId, [Password] = @Password, [Nick] = @Nick, [QQ] = @QQ, [DPassword] = @DPassword, [DPasswordCreateTime] = @DPasswordCreateTime, [IsOnline] = @IsOnline, [LastOnlineTime] = @LastOnlineTime, [Status] = @Status, [CreateTime] = @CreateTime, [LastTime] = @LastTime, [IsVerifyMobile] = @IsVerifyMobile, [Remark] = @Remark, [RevokeRate] = @RevokeRate, [FinishAvg] = @FinishAvg, [IsDailian] = @IsDailian, [OnlineDuration] = @OnlineDuration, [Avatar] = @Avatar, [PayPassword] = @PayPassword, [CashPassword] = @CashPassword, [PostRate] = @PostRate, [ReceiveRate] = @ReceiveRate","Id"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[Users]","[NumberId] = @NumberId, [LetterId] = @LetterId, [MobileId] = @MobileId, [EmailId] = @EmailId, [Password] = @Password, [Nick] = @Nick, [QQ] = @QQ, [DPassword] = @DPassword, [DPasswordCreateTime] = @DPasswordCreateTime, [IsOnline] = @IsOnline, [LastOnlineTime] = @LastOnlineTime, [Status] = @Status, [CreateTime] = @CreateTime, [LastTime] = @LastTime, [IsVerifyMobile] = @IsVerifyMobile, [Remark] = @Remark, [RevokeRate] = @RevokeRate, [FinishAvg] = @FinishAvg, [IsDailian] = @IsDailian, [OnlineDuration] = @OnlineDuration, [Avatar] = @Avatar, [PayPassword] = @PayPassword, [CashPassword] = @CashPassword, [PostRate] = @PostRate, [ReceiveRate] = @ReceiveRate","Id"));

            db.AddInParameter(dbc, "@Id", DbType.Int32, this.Id);
            db.AddInParameter(dbc, "@NumberId", DbType.AnsiString, this.NumberId);
            db.AddInParameter(dbc, "@LetterId", DbType.String, this.LetterId);
            db.AddInParameter(dbc, "@MobileId", DbType.AnsiString, this.MobileId);
            db.AddInParameter(dbc, "@EmailId", DbType.AnsiString, this.EmailId);
            db.AddInParameter(dbc, "@Password", DbType.AnsiString, this.Password);
            db.AddInParameter(dbc, "@Nick", DbType.AnsiString, this.Nick);
            db.AddInParameter(dbc, "@QQ", DbType.AnsiString, this.QQ);
            db.AddInParameter(dbc, "@DPassword", DbType.AnsiString, this.DPassword);
            db.AddInParameter(dbc, "@DPasswordCreateTime", DbType.DateTime, this.DPasswordCreateTime);
            db.AddInParameter(dbc, "@IsOnline", DbType.Int32, this.IsOnline);
            db.AddInParameter(dbc, "@LastOnlineTime", DbType.DateTime, this.LastOnlineTime);
            db.AddInParameter(dbc, "@Status", DbType.Int32, this.Status);
            db.AddInParameter(dbc, "@CreateTime", DbType.DateTime, this.CreateTime);
            db.AddInParameter(dbc, "@LastTime", DbType.DateTime, this.LastTime);
            db.AddInParameter(dbc, "@IsVerifyMobile", DbType.Int32, this.IsVerifyMobile);
            db.AddInParameter(dbc, "@Remark", DbType.String, this.Remark);
            db.AddInParameter(dbc, "@RevokeRate", DbType.Int32, this.RevokeRate);
            db.AddInParameter(dbc, "@FinishAvg", DbType.Int32, this.FinishAvg);
            db.AddInParameter(dbc, "@IsDailian", DbType.Boolean, this.IsDailian);
            db.AddInParameter(dbc, "@OnlineDuration", DbType.Int32, this.OnlineDuration);
            db.AddInParameter(dbc, "@Avatar", DbType.AnsiString, this.Avatar);
            db.AddInParameter(dbc, "@PayPassword", DbType.AnsiString, this.PayPassword);
            db.AddInParameter(dbc, "@CashPassword", DbType.AnsiString, this.CashPassword);
            db.AddInParameter(dbc, "@PostRate", DbType.Int32, this.PostRate);
            db.AddInParameter(dbc, "@ReceiveRate", DbType.Int32, this.ReceiveRate);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[Users]", "[Id]" ,"@Id"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[Users]", "[Id]" ,"@Id"));

            db.AddInParameter(dbc, "@Id", DbType.Int32, this.Id);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// Users dal接口
    /// </summary>
    public interface IUsers : IBasicDal<Os.Brain.iBxg.Core.Entity.Users>
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
    /// Users dal数据处理层
    /// </summary>
    public partial class Users:IUsers
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
		public object Edit(Os.Brain.iBxg.Core.Entity.Users model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST,"[dbo].[Users]","[Id]","@Id"));            
            Debug.WriteLine("@Id="+"," + ids.Trim(',') + ",");            
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Users.CONN);
            DbCommand dbc= db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST,"[dbo].[Users]","[Id]","@Id"));

            db.AddInParameter(dbc, "@Id", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
		public Os.Brain.iBxg.Core.Entity.Users GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM,"[dbo].[Users]","[Id]","@Id"));            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion
            
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.Users _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Users.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM,"[dbo].[Users]","[Id]","@Id"));

            db.AddInParameter(dbc, "@Id", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Users();

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
        public IList<Os.Brain.iBxg.Core.Entity.Users> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.Users> returnList = new List<Os.Brain.iBxg.Core.Entity.Users>();
            Os.Brain.iBxg.Core.Entity.Users _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Users.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Users_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.Users();

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
        public IList<Os.Brain.iBxg.Core.Entity.Users> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.Users> returnList = new List<Os.Brain.iBxg.Core.Entity.Users>();
            Os.Brain.iBxg.Core.Entity.Users _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Users.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Users_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.Users();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Users.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Users_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Users.CONN);
            DbCommand dbc = db.GetStoredProcCommand("Users_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[Users]", "Id", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.Users.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }            

            var ds=db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr,Os.Brain.iBxg.Core.Entity.Users model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
        		if (!dr.IsDBNull(0)) model.Id = dr.GetInt32(0);
        		if (!dr.IsDBNull(1)) model.NumberId = dr.GetString(1);
        		if (!dr.IsDBNull(2)) model.LetterId = dr.GetString(2);
        		if (!dr.IsDBNull(3)) model.MobileId = dr.GetString(3);
        		if (!dr.IsDBNull(4)) model.EmailId = dr.GetString(4);
        		if (!dr.IsDBNull(5)) model.Password = dr.GetString(5);
        		if (!dr.IsDBNull(6)) model.Nick = dr.GetString(6);
        		if (!dr.IsDBNull(7)) model.QQ = dr.GetString(7);
        		if (!dr.IsDBNull(8)) model.DPassword = dr.GetString(8);
        		if (!dr.IsDBNull(9)) model.DPasswordCreateTime = dr.GetDateTime(9);
        		if (!dr.IsDBNull(10)) model.IsOnline = dr.GetInt32(10);
        		if (!dr.IsDBNull(11)) model.LastOnlineTime = dr.GetDateTime(11);
        		if (!dr.IsDBNull(12)) model.Status = dr.GetInt32(12);
        		if (!dr.IsDBNull(13)) model.CreateTime = dr.GetDateTime(13);
        		if (!dr.IsDBNull(14)) model.LastTime = dr.GetDateTime(14);
        		if (!dr.IsDBNull(15)) model.IsVerifyMobile = dr.GetInt32(15);
        		if (!dr.IsDBNull(16)) model.Remark = dr.GetString(16);
        		if (!dr.IsDBNull(17)) model.RevokeRate = dr.GetInt32(17);
        		if (!dr.IsDBNull(18)) model.FinishAvg = dr.GetInt32(18);
        		if (!dr.IsDBNull(19)) model.IsDailian = dr.GetBoolean(19);
        		if (!dr.IsDBNull(20)) model.OnlineDuration = dr.GetInt32(20);
        		if (!dr.IsDBNull(21)) model.Avatar = dr.GetString(21);
        		if (!dr.IsDBNull(22)) model.PayPassword = dr.GetString(22);
        		if (!dr.IsDBNull(23)) model.CashPassword = dr.GetString(23);
        		if (!dr.IsDBNull(24)) model.PostRate = dr.GetInt32(24);
        		if (!dr.IsDBNull(25)) model.ReceiveRate = dr.GetInt32(25);
        	}
        }

        protected void LoadFromReader1(IDataReader dr,Os.Brain.iBxg.Core.Entity.Users model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
                model.Id = (int)dr["Id"];
                model.NumberId = dr["NumberId"].ToString();
                model.LetterId = dr["LetterId"].ToString();
                model.MobileId = dr["MobileId"].ToString();
                model.EmailId = dr["EmailId"].ToString();
                model.Password = dr["Password"].ToString();
                model.Nick = dr["Nick"].ToString();
                model.QQ = dr["QQ"].ToString();
                model.DPassword = dr["DPassword"].ToString();
                if (DBNull.Value != dr["DPasswordCreateTime"])
					{
						model.DPasswordCreateTime = (DateTime)dr["DPasswordCreateTime"];
					}

                if (DBNull.Value != dr["IsOnline"])
					{
						model.IsOnline = (int)dr["IsOnline"];
					}

                if (DBNull.Value != dr["LastOnlineTime"])
					{
						model.LastOnlineTime = (DateTime)dr["LastOnlineTime"];
					}

                if (DBNull.Value != dr["Status"])
					{
						model.Status = (int)dr["Status"];
					}

                if (DBNull.Value != dr["CreateTime"])
					{
						model.CreateTime = (DateTime)dr["CreateTime"];
					}

                if (DBNull.Value != dr["LastTime"])
					{
						model.LastTime = (DateTime)dr["LastTime"];
					}

                if (DBNull.Value != dr["IsVerifyMobile"])
					{
						model.IsVerifyMobile = (int)dr["IsVerifyMobile"];
					}

                model.Remark = dr["Remark"].ToString();
                if (DBNull.Value != dr["RevokeRate"])
					{
						model.RevokeRate = (int)dr["RevokeRate"];
					}

                if (DBNull.Value != dr["FinishAvg"])
					{
						model.FinishAvg = (int)dr["FinishAvg"];
					}

                model.IsDailian = (bool)dr["IsDailian"];
                model.OnlineDuration = (int)dr["OnlineDuration"];
                model.Avatar = dr["Avatar"].ToString();
                model.PayPassword = dr["PayPassword"].ToString();
                model.CashPassword = dr["CashPassword"].ToString();
                if (DBNull.Value != dr["PostRate"])
					{
						model.PostRate = (int)dr["PostRate"];
					}

                if (DBNull.Value != dr["ReceiveRate"])
					{
						model.ReceiveRate = (int)dr["ReceiveRate"];
					}

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
    /// Users 业务逻辑层
    /// </summary>
    public partial class Users
    {
        /// <summary>
        /// dal 获取接口 IUsers
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.IUsers dal=DalFactory.CreateUsers();

        /// <summary>
        /// Initializes a new instance of the <see cref="Users"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public Users(Os.Brain.Data.DataActions action)
        {
            this.dal.Action=action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
		public object Edit(Os.Brain.iBxg.Core.Entity.Users model)
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
		public Os.Brain.iBxg.Core.Entity.Users Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
		public IList<Os.Brain.iBxg.Core.Entity.Users> GetList(DbParameter[] dataParams)
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
		public IList<Os.Brain.iBxg.Core.Entity.Users> GetList(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
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
    /// Users 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateUsers 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.IUsers CreateUsers()
        {
            return new Os.Brain.iBxg.Core.Dal.Users();
        }
    }
}




