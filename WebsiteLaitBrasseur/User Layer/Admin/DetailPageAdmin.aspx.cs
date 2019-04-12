using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class DetailPageAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            var idString = Request.QueryString["id"];
            int id;
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                // create new dummy database object
                DAL.DemoDatabase db = new DAL.DemoDatabase();

                if (!IsPostBack)
                {
                    // retrieve a prodcut from our db
                    var product = db.GetProduct(id);
                    if (product != null)
                    {
                        TextLongDescription.Text = product.LongDescription;
                        TextProducer.Text = product.ProducerName;
                        TextShortDescription.Text = product.ShortDescription;
                        destinationImg.ImageUrl = product.ImagePath;
                    }
                }
            }
        }
    }
}