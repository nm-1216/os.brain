//-----------------------------------------------------------------------
// <copyright file="DataActions.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>数据操作行为</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Data
{
    using System;

    /// <summary>
    /// Data Action
    /// </summary>
    [Flags]
    public enum DataActions
    {
        /// <summary>
        /// Insert Data
        /// </summary>
        insert = 1,

        /// <summary>
        /// Update Data
        /// </summary>
        update = 2,

        /// <summary>
        /// Get Data
        /// </summary>
        select = 4,

        /// <summary>
        /// Delete Data
        /// </summary>
        delete = 8,

        /// <summary>
        /// Insert or update or select or delete
        /// </summary>
        all = insert | update | select | delete
    }
}
