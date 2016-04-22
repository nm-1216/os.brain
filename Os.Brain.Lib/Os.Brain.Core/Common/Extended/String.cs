//-----------------------------------------------------------------------
// <copyright file="String.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>字符串函数扩展</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common.Extended
{
    using Os.Brain.Common;

    /// <summary>
    /// String 字符串函数扩展
    /// </summary>
    public static class StringExt
    {
        #region Tel
        
        /// <summary>
        /// String Is Fixed Telephone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number</returns>
        public static bool IsTel(this string str)
        {
            return RegExp.IsTel(str);
        }

        /// <summary>
        /// String Is Fixed Telephone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number</returns>
        public static bool IsTels(this string str)
        {
            return RegExp.IsTels(str);
        }

        /// <summary>
        /// String Is Fixed Telephone List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <param name="separator">separator char</param>
        /// <returns>returns String Is Fixed Telephone List</returns>
        public static bool IsTels(this string str, params char[] separator)
        {
            return RegExp.IsTels(str, separator);
        }

        #endregion

        #region Mobile

        /// <summary>
        /// String Is A Legal Mobile Phone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is A Legal Mobile Phone Number</returns>
        public static bool IsMobile(this string str)
        {
            return RegExp.IsMobile(str);
        }

        /// <summary>
        /// String Is Legal Mobile Phone List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is A Legal Mobile Phone Number</returns>
        public static bool IsMobiles(this string str)
        {
            return RegExp.IsMobiles(str);
        }

        /// <summary>
        /// String Is Legal Mobile Phone List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <param name="separator">separator char</param>
        /// <returns>returns String Is A Legal Mobile Phone List</returns>
        public static bool IsMobiles(this string str, params char[] separator)
        {
            return RegExp.IsMobiles(str, separator);
        }

        #endregion

        #region Phone
        /// <summary>
        /// String Is Fixed Telephone Number Or A Legal Mobile Phone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number Or A Legal Mobile Phone Number</returns>
        public static bool IsPhone(this string str)
        {
            return RegExp.IsPhone(str);
        }

        /// <summary>
        /// String Is Fixed Telephone Number Or A Legal Mobile Phone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number Or A Legal Mobile Phone Number</returns>
        public static bool IsPhones(this string str)
        {
            return RegExp.IsPhones(str);
        }

        /// <summary>
        /// String Is Fixed Telephone Number Or A Legal Mobile Phone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <param name="separator">separator char</param>
        /// <returns>returns String Is Fixed Telephone Number Or A Legal Mobile Phone Number</returns>
        public static bool IsPhones(this string str, params char[] separator)
        {
            return RegExp.IsPhones(str, separator);
        }

        #endregion

        #region Date

        #endregion
    }
}
