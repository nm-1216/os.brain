//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Groups.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:47:17</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Group : Group<string>
    {
        public Group()
        {
            this.GroupId = Guid.NewGuid().ToString();
        }

        public Group(string groupName,string description,string parentId):this()
        {
            this.GroupId = groupName;
            this.Description = description;
            this.ParentId = parentId;
        }
    }

    /// <summary>
    /// Groups 实体类
    /// </summary>
    public partial class Group<TKey> where TKey : IEquatable<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets GroupId 
        /// </summary>
        public virtual TKey GroupId { get; set; }

        /// <summary>
        /// Gets or sets GroupName 
        /// </summary>
        public virtual string GroupName { get; set; }
        
        /// <summary>
        /// Gets or sets Description 
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets ParentId 
        /// </summary>
        public virtual TKey ParentId { get; set; }

        #endregion

        [ForeignKey("ParentId")]
        public virtual ICollection<Group<TKey>> Child { get; } = new List<Group<TKey>>();

        public virtual ICollection<UserInGroup<TKey>> Users { get; } = new List<UserInGroup<TKey>>();

        public virtual ICollection<GroupInRole<TKey>> Roles { get; } = new List<GroupInRole<TKey>>();

    }
}





