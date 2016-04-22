//-----------------------------------------------------------------------
// <copyright file="Sex.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>GB2261 人的性别代码国家标准</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.GB
{
    /// <summary>
    /// GB2261 人的性别代码国家标准
    /// 0 - 未知的性别 1 - 男性 2 - 女性 5 - 女性改（变）为男性 6 - 男性改（变）为女性 9 - 未说明的性别
    /// </summary>
    public enum Sex : int
    {
        /// <summary>
        /// Unknown 未知的性别
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Man 男性
        /// </summary>
        Man = 1,

        /// <summary>
        /// Woman 女性
        /// </summary>
        Woman = 2,

        /// <summary>
        /// WomanToMan 女性改（变）为男性
        /// </summary>
        WomanToMan = 5,

        /// <summary>
        /// ManToWoman 男性改（变）为女性
        /// </summary>
        ManToWoman = 6,

        /// <summary>
        /// NoDiscription 未说明的性别
        /// </summary>
        NoDiscription = 9
    }
}
