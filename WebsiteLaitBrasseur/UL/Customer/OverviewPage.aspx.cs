using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Data;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class OverviewPage : System.Web.UI.Page
    {
        List<ProductDTO> LP = new List<ProductDTO>();
        List<SizeDTO> LS = new List<SizeDTO>();
        ProductBL blProd = new ProductBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                // get id from query string and try to parse
                var type = Request.QueryString["productType"];
                if (!string.IsNullOrEmpty(type))
                {   
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("debugging--"+ type);
                    if (!IsPostBack)
                    {
                        // retrieve a list of filtered prodcuts from the blProd
                        BindDataByType(type);                                           
                        if (LP != null)
                        {
                            Subtitle_Warn.Text = "A selection of our best " + type + " products.";
                        }
                        else
                        {
                            Subtitle_Warn.Text = "No products could be found.";
                        }
                    }
                }
                else
                {
                    // retrieve a list of all prodcuts from the blProd
                    BindDataAll();
                    if (LP != null)
                    {
                        Subtitle_Warn.Text = "A hand selected overview of all seasonal available products.";
                    }
                }
            }
        }

        protected void imgCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("/UL/Customer/DetailPageCustomer.aspx?id=" + e.CommandArgument);
        }

        protected void ImageRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
     

        protected void BindDataAll()
        {
            LP = blProd.GetAllProducts();
            ImageRepeater.DataSource = getDataTable();
            ImageRepeater.DataBind();
        }

        protected void BindDataByType(string type)
        {
            LP = blProd.GetProducts(type);
            ImageRepeater.DataSource = getDataTable();
            ImageRepeater.DataBind();
        }

        protected DataTable getDataTable()
        {
            //DataTable initialization
            DataTable dtProduct = new DataTable();

            //Colmuns declaration
            dtProduct.Columns.Add("ID");
            dtProduct.Columns.Add("ImgPath");
            dtProduct.Columns.Add("Name");
            dtProduct.Columns.Add("ShortInfo");
            dtProduct.Columns.Add("Size");
            dtProduct.Columns.Add("Price");
            dtProduct.Columns.Add("Status");

            for (int i = 0; i < LP.Count; i++)
            {
                LS = LP[i].GetDetails();
                    DataRow dr = dtProduct.NewRow();
                    dr["ID"] = LP[i].GetId();
                    dr["ImgPath"] = LP[i].GetImgPath();
                    dr["Name"] = LP[i].GetName();
                    dr["ShortInfo"] = LP[i].GetShortInfo();
                    //dr["Price"] = LS[0].GetPrice();
                    //dr["Size"] = LS[0].GetSize();
                    if (LP[i].GetStatus() == 1) { dr["Status"] = "Available"; }
                    else { dr["Status"] = "Unavailable"; }
                    dtProduct.Rows.Add(dr);
            }
            return dtProduct;
        }
    }
}