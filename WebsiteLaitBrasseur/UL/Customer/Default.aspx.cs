using System;
using System.Collections.Generic;
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
            try { 
                //Welcome
                string email= this.Session["email"].ToString();

                if (email != null)
                {
                    AccountDTO customer = new AccountDTO();
                    customer = DB.GetCustomer(email);
                    lblWelcome.Text = "Welcome back " + customer.GetFirstName() + " " + customer.GetLastName();
                }
            }
            catch
            {
                lblWelcome.Text = "Welcome & Bienvenue";
            }
        }

        // image has a click interaction to overview page containing the requested products
        protected void imgCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("/UL/Customer/OverviewPage.aspx?productType=" + e.CommandArgument);
        }
    }
}