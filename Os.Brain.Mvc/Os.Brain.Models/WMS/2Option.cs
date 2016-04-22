using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    public class Option : ClassBase
    {
        public virtual int AttributeOptionID { get; set; }

        public virtual string Value { get; set; }

        #region virtual

        public virtual ICollection<Attribute> Attributes { get; } = new List<Attribute>();
        #endregion
    }
}
