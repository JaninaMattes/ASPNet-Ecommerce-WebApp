using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class PaymentDTO
    {
        //private properties
        private int id;
        private decimal totalAmount;
        private DateTime paymentDate;
        private AccountDTO customer;
        private InvoiceDTO invoice;

        //getter and setter
        public int GetId()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public decimal GetTotal()
        {
            return this.totalAmount;
        }

        public void SetTotal(decimal total)
        {
            this.totalAmount = total;
        }
        public DateTime GetPaymentDate()
        {
            return this.paymentDate;
        }

        public void SetPaymentDate(DateTime date)
        {
            this.paymentDate = date;
        }

        public InvoiceDTO GetInvoice()
        {
            return this.invoice;
        }

        public void SetInvoice(InvoiceDTO invoice)
        {
            this.invoice = invoice;
        }
        public AccountDTO GetCustomer()
        {
            return this.customer;
        }

        public void SetCustomer(AccountDTO customer)
        {
            this.customer = customer;
        }

        public override bool Equals(object obj)
        {
            return obj is PaymentDTO dTO &&
                   id == dTO.id &&
                   totalAmount == dTO.totalAmount &&
                   paymentDate == dTO.paymentDate &&
                   EqualityComparer<AccountDTO>.Default.Equals(customer, dTO.customer) &&
                   EqualityComparer<InvoiceDTO>.Default.Equals(invoice, dTO.invoice);
        }

        public override int GetHashCode()
        {
            var hashCode = 273543346;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + totalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + paymentDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<AccountDTO>.Default.GetHashCode(customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<InvoiceDTO>.Default.GetHashCode(invoice);
            return hashCode;
        }


        //constructor
        public PaymentDTO()
        {
        }

        public PaymentDTO(byte id, decimal totalAmount, DateTime paymentDate)
        {
            this.id = id;
            this.totalAmount = totalAmount;
            this.paymentDate = paymentDate;
        }

        public PaymentDTO(int id, decimal totalAmount, DateTime paymentDate, AccountDTO customer, InvoiceDTO invoice)
        {
            this.id = id;
            this.totalAmount = totalAmount;
            this.paymentDate = paymentDate;
            this.customer = customer;
            this.invoice = invoice;
        }
    }
}