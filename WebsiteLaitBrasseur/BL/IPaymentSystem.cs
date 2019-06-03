using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT3050.PaymentSystem
{
    /// <summary>
    /// Result of a transaction
    /// </summary>
    public enum TransactionResult
    {
        Approved,
        Declined,
        InvalidCard,
        InvalidExpiry,
        ConnectionFailure
    }

    /// <summary>
    /// An attempted credit card payment
    /// </summary>
    public class PaymentRequest
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public DateTime Expiry { get; set; }
        public int CVC { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// The result of an attempted payment
    /// </summary>
    public class PaymentResult
    {
        public TransactionResult TransactionResult { get; set;  }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public long ReceiptId { get; set; }
    }
   

    /// <summary>
    /// Payment system interface - takes a payment request and will return a 
    /// task that on completion will return a result. By using an interface here 
    /// we create a system that can easily be swapped for unit testing, and later changes 
    /// to payment sytems 
    /// </summary>
    public interface IPaymentSystem
    {
        Task<PaymentResult> MakePayment(PaymentRequest payment);
    }
}
