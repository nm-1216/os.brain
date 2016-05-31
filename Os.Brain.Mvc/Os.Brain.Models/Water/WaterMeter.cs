//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="WaterMeter.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2016/05/11 20:14:27</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Os.Brain.Models
{

    /// <summary>
    /// WaterMeter 实体类
    /// </summary>
    public partial class WaterMeter
    {
        #region Public Properties

        /// <summary>
        /// 水费卡卡号(水表编号，户号)
        /// </summary>
        public string Wm_IdCard { get; set; }

        #region WaterUser
        /// <summary>
        /// 名称
        /// </summary>
        public string Wu_Name { get; set; }


        /// <summary>
        /// 地址 
        /// </summary>
        public string Wu_Address { get; set; }

        /// <summary>
        /// 村庄
        /// </summary>
        public string Wu_Village { get; set; }
        #endregion

        #region web
        /// <summary>
        /// Gets or sets User_LogName 
        /// </summary>
        public string Wm_LogName { get; set; }

        /// <summary>
        /// Gets or sets User_Weixin 
        /// </summary>
        public string Wm_Weixin { get; set; }

        /// <summary>
        /// Gets or sets User_Tel 
        /// </summary>
        public string Wm_Tel { get; set; }

        /// <summary>
        /// Gets or sets User_Pwd 
        /// </summary>
        public string Wm_Pwd { get; set; }
        #endregion

        /// <summary>
        /// 是否是集体表
        /// </summary>
        public bool isGroup { get; set; }

        /// <summary>
        /// 是否需要缴费
        /// </summary>
        public bool isNeedPay { get; set; }

        #endregion
    }
}





