using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Account
{
    public partial class OverviewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db = new DAL.DemoDatabase();
                var products = db.GetProducts();

                ImageRepeater.DataSource = products;
                ImageRepeater.DataBind();
            }
        }

        protected void imgCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("DetailPage.aspx?id=" + e.CommandArgument);
        }
    }
}