using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class Transactions : System.Web.UI.Page
    {
        InvoiceBL BL = new InvoiceBL();
        AccountBL AL = new AccountBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: get id from query string and try to parse
            int custID = Convert.ToInt32(Request.QueryString["custID"]);
          
            if (!string.IsNullOrEmpty(custID.ToString()) && int.TryParse(custID.ToString(), out custID))
            {
                BindDataInvoices(custID);
            }
        }

        //protected void InvoiceListTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //}

        //protected void InvoiceListTable_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //}
        
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
                else
                {
                    dr["PaymentStatus"] = "Open";
                }

                dtInvoice.Rows.Add(dr);

            }
            return dtInvoice;
        }

        protected void BindDataInvoices(int accountID)
        {            
            try
            {
                IEnumerable<InvoiceDTO> invoices = new List<InvoiceDTO>();
                invoices = BL.FindInvoices(accountID);
                AccountDTO customer = new AccountDTO();
                customer = AL.GetCustomer(accountID);
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
    }
}