//-----------------------------------------------------------------------
// <copyright file="PageList.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>通用分页列表类</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// PageList 返回一个带分页的记录集
    /// </summary>
    /// <typeparam name="T">实体类型集 T</typeparam>
    public class PageList<T> : List<T>
    {
        /// <summary>
        /// Gets or sets 记录集条数
        /// </summary>
        public int RecordCount
        {
            get;
            set;
        }
    }
}
