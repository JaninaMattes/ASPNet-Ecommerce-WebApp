using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;


namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class DetailPageAdmin : System.Web.UI.Page
    {
        //call product from Database                
        ProductBL db = new ProductBL();
        ProductDTO product = new ProductDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            if (!IsPostBack)
            {
                var idString = Request.QueryString["id"];
                int id;
                if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
                {
                    // retrieve a prodcut from the db and feed the information on website

                    BindData(id);
                }
            }
            
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            var idString = Request.QueryString["id"];
            int id;
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                db.UpdateSecondary(id, TextShortDescription.Text, TextLongDescription.Text, TextProducer.Text);

                BindData(id);
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            var idString = Request.QueryString["id"];
            int id;
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                db.UpdateImg(id, TextImageLink.Text);
                BindData(id);
            }
        }


        protected void BindData(int id)
        {
            product = db.GetProduct(id);
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