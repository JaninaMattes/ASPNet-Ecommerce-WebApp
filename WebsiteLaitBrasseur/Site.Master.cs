using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUserProfile_Click(sender, e);

            try {
                if (this.Session["email"] != null)
                {
                    lblLogout.Visible = true;
                }
            }
            catch { }

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ProductOverview.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {


        }

        protected void btnUserProfile_Click(object sender, EventArgs e)
        {
            /*Response.Redirect("~/Account/CustomerProfile.aspx");*/
        }

    }
}