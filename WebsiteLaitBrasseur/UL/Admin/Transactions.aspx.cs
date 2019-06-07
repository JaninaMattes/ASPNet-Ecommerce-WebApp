using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using Microsoft.AspNet.FriendlyUrls;
using System.Configuration;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class Transactions : System.Web.UI.Page
    {
        // BL/DTO variables initialization
        InvoiceBL blInvoice = new InvoiceBL();
        AccountBL blCustomer = new AccountBL();


        protected void Page_Load(object sender, EventArgs e)
        {
            string custIDstr = "";
            int custID;

            //Redirection if not login
            if (this.Session["AdminID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx");
            }

            // get id from URL segment
            try
            {
                var segments = Request.GetFriendlyUrlSegments();
                custIDstr = segments[0];
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
                lblError.Text = "Error URL";
            }

            // get id from url and try to parse
            if (!string.IsNullOrEmpty(custIDstr.ToString()) && int.TryParse(custIDstr.ToString(), out custID))
            {
                //BindData
                BindDataInvoices(custID);
            }
            else
            {
                lblError.Text = "Error URL";
            }
        }

        /// <summary>
        /// Take list of invoice of a customer from DB
        /// Display it in gridview
        /// </summary>
        /// <param name="accountID"></param>
        protected void BindDataInvoices(int accountID)
        {
            try
            {
                IEnumerable<InvoiceDTO> invoices = new List<InvoiceDTO>();
                invoices = blInvoice.FindInvoices(accountID);
                AccountDTO customer = new AccountDTO();
                customer = blCustomer.GetCustomer(accountID);
                ShoppingTable.DataSource = GetDataTable(invoices);
                ShoppingTable.DataBind();

                if (invoices.Count() > 0)
                {
                    tableShoppingHistoryLabel.Text = $"The transactionlist of {customer.GetFirstName()} " +
                        $"{customer.GetLastName()} has {invoices.Count()} items.";
                }
                else
                {
                    tableShoppingHistoryLabel.Text = $"The transactionlist is empty.";
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        //Shopping history generation (Same in /Account/Profile.aspx)
        protected DataTable GetDataTable(IEnumerable<InvoiceDTO> invoices)
        {
            //DataTable initialization
            DataTable dtInvoice = new DataTable();

            //Colmuns declaration
            dtInvoice.Columns.Add("InvoiceNumber");
            dtInvoice.Columns.Add("Quantity");
            dtInvoice.Columns.Add("TotalAmount");
            dtInvoice.Columns.Add("OrderDate");
            dtInvoice.Columns.Add("ArrivalDate");
            dtInvoice.Columns.Add("PaymentStatus");
            dtInvoice.Columns.Add("PaymentDate");

            foreach (InvoiceDTO invoice in invoices)
            {
                DataRow dr = dtInvoice.NewRow();
                dr["InvoiceNumber"] = invoice.GetID();
                dr["Quantity"] = invoice.GetQuantity();
                dr["TotalAmount"] = invoice.GetTotal();
                dr["OrderDate"] = invoice.GetOrderDate();
                dr["ArrivalDate"] = invoice.GetArrivalDate();
                dr["PaymentDate"] = invoice.GetPaymentDate();
                if (invoice.GetStatus() == 1)
                {
                    dr["PaymentStatus"] = "Paied";
                }
                else if (invoice.GetStatus() == 2)
                {
                    dr["PaymentStatus"] = "Cancelled";
                }
                else
                {
                    dr["PaymentStatus"] = "ErrorValue";
                }

                dtInvoice.Rows.Add(dr);

            }
            return dtInvoice;
        }
    }
}