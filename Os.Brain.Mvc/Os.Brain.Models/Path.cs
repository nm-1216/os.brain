//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Paths.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:49:33</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Path : Path<string>
    {
        public Path()
        {
            PathId = Guid.NewGuid().ToString();
        }        
    }

    /// <summary>
    /// Paths 实体类
    /// </summary>
    public partial class Path<TKey> where TKey : IEquatable<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets PathId 
        /// </summary>
        public TKey PathId { get; set; }


        /// <summary>
        /// Gets or sets ApplicationId 
        /// </summary>
        public TKey ApplicationId { get; set; }


        /// <summary>
        /// Gets or sets Path 
        /// </summary>
        [Column("Path")]
        public string _Path { get; set; }


        /// <summary>
        /// Gets or sets PathName 
        /// </summary>
        public string PathName { get; set; }


        /// <summary>
        /// Gets or sets PathCategory 
        /// </summary>
        public string PathCategory { get; set; }


        /// <summary>
        /// Gets or sets ParentId 
        /// </summary>
        public TKey ParentId { get; set; }

        #endregion

        #region

        [ForeignKey("ParentId")]
        public virtual ICollection<Path<TKey>> Child { get; } = new List<Path<TKey>>();

        public virtual ICollection<PathInRole<TKey>> Roles { get; } = new List<PathInRole<TKey>>();

        public virtual ICollection<PathRestrition<TKey>> PathRestritions { get; } = new List<PathRestrition<TKey>>();

        public virtual ICollection<PersonalizationPerUser<TKey>> Users { get; } = new List<PersonalizationPerUser<TKey>>();

        public virtual ICollection<Action<TKey>> Actions { get; } = new List<Action<TKey>>();

        #endregion
    }
}





