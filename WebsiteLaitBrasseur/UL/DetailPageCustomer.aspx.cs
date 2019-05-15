using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.Customer
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
                //call product from Database                
                ProductBL db = new ProductBL();
                if (!IsPostBack)
                {
                    // retrieve a prodcut from our db
                    var product = db.GetProduct(id);
                    if (product != null && product.GetStatus()==1)
                    {
                        // set up detail page elements
                        headerTitle.Text = product.GetName();
                        headerSubtitle.Text = product.GetShortInfo();
                        descriptionLabel.Text = product.GetName();
                        destinationImg.ImageUrl = product.GetImgPath();
                        nameLabel.Text = product.GetName();
                        labelProduct.Text = product.GetProductType();
                        labelProducer.Text = product.GetProducer();
                        labelPrice.Text = product.GetPrice().ToString();
                        unitDropDownList.Text = product.GetUnit().ToString();
                        quantityDropDownList.Text = product.GetStock().ToString();
                        totalAmount.Text = product.GetStock().ToString();
                    }
                    else
                    {
                        //TODO Use case when product is not in stock 
                        headerTitle.Text = "Product currently not available";
                    }
                }
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
        }
    }
}