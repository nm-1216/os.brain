﻿//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="WaterPayment.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2016/05/11 21:12:38</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;

    /// <summary>
    /// WaterPayment 实体类
    /// </summary>
    public partial class LateFees
    {
        #region Public Properties

        /// <summary>
        /// 电表
        /// </summary>
        public string Wm_IdCard { get; set; }


        /// <summary>
        /// 年份
        /// </summary>
        public int Wv_Year { get; set; }


        /// <summary>
        /// 月份
        /// </summary>
        public int Wv_Month { get; set; }


        /// <summary>
        /// 金额
        /// </summary>
        public float prices { get; set; }


        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime  addTime { get; set; }


        /// <summary>
        /// 备注如果金额变动
        /// </summary>
        public string remark { get; set; }

        #endregion
    }
}




