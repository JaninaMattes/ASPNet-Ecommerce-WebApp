using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class PaymentDTO
    {
        //private properties
        private int _id;
        private decimal _totalAmount;
        private DateTime _paymentDate;
        private AccountDTO _customer;
        private InvoiceDTO _invoice;

        //getter and setter
        public int GetId()
        {
            return this._id;
        }

        public void SetID(int id)
        {
            this._id = id;
        }

        public decimal GetTotal()
        {
            return this._totalAmount;
        }

        public void SetTotal(decimal total)
        {
            this._totalAmount = total;
        }
        public DateTime GetPaymentDate()
        {
            return this._paymentDate;
        }

        public void SetPaymentDate(DateTime date)
        {
            this._paymentDate = date;
        }

        public InvoiceDTO GetInvoice()
        {
            return this._invoice;
        }

        public void SetInvoice(InvoiceDTO invoice)
        {
            this._invoice = invoice;
        }
        public AccountDTO GetCustomer()
        {
            return this._customer;
        }

        public void SetCustomer(AccountDTO customer)
        {
            this._customer = customer;
        }

        public override bool Equals(object obj)
        {
            return obj is PaymentDTO dTO &&
                   _id == dTO._id &&
                   _totalAmount == dTO._totalAmount &&
                   _paymentDate == dTO._paymentDate &&
                   EqualityComparer<AccountDTO>.Default.Equals(_customer, dTO._customer) &&
                   EqualityComparer<InvoiceDTO>.Default.Equals(_invoice, dTO._invoice);
        }

        public override int GetHashCode()
        {
            var hashCode = 273543346;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + _totalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + _paymentDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<AccountDTO>.Default.GetHashCode(_customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<InvoiceDTO>.Default.GetHashCode(_invoice);
            return hashCode;
        }


        //constructor
        public PaymentDTO()
        {
        }

        public PaymentDTO(byte id, decimal totalAmount, DateTime paymentDate)
        {
            _id = id;
            _totalAmount = totalAmount;
            _paymentDate = paymentDate;
        }

        public PaymentDTO(int id, decimal totalAmount, DateTime paymentDate, AccountDTO customer, InvoiceDTO invoice)
        {
            _id = id;
            _totalAmount = totalAmount;
            _paymentDate = paymentDate;
            _customer = customer;
            _invoice = invoice;
        }
    }
}