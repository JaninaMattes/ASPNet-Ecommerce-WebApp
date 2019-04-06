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

        protected void BeerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ProductOverview.aspx");
        }

        protected void CheeseButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ProductOverview.aspx");
        }
    }
}