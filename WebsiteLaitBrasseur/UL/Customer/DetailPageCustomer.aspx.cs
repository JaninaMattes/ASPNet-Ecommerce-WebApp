using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using Microsoft.AspNet.FriendlyUrls;
using WebsiteLaitBrasseur.BL;
using System.Configuration;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class DetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddButton_Click(sender, e); //Useful ?
            string idString = "";
            int id;

            // get id from URL segment
            try
            {

                var segments = Request.GetFriendlyUrlSegments();
                idString = segments[0];
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
                lblResult.Text = "Error URL";
            }

            // get id from query string and try to parse
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                //call product from Database                
                ProductBL db = new ProductBL();
                SizeBL sb = new SizeBL();

                if (IsPostBack)
                {
                    labelPrice.Text = sb.GetPriceBySize(id, Convert.ToInt32(unitDropDownList.SelectedValue)).ToString();
                    totalAmount.Text = GetTotalAmount(labelPrice.Text, quantityDropDownList.SelectedValue.ToString());
                }
                if (!IsPostBack)
                {
                    // retrieve a prodcut from our db
                    var product = db.GetProduct(id);
                    var details = sb.GetDetails(product.GetId());
                    List<SizeDTO> productDetails = details.ToList();

                    //only display available products to the customer
                    if (product != null && product.GetStatus() == 1)
                    {
                        // set up detail page elements
                        headerTitle.Text = product.GetName();
                        headerSubtitle.Text = product.GetShortInfo();
                        descriptionLabel.Text = product.GetInfo();
                        destinationImg.ImageUrl = product.GetImgPath();
                        nameLabel.Text = product.GetName();
                        labelProduct.Text = product.GetProductType();
                        labelProducer.Text = product.GetProducer();
                        for (int i = 0; i < productDetails.Count; i++) { unitDropDownList.Items.Add(productDetails[i].GetSize().ToString()); }
                        labelPrice.Text = sb.GetPriceBySize(id, Convert.ToInt32(unitDropDownList.SelectedValue)).ToString();
                        for (int i = 0; i < product.GetStock(); i++) { quantityDropDownList.Items.Add(i.ToString()); }
                        if (product.GetStock() <= 5) { lowStock.Text = $"Low stock. Only {product.GetStock()} availble"; }
                    }
                    else
                    {
                        //TODO Use case when product is not in stock 
                        headerTitle.Text = "Product currently not available";
                    }
                }
            }
            else 
            {
                lblResult.Text = "Error URL";
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            //TODO shopping list
        }

        private string GetTotalAmount(string priceStr, string QuantityStr)
        {
            decimal price = Convert.ToDecimal(priceStr);
            int quantity = Convert.ToInt32(QuantityStr);
            return Convert.ToString((price * quantity));
        }

    }
}