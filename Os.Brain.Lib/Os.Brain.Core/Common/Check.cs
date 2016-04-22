//-----------------------------------------------------------------------
// <copyright file="Check.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>有效性检查</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Check 字符串有效醒校验
    /// </summary>
    public class Check
    {
        /// <summary>
        /// IsInLength 校验字符串对象是否在有效范围长度区间范围内
        /// </summary>
        /// <param name="str">str 字符串对象</param>
        /// <param name="min">min 最小长度</param>
        /// <param name="max">max 最大长度</param>
        /// <returns>返回 结果</returns>
        public static bool IsInLength(string str, int min, int max)
        {
            Algorithms.Swap(ref min, ref max, 0);

            return Regex.IsMatch(str, string.Format(@"^\w{2}{0},{1}{3}$", min, max, "{", "}"));
        }
    }
}
