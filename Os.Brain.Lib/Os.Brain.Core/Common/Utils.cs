//-----------------------------------------------------------------------
// <copyright file="Utils.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>公用方法</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;

    /// <summary>
    /// Utils 公用方法
    /// </summary>
    public class Utils
    {
        #region StrLen
        /// <summary>
        /// Get String Length
        /// </summary>
        /// <param name="str">Object string</param>
        /// <returns>Return String Length</returns>
        public static int StrLen(string str)
        {
            return Encoding.Default.GetByteCount(str);
        }
        #endregion

        #region Cut String

        /// <summary>
        /// Cut String
        /// </summary>
        /// <param name="str">Object String</param>
        /// <param name="length">Keep Length</param>
        /// <returns>Return Sub String</returns>
        public static string CutStr(string str, int length)
        {
            return CutStr(str, length, "...");
        }

        /// <summary>
        /// Cut String
        /// </summary>
        /// <param name="str">Object String</param>
        /// <param name="length">Keep Length</param>
        /// <param name="fix">fix 后缀</param>
        /// <returns>Return String</returns>
        public static string CutStr(string str, int length, string fix)
        {
            int byteLen = StrLen(str);
            int byteCount = 0;
            int pos = 0;
            if (byteLen > length * 2)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)
                    {
                        byteCount += 2;
                    }
                    else
                    {
                        byteCount++;
                    }

                    if (byteCount > length * 2)
                    {
                        pos = i;
                        break;
                    }
                }

                return str.Substring(0, pos) + fix;
            }
            else
            {
                return str;
            }
        }
        #endregion

        #region Sub String

        /// <summary>
        /// Sub String
        /// </summary>
        /// <param name="str">Object String</param>
        /// <param name="length">Keep Length</param>
        /// <returns>Return String</returns>
        public static string SubStr(string str, int length)
        {
            return SubStr(str, 0, length);
        }

        /// <summary>
        /// SubStr 从字符串的指定位置截取指定长度的子字符串【支持负方向】
        /// </summary>
        /// <param name="str">str 原字符串</param>
        /// <param name="indexStart">indexStart 子字符串的起始位置</param>
        /// <param name="length">length 子字符串的长度</param>
        /// <returns>返回 子字符串</returns>
        public static string SubStr(string str, int indexStart, int length)
        {
            int indexEnd = 0;
            if (indexStart < 0)
            {
                indexStart = (str.Length + indexStart) < 0 ? 0 : (str.Length + indexStart);
            }

            indexEnd = ((indexStart + length) > str.Length) ? str.Length : ((indexStart + length) < 0 ? 0 : (indexStart + length));
            return str.Substring(Math.Min(indexStart, indexEnd), Math.Abs(indexStart - indexEnd));
        }

        #endregion

        #region Array
        /// <summary>
        /// IsInArray 判断目标字符串是否在字符串中
        /// </summary>
        /// <param name="strSearch">搜索 字符串</param>
        /// <param name="strArr">目标 字符串</param>
        /// <returns>返回 是否存在</returns>
        public static bool IsInArray(string strSearch, string strArr)
        {
            return GetIndexInArray(strSearch, strArr.Split(','), false) >= 0;
        }

        /// <summary>
        /// IsInArray 判断目标字符串是否在字符串中
        /// </summary>
        /// <param name="strSearch">搜索 字符串</param>
        /// <param name="strArr">目标 字符串</param>
        /// <param name="seprator">seprator 分割符号</param>
        /// <returns>返回 是否存在</returns>
        public static bool IsInArray(string strSearch, string strArr, params char[] seprator)
        {
            return GetIndexInArray(strSearch, strArr.Split(seprator), false) >= 0;
        }

        /// <summary>
        /// IsInArray 判断目标字符串是否在字符串中
        /// </summary>
        /// <param name="strSearch">搜索 字符串</param>
        /// <param name="strArr">目标 字符串</param>
        /// <param name="ignoreCase">是否 区分大小写</param>
        /// <returns>返回 是否存在</returns>
        public static bool IsInArray(string strSearch, string strArr, bool ignoreCase)
        {
            return GetIndexInArray(strSearch, strArr.Split(','), ignoreCase) >= 0;
        }

        /// <summary>
        /// IsInArray 判断目标字符串是否在字符串中
        /// </summary>
        /// <param name="strSearch">搜索 字符串</param>
        /// <param name="strArr">目标 字符串</param>
        /// <param name="ignoreCase">是否 区分大小写</param>
        /// <param name="seprator">seprator 分割符号</param>
        /// <returns>返回 是否存在</returns>
        public static bool IsInArray(string strSearch, string strArr, bool ignoreCase, params char[] seprator)
        {
            return GetIndexInArray(strSearch, strArr.Split(seprator), ignoreCase) >= 0;
        }

        /// <summary>
        /// IsInArray 判断目标字符串是否在字符串中
        /// </summary>
        /// <param name="strSearch">搜索 字符串</param>
        /// <param name="strArr">目标 字符串</param>
        /// <returns>返回 是否存在</returns>
        public static bool IsInArray(string strSearch, string[] strArr)
        {
            return GetIndexInArray(strSearch, strArr, false) >= 0;
        }

        /// <summary>
        /// IsInArray 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">strSearch 字符串</param>
        /// <param name="strArr">strArr 字符串数组</param>
        /// <param name="ignoreCase">IgnoreCase 是否忽略大小写, true为不区分, false为区分</param>
        /// <returns>返回 判断结果</returns>
        public static bool IsInArray(string strSearch, string[] strArr, bool ignoreCase)
        {
            return GetIndexInArray(strSearch, strArr, ignoreCase) >= 0;
        }

        /// <summary>
        /// GetIndexInArray 获取目标字符串的索引位置
        /// </summary>
        /// <param name="strSearch">搜索 字符串</param>
        /// <param name="strArr">目标 字符串</param>
        /// <returns>返回 索引位置</returns>
        public static int GetIndexInArray(string strSearch, string[] strArr)
        {
            return GetIndexInArray(strSearch, strArr, true);
        }

        /// <summary>
        /// GetIndexInArray 获取指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">搜索 字符串</param>
        /// <param name="strArr">目标 字符串</param>
        /// <param name="ignoreCase">IgnoreCase 忽略大小写, true为不区分大小写, false为区分大小写</param>
        /// <returns>返回 字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetIndexInArray(string strSearch, string[] strArr, bool ignoreCase)
        {
            if (ignoreCase)
            {
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (strSearch.ToLower() == strArr[i].ToLower())
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int j = 0; j < strArr.Length; j++)
                {
                    if (strSearch == strArr[j])
                    {
                        return j;
                    }
                }
            }

            return -1;
        }

        #endregion

        #region MapPath

        /// <summary>
        /// 获取 系统绝对路径
        /// </summary>
        /// <param name="strPath">strPath 相对路径</param>
        /// <returns>返回 系统绝对路径</returns>
        public static string MapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else
            {
                strPath = strPath.Replace("/", "\\");

                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }

                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        #endregion

        #region 转成数组
        /// <summary>
        /// 字符串 转换成数组
        /// </summary>
        /// <param name="str">目标 字符串</param>
        /// <param name="separator">分割 符号</param>
        /// <returns>返回 结果数组</returns>
        public static List<string> ToArray(string str, char separator)
        {
            return ToArray(str, separator, false);
        }

        /// <summary>
        /// 字符串 转换成数组
        /// </summary>
        /// <param name="str">目标 字符串</param>
        /// <param name="separator">分割 符号</param>
        /// <param name="toLower">转换 成小写</param>
        /// <returns>返回 结果数组</returns>
        public static List<string> ToArray(string str, char separator, bool toLower)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(separator);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != separator.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }

                    list.Add(strVal);
                }
            }

            return list;
        }

        /// <summary>
        /// 数组 转换成字符串
        /// </summary>
        /// <param name="list">目标 数组</param>
        /// <param name="separator">分割 符号</param>
        /// <returns>返回 字符串</returns>
        public static string ToString(List<string> list, string separator)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(separator);
                    sb.Append(list[i]);
                }
            }

            return sb.ToString();
        }

        #endregion


    }
}
