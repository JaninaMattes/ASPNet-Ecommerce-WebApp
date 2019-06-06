using INFT3050.PaymentSystem;
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
    public partial class CardPayment : System.Web.UI.Page
    {
        InvoiceBL blInvoice = new InvoiceBL();
        InvoiceDTO dtoInvoice = new InvoiceDTO();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["CustID"] != null)             //Test customer is authentified OK ; else => redirection login
                {
                    if (this.Session["InvoiceID"]  == null)     //Test : invoice no created => redirection cart
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Cart.aspx");
                    }
                }
                else
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
                }
            }
            else 
            {
                //Label result cleaned
                lblResult.Text="";

                //Atempt incrementation
                int attempt = Convert.ToInt16(this.Session["attempt"]);
                attempt++;
                this.Session["attempt"] = attempt;
                Debug.Write("\n Attempt :  " + attempt); //DEBUG

                //if 3 attempt : redirection
                if (attempt>=3)
                {
                    var urlF = FriendlyUrl.Href("/UL/Customer/checkout", 0);
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + urlF);
                }
            }
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Invoice recuperation (List of 1 element)
                int customerID = Convert.ToInt32(this.Session["CustID"]);
                int invoiceID = Convert.ToInt32(this.Session["InvoiceID"]);
                decimal TotalAmount = blInvoice.FindInvoiceByID(customerID, invoiceID)[0].GetTotal();

                //Payment 
                //Created the Payment system
                IPaymentSystem paymentSystem = INFT3050PaymentFactory.Create();

                //Making a payment
                PaymentRequest payment = new PaymentRequest();


                //Value to make the payment approved
                payment.CardName = "Arthur Anderson";
                payment.CardNumber = "4444333322221111";
                payment.CVC = 123;
                payment.Expiry = new DateTime(2020, 11, 1);
                payment.Amount = 200;

                /*payment.CardName = TextName.Text;
                payment.CardNumber = TextCardNumber.Text;
                payment.CVC = Convert.ToInt16(TextCSC.Text);
                payment.Expiry = new DateTime(Convert.ToInt16(YearExpiration.SelectedValue), Convert.ToInt16(MonthExpiration.SelectedValue), 1);
                payment.Amount = TotalAmount;*/
                payment.Description = "OrderID : " + invoiceID + " for customer : " + customerID;
                var task = paymentSystem.MakePayment(payment);

                int i = 0;
                while (!task.IsCompleted)  { /*i++; if (i > 200000000) { break; } */}      //Let time to executing transaction

                 Debug.Write("\n" + i + "\n"); //DEBUG

                //Display result
                if (task.Result.TransactionResult.ToString() == "Approved")
                {
                    lblResult.CssClass = "text-success";
                    lblResult.Text = "Your paiment is approved !";

                    var urlF = FriendlyUrl.Href("/UL/Customer/checkout", 1);
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + urlF);

                }
                else if ( task.Status.ToString() == "RanToCompletion")
                {

                    lblResult.CssClass = "text-danger";
                    lblResult.Text = "Issue during the paiment :  " + task.Result.TransactionResult.ToString();
                }
                else
                {
                    lblResult.Text = "Issue during the paiment procedure, please try later";
                }
            }
            catch(Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Cart.aspx");
        }
    }
}