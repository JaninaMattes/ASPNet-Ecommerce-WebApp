using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.EnableFriendlyUrls();

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Attempt"] = 0;
            Session["Cart"] = new List<ProductSelectionDTO>();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //this.Session.Remove("Attempt");
            this.Session.Clear();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}