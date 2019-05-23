using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IInvoiceDataAccess
    {
        int Insert(int accountID, int shippingID, int totalQuantity, decimal totalShippingCost, decimal totalProductCost, decimal totalTaxes, decimal totalAmount, DateTime orderDate, DateTime paymentDate, DateTime arrivalDate, DateTime postageDate, int paymentStatus, string customerMail);
        int Update(int id, int paymentStatus);
        int UpdateDate(int id, bool arrivalDate);
        BL.InvoiceDTO FindBy(int id);
        List<BL.InvoiceDTO> FindByCustomer(int accountID);
        List<BL.InvoiceDTO> FindByStatus(int accountID, int paymentStatus);
        List<BL.InvoiceDTO> FindBy(DateTime paymentDate);
        List<BL.InvoiceDTO> FindAll();
        List<BL.InvoiceDTO> FindAllByStatus(int paymentStatus);
        List<BL.InvoiceDTO> FindAllByCustomer(int accountID);
    }
}
