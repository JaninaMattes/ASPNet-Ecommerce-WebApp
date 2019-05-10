using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Display Logout button if a session is active
                if (this.Session["email"] != null)
                {
                    lblLogout.Visible = true;
                }
            }
            catch { }
        }
    }
}