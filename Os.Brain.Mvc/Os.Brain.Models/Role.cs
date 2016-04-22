namespace Os.Brain.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System;

    public class Role : Role<string>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public Role(string roleName) : this()
        {
            Name = roleName;
        }
    }


    public class Role<TKey> : IdentityRole<TKey> where TKey : IEquatable<TKey>
    {
        public virtual ICollection<GroupInRole<TKey>> Groups { get; } = new List<GroupInRole<TKey>>();
        public virtual ICollection<PathInRole<TKey>> Paths { get; } = new List<PathInRole<TKey>>();
        public virtual ICollection<ActionInRole<TKey>> Actions { get; } = new List<ActionInRole<TKey>>();
        public virtual ICollection<RoleRestrition<TKey>> RoleRestritions { get; } = new List<RoleRestrition<TKey>>();
    }
}
