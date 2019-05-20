using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
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
                SizeBL sb = new SizeBL();

                if (IsPostBack)
                {
                    labelPrice.Text = sb.GetPriceBySize(id, Int32.Parse(unitDropDownList.SelectedValue)).ToString();
                    totalAmount.Text = GetTotalAmount(labelPrice.Text , quantityDropDownList.SelectedValue.ToString());
                }
                if (!IsPostBack)
                {
                    // retrieve a prodcut from our db
                    var product = db.GetProduct(id);
                    var details = sb.GetDetails(product.GetId());

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
                        for (int i = 0; i < details.Count; i++)  {  unitDropDownList.Items.Add(details[i].GetSize().ToString());  }
                        labelPrice.Text = sb.GetPriceBySize ( id , Int32.Parse(unitDropDownList.SelectedValue)).ToString();
                        for (int i = 0; i < product.GetStock(); i++) { quantityDropDownList.Items.Add(i.ToString()); }
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

        private string GetTotalAmount(string priceStr, string QuantityStr)
        {
            decimal price = Decimal.Parse(priceStr);
            int quantity = Int32.Parse(QuantityStr);
            return Convert.ToString((price * quantity));
        }

    }
}