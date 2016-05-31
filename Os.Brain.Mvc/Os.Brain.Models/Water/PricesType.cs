//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PricesType.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2016/05/11 20:41:35</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;
    using System.Collections.Generic;    /// <summary>
                                         /// PricesType 实体类
                                         /// </summary>
    public partial class PricesType
    {
        #region Public Properties

        /// <summary>
        /// 自动编号
        /// </summary>
        public int ids { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }


        /// <summary>
        /// 是否启用
        /// </summary>
        public bool isUse { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime addTime { get; set; }

        public virtual ICollection<WaterPrices> WaterPrices { get; set; }
        #endregion

    }
}





