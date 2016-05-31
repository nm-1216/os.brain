//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Prices.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2016/05/11 20:46:58</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;

    /// <summary>
    /// Prices 实体类
    /// </summary>
    public partial class WaterPrices
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Prices_Id 
        /// </summary>
        public int Prices_Id { get; set; }
        
        /// <summary>
        /// Gets or sets Prices_Value 
        /// </summary>
        public double Prices_Value { get; set; }
        
        /// <summary>
        /// Gets or sets Prices_Start 
        /// </summary>
        public int Prices_Start { get; set; }

        /// <summary>
        /// Gets or sets Prices_End 
        /// </summary>
        public int Prices_End { get; set; }


        /// <summary>
        /// Gets or sets Prices_AddTime 
        /// </summary>
        public DateTime Prices_AddTime { get; set; }


        public int ids { get; set; }

        #endregion

    }
}





