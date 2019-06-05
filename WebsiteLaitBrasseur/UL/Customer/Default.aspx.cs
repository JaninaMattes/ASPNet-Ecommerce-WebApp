using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Default : System.Web.UI.Page
    {
        AccountBL DB = new AccountBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Email"] != null)
            { 
                string email= this.Session["Email"].ToString();
                AccountDTO customer = new AccountDTO();
                customer = DB.GetCustomer(email);
                lblWelcome.Text = "Welcome back " + customer.GetFirstName() + " " + customer.GetLastName();
            }
            else
            { 
                lblWelcome.Text = "Welcome & Bienvenue";

            }
        }

        // image has a click interaction to overview page containing the requested products
        protected void imgCommand(object sender, CommandEventArgs e)
        {
            var urlF = FriendlyUrl.Href("/UL/Customer/OverviewPage", e.CommandArgument);
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + urlF);
        }
    }
}