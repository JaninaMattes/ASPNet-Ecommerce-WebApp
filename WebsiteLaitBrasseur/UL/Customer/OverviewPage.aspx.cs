﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Data;
using System.Configuration;
using Microsoft.AspNet.FriendlyUrls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class OverviewPage : System.Web.UI.Page
    {
        List<ProductDTO> productList = new List<ProductDTO>();
        //List<SizeDTO> sizeList = new List<SizeDTO>();
        ProductBL BL = new ProductBL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string type = "";

                // get id from URL segment
                try
                {
                    var segments = Request.GetFriendlyUrlSegments();
                    type = segments[0];
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    Debug.Write(ex.ToString());
                    Debug.Write("\n\n Pas d'ID \n\n");
                }

                //Test type of product pre-selected
                if (!string.IsNullOrEmpty(type))
                {
                    Debug.WriteLine($"Product {type} selected.");
                    if (!IsPostBack)
                    {
                        // retrieve a list of filtered prodcuts from the blProd
                        BindDataByType(type);
                        if (productList != null)
                        {
                            Subtitle_Warn.Text = $"A selection of our best {type} products.";
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
                    BindAllData();
                    if (productList != null)
                    {
                        Subtitle_Warn.Text = "A hand selected overview of all seasonal available products.";
                    }
                }

            }
        }

        //Redirection to Details page of a product
        protected void imgCommand(object sender, CommandEventArgs e)
        {
            var urlF = FriendlyUrl.Href("/UL/Customer/DetailPageCustomer", e.CommandArgument);
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + urlF);

        }

        protected void ImageRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }


        protected void BindAllData()
        {
            try
            {
                Debug.WriteLine("BindAllDAta");
                var result = BL.GetAllActiveProducts();
                productList = result.ToList();
                ImageRepeater.DataSource = GetDataTable();
                ImageRepeater.DataBind();
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        protected void BindDataByType(string type)
        {
            productList = BL.GetProducts(type);
            ImageRepeater.DataSource = GetDataTable();
            ImageRepeater.DataBind();
        }

        protected DataTable GetDataTable()
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

            foreach (ProductDTO p in productList)
            {
                Debug.WriteLine($"Overviewpage: / ProductID {p.GetId()}");
                //sizeList = p.GetDetails();
                DataRow dr = dtProduct.NewRow();
                dr["ID"] = p.GetId();
                dr["ImgPath"] = p.GetImgPath();
                dr["Name"] = p.GetName();
                dr["ShortInfo"] = p.GetShortInfo();
                //dr["Price"] = p.GetPrice();
                //dr["Size"] = p.GetSize();
                if (p.GetStatus() == 1) { dr["Status"] = "Available"; }
                else { dr["Status"] = "Out of Stock"; }
                dtProduct.Rows.Add(dr);
            }
            return dtProduct;
        }
    }
}