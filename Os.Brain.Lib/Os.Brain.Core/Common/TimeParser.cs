//-----------------------------------------------------------------------
// <copyright file="TimeParser.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>TimeParser
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;

    /// <summary>
    /// 时间 提供程序
    /// </summary>
    public class TimeParser
    {
        /// <summary>
        /// Gets Monthes. 
        /// </summary>
        public static string[] Monthes
        {
            get
            {
                return new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            }
        }

        /// <summary>
        /// Gets GetDate. 
        /// </summary>
        public static string GetDate
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// Gets GetTime. 
        /// </summary>
        public static string GetTime
        {
            get
            {
                return DateTime.Now.ToString("HH:mm:ss");
            }
        }

        /// <summary>
        /// Gets GetDateTime. 
        /// </summary>
        public static string GetDateTime
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// Gets GetDateTimeF. 
        /// </summary>
        public static string GetDateTimeF
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
            }
        }

        /// <summary>
        /// AddDate 获取时间
        /// </summary>
        /// <param name="days">days 天数</param>
        /// <returns>返回 时间</returns>
        public static string AddDate(int days)
        {
            return DateTime.Now.AddDays(days).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// SecondToMinute 秒转换成分钟
        /// </summary>
        /// <param name="second">Second 秒</param>
        /// <returns>返回 分钟数</returns>
        public static int SecondToMinute(int second)
        {
            decimal mm = (decimal)((decimal)second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        /// <summary>
        /// GetMonthLastDate 获取每月的最后一天
        /// </summary>
        /// <param name="year">year 年</param>
        /// <param name="month">month 月</param>
        /// <returns>返回 某年某月的天数</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            
            return lastDay.Day;
        }

        /// <summary>
        /// DateDiff 计算两个时间天的相差天数
        /// </summary>
        /// <param name="dateTime1">DateTime1 时间一</param>
        /// <param name="dateTime2">DateTime2 时间二</param>
        /// <returns>返回 计算两个时间天的相差天数</returns>
        public static string DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts = dateTime2 - dateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = dateTime1.Month.ToString() + "月" + dateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            {
            }

            return dateDiff;
        }
    }
}
