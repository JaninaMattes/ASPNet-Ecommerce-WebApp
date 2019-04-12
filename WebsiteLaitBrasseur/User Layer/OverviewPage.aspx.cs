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
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("debugging--"+ type);
                    if (!IsPostBack)
                    {
                        // retrieve a list of filtered prodcuts from the db
                        var products = db.GetProducts(type);                                            
                        if (products != null)
                        {
                            for (int i = 0; i < products.Length; i++)
                            {
                                //debugging purpose, will later remove
                                System.Diagnostics.Debug.WriteLine("debugging--" + products[i].ImagePath);
                            }
                            ImageRepeater.DataSource = products;
                            ImageRepeater.DataBind();
                            Subtitle_Warn.Text = "A selection of our best " + type + " products.";
                        }
                        else
                        {
                            Subtitle_Warn.Text = "No products could be found.";
                        }
                    }
                }
                else
                {
                    // retrieve a list of all prodcuts from the db
                    var products = db.GetProducts();
                    if (products != null)
                    {
                        ImageRepeater.DataSource = products;
                        ImageRepeater.DataBind();
                        Subtitle_Warn.Text = "A hand selected overview of all seasonal available products.";
                    }
                }
            }
        }

        protected void imgCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("/User Layer/DetailPage.aspx?id=" + e.CommandArgument);
        }

        protected void ImageRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}