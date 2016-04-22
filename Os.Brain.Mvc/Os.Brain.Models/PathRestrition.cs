using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models
{
    public class PathRestrition<TKey> where TKey : IEquatable<TKey>
    {
        public virtual int Id { get; set; }

        public virtual TKey PathId { get; set; }

        public virtual string ACLType { get; set; }

    }
}
