using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models
{
    public class RoleRestrition<TKey> where TKey : IEquatable<TKey>
    {
        public virtual int Id { get; set; }

        public virtual TKey RoleId { get; set; }

        public virtual string ACLType { get; set; }

    }
}
