using System;
using System.Web;
using System.Configuration;

using System.Data.SqlClient;
using System.Data;

namespace Os.Brain.HttpModules
{
    public class AnalyticsFilter : IHttpModule
    {
        private string[] FilterType = new string[] { ".htm", ".html", ".aspx" };
        private string[] NotFilterType = new string[] { "/iframe/"};
        private string[] FilterSpider = new string[] { "bot","robot" ,"mj12bot", "wget", "spider", "youdaobot", "baiduspider", "iaskspider", "yahoo!", "googlebot", "msnbot", "alexibot", "sogou inst spider", "ia_archiver", "sohu-search", "soso", "163", "qihoobot", "yodaobot", "twiceler", "psbot", "webbot", "heritrix", "ms web services client protocol", "sosospider", "shockwave flash" };

        private const string REGEXP_IP = @"^(?:(?:2[0-4]\d|25[0-5]|1\d\d|[1-9]\d|\d)\.){3}(?:2[0-4]\d|25[0-5]|1\d\d|[1-9]\d|\d)$";

        private InsertData _InsertData;

        public AnalyticsFilter()
        {
            try
            {
                //FilterType = ConfigurationManager.AppSettings["FlowType"].Split((new string[] { "|" }), StringSplitOptions.RemoveEmptyEntries);
                //NotFilterType = ConfigurationManager.AppSettings["NotFilterType"].Split((new string[] { "|" }), StringSplitOptions.RemoveEmptyEntries);
                //FilterSpider = ConfigurationManager.AppSettings["FilterSpider"].Split((new string[] { "|" }), StringSplitOptions.RemoveEmptyEntries);
            }            
            catch
            {
            }

            _InsertData = new InsertData();

        }

        /// <summary>
        /// 初始化模块，并使其为处理请求做好准备。使用 Init 方法向特定事件注册事件处理方法。
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }

        private void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext ctx = (sender as HttpApplication).Context;

            if (null == ctx.Session)
                return;

            //if (isSpider(ctx.Request.UserAgent))
            //    return;
            
            //if (isNotInFilter(ctx.Request.Url.AbsoluteUri))
            //    return;

            //if (!isInFilter(ctx.Request.Url.AbsoluteUri))
            //    return;
            
            _InsertData.insert(ctx.Session.SessionID
                , GetRealIP(GetIp(ctx))
                , GetUv(ctx)//UserHostName//Guid.NewGuid().ToString()//ctx.Request.UserHostName
                , ctx.Request.UserLanguages[0].ToLower()
                , GetOSNameByUserAgent(ctx.Request.UserAgent)//ctx.Request.Browser.Platform
                , ctx.Request.Url.AbsoluteUri
                , null == ctx.Request.UrlReferrer ? string.Empty : ctx.Request.UrlReferrer.ToString()
                , ctx.Request.Browser.Browser
                , ctx.Request.Browser.Type
                , ctx.Request.Browser.MajorVersion.ToString()
                , ctx.Request.Browser.MinorVersion.ToString()
                );
        }
        
        private string GetIp(HttpContext context)
        {
            return (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? GetRealIP(context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) : context.Request.ServerVariables["REMOTE_ADDR"];
        }

        private string GetRealIP(string ips)
        {
            ips = ips.Replace(" ", "").Replace("'", "");
            string[] temparyip = ips.Split(",;".ToCharArray());
            for (int i = 0; i < temparyip.Length; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(temparyip[i], REGEXP_IP)
                    && temparyip[i].Substring(0, 3) != "10."
                    && temparyip[i].Substring(0, 7) != "192.168"
                    && temparyip[i].Substring(0, 7) != "172.16.")
                {
                    return temparyip[i];
                }
            }

            return "127.0.0.1";
        }

        private bool isNotInFilter(string str)
        {
            foreach (string ft in NotFilterType)
            {
                if (str.ToLower().Contains(ft))
                    return true;
            }

            return false;
        }

        private bool isInFilter(string str)
        {
            foreach (string ft in FilterType)
            {
                if (str.ToLower().Contains(ft))
                    return true;
            }

            return false;
        }
        
        private bool isSpider(string str)
        {
            foreach (string ft in FilterSpider)
            {
                if (str.ToLower().Contains(ft))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 处置由实现 IHttpModule 的模块使用的资源（内存除外）。
        /// </summary>
        public void Dispose()
        {
        }


        private string GetOSNameByUserAgent(string userAgent)
        {
            //string osVersion = "Unknown";
            string osVersion = userAgent;

            if (userAgent.Contains("NT 6.1"))
            {
                osVersion = "Windows 7";
            }
            if (userAgent.Contains("NT 6.0"))
            {
                osVersion = "Windows Vista";
            }
            else if (userAgent.Contains("NT 5.2"))
            {
                osVersion = "Windows Server 2003";
            }
            else if (userAgent.Contains("NT 5.1"))
            {
                osVersion = "Windows XP";
            }
            else if (userAgent.Contains("NT 5"))
            {
                osVersion = "Windows 2000";
            }
            else if (userAgent.Contains("NT 4"))
            {
                osVersion = "Windows NT4";
            }
            else if (userAgent.Contains("Me"))
            {
                osVersion = "Windows Me";
            }
            else if (userAgent.Contains("98"))
            {
                osVersion = "Windows 98";
            }
            else if (userAgent.Contains("95"))
            {
                osVersion = "Windows 95";
            }
            else if (userAgent.Contains("Mac"))
            {
                osVersion = "Mac";
            }
            else if (userAgent.Contains("Unix"))
            {
                osVersion = "UNIX";
            }
            else if (userAgent.Contains("Linux"))
            {
                osVersion = "Linux";
            }
            else if (userAgent.Contains("SunOS"))
            {
                osVersion = "SunOS";
            }
            return osVersion;
        }

        private string GetUv(HttpContext ctx)
        {
            string temp = string.Empty;
            if (null == ctx.Request.Cookies["bxg_Analytics_UserHostName"])
            {
                HttpCookie _cookies = new HttpCookie("bxg_Analytics_UserHostName");
                _cookies.Expires = DateTime.Today.AddDays(1);
                temp = _cookies.Value = Guid.NewGuid().ToString();
                ctx.Response.Cookies.Add(_cookies);

            }
            else
            {
                temp = ctx.Request.Cookies["bxg_Analytics_UserHostName"].Value;
            }
            return temp;
        }

    }

    public class InsertData : IDisposable
    {
        private SqlConnection _conn = null;
        public InsertData()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_AnalyticsFilter"].ConnectionString);
        }

        private const string _sql_format = "INSERT INTO [Ana_Records] ([AR_UV],[AR_IP],[AR_UserHostName],[AR_UserLanguage],[AR_Platform],[AR_Url],[AR_UrlReferrer],[AR_BrowserName],[AR_BrowserType],[AR_BrowserMajorVersion],[AR_BrowserMinorVersion]) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";

        public void insert(string AR_UV, string AR_IP, string AR_UserHostName, string AR_UserLanguage, string AR_Platform, string AR_Url, string AR_UrlReferrer, string AR_BrowserName, string AR_BrowserType, string AR_BrowserMajorVersion, string AR_BrowserMinorVersion)
        {
            try
            {
                Common.Debug.WriteLog("~/debug.txt",string.Format(_sql_format, AR_UV, AR_IP, AR_UserHostName, AR_UserLanguage, AR_Platform, AR_Url, AR_UrlReferrer, AR_BrowserName, AR_BrowserType, AR_BrowserMajorVersion, AR_BrowserMinorVersion));
                SqlCommand cmd = new SqlCommand(string.Format(_sql_format, AR_UV, AR_IP, AR_UserHostName, AR_UserLanguage, AR_Platform, AR_Url, AR_UrlReferrer, AR_BrowserName, AR_BrowserType, AR_BrowserMajorVersion, AR_BrowserMinorVersion), _conn);
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                cmd.BeginExecuteNonQuery(new AsyncCallback(dbcommandCallBack), cmd);
            }
            catch (Exception ex)
            {
                Common.Debug.WriteLog(ex.Message);
            }

        }

        public void dbcommandCallBack(IAsyncResult result)
        {
            try
            {
                using (SqlCommand cmd = result.AsyncState as SqlCommand)
                {
                    cmd.EndExecuteNonQuery(result);
                }
            }
            catch (Exception ex)
            {
                Common.Debug.WriteLog(ex.Message);
            }
        }

        public void Dispose()
        {
            _conn.Close();
        }
    }
}