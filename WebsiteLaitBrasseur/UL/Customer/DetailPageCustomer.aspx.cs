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
        ProductSelectionDTO dtoProdSel = new ProductSelectionDTO();
        List<ProductSelectionDTO> cart = new List<ProductSelectionDTO>();
        ProductBL blProduct = new ProductBL();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                lblError.Text = "Error URL";
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
                        for (int i = 1; i < product.GetStock(); i++) { quantityDropDownList.Items.Add(i.ToString()); }
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
                lblError.Text = "Error URL";
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

            try
            {
                // get id from URL segment
                var segments = Request.GetFriendlyUrlSegments();
                int productID = Convert.ToInt32(segments[0]);
                Debug.Write("\n productID :" + productID); //DEBUG

                //ProductSelectionCreation
                dtoProdSel.SetProduct(blProduct.GetProduct(productID));
                dtoProdSel.SetOrigPrice(Convert.ToDecimal(labelPrice.Text));
                dtoProdSel.SetOrigSize(Convert.ToInt32(unitDropDownList.SelectedValue));
                dtoProdSel.SetQuantity(Convert.ToInt32(quantityDropDownList.SelectedValue));


                Debug.Write("\n Product name :" + blProduct.GetProduct(productID).GetName()); //DEBUG
                Debug.Write("\n  Price :" + Convert.ToDecimal(labelPrice.Text).ToString()); //DEBUG
                Debug.Write("\n  Size  :" + Convert.ToInt32(unitDropDownList.SelectedValue).ToString()); //DEBUG
                Debug.Write("\n  Quantity : " + Convert.ToInt32(quantityDropDownList.SelectedValue).ToString()); //DEBUG

                
                //Add to Cart 
                cart = (List<ProductSelectionDTO>) (this.Session["cart"]);
                cart.Insert(cart.Count, dtoProdSel);
                this.Session["cart"] = cart;
                lblResult.Text = "Added to cart with success!";

                //TEST CART
                int i=0;
                foreach (ProductSelectionDTO p in cart)
                {
                    i++;
                    Debug.Write("\n "+ i +"   Product name :  " + p.GetProduct().GetName()); //DEBUG;
                }
                //END  TEST CART
                
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
                lblResult.Text = "Error during cart managment";
            }
        }

        private string GetTotalAmount(string priceStr, string QuantityStr)
        {
            decimal price = Convert.ToDecimal(priceStr);
            int quantity = Convert.ToInt32(QuantityStr);
            return Convert.ToString((price * quantity));
        }

    }
}