using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class Payment
    {
        //private properties
        private byte _id;
        private decimal _totalAmount;
        private DateTime _paymentDate;

        //getter and setter
        public int GetId()
        {
            return this._id;
        }

        public void SetId(byte id)
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

        //constructor
        public Payment()
        {
        }

        public Payment(byte id, decimal totalAmount, DateTime paymentDate)
        {
            _id = id;
            _totalAmount = totalAmount;
            _paymentDate = paymentDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Payment payment &&
                   _id == payment._id &&
                   _totalAmount == payment._totalAmount &&
                   _paymentDate == payment._paymentDate;
        }

        public override int GetHashCode()
        {
            var hashCode = -1479567049;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + _totalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + _paymentDate.GetHashCode();
            return hashCode;
        }
    }
}