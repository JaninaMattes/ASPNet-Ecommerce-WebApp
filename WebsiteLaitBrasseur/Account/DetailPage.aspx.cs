using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Account
{
    public partial class DetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddButton_Click(sender, e);

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
<<<<<<< HEAD
                    var product = db.GetProduct(id);
=======
                    var product = db.GetProductById(id);
>>>>>>> f3f42df0f11a9a8769d53d9df77f123322f9c69e
                    if (product != null)
                    {
                        // set up detail page elements
                        headerTitle.Text = product.ProductName;
                        headerSubtitle.Text = product.ShortDescription;
                        descriptionLabel.Text = product.LongDescription;
                        destinationImg.ImageUrl = product.ImagePath;
                        nameLabel.Text = product.ProductName;
                        labelProduct.Text = product.ProductName;
                        labelProducer.Text = product.ProducerName;
                        labelPrice.Text = product.Price.ToString();
                        unitDropDownList.Text = product.Unit.ToString();
                        quantityDropDownList.Text = product.Quantity.ToString();
                        totalAmount.Text = product.TotalAmount.ToString();
                    }
                }
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
        }
    }
}