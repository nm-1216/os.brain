using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Os.Brain.iBxg.Admin
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }



        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.Request.IsAuthenticated)
            {
                HttpCookie Auth = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(Auth.Value);

                Context.User = new System.Security.Principal.GenericPrincipal(Context.User.Identity, System.Text.RegularExpressions.Regex.Replace(authTicket.UserData, "^.*?Roles:{(.*?)}.*?", "$1").Split(','));
            }
        }
    }
}