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
    public partial class Transactions : System.Web.UI.Page
    {
        InvoiceBL BL = new InvoiceBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            int custID = Convert.ToInt32(Request.QueryString["custID"]);
          
            if (!string.IsNullOrEmpty(custID.ToString()) && int.TryParse(custID.ToString(), out custID))
            {
                    BindTableLabel(custID);
                    BindGridList(custID);
            }
        }

        //Shopping history generation (Same in /Account/Profile.aspx)
        protected void BindGridList(int id)
        {
            ShoppingTable.DataSource = getShoppingList(id);
            ShoppingTable.DataBind();
        }


        protected void BindTableLabel(int id)
        {
            IEnumerable<InvoiceDTO> invoices = getShoppingList(id);
            //TODO 


            if (invoices.Count() > 0)
            {
                tableShoppingHistoryLabel.Text = $"Your shopping history has {invoices.Count()} items.";
            }
            else
            {
                tableShoppingHistoryLabel.Text = $"Your shoppinglist is empty.";
            }
        }

        protected IEnumerable<InvoiceDTO> getShoppingList(int accountID)
        {
            IEnumerable<InvoiceDTO> invoices = new List<InvoiceDTO>();
            try
            {
                invoices = BL.FindInvoices(accountID);
                if(invoices != null)
                {
                    foreach (InvoiceDTO i in invoices)
                    {
                        Debug.Print($"Transactions: / GetShoppingList / {i.GetID()}"); //Debugging 
                    }
                }               
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }            
            return invoices;
        }
    }
}