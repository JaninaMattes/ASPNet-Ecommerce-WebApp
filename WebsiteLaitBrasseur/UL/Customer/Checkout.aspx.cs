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

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Checkout : System.Web.UI.Page
    {
        InvoiceBL blInvoice = new InvoiceBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string result="";
                if (this.Session["CustID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx"); ;
                }

                //Attempt reinitialization
                this.Session["attempt"] = 0;

                //Get id from url
                try
                {
                    var segments = Request.GetFriendlyUrlSegments();
                    result = segments[0];
                }
                catch(Exception ex)
                {
                    ex.GetBaseException();
                    Debug.Write(ex.ToString());
                    lblResult.Text = "Error URL";
                }

                //Test customer is authentified OK ; else => redirection login  
                if (this.Session["CustID"] != null && result != null)     
                {
                    try
                    {
                        int invoiceID = Convert.ToInt32(this.Session["InvoiceID"]);
                        if (result == "0")  //Denied
                        {
                            int res;
                            //Reverse the stock modifications in DB
                                //Old cart recuperation from invoiceID
                            ProductSelectionBL blProdSel = new ProductSelectionBL();
                            //List<ProductSelectionDTO> oldcart = blProdSel.GetProducts(invoiceID);
                            List<ProductSelectionDTO> cart = (List<ProductSelectionDTO>)(this.Session["Cart"]);

                            if (cart.Count != 0)
                            {
                                //Update DB in reverse mode
                                res = blInvoice.UpdateStockProductSelection(invoiceID, cart, true);
                            }
                            else
                            {
                                Debug.Write("Reverse update database Failed");
                            }
                            
                            //Set invoice status as cancelled
                            blInvoice.SetAsCancelled(invoiceID);
                            lblResult.Text = "There is an error in your payment information, the order has been cancelled.";

                            //Cart cleared
                            this.Session.Remove("Cart");
                        }
                        else if (result == "1")  //Approved 
                        {
                            blInvoice.SetAsPaied(invoiceID);
                            List<InvoiceDTO> dtoInvoice = blInvoice.FindInvoiceByID(Convert.ToInt32(this.Session["CustID"]),invoiceID);
                            DateTime dt = dtoInvoice[0].GetArrivalDate();
                            lblResult.Text = "Your order is well register, thank you !";
                            lblArrivalDate.Text = "It should arrive around the " + dt.ToString("dd/MM/yyyy");

                            //Cart cleared
                            this.Session.Remove("Cart");
                        }
                        else { lblResult.Text = "Error"; }
                    }
                    catch(Exception ex)
                    {
                        ex.GetBaseException();
                        Debug.Write(ex.ToString());
                        lblResult.Text = "Error";
                    }
                }
                else
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
                }
            }
        }
    }
}