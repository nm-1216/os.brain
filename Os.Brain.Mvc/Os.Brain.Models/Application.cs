//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Applications.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:42:33</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Application : Application<string>
    {
        public Application()
        {
            ApplicationId = Guid.NewGuid().ToString();
        }

        public Application(string applicationName, string description) : this()
        {
            this.ApplicationName = applicationName;
            this.Description = description;
        }
    }

    /// <summary>
    /// Applications 实体类
    /// </summary>
    public partial class Application<TKey> where TKey : IEquatable<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets ApplicationId 
        /// </summary>
        public virtual TKey ApplicationId { get; set; }


        /// <summary>
        /// Gets or sets ApplicationName 
        /// </summary>
        [Required]
        public virtual string ApplicationName { get; set; }


        /// <summary>
        /// Gets or sets Description 
        /// </summary>
        [Required]
        public virtual string Description { get; set; }


        public virtual int OrderBy { get; set; }
        #endregion

        #region virtual
        
        public virtual ICollection<Path<TKey>> Paths { get; } = new List<Path<TKey>>();
        #endregion
    }
}