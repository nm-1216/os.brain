//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="SysInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/04/01 16:24:23</datetime>
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
    /// SysInfo 实体类
    /// </summary>
    public partial class SysInfo:BasicEntity
    {
        /// <summary>
        /// conn 数据连接对象
        /// </summary>
        public static readonly string CONN = "conn";

        #region Private Properties

        /// <summary>
        /// _sysInfo_Serial 自动编号
        /// </summary>
        private int _sysInfo_Serial;

        /// <summary>
        /// _sysInfo_Language 语言
        /// </summary>
        private int _sysInfo_Language = 1;

        /// <summary>
        /// _sysInfo_Valid 有效性（当前配置是否有效，0无效 1有效）
        /// </summary>
        private bool _sysInfo_Valid = false;

        /// <summary>
        /// _sysInfo_Field1 字段一 {网站名称}
        /// </summary>
        private string _sysInfo_Field1 = "";

        /// <summary>
        /// _sysInfo_Field2 字段二{网站关键字}
        /// </summary>
        private string _sysInfo_Field2 = "";

        /// <summary>
        /// _sysInfo_Field3 字段三{抽象企业简介}
        /// </summary>
        private string _sysInfo_Field3 = "";

        /// <summary>
        /// _sysInfo_Field4 字段四{企业简介}
        /// </summary>
        private string _sysInfo_Field4 = "";

        /// <summary>
        /// _sysInfo_Field5 字段五{联系我们}
        /// </summary>
        private string _sysInfo_Field5 = "";

        /// <summary>
        /// _sysInfo_Field6 字段六
        /// </summary>
        private string _sysInfo_Field6 = "";

        /// <summary>
        /// _sysInfo_Field7 字段七
        /// </summary>
        private string _sysInfo_Field7 = "";

        /// <summary>
        /// _sysInfo_Field8 字段八
        /// </summary>
        private string _sysInfo_Field8 = "";

        /// <summary>
        /// _sysInfo_Field9 字段九
        /// </summary>
        private string _sysInfo_Field9 = "";

        /// <summary>
        /// _sysInfo_Field10 字段十
        /// </summary>
        private string _sysInfo_Field10 = "";
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets SysInfo_Serial 自动编号
        /// </summary>
        public int SysInfo_Serial
        {
            get {return this._sysInfo_Serial;}
            set {this._sysInfo_Serial = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Language 语言
        /// </summary>
        public int SysInfo_Language
        {
            get {return this._sysInfo_Language;}
            set {this._sysInfo_Language = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Valid 有效性（当前配置是否有效，0无效 1有效）
        /// </summary>
        public bool SysInfo_Valid
        {
            get {return this._sysInfo_Valid;}
            set {this._sysInfo_Valid = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field1 字段一 {网站名称}
        /// </summary>
        public string SysInfo_Field1
        {
            get {return this._sysInfo_Field1;}
            set {this._sysInfo_Field1 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field2 字段二{网站关键字}
        /// </summary>
        public string SysInfo_Field2
        {
            get {return this._sysInfo_Field2;}
            set {this._sysInfo_Field2 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field3 字段三{抽象企业简介}
        /// </summary>
        public string SysInfo_Field3
        {
            get {return this._sysInfo_Field3;}
            set {this._sysInfo_Field3 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field4 字段四{企业简介}
        /// </summary>
        public string SysInfo_Field4
        {
            get {return this._sysInfo_Field4;}
            set {this._sysInfo_Field4 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field5 字段五{联系我们}
        /// </summary>
        public string SysInfo_Field5
        {
            get {return this._sysInfo_Field5;}
            set {this._sysInfo_Field5 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field6 字段六
        /// </summary>
        public string SysInfo_Field6
        {
            get {return this._sysInfo_Field6;}
            set {this._sysInfo_Field6 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field7 字段七
        /// </summary>
        public string SysInfo_Field7
        {
            get {return this._sysInfo_Field7;}
            set {this._sysInfo_Field7 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field8 字段八
        /// </summary>
        public string SysInfo_Field8
        {
            get {return this._sysInfo_Field8;}
            set {this._sysInfo_Field8 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field9 字段九
        /// </summary>
        public string SysInfo_Field9
        {
            get {return this._sysInfo_Field9;}
            set {this._sysInfo_Field9 = value;}
        }


        /// <summary>
        /// Gets or sets SysInfo_Field10 字段十
        /// </summary>
        public string SysInfo_Field10
        {
            get {return this._sysInfo_Field10;}
            set {this._sysInfo_Field10 = value;}
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
            Debug.WriteLine(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[SysInfo]", "[SysInfo_Language], [SysInfo_Valid], [SysInfo_Field1], [SysInfo_Field2], [SysInfo_Field3], [SysInfo_Field4], [SysInfo_Field5], [SysInfo_Field6], [SysInfo_Field7], [SysInfo_Field8], [SysInfo_Field9], [SysInfo_Field10]" , "@SysInfo_Language, @SysInfo_Valid, @SysInfo_Field1, @SysInfo_Field2, @SysInfo_Field3, @SysInfo_Field4, @SysInfo_Field5, @SysInfo_Field6, @SysInfo_Field7, @SysInfo_Field8, @SysInfo_Field9, @SysInfo_Field10"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Insert END"));
            #endregion
            
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.INSERT_VALUE_IDENTITY, "[dbo].[SysInfo]", "[SysInfo_Language], [SysInfo_Valid], [SysInfo_Field1], [SysInfo_Field2], [SysInfo_Field3], [SysInfo_Field4], [SysInfo_Field5], [SysInfo_Field6], [SysInfo_Field7], [SysInfo_Field8], [SysInfo_Field9], [SysInfo_Field10]" , "@SysInfo_Language, @SysInfo_Valid, @SysInfo_Field1, @SysInfo_Field2, @SysInfo_Field3, @SysInfo_Field4, @SysInfo_Field5, @SysInfo_Field6, @SysInfo_Field7, @SysInfo_Field8, @SysInfo_Field9, @SysInfo_Field10"));

            db.AddInParameter(dbc, "@SysInfo_Language", DbType.Int32, this.SysInfo_Language);
            db.AddInParameter(dbc, "@SysInfo_Valid", DbType.Boolean, this.SysInfo_Valid);
            db.AddInParameter(dbc, "@SysInfo_Field1", DbType.String, this.SysInfo_Field1);
            db.AddInParameter(dbc, "@SysInfo_Field2", DbType.String, this.SysInfo_Field2);
            db.AddInParameter(dbc, "@SysInfo_Field3", DbType.String, this.SysInfo_Field3);
            db.AddInParameter(dbc, "@SysInfo_Field4", DbType.String, this.SysInfo_Field4);
            db.AddInParameter(dbc, "@SysInfo_Field5", DbType.String, this.SysInfo_Field5);
            db.AddInParameter(dbc, "@SysInfo_Field6", DbType.String, this.SysInfo_Field6);
            db.AddInParameter(dbc, "@SysInfo_Field7", DbType.String, this.SysInfo_Field7);
            db.AddInParameter(dbc, "@SysInfo_Field8", DbType.String, this.SysInfo_Field8);
            db.AddInParameter(dbc, "@SysInfo_Field9", DbType.String, this.SysInfo_Field9);
            db.AddInParameter(dbc, "@SysInfo_Field10", DbType.String, this.SysInfo_Field10);

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
            Debug.WriteLine(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[SysInfo]","[SysInfo_Language] = @SysInfo_Language, [SysInfo_Valid] = @SysInfo_Valid, [SysInfo_Field1] = @SysInfo_Field1, [SysInfo_Field2] = @SysInfo_Field2, [SysInfo_Field3] = @SysInfo_Field3, [SysInfo_Field4] = @SysInfo_Field4, [SysInfo_Field5] = @SysInfo_Field5, [SysInfo_Field6] = @SysInfo_Field6, [SysInfo_Field7] = @SysInfo_Field7, [SysInfo_Field8] = @SysInfo_Field8, [SysInfo_Field9] = @SysInfo_Field9, [SysInfo_Field10] = @SysInfo_Field10","SysInfo_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Update END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;
            
            dbc = db.GetSqlStringCommand(string.Format(TSQL.UPDATE_MORE_FIELD_IDENTITY,"[dbo].[SysInfo]","[SysInfo_Language] = @SysInfo_Language, [SysInfo_Valid] = @SysInfo_Valid, [SysInfo_Field1] = @SysInfo_Field1, [SysInfo_Field2] = @SysInfo_Field2, [SysInfo_Field3] = @SysInfo_Field3, [SysInfo_Field4] = @SysInfo_Field4, [SysInfo_Field5] = @SysInfo_Field5, [SysInfo_Field6] = @SysInfo_Field6, [SysInfo_Field7] = @SysInfo_Field7, [SysInfo_Field8] = @SysInfo_Field8, [SysInfo_Field9] = @SysInfo_Field9, [SysInfo_Field10] = @SysInfo_Field10","SysInfo_Serial"));

            db.AddInParameter(dbc, "@SysInfo_Serial", DbType.Int32, this.SysInfo_Serial);
            db.AddInParameter(dbc, "@SysInfo_Language", DbType.Int32, this.SysInfo_Language);
            db.AddInParameter(dbc, "@SysInfo_Valid", DbType.Boolean, this.SysInfo_Valid);
            db.AddInParameter(dbc, "@SysInfo_Field1", DbType.String, this.SysInfo_Field1);
            db.AddInParameter(dbc, "@SysInfo_Field2", DbType.String, this.SysInfo_Field2);
            db.AddInParameter(dbc, "@SysInfo_Field3", DbType.String, this.SysInfo_Field3);
            db.AddInParameter(dbc, "@SysInfo_Field4", DbType.String, this.SysInfo_Field4);
            db.AddInParameter(dbc, "@SysInfo_Field5", DbType.String, this.SysInfo_Field5);
            db.AddInParameter(dbc, "@SysInfo_Field6", DbType.String, this.SysInfo_Field6);
            db.AddInParameter(dbc, "@SysInfo_Field7", DbType.String, this.SysInfo_Field7);
            db.AddInParameter(dbc, "@SysInfo_Field8", DbType.String, this.SysInfo_Field8);
            db.AddInParameter(dbc, "@SysInfo_Field9", DbType.String, this.SysInfo_Field9);
            db.AddInParameter(dbc, "@SysInfo_Field10", DbType.String, this.SysInfo_Field10);

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
            Debug.WriteLine(string.Format(TSQL.DELETE_ITEM, "[dbo].[SysInfo]", "[SysInfo_Serial]" ,"@SysInfo_Serial"));
            Debug.WriteLine(this.ToString());
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Entity.Delete END"));
            #endregion
        
            Database db = DatabaseFactory.CreateDatabase(CONN);
            DbCommand dbc;

            dbc = db.GetSqlStringCommand(string.Format(TSQL.DELETE_ITEM, "[dbo].[SysInfo]", "[SysInfo_Serial]" ,"@SysInfo_Serial"));

            db.AddInParameter(dbc, "@SysInfo_Serial", DbType.Int32, this.SysInfo_Serial);

            return db.ExecuteNonQuery(dbc);
        }
        #endregion
    }
}
namespace Os.Brain.iBxg.Core.Dal
{
    using Os.Brain.Data.Dal;

    /// <summary>
    /// SysInfo dal接口
    /// </summary>
    public interface ISysInfo : IBasicDal<Os.Brain.iBxg.Core.Entity.SysInfo>
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
    /// SysInfo dal数据处理层
    /// </summary>
    public partial class SysInfo:ISysInfo
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
		public object Edit(Os.Brain.iBxg.Core.Entity.SysInfo model)
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
            Debug.WriteLine(string.Format(TSQL.DELETE_LIST,"[dbo].[SysInfo]","[SysInfo_Serial]","@SysInfo_Serial"));            
            Debug.WriteLine("@SysInfo_Serial="+"," + ids.Trim(',') + ",");            
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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.SysInfo.CONN);
            DbCommand dbc= db.GetSqlStringCommand(string.Format(TSQL.DELETE_LIST,"[dbo].[SysInfo]","[SysInfo_Serial]","@SysInfo_Serial"));

            db.AddInParameter(dbc, "@SysInfo_Serial", DbType.String, "," + ids.Trim(',') + ",");

            return db.ExecuteNonQuery(dbc);
        }

        /// <summary>
        /// GetItem 获取单个实体
        /// </summary>
        /// <param name="ids">ids 主键值</param>
        /// <returns>返回 空或实体</returns>
		public Os.Brain.iBxg.Core.Entity.SysInfo GetItem(string ids)
        {
            #region DEBUG
            Debug.WriteLine(string.Format(TSQL.DEBUG_START_LINE,"Os.Brain.iBxg.Core.Dal.GetItem START"));
            Debug.WriteLine(string.Format(TSQL.SELECT_ITEM,"[dbo].[SysInfo]","[SysInfo_Serial]","@SysInfo_Serial"));            
            Debug.WriteLine(string.Format(TSQL.DEBUG_END_LINE,"Os.Brain.iBxg.Core.Dal.GetItem END"));
            #endregion
            
            if (DataActions.select != this.Action)
            {
                return null;
            }

            Os.Brain.iBxg.Core.Entity.SysInfo _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.SysInfo.CONN);
            DbCommand dbc = db.GetSqlStringCommand(string.Format(TSQL.SELECT_ITEM,"[dbo].[SysInfo]","[SysInfo_Serial]","@SysInfo_Serial"));

            db.AddInParameter(dbc, "@SysInfo_Serial", DbType.Int32, ids);

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                if (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.SysInfo();

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
        public IList<Os.Brain.iBxg.Core.Entity.SysInfo> GetList(params DbParameter[] dataParams)
        {
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.SysInfo> returnList = new List<Os.Brain.iBxg.Core.Entity.SysInfo>();
            Os.Brain.iBxg.Core.Entity.SysInfo _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.SysInfo.CONN);
            DbCommand dbc = db.GetStoredProcCommand("SysInfo_Get");

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }

            using (IDataReader dr = db.ExecuteReader(dbc))
            {
                while (dr.Read())
                {
                    _model = new Os.Brain.iBxg.Core.Entity.SysInfo();

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
        public IList<Os.Brain.iBxg.Core.Entity.SysInfo> GetList(int pageSize, int currPage, out int recordCount, params DbParameter[] dataParams)
        {
            recordCount=0;
            if (DataActions.select != this.Action)
            {
                return null;
            }

            IList<Os.Brain.iBxg.Core.Entity.SysInfo> returnList = new List<Os.Brain.iBxg.Core.Entity.SysInfo>();
            Os.Brain.iBxg.Core.Entity.SysInfo _model = null;

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.SysInfo.CONN);
            DbCommand dbc = db.GetStoredProcCommand("SysInfo_Get");

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
                    _model = new Os.Brain.iBxg.Core.Entity.SysInfo();

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.SysInfo.CONN);
            DbCommand dbc = db.GetStoredProcCommand("SysInfo_Get");

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

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.SysInfo.CONN);
            DbCommand dbc = db.GetStoredProcCommand("SysInfo_Get");

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

            proc_common_GetRecord pcg = new proc_common_GetRecord("[dbo].[SysInfo]", "SysInfo_Serial", "*", strWhere, string.Empty, pageSize, currPage);

            Database db = DatabaseFactory.CreateDatabase(Os.Brain.iBxg.Core.Entity.SysInfo.CONN);
            DbCommand dbc = db.GetSqlStringCommand(pcg.TSQL);

            if (null != dataParams)
            {
                dbc.Parameters.AddRange(dataParams);
            }            

            var ds=db.ExecuteDataSet(dbc);

            recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return ds;
        }

        protected void LoadFromReader(IDataReader dr,Os.Brain.iBxg.Core.Entity.SysInfo model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
        		if (!dr.IsDBNull(0)) model.SysInfo_Serial = dr.GetInt32(0);
        		if (!dr.IsDBNull(1)) model.SysInfo_Language = dr.GetInt32(1);
        		if (!dr.IsDBNull(2)) model.SysInfo_Valid = dr.GetBoolean(2);
        		if (!dr.IsDBNull(3)) model.SysInfo_Field1 = dr.GetString(3);
        		if (!dr.IsDBNull(4)) model.SysInfo_Field2 = dr.GetString(4);
        		if (!dr.IsDBNull(5)) model.SysInfo_Field3 = dr.GetString(5);
        		if (!dr.IsDBNull(6)) model.SysInfo_Field4 = dr.GetString(6);
        		if (!dr.IsDBNull(7)) model.SysInfo_Field5 = dr.GetString(7);
        		if (!dr.IsDBNull(8)) model.SysInfo_Field6 = dr.GetString(8);
        		if (!dr.IsDBNull(9)) model.SysInfo_Field7 = dr.GetString(9);
        		if (!dr.IsDBNull(10)) model.SysInfo_Field8 = dr.GetString(10);
        		if (!dr.IsDBNull(11)) model.SysInfo_Field9 = dr.GetString(11);
        		if (!dr.IsDBNull(12)) model.SysInfo_Field10 = dr.GetString(12);
        	}
        }

        protected void LoadFromReader1(IDataReader dr,Os.Brain.iBxg.Core.Entity.SysInfo model)
        {
        	if (dr != null && !dr.IsClosed)
        	{
                model.SysInfo_Serial = (int)dr["SysInfo_Serial"];
                model.SysInfo_Language = (int)dr["SysInfo_Language"];
                model.SysInfo_Valid = (bool)dr["SysInfo_Valid"];
                model.SysInfo_Field1 = dr["SysInfo_Field1"].ToString();
                model.SysInfo_Field2 = dr["SysInfo_Field2"].ToString();
                model.SysInfo_Field3 = dr["SysInfo_Field3"].ToString();
                model.SysInfo_Field4 = dr["SysInfo_Field4"].ToString();
                model.SysInfo_Field5 = dr["SysInfo_Field5"].ToString();
                model.SysInfo_Field6 = dr["SysInfo_Field6"].ToString();
                model.SysInfo_Field7 = dr["SysInfo_Field7"].ToString();
                model.SysInfo_Field8 = dr["SysInfo_Field8"].ToString();
                model.SysInfo_Field9 = dr["SysInfo_Field9"].ToString();
                model.SysInfo_Field10 = dr["SysInfo_Field10"].ToString();
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
    /// SysInfo 业务逻辑层
    /// </summary>
    public partial class SysInfo
    {
        /// <summary>
        /// dal 获取接口 ISysInfo
        /// </summary>
        private readonly Os.Brain.iBxg.Core.Dal.ISysInfo dal=DalFactory.CreateSysInfo();

        /// <summary>
        /// Initializes a new instance of the <see cref="SysInfo"/> class.
        /// </summary>
        /// <param name="action">action 操作符</param>
        public SysInfo(Os.Brain.Data.DataActions action)
        {
            this.dal.Action=action;
        }

        /// <summary>
        /// Edit 编辑（新增，修改）一条数据
        /// </summary>
        /// <param name="model">model 实体</param>
        /// <returns>returns 实体主键</returns>
		public object Edit(Os.Brain.iBxg.Core.Entity.SysInfo model)
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
		public Os.Brain.iBxg.Core.Entity.SysInfo Read(string ids)
        {
            return this.dal.GetItem(ids);
        }

        /// <summary>
        /// GetList 获取数据集
        /// </summary>
        /// <param name="dataParams">dataParams 查询参数</param>
        /// <returns>returns 数据集</returns>
		public IList<Os.Brain.iBxg.Core.Entity.SysInfo> GetList(DbParameter[] dataParams)
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
		public IList<Os.Brain.iBxg.Core.Entity.SysInfo> GetList(int pageSize, int currPage,out int recordCount, DbParameter[] dataParams)
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
    /// SysInfo 工厂
    /// </summary>
    public sealed partial class DalFactory
    {
        /// <summary>
        /// CreateSysInfo 工厂构造器
        /// </summary>
        /// <returns>返回 实体</returns>
        public static Os.Brain.iBxg.Core.Dal.ISysInfo CreateSysInfo()
        {
            return new Os.Brain.iBxg.Core.Dal.SysInfo();
        }
    }
}




