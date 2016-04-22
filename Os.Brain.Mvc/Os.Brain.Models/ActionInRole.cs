//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionsInRoles.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:55:35</datetime>
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
    /// ActionsInRoles 实体类
    /// </summary>
    public partial class ActionInRole<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets ActionId 
        /// </summary>
        public TKey ActionId { get; set; }


        /// <summary>
        /// Gets or sets RoleId 
        /// </summary>
        public TKey RoleId { get; set; }

        #endregion
    }
}





