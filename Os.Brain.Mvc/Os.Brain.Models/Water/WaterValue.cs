//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="WaterValue.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2016/05/11 20:00:55</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{
    using System;

    /// <summary>
    /// WaterValue 实体类
    /// </summary>
    public partial class WaterValue
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Wv_User 
        /// </summary>
        public virtual string Wm_IdCard { get; set; }

        

        /// <summary>
        /// Gets or sets Wv_Year 
        /// </summary>
        public int Wv_Year { get; set; }


        /// <summary>
        /// Gets or sets Wv_Month 
        /// </summary>
        public virtual Month Wv_Month { get; set; }


        /// <summary>
        /// 价格
        /// </summary>
        public double Wv_Price { get; set; }


        /// <summary>
        /// 开始读数
        /// </summary>
        public int Wv_Start { get; set; }


        /// <summary>
        /// 结束读数 
        /// </summary>
        public int Wv_End { get; set; }

        /// <summary>
        /// 是否换表
        /// </summary>
        public int Wv_ExChange { get; set; }


        /// <summary>
        /// 老表开始时间
        /// </summary>
        public int Wv_OldStart { get; set; }

        /// <summary>
        /// 老表结束时间
        /// </summary>
        public int Wv_OldEnd { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public int Wv_Status { get; set; }


        /// <summary>
        /// 抄表时间
        /// </summary>
        public DateTime Wv_ReadTime { get; set; }


        /// <summary>
        /// 缴费时间
        /// </summary>
        public DateTime Wv_DoTime { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Wv_AddTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string Wv_AddUser { get; set; }


        /// <summary>
        /// 打印次数
        /// </summary>
        public int Wv_Prints { get; set; }

        #endregion

        public virtual WaterMeter WaterMeter { get; set; }
    }

    public enum Month
    { 
        m2=2,
        m4=4,
        m6=6,
        m8=8,
        m10=10,
        m12=12
    }
}





