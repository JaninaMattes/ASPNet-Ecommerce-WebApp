using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Session["Email"] != null)
                {
                    LogoutButton.Visible = true;
                    LogInButton.Visible = false;
                }
                else
                {
                    LogoutButton.Visible = false;
                    LogInButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }
        }
    }
}