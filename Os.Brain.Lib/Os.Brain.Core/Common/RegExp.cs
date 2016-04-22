//-----------------------------------------------------------------------
// <copyright file="RegExp.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Common Regular Expression
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// RegExp 正则匹配字符串
    /// </summary>
    public class RegExp
    {
        #region Mothed

        #region Tel Mobile Phone

        /// <summary>
        /// String Is Fixed Telephone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number</returns>
        public static bool IsTel(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Tel);
        }

        /// <summary>
        /// String Is Fixed Telephone Number List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number List</returns>
        public static bool IsTels(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Tels);
        }

        /// <summary>
        /// String Is Fixed Telephone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <param name="separator">separator char</param>
        /// <returns>returns String Is Fixed Telephone Number List</returns>
        public static bool IsTels(string str, params char[] separator)
        {
            string temp = string.Empty;
            foreach (char c in separator)
            {
                temp += @"|\" + c.ToString();
            }

            return Regex.IsMatch(Regex.Replace(str, temp.TrimStart('|'), ","), Resx.Regexs.Tels);
        }

        /// <summary>
        /// String Is A Legal Mobile Phone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is A Legal Mobile Phone Number</returns>
        public static bool IsMobile(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Mobile);
        }

        /// <summary>
        /// String Is A Legal Mobile Phone Number List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is A Legal Mobile Phone Number</returns>
        public static bool IsMobiles(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Mobiles);
        }

        /// <summary>
        /// String Is A Legal Mobile Phone Number List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <param name="separator">separator char</param>
        /// <returns>returns String Is A Legal Mobile Phone Number</returns>
        public static bool IsMobiles(string str, params char[] separator)
        {
            string temp = string.Empty;
            foreach (char c in separator)
            {
                temp += @"|\" + c.ToString();
            }

            return Regex.IsMatch(Regex.Replace(str, temp.TrimStart('|'), ","), Resx.Regexs.Mobiles);
        }

        /// <summary>
        /// String Is Fixed Telephone Number Or A Legal Mobile Phone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number Or A Legal Mobile Phone Number</returns>
        public static bool IsPhone(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Phone);
        }

        /// <summary>
        /// String Is Fixed Telephone Number Or Legal Mobile Phone Number List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Fixed Telephone Number Or Legal Mobile Phone Number List</returns>
        public static bool IsPhones(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Phones);
        }

        /// <summary>
        /// String Is Fixed Telephone Number Or Legal Mobile Phone Number List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <param name="separator">separator char</param>
        /// <returns>returns String Is Fixed Telephone Number Or Legal Mobile Phone Number List</returns>
        public static bool IsPhones(string str, params char[] separator)
        {
            string temp = string.Empty;
            foreach (char c in separator)
            {
                temp += @"|\" + c.ToString();
            }

            return Regex.IsMatch(Regex.Replace(str, temp.TrimStart('|'), ","), Resx.Regexs.Phones);
        }

        #endregion

        #region Date Time

        /// <summary>
        /// String Is Date Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Date Type</returns>
        public static bool IsDate(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Date);
        }

        /// <summary>
        /// String Is Time Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Time Type</returns>
        public static bool IsTime(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Time);
        }

        /// <summary>
        /// String Is DateTime Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is DateTime Type</returns>
        public static bool IsDateTime(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.DateTime);
        }

        #endregion

        #region Number

        /// <summary>
        /// String Is Int Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Int Type</returns>
        public static bool IsInt(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Int);
        }

        /// <summary>
        /// String Is Float Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Float Type</returns>
        public static bool IsFloat(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Float);
        }

        /// <summary>
        /// String Is Money Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Money Type</returns>
        public static bool IsMoney(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Money);
        }

        /// <summary>
        /// String Is Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Number</returns>
        public static bool IsNumber(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Number);
        }

        #endregion

        #region Email Url Ip Zone Idcard

        /// <summary>
        ///  String Is Legal  Email Address
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Legal  Email Address</returns>
        public static bool IsEmail(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Email, RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///  String Is Legal  Email Address List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Legal  Email Address List</returns>
        public static bool IsEmails(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Emails, RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///  String Is Legal  Email Address List
        /// </summary>
        /// <param name="str">Check String</param>
        /// <param name="separator">separator char</param>
        /// <returns>returns String Is Legal  Email Address List</returns>
        public static bool isEmails(string str, params char[] separator)
        {
            string temp = string.Empty;
            foreach (char c in separator)
            {
                temp += @"|\" + c.ToString();
            }

            return Regex.IsMatch(Regex.Replace(str, temp.TrimStart('|'), ","), Resx.Regexs.Emails, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// String Is Effect Url
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Effect Url</returns>
        public static bool IsUrl(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Url, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// String Is IP Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is IP Type</returns>
        public static bool IsIP(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.IP);
        }

        /// <summary>
        /// String is Zone Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String is Zone Number</returns>
        public static bool IsZone(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Zone);
        }

        /// <summary>
        /// String is User IdCard
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String is User IdCard</returns>
        public static bool IsIdcard(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Idcard);
        }

        #endregion

        #region String

        /// <summary>
        /// String is Blank Words
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String is Blank Words</returns>
        public static bool IsBlank(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Blank);
        }

        /// <summary>
        /// String is Effect Color Number
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String Is Effect Color Number</returns>
        public static bool IsColor(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Color, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// String is String
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String is String</returns>
        public static bool IsABC(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.ABC, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// String is Image Files
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String is Image Files</returns>
        public static bool IsImg(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Img);
        }

        /// <summary>
        /// String is Effect Marks
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns string is Effect Marks</returns>
        public static bool IsMark(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.Mark, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// String is List Type
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns String is List Type</returns>
        public static bool IsList(string str)
        {
            return Regex.IsMatch(str, Resx.Regexs.List);
        }

        /// <summary>
        /// String is Script
        /// </summary>
        /// <param name="str">Check String</param>
        /// <returns>returns string is Script</returns>
        public static bool IsScript(string str)
        {
            return Regex.IsMatch(str, "^" + Resx.Regexs.Script + "$");
        }

        #endregion

        #region Strip

        /// <summary>
        /// Strip Tags
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>returns Strip Tags</returns>
        public static string StripTags(string str)
        {
            return Regex.Replace(str, Resx.Regexs.Tags, string.Empty);
        }

        /// <summary>
        /// Strip HTML Tags
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>returns Strip HTML Tags</returns>
        public static string StripHTML(string str)
        {
            return Regex.Replace(str, Resx.Regexs.Tags, string.Empty).Replace("&nbsp;", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);
        }

        /// <summary>
        /// Strip Script
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>returns Strip Script</returns>
        public static string StripScript(string str)
        {
            return Regex.Replace(str, Resx.Regexs.Script, string.Empty);
        }

        /// <summary>
        /// Strip Iframe
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>returns Strip Iframe</returns>
        public static string StripIframe(string str)
        {
            return Regex.Replace(str, Resx.Regexs.Iframe, string.Empty);
        }

        /// <summary>
        /// Strip Css
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>returns Strip Css</returns>
        public static string StripCss(string str)
        {
            return Regex.Replace(str, Resx.Regexs.Css, string.Empty);
        }

        #endregion

        #endregion
    }
}
