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
           
                // get id from query string and try to parse
                var type = Request.QueryString["productType"];
                if (!string.IsNullOrEmpty(type))
                {
                    if (!IsPostBack)
                    {
                        // retrieve a list of filtered prodcuts from the db
                        var products = db.GetProducts(type);
                        if (products != null)
                        {
                            ImageRepeater.DataSource = products;
                            ImageRepeater.DataBind();
                        }
                    }
                }

                else
                {   
                    // retrieve a list of all products from the db
                    var products = db.GetProducts();
                    if (products != null)
                    {
                        ImageRepeater.DataSource = products;
                        ImageRepeater.DataBind();
                    }
                }
            }
        }

        protected void imgCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("DetailPage.aspx?id=" + e.CommandArgument);
        }

        protected void ImageRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}