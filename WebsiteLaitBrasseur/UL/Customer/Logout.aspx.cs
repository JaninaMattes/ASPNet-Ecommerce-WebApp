using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                //session informations recuperation
                string email = this.Session["email"].ToString();   
                if (email != null)
                {
                    lblGoodBye.Text = "Good bye " + email;

                    //Session variable removing
                    this.Session.Clear();
                }
            }
            catch
            {
                lblGoodBye.Text = "Good bye ";
            }
        }
    }
}