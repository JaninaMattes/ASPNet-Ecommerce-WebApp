using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IPaymentDataAccess
    {
        int Insert(decimal totalAmount, DateTime paymentDate, int accountID, int invoiceID);
        BL.PaymentDTO FindBy(int id);
        BL.PaymentDTO FindBy(DateTime paymentDate);
        List<BL.PaymentDTO> FindByCustomer(int accountID);
        List<BL.PaymentDTO> FindAll();
    }
}
