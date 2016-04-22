//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupsInRoles.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:57:19</datetime>
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
    /// GroupsInRoles 实体类
    /// </summary>
    public partial class GroupInRole<TKey> where TKey : IEquatable<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets GroupId 
        /// </summary>
        public TKey GroupId { get; set; }


        /// <summary>
        /// Gets or sets RoleId 
        /// </summary>
        public TKey RoleId { get; set; }

        #endregion
    }
}





