//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PathsInRoles.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:58:42</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// PathsInRoles 实体类
    /// </summary>
    public partial class PathInRole<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets PathId 
        /// </summary>
        public virtual TKey PathId { get; set; }


        /// <summary>
        /// Gets or sets RoleId 
        /// </summary>
        public virtual TKey RoleId { get; set; }

        #endregion
    }
}





