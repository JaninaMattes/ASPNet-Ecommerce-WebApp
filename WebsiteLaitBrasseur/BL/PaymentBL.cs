using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class PaymentBL
    {
        PaymentDAL DB = new PaymentDAL();
        AccountDAL AB = new AccountDAL();
        InvoiceDAL IB = new InvoiceDAL();

        /// <summary>
        /// Create a new payment and update
        /// the payment status of an invoice.
        /// If successfull return = 1
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="email"></param>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public int Create(decimal totalAmount, string email, int invoiceID)
        {
            DateTime paymentDate = DateTime.Now;
            AccountDTO customer = new AccountDTO();
            int result = 0;
            int paymentStatus = 1;
            customer = AB.FindBy(email);
            result = DB.Insert(totalAmount, paymentDate, customer.GetID(), invoiceID);
            if (result > 0)
            {
                IB.Update(invoiceID, paymentStatus);
            }            
            return result;
        }
    }
}