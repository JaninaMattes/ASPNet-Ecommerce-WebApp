using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                if (this.Session["Email"] != null)
                {
                    LogoutButton.Visible = true;
                    LogInButton.Visible = false;
                }
                else
                {
                    LogoutButton.Visible =false;
                    LogInButton.Visible = true;
                }
            }
            catch { }

        }
    }
}