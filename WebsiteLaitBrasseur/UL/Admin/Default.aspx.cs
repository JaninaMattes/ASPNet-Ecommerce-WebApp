using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Shippingbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Admin/PostagesManagement.aspx");
        }

        protected void Customerbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Admin/AccountManagment.aspx");
        }

        protected void Productbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Admin/ItemsManagement.aspx");
        }
    }
}