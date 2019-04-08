using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
                string email = this.Session["email"].ToString();    //session information recuperation
                if (email != null)
                {
                    lblGoodBye.Text = "Good bye " + email;
                    this.Session.Clear();
                }
            }
            catch
            {
                lblGoodBye.Text = "Good bye /Debug : Pas de session";
            }
        }
    }
}