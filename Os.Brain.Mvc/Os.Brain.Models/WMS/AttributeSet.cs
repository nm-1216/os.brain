using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    /// <summary>
    /// 属性分类
    /// </summary>
    public class AttributeSet : ClassBase
    {
        public virtual int AttributeSetID { get; set; }

        public virtual string Name { get; set; }

    }
}
