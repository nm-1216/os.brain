using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.TEST
{
    public class Product
    {
/// <summary>
        /// 产品ID
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<int> Quantity { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public Nullable<int> UnitsInStock { get; set; }

        /// <summary>
        /// 产品类别ID
        /// </summary>
        public Guid CategoryID { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public virtual Category Category { get; set; }

    }
}
