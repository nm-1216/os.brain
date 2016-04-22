using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Os.Brain.Data.MsSQL
{
    public partial class proc_common_GetRecord
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="QueryStr">表名、视图名、查询语句</param>
        /// <param name="FdName">表中的主键或表、临时表中的标识列名</param>
        /// <param name="FdShow">要显示的字段列表, 如果查询结果 有 标识字段,需要指定此值,且不包含标识字段</param>
        /// <param name="QueryWhere">查询条件</param>
        /// <param name="FdOrder">排序字段列表</param>
        /// <param name="PageSize">每页的大小(行数)</param>
        /// <param name="PageIndex">要显示的页</param>
        
        public proc_common_GetRecord(string QueryStr, string FdName, string FdShow, string QueryWhere, string FdOrder, int PageSize, int PageIndex)
        {
            this._querystr = QueryStr;
            this._querywhere = QueryWhere;
            this._fdname = FdName;
            this._fdorder = FdOrder;
            this._fdshow = FdShow;
            this._pageindex = PageIndex;
            this._pagesize = PageSize;

            if (string.IsNullOrEmpty(this._fdname) && string.IsNullOrEmpty(this._fdorder))
            {
                throw new ArgumentNullException("FdName,FdOrder", "FdName,FdOrde 不能同时为空");
            }

            init();
        }

        #region private property
        /// <summary>
        /// --表名、视图名、查询语句
        /// </summary>
        private string _querystr = string.Empty;

        /// <summary>
        /// --表中的主键或表、临时表中的标识列名
        /// </summary>
        private string _fdname = string.Empty;

        /// <summary>
        /// --要显示的字段列表, 如果查询结果 有 标识字段,需要指定此值,且不包含标识字段
        /// </summary>
        private string _fdshow = string.Empty;

        /// <summary>
        /// --查询条件
        /// </summary>
        private string _querywhere = string.Empty;

        /// <summary>
        /// --排序字段列表
        /// </summary>
        private string _fdorder = string.Empty;

        /// <summary>
        /// --每页的大小(行数)
        /// </summary>
        private int _pagesize = 20;

        /// <summary>
        /// --要显示的页
        /// </summary>
        private int _pageindex = 1;

        /// <summary>
        /// --是否返回总条数，0：返回列表、不返回总条数；1：返回列表、并返回总条数；0：-1返回总条数、不返回列表
        /// </summary>
        private bool _isgetcount = true;

        /// <summary>
        /// --总记录数
        /// </summary>
        private int _recordcount = 0;

        #endregion

        #region public property
        /// <summary>
        /// --表名、视图名、查询语句
        /// </summary>
        public string QueryStr
        {
            get { return _querystr; }
            //set { _querystr = value; }
        }

        /// <summary>
        /// --表中的主键或表、临时表中的标识列名
        /// </summary>
        public string FdName
        {
            get { return _fdname; }
            //set { _fdname = value; }
        }

        /// <summary>
        /// --要显示的字段列表, 如果查询结果 有 标识字段,需要指定此值,且不包含标识字段
        /// </summary>
        public string FdShow
        {
            get { return _fdshow; }
            //set { _fdshow = value; }
        }

        /// <summary>
        /// --查询条件
        /// </summary>
        public string QueryWhere
        {
            get { return _querywhere; }
            //set { _querywhere = value; }
        }

        /// <summary>
        /// --排序字段列表
        /// </summary>
        public string FdOrder
        {
            get { return _fdorder; }
            //set { _fdorder = value; }
        }

        /// <summary>
        /// --每页的大小(行数)
        /// </summary>
        public int PageSize
        {
            get { return _pagesize; }
            //set { _pagesize = value; }
        }

        /// <summary>
        /// --要显示的页
        /// </summary>
        public int PageIndex
        {
            get { return _pageindex; }
            //set { _pageindex = value; }
        }

        /// <summary>
        /// --是否返回总条数，0：返回列表、不返回总条数；1：返回列表、并返回总条数；0：-1返回总条数、不返回列表
        /// </summary>
        public bool IsGetCount
        {
            get { return _isgetcount; }
            //set { _isgetcount = value; }
        }

        /// <summary>
        /// --总记录数
        /// </summary>
        public int RecordCount
        {
            get { return _recordcount; }
            //set { _recordcount = value; }
        }

        #endregion

        private void init()
        {
            if (string.IsNullOrEmpty(this._fdshow))
                this._fdshow = "*";

            if (!string.IsNullOrEmpty(this._fdorder))
                this._fdorder = string.Format("ORDER BY {0}", this._fdorder.Trim());
            else
                this._fdorder = string.Format("ORDER BY {0} DESC", this._fdname.Trim());

            if (!string.IsNullOrEmpty(this._querywhere))
                this._querywhere = string.Format("WHERE {0}", this._querywhere.Trim());
        }

        public string TSQL_RecordCount
        {
            get
            {
                return string.Format("SELECT COUNT(*) RecordCount FROM {0} {1}", this._querystr, this._querywhere);
            }
        }

        public string TSQL_List
        {
            get
            {
                //init();

                if (this.PageIndex == 1)
                {
                    return string.Format("SELECT TOP {0} {1} FROM {2} {3} {4}", this._pagesize, this._fdshow, this._querystr, this._querywhere, this._fdorder);
                }
                else
                {
                    return string.Format("WITH tmpCTE AS(SELECT * FROM {0}),tmpCTE2 AS (SELECT ROW_NUMBER() OVER({1}) AS _ID,{2} FROM tmpCTE {3}) SELECT TOP {4} {2} FROM tmpCTE2 WHERE _ID >={5} ORDER BY _ID",
                        this._querystr,
                        this._fdorder,
                        this.FdShow,
                        this._querywhere,
                        this._pagesize,
                        
                        (this._pageindex - 1) * (this._pagesize + 1)
                        );
                }
            }
        }

        public string TSQL
        {
            get {
                return string.Format("{0};\r\n{1}", this.TSQL_RecordCount.Trim(), this.TSQL_List.Trim());
            }
        }
    }
}
