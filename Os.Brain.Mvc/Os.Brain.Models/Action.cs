//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Actions.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:53:56</datetime>
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
    /// Actions 实体类
    /// </summary>
    public partial class Action<TKey> where TKey : IEquatable<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets ActionId 
        /// </summary>
        public virtual TKey ActionId { get; set; }


        /// <summary>
        /// Gets or sets ActionName 
        /// </summary>
        public virtual string ActionName { get; set; }


        /// <summary>
        /// Gets or sets PathId 
        /// </summary>
        public virtual TKey PathId { get; set; }

        /// <summary>
        /// Gets or sets Description 
        /// </summary>
        public virtual string Description { get; set; }


        public virtual ICollection<ActionInRole<TKey>> Roles { get; } = new List<ActionInRole<TKey>>();


        #endregion
    }
}





