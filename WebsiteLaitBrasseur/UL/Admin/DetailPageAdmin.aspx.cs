using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            //Redirection if not login
            if (this.Session["AdminID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    // get id from url and try to parse
                    var segments = Request.GetFriendlyUrlSegments();
                    string productIDstr = segments[0];
                    int id;

                    if (productIDstr == null) { Debug.Write("\nError Url Friendly"); }//DEBUG 

                    if (!string.IsNullOrEmpty(productIDstr) && int.TryParse(productIDstr, out id))
                    {
                        // retrieve a prodcut from the db and feed the information on website
                        BindData(id);
                    }
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                }
            }
            
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // get id from url and try to parse
            var segments = Request.GetFriendlyUrlSegments();
            string productIDstr = segments[0];
            int id;

            if (productIDstr == null) { Debug.Write("\nError Url Friendly"); }//DEBUG 

            if (!string.IsNullOrEmpty(productIDstr) && int.TryParse(productIDstr, out id))
            {
                db.UpdateSecondary(id, TextShortDescription.Text, TextLongDescription.Text, TextProducer.Text);

                BindData(id);
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // get id from url and try to parse
            var segments = Request.GetFriendlyUrlSegments();
            string productIDstr = segments[0];
            int id;

            if (productIDstr == null) { Debug.Write("\nError Url Friendly"); }//DEBUG 

            if (!string.IsNullOrEmpty(productIDstr) && int.TryParse(productIDstr, out id))
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