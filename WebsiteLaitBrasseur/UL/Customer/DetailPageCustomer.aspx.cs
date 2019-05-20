using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using WebsiteLaitBrasseur.DAL; //debug

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

            //DEBUG
            id = 1;
            ProductDAL test = new ProductDAL();
            ProductDTO testDTO = new ProductDTO();

            testDTO = test.FindBy(1);

            //



            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                //call product from Database                
                ProductBL db = new ProductBL();
                var product = db.GetProduct(id);
               // Debug.Write(db.GetProduct(id).GetName().ToString());//DEBUG

                if (!IsPostBack)
                {
                    // retrieve a prodcut from our db

                        if (db.GetProduct(id) != null && db.GetProduct(id).GetStatus() == 1)
                        {
                            // set up detail page elements
                            
                            headerTitle.Text = db.GetProduct(id).GetName();
                            headerSubtitle.Text = db.GetProduct(id).GetShortInfo();
                            descriptionLabel.Text = db.GetProduct(id).GetName();
                            destinationImg.ImageUrl = db.GetProduct(id).GetImgPath();
                            nameLabel.Text = db.GetProduct(id).GetName();
                            labelProduct.Text = db.GetProduct(id).GetProductType();
                            labelProducer.Text = db.GetProduct(id).GetProducer();
                            labelPrice.Text = db.GetProduct(id).GetDetails()[0].GetPrice().ToString();
                            unitDropDownList.Text = db.GetProduct(id).GetDetails()[0].GetSize().ToString();
                            quantityDropDownList.Text = db.GetProduct(id).GetStock().ToString();
                            totalAmount.Text = db.GetProduct(id).GetStock().ToString();
                        }
                        else
                        {
                            Debug.Write(idString);
                            Debug.Write(id);
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