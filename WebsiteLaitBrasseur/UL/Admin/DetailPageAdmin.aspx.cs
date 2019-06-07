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
        //BL DTO variables initialization               
        ProductBL db = new ProductBL();
        ProductDTO product = new ProductDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            string productIDstr = "";
            int productID;

            //Redirection if not login
            if (this.Session["AdminID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx");
            }

            if (!IsPostBack)
            {
                // get id from URL segment
                try
                {
                    var segments = Request.GetFriendlyUrlSegments();
                    productIDstr = segments[0];

                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    Debug.Write(ex.ToString());
                    lblError.Text = "Error URL";
                }

                // check id and try to parse
                if (!string.IsNullOrEmpty(productIDstr) && int.TryParse(productIDstr, out productID))
                {
                    // retrieve a product from the db and feed the information on website
                    BindData(productID);
                }
                else
                {
                    lblError.Text = "Error URL";
                }
            }
        }

        /// <summary>
        /// Update Desciptions and producer of the product-Take id from urlFriendly
        /// </summary>
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // get id from url and try to parse
                var segments = Request.GetFriendlyUrlSegments();
                string productIDstr = segments[0];
                int id;

                // check id and try to parse
                if (!string.IsNullOrEmpty(productIDstr) && int.TryParse(productIDstr, out id))
                {
                    db.UpdateSecondary(id, TextShortDescription.Text, TextLongDescription.Text, TextProducer.Text);
                    BindData(id);
                    lblResult.Text = "Updated with success";
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                lblError.Text = "Error Database";
            }
        }

        /// <summary>
        /// Update image link
        /// </summary>
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // get id from url and try to parse
                var segments = Request.GetFriendlyUrlSegments();
                string productIDstr = segments[0];
                int id;

                // check id and try to parse
                if (!string.IsNullOrEmpty(productIDstr) && int.TryParse(productIDstr, out id))
                {
                    db.UpdateImg(id, TextImageLink.Text);
                    BindData(id);
                }

            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                lblError.Text = "Error Database";
            }
        }

        /// <summary>
        /// Get Product from DB
        /// Bind information from product in TextBox
        /// </summary>
        /// <param name="id"></param>
        protected void BindData(int id)
        {
            try
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
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                lblError.Text = "Error Database";
            }
        }
    }
}