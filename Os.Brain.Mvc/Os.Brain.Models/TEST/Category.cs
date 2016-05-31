using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.TEST
{
    public class Category
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public Guid CategoryID { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

    }
}
