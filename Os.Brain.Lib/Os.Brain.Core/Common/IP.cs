//-----------------------------------------------------------------------
// <copyright file="IP.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Common Regular Expression
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Text;
    using System.Web;

    /// <summary>
    /// IP Address
    /// </summary>
    public class IP
    {
        /// <summary>
        /// Get Ip
        /// </summary>
        /// <returns>returns Ip</returns>
        public static string GetIp()
        {
            return (
                HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != string.Empty) ? GetRealIP(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
                
        /// <summary>
        /// Number ip to string
        /// </summary>
        /// <param name="ip">long type ip</param>
        /// <returns>returns ip</returns>
        public static string ToString(long ip)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append(ip >> 24);
            temp.Append(".");
            temp.Append(ip >> 16 & 255);
            temp.Append(".");
            temp.Append(ip >> 8 & 255);
            temp.Append(".");
            temp.Append(ip & 255);

            return temp.ToString();
        }

        /// <summary>
        /// Ip string to long
        /// </summary>
        /// <param name="ip">string type ip</param>
        /// <returns>return ip</returns>
        public static long ToInt(string ip)
        {
            string[] temp = ip.Split('.');
            long res = long.Parse(temp[0]) << 24;

            res += long.Parse(temp[1]) << 16;

            res += long.Parse(temp[2]) << 8;

            res += long.Parse(temp[3]);

            return res;
        }

        /// <summary>
        /// Ip long to bytes
        /// </summary>
        /// <param name="ip">long type ip</param>
        /// <returns>return ip</returns>
        public static string ToBytes(long ip)
        {
            return System.Convert.ToString(ip, 2);
        }

        /// <summary>
        /// Ip string to bytes
        /// </summary>
        /// <param name="ip">string ip</param>
        /// <returns>return ip</returns>
        public static string ToBytes(string ip)
        {
            return ToBytes(ToInt(ip));
        }

        /// <summary>
        /// Get Real IP
        /// </summary>
        /// <param name="ips">ip list</param>
        /// <returns>return ip</returns>
        private static string GetRealIP(string ips)
        {
            ips = ips.Replace(" ", string.Empty).Replace("'", string.Empty);
            string[] temparyip = ips.Split(",;".ToCharArray());
            for (int i = 0; i < temparyip.Length; i++)
            {
                if (RegExp.IsIP(temparyip[i])
                    && temparyip[i].Substring(0, 3) != "10."
                    && temparyip[i].Substring(0, 7) != "192.168"
                    && temparyip[i].Substring(0, 7) != "172.16.")
                {
                    return temparyip[i];
                }
            }

            return "127.0.0.1";
        }

        /*
        static QQWry qqwry;

        public static IPLocation SearchIPLocation(string ip)
        {
            if (qqwry == null)
                qqwry = new QQWry(HttpContext.Current.Server.MapPath("/data/QQWry.Dat"));
            IPLocation location = qqwry.SearchIPLocation(ip);
            return location;
        }
        */ 
    }
}
