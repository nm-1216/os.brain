//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="BankUser.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:23:04</datetime>
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
    /// BankUser 实体类
    /// </summary>
    public partial class BankUser:BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _userBank_Ids 自动编号
        /// </summary>
        private int _userBank_Ids;

        /// <summary>
        /// _userBank_UserId 用户编码
        /// </summary>
        private int _userBank_UserId;

        /// <summary>
        /// _userBank_UserName 用户名
        /// </summary>
        private string _userBank_UserName = string.Empty;

        /// <summary>
        /// _userBank_BankName 开户行
        /// </summary>
        private string _userBank_BankName = string.Empty;

        /// <summary>
        /// _userBank_Account 帐号
        /// </summary>
        private string _userBank_Account = string.Empty;

        /// <summary>
        /// _userBank_AddTime 添加时间
        /// </summary>
        private DateTime _userBank_AddTime =  DateTime.Now;

        /// <summary>
        /// _userBank_Filed1 备用1
        /// </summary>
        private string _userBank_Filed1 = string.Empty;

        /// <summary>
        /// _userBank_Filed2 备用2
        /// </summary>
        private string _userBank_Filed2 = string.Empty;

        /// <summary>
        /// _userBank_Filed3 备用3
        /// </summary>
        private string _userBank_Filed3 = string.Empty;

        /// <summary>
        /// _userBank_Filed4 备用4
        /// </summary>
        private string _userBank_Filed4 = string.Empty;

        /// <summary>
        /// _userBank_Filed5 备用5
        /// </summary>
        private string _userBank_Filed5 = string.Empty;

        /// <summary>
        /// _userBank_Filed6 备用6
        /// </summary>
        private string _userBank_Filed6 = string.Empty;

        /// <summary>
        /// _userBank_Filed7 备用7
        /// </summary>
        private string _userBank_Filed7 = string.Empty;

        /// <summary>
        /// _userBank_Filed8 备用8
        /// </summary>
        private string _userBank_Filed8 = string.Empty;

        /// <summary>
        /// _userBank_Filed9 备用9
        /// </summary>
        private string _userBank_Filed9 = string.Empty;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets UserBank_Ids 自动编号
        /// </summary>
        public int UserBank_Ids
        {
            get {return this._userBank_Ids;}
            set {this._userBank_Ids = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_UserId 用户编码
        /// </summary>
        public int UserBank_UserId
        {
            get {return this._userBank_UserId;}
            set {this._userBank_UserId = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_UserName 用户名
        /// </summary>
        public string UserBank_UserName
        {
            get {return this._userBank_UserName;}
            set {this._userBank_UserName = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_BankName 开户行
        /// </summary>
        public string UserBank_BankName
        {
            get {return this._userBank_BankName;}
            set {this._userBank_BankName = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Account 帐号
        /// </summary>
        public string UserBank_Account
        {
            get {return this._userBank_Account;}
            set {this._userBank_Account = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_AddTime 添加时间
        /// </summary>
        public DateTime UserBank_AddTime
        {
            get {return this._userBank_AddTime;}
            set {this._userBank_AddTime = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed1 备用1
        /// </summary>
        public string UserBank_Filed1
        {
            get {return this._userBank_Filed1;}
            set {this._userBank_Filed1 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed2 备用2
        /// </summary>
        public string UserBank_Filed2
        {
            get {return this._userBank_Filed2;}
            set {this._userBank_Filed2 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed3 备用3
        /// </summary>
        public string UserBank_Filed3
        {
            get {return this._userBank_Filed3;}
            set {this._userBank_Filed3 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed4 备用4
        /// </summary>
        public string UserBank_Filed4
        {
            get {return this._userBank_Filed4;}
            set {this._userBank_Filed4 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed5 备用5
        /// </summary>
        public string UserBank_Filed5
        {
            get {return this._userBank_Filed5;}
            set {this._userBank_Filed5 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed6 备用6
        /// </summary>
        public string UserBank_Filed6
        {
            get {return this._userBank_Filed6;}
            set {this._userBank_Filed6 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed7 备用7
        /// </summary>
        public string UserBank_Filed7
        {
            get {return this._userBank_Filed7;}
            set {this._userBank_Filed7 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed8 备用8
        /// </summary>
        public string UserBank_Filed8
        {
            get {return this._userBank_Filed8;}
            set {this._userBank_Filed8 = value;}
        }


        /// <summary>
        /// Gets or sets UserBank_Filed9 备用9
        /// </summary>
        public string UserBank_Filed9
        {
            get {return this._userBank_Filed9;}
            set {this._userBank_Filed9 = value;}
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankUser]", "[UserBank_UserId], [UserBank_UserName], [UserBank_BankName], [UserBank_Account], [UserBank_AddTime], [UserBank_Filed1], [UserBank_Filed2], [UserBank_Filed3], [UserBank_Filed4], [UserBank_Filed5], [UserBank_Filed6], [UserBank_Filed7], [UserBank_Filed8], [UserBank_Filed9]" , "@UserBank_UserId, @UserBank_UserName, @UserBank_BankName, @UserBank_Account, @UserBank_AddTime, @UserBank_Filed1, @UserBank_Filed2, @UserBank_Filed3, @UserBank_Filed4, @UserBank_Filed5, @UserBank_Filed6, @UserBank_Filed7, @UserBank_Filed8, @UserBank_Filed9"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion
            
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[BankUser]", "[UserBank_UserId], [UserBank_UserName], [UserBank_BankName], [UserBank_Account], [UserBank_AddTime], [UserBank_Filed1], [UserBank_Filed2], [UserBank_Filed3], [UserBank_Filed4], [UserBank_Filed5], [UserBank_Filed6], [UserBank_Filed7], [UserBank_Filed8], [UserBank_Filed9]" , "@UserBank_UserId, @UserBank_UserName, @UserBank_BankName, @UserBank_Account, @UserBank_AddTime, @UserBank_Filed1, @UserBank_Filed2, @UserBank_Filed3, @UserBank_Filed4, @UserBank_Filed5, @UserBank_Filed6, @UserBank_Filed7, @UserBank_Filed8, @UserBank_Filed9"));

            db.AddInParameter(dbc, "@UserBank_UserId", DbType.Int32, this.UserBank_UserId);
            db.AddInParameter(dbc, "@UserBank_UserName", DbType.AnsiString, this.UserBank_UserName);
            db.AddInParameter(dbc, "@UserBank_BankName", DbType.AnsiString, this.UserBank_BankName);
            db.AddInParameter(dbc, "@UserBank_Account", DbType.AnsiString, this.UserBank_Account);
            db.AddInParameter(dbc, "@UserBank_AddTime", DbType.DateTime, this.UserBank_AddTime);
            db.AddInParameter(dbc, "@UserBank_Filed1", DbType.AnsiString, this.UserBank_Filed1);
            db.AddInParameter(dbc, "@UserBank_Filed2", DbType.AnsiString, this.UserBank_Filed2);
            db.AddInParameter(dbc, "@UserBank_Filed3", DbType.AnsiString, this.UserBank_Filed3);
            db.AddInParameter(dbc, "@UserBank_Filed4", DbType.AnsiString, this.UserBank_Filed4);
            db.AddInParameter(dbc, "@UserBank_Filed5", DbType.AnsiString, this.UserBank_Filed5);
            db.AddInParameter(dbc, "@UserBank_Filed6", DbType.AnsiString, this.UserBank_Filed6);
            db.AddInParameter(dbc, "@UserBank_Filed7", DbType.AnsiString, this.UserBank_Filed7);
            db.AddInParameter(dbc, "@UserBank_Filed8", DbType.AnsiString, this.UserBank_Filed8);
            db.AddInParameter(dbc, "@UserBank_Filed9", DbType.AnsiString, this.UserBank_Filed9);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[BankUser]","[UserBank_UserId] = @UserBank_UserId, [UserBank_UserName] = @UserBank_UserName, [UserBank_BankName] = @UserBank_BankName, [UserBank_Account] = @UserBank_Account, [UserBank_AddTime] = @UserBank_AddTime, [UserBank_Filed1] = @UserBank_Filed1, [UserBank_Filed2] = @UserBank_Filed2, [UserBank_Filed3] = @UserBank_Filed3, [UserBank_Filed4] = @UserBank_Filed4, [UserBank_Filed5] = @UserBank_Filed5, [UserBank_Filed6] = @UserBank_Filed6, [UserBank_Filed7] = @UserBank_Filed7, [UserBank_Filed8] = @UserBank_Filed8, [UserBank_Filed9] = @UserBank_Filed9","UserBank_Ids"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[BankUser]","[UserBank_UserId] = @UserBank_UserId, [UserBank_UserName] = @UserBank_UserName, [UserBank_BankName] = @UserBank_BankName, [UserBank_Account] = @UserBank_Account, [UserBank_AddTime] = @UserBank_AddTime, [UserBank_Filed1] = @UserBank_Filed1, [UserBank_Filed2] = @UserBank_Filed2, [UserBank_Filed3] = @UserBank_Filed3, [UserBank_Filed4] = @UserBank_Filed4, [UserBank_Filed5] = @UserBank_Filed5, [UserBank_Filed6] = @UserBank_Filed6, [UserBank_Filed7] = @UserBank_Filed7, [UserBank_Filed8] = @UserBank_Filed8, [UserBank_Filed9] = @UserBank_Filed9","UserBank_Ids"));

            db.AddInParameter(dbc, "@UserBank_Ids", DbType.Int32, this.UserBank_Ids);
            db.AddInParameter(dbc, "@UserBank_UserId", DbType.Int32, this.UserBank_UserId);
            db.AddInParameter(dbc, "@UserBank_UserName", DbType.AnsiString, this.UserBank_UserName);
            db.AddInParameter(dbc, "@UserBank_BankName", DbType.AnsiString, this.UserBank_BankName);
            db.AddInParameter(dbc, "@UserBank_Account", DbType.AnsiString, this.UserBank_Account);
            db.AddInParameter(dbc, "@UserBank_AddTime", DbType.DateTime, this.UserBank_AddTime);
            db.AddInParameter(dbc, "@UserBank_Filed1", DbType.AnsiString, this.UserBank_Filed1);
            db.AddInParameter(dbc, "@UserBank_Filed2", DbType.AnsiString, this.UserBank_Filed2);
            db.AddInParameter(dbc, "@UserBank_Filed3", DbType.AnsiString, this.UserBank_Filed3);
            db.AddInParameter(dbc, "@UserBank_Filed4", DbType.AnsiString, this.UserBank_Filed4);
            db.AddInParameter(dbc, "@UserBank_Filed5", DbType.AnsiString, this.UserBank_Filed5);
            db.AddInParameter(dbc, "@UserBank_Filed6", DbType.AnsiString, this.UserBank_Filed6);
            db.AddInParameter(dbc, "@UserBank_Filed7", DbType.AnsiString, this.UserBank_Filed7);
            db.AddInParameter(dbc, "@UserBank_Filed8", DbType.AnsiString, this.UserBank_Filed8);
            db.AddInParameter(dbc, "@UserBank_Filed9", DbType.AnsiString, this.UserBank_Filed9);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankUser]", "[UserBank_Ids]" ,"@UserBank_Ids"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[BankUser]", "[UserBank_Ids]" ,"@UserBank_Ids"));

            db.AddInParameter(dbc, "@UserBank_Ids", DbType.Int32, this.UserBank_Ids);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// BankUser dal接口
    /// </summary>
    public interface IBankUser : IBasicDal<Os.Brain.iBxg.Core.Entity.BankUser>
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
    /// BankUser dal数据处理层
    /// </summary>
    public partial class BankUser:IBankUser
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
		public object Edit(Os.Brain.iBxg.Core.Entity.BankUser model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST,"[dbo].[BankUser]","[UserBank_Ids]","@UserBank_Ids"));            
            Debug.WriteLine("@UserBank_Ids="+"," + ids.Trim(',') + ",");            
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankUser.CONN);
            DbCommand dbc= db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST,"[dbo].[BankUser]","[UserBank_Ids]","@UserBank_Ids"));

            db.AddInParameter(dbc, "@UserBank_Ids", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
		public Os.Brain.iBxg.Core.Entity.BankUser GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM,"[dbo].[BankUser]","[UserBank_Ids]","@UserBank_Ids"));            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion
            
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.BankUser _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankUser.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM,"[dbo].[BankUser]","[UserBank_Ids]","@UserBank_Ids"));

            db.AddInParameter(dbc, "@UserBank_Ids", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankUser();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankUser> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankUser> returnList = new List<Os.Brain.iBxg.Core.Entity.BankUser>();
            Os.Brain.iBxg.Core.Entity.BankUser _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankUser.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankUser_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.BankUser();

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
        public IList<Os.Brain.iBxg.Core.Entity.BankUser> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.BankUser> returnList = new List<Os.Brain.iBxg.Core.Entity.BankUser>();
            Os.Brain.iBxg.Core.Entity.BankUser _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankUser.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankUser_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.BankUser();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankUser.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankUser_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankUser.CONN);
            DbCommand dbc = db.GetStoredProcCommand("BankUser_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[BankUser]", "UserBank_Ids", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.BankUser.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }            

            var ds=db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr,Os.Brain.iBxg.Core.Entity.BankUser model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
        		if (!dr.IsDBNull(0)) model.UserBank_Ids = dr.GetInt32(0);
        		if (!dr.IsDBNull(1)) model.UserBank_UserId = dr.GetInt32(1);
        		if (!dr.IsDBNull(2)) model.UserBank_UserName = dr.GetString(2);
        		if (!dr.IsDBNull(3)) model.UserBank_BankName = dr.GetString(3);
        		if (!dr.IsDBNull(4)) model.UserBank_Account = dr.GetString(4);
        		if (!dr.IsDBNull(5)) model.UserBank_AddTime = dr.GetDateTime(5);
        		if (!dr.IsDBNull(6)) model.UserBank_Filed1 = dr.GetString(6);
        		if (!dr.IsDBNull(7)) model.UserBank_Filed2 = dr.GetString(7);
        		if (!dr.IsDBNull(8)) model.UserBank_Filed3 = dr.GetString(8);
        		if (!dr.IsDBNull(9)) model.UserBank_Filed4 = dr.GetString(9);
        		if (!dr.IsDBNull(10)) model.UserBank_Filed5 = dr.GetString(10);
        		if (!dr.IsDBNull(11)) model.UserBank_Filed6 = dr.GetString(11);
        		if (!dr.IsDBNull(12)) model.UserBank_Filed7 = dr.GetString(12);
        		if (!dr.IsDBNull(13)) model.UserBank_Filed8 = dr.GetString(13);
        		if (!dr.IsDBNull(14)) model.UserBank_Filed9 = dr.GetString(14);
        	}
        }

        protected void LoadFromReader1(IDataReader dr,Os.Brain.iBxg.Core.Entity.BankUser model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
                model.UserBank_Ids = (int)dr["UserBank_Ids"];
                model.UserBank_UserId = (int)dr["UserBank_UserId"];
                model.UserBank_UserName = dr["UserBank_UserName"].ToString();
                model.UserBank_BankName = dr["UserBank_BankName"].ToString();
                model.UserBank_Account = dr["UserBank_Account"].ToString();
                model.UserBank_AddTime = (DateTime)dr["UserBank_AddTime"];
                model.UserBank_Filed1 = dr["UserBank_Filed1"].ToString();
                model.UserBank_Filed2 = dr["UserBank_Filed2"].ToString();
                model.UserBank_Filed3 = dr["UserBank_Filed3"].ToString();
                model.UserBank_Filed4 = dr["UserBank_Filed4"].ToString();
                model.UserBank_Filed5 = dr["UserBank_Filed5"].ToString();
                model.UserBank_Filed6 = dr["UserBank_Filed6"].ToString();
                model.UserBank_Filed7 = dr["UserBank_Filed7"].ToString();
                model.UserBank_Filed8 = dr["UserBank_Filed8"].ToString();
                model.UserBank_Filed9 = dr["UserBank_Filed9"].ToString();
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
    /// BankUser 业务逻辑层
    /// </summary>
    public partial class BankUser
    {
        /// <summary>
        /// dal 获取接口 IBankUser
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.IBankUser dal=DalFactory.CreateBankUser();

        /// <summary>
        /// Initializes a new instance of the <see cref="BankUser"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public BankUser(Os.Brain.Data.DataActions action)
        {
            this.dal.Action=action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
		public object Edit(Os.Brain.iBxg.Core.Entity.BankUser model)
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
		public Os.Brain.iBxg.Core.Entity.BankUser Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
		public IList<Os.Brain.iBxg.Core.Entity.BankUser> GetList(DbParameter[] dataParams)
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
		public IList<Os.Brain.iBxg.Core.Entity.BankUser> GetList(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
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
    /// BankUser 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateBankUser 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.IBankUser CreateBankUser()
        {
            return new Os.Brain.iBxg.Core.Dal.BankUser();
        }
    }
}




