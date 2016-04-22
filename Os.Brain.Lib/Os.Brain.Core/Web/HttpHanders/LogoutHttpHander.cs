//-----------------------------------------------------------------------
// <copyright file="LogoutHttpHander.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>登陆退出处理程序</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.HttpHanders
{
    using System;
    using System.Web;
    using System.Web.Security;

    /// <summary>
    /// 用户权限 用户退出
    /// </summary>
    public class LogoutHttpHander : IHttpHandler
    {
        /// <summary>
        /// Gets a value indicating whether the item is IsReusable.
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// Process Request
        /// </summary>
        /// <param name="context">Http Context</param>
        public void ProcessRequest(HttpContext context)
        {
            System.Web.HttpCookie userloginname = context.Request.Cookies["UserLoginName"];

            if (null != userloginname)
            {
                userloginname.Expires = DateTime.Now.AddDays(-1);

                if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                    userloginname.Domain = FormsAuthentication.CookieDomain;
                System.Web.HttpContext.Current.Response.Cookies.Add(userloginname);
            }

            FormsAuthentication.SignOut();

            HttpCookie auth = HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];

            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                auth.Domain = FormsAuthentication.CookieDomain;
            
            auth.Expires = DateTime.Now.AddDays(-1);
            System.Web.HttpContext.Current.Response.Cookies.Add(auth);

            context.Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}