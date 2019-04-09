using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Welcome
            HttpCookie email = Request.Cookies["email"];
            if (email != null)
            {
                lblWelcome.Text = "Welcome back " + email.Value;
            }
        }

        // image has a click interaction to overview page containing the requested products
        protected void imgCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("OverviewPage.aspx?productType=" + e.CommandArgument);
        }
    }
}