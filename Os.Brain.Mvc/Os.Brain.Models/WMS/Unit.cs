using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    /// <summary>
    /// 单位
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public virtual int UnitId { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public virtual string Name { get; set; }
    }
}
