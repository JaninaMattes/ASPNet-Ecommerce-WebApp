using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

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
                //call product from Database                
                ProductBL db = new ProductBL();
                if (!IsPostBack)
                {
                    // retrieve a prodcut from the db and feed the information on website
                    var product = db.GetProduct(id);
                    if (product != null)
                    {
                        TextLongDescription.Text = product.GetInfo();
                        TextProducer.Text = product.GetProducer();
                        TextShortDescription.Text = product.GetShortInfo();
                        DestinationImg.ImageUrl = product.GetImgPath();
                    }
                }
            }
        }
    }
}