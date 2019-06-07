using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                string resultPayment = "";

                //Redirection if not Login
                if (this.Session["CustID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx"); ;
                }

                //Attempt reinitialization
                this.Session["attempt"] = 0;

                //Get id from urlFriendly
                try
                {
                    var segments = Request.GetFriendlyUrlSegments();
                    resultPayment = segments[0];
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    Debug.Write(ex.ToString());
                    lblResult.Text = "Error URL";
                }

                //Test : invoiceID set and Payment executed
                if (this.Session["InvoiceID"] != null && resultPayment != null)
                {
                    try
                    {
                        int invoiceID = Convert.ToInt32(this.Session["InvoiceID"]);

                        //Payment Denied
                        if (resultPayment == "0")
                        {
                            int res;
                            //Reverse the stock modifications in DB
                            //Old cart recuperation from invoiceID
                            ProductSelectionBL blProdSel = new ProductSelectionBL();
                            List<ProductSelectionDTO> cart = (List<ProductSelectionDTO>)(this.Session["Cart"]);

                            if (cart.Count != 0)
                            {
                                //Update DB in reverse mode
                                res = blInvoice.UpdateStockProductSelection(invoiceID, cart, true);
                            }
                            else
                            {
                                Debug.Write("\nReverse update database Failed, Cart empty\n");
                            }

                            //Set invoice status as cancelled
                            blInvoice.SetAsCancelled(invoiceID);
                            lblResult.Text = "There is an error in your payment information, the order has been cancelled.";

                            //Cart Reinitialization
                            this.Session.Remove("Cart");
                            Session["Cart"] = new List<ProductSelectionDTO>();
                        }

                        //Payment Approved
                        else if (resultPayment == "1")
                        {
                            //Set PaymentDate
                            List<InvoiceDTO> dtoInvoice = blInvoice.FindInvoiceByID(Convert.ToInt32(this.Session["CustID"]), invoiceID);
                            DateTime dt = dtoInvoice[0].GetArrivalDate();

                            //Set invoice status as Paied
                            blInvoice.SetAsPaied(invoiceID);
                            lblResult.Text = "Your order is well register, thank you ! ";
                            lblArrivalDate.Text = "Your order should arrive around the " + dt.ToString("dd/MM/yyyy");

                            //Send Mail containing invoice information to the customer
                            MailSender(dtoInvoice[0]);

                            //Cart Reinitialization
                            this.Session.Remove("Cart");
                            Session["Cart"] = new List<ProductSelectionDTO>();
                        }
                        else { lblResult.Text = "Error"; }
                    }
                    catch (Exception ex)
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

        /// <summary>
        /// Generate the mail containing invoice information
        /// send the mail to the user
        /// </summary>
        /// <param name="invoice"></param>
        private void MailSender(InvoiceDTO invoice)
        {
            string email = this.Session["Email"].ToString();

            if (email != null)
            {
                //Mail sending procedure
                //Body creation
                AccountBL accountBL = new AccountBL();
                AccountDTO customer = accountBL.GetCustomer(email);
                List<ProductSelectionDTO> products = (List<ProductSelectionDTO>)(this.Session["Cart"]);

                //Introduction
                string body = "Hi, " + customer.GetFirstName() + " " + customer.GetLastName() + ",\n\nHere your order of " + invoice.GetOrderDate().ToString("dd/MM/yyyy") + " :\n\n";

                //List of product
                foreach (ProductSelectionDTO p in products)
                {
                    body += p.GetQuantity() + " " + p.GetProduct().GetName() + " " + p.GetOrigSize() + " at " + p.GetOrigPrice() + "/Unit\n";
                }
                //Invoice costs
                body += "\nShipping cost :" + invoice.GetShippingCost() + "AUS$\nTax : " + invoice.GetTax() + "%\nTotal Amount : " + invoice.GetTotal() + " AUS$\nEstimate arrival date : " + invoice.GetArrivalDate().ToString("dd/MM/yyyy");
                body += "\n\nThank you for your confidence.\nHope to see you soon on LaitBrasseur.com !";

                //Message creation (To / From/ link to verification)
                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(email));
                mm.From = new MailAddress("webProgProjUon@gmail.com");
                mm.Body = body;

                mm.IsBodyHtml = false;
                mm.Subject = "Your order " + invoice.GetOrderDate().ToString("dd/MM/yyyy");

                //SMTP client initialization (gmail with projet address)
                SmtpClient smcl = new SmtpClient();
                smcl.Host = "smtp.gmail.com";
                smcl.Port = 587;
                smcl.Credentials = new NetworkCredential("webProgProjUon@gmail.com", "clementjanina");
                smcl.EnableSsl = true;
                smcl.Send(mm);

                //Feedback
                lblResult.CssClass = "text-success";
                lblResult.Text += "A confirmation email has been sent.";
            }
            else
                lblResult.Text = "There is a problem with your email.";

        }

    }
}