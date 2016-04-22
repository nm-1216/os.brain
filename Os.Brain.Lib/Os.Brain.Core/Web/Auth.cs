//-----------------------------------------------------------------------
// <copyright file="Auth.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Auth</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Web
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Security;

    /// <summary>
    /// Auth 用户票据
    /// </summary>
    public class Auth
    {
        /// <summary>
        /// WriteTicket 写票据
        /// </summary>
        /// <param name="version">version 版本号</param>
        /// <param name="name">name 名称</param>
        /// <param name="timeout">timeout 过期时间</param>
        /// <param name="isPersistent">isPersistent 时候持久的</param>
        /// <param name="userData">userData 用户数据</param>
        public static void WriteTicket(int version, string name, int timeout, bool isPersistent, string userData)
        {
            FormsAuthenticationTicket _ticket = new FormsAuthenticationTicket(
                version,
                name,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                userData,
                FormsAuthentication.FormsCookiePath
            );

            HttpCookie _auth = new HttpCookie(FormsAuthentication.FormsCookieName);

            _auth.Value = FormsAuthentication.Encrypt(_ticket);

            if (_ticket.IsPersistent)
                _auth.Expires = _ticket.Expiration;

            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                _auth.Domain = FormsAuthentication.CookieDomain;

            HttpContext.Current.Response.Cookies.Add(_auth);
        }
    }
}