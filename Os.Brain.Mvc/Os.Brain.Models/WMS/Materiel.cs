using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    /// <summary>
    /// 物料表
    /// </summary>
    public class Materiel
    {
        public virtual int MaterielId { get; set; }

        public virtual string Name { get; set; }

        public virtual string MiniName { get; set; }

        public virtual string Discription { get; set; }

        /// <summary>
        /// 最小计量单位(Stock Keeping Unit)
        /// </summary>
        public virtual string SKU { get; set; }
    }
}
