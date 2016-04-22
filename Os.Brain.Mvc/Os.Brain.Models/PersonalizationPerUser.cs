//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalizationPerUser.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:59:57</datetime>
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
    /// PersonalizationPerUser 实体类
    /// </summary>
    public partial class PersonalizationPerUser<TKey> where TKey : IEquatable<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets PathId 
        /// </summary>
        public virtual TKey PathId { get; set; }

        /// <summary>
        /// Gets or sets UserId 
        /// </summary>
        public virtual TKey UserId { get; set; }

        /// <summary>
        /// Gets or sets IsAllow 
        /// </summary>
        public virtual bool IsAllow { get; set; }

        #endregion
    }
}





