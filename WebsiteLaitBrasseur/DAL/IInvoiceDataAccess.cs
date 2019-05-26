using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IInvoiceDataAccess
    {
        int Insert(int accountID, int shippingID, int totalQuantity, decimal totalShippingCost, decimal totalProductCost, decimal totalTaxes, decimal totalAmount, string orderDate, string paymentDate, string arrivalDate, string postageDate, int paymentStatus, string customerMail);
        int Update(int id, int paymentStatus);
        int UpdateDate(int id, string arrivalDate);
        BL.InvoiceDTO GetInvoiceBy(int id);
        IEnumerable<BL.InvoiceDTO> FindByCustomer(int accountID);
        IEnumerable<BL.InvoiceDTO> FindByStatus(int accountID, int paymentStatus);
        IEnumerable<BL.InvoiceDTO> GetInvoicesBy(string paymentDate);
        IEnumerable<BL.InvoiceDTO> GetInvoices();
        IEnumerable<BL.InvoiceDTO> FindAllByStatus(int paymentStatus);
        IEnumerable<BL.InvoiceDTO> FindAllByCustomer(int accountID);
    }
}
