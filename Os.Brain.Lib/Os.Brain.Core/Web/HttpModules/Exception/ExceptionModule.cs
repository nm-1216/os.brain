//-----------------------------------------------------------------------
// <copyright file="ExceptionModule.cs" company="com.hwx">Copyright (c) hwx. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/04/18</datetime>
// <discription>统一异常处理程序</discription>
//-----------------------------------------------------------------------



namespace Os.Brain.HttpModules
{
    using System;
    using System.Web;

    using Os.Brain.Instrumentation;

    public class ExceptionModule : IHttpModule
    {

        #region IHttpModule Members

        public void Init(HttpApplication application)
        {
            application.Error += OnErrorRequest;
        }

        public void Dispose()
        {
        }

        #endregion

        private void OnErrorRequest(object s, EventArgs e)
        {
            try
            {
                if (HttpContext.Current == null)
                {
                    return;
                }

                HttpApplication ap = s as HttpApplication;
                HttpContext Context = HttpContext.Current;
                HttpServerUtility Server = Context.Server;
                HttpRequest Request = Context.Request;
                Exception lastException = Server.GetLastError();

                if (!(lastException is HttpException))
                {
                    var lex = new Exception("Unhandled Error: ", Server.GetLastError());
                    AppLog.Error(lex);
                }
                else
                {
                    AppLog.Error(lastException);
                }
            }
            catch (Exception exc)
            {
                AppLog.Error(exc);
            }
        }
    }
}
