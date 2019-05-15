﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class Invoice
    {
        //private properties
        private byte _id;
        private AccountBO _customer;
        private List<ProductSelection> _products;
        private Shippment _shipping;
        private byte _totalQuantity;
        private decimal _totalShippingCost;
        private decimal _totalTaxes;
        private decimal _totalAmount;
        private DateTime _orderDate;
        private DateTime _paymentDate;
        private string _email;
        private bool _status = false;

        //getter and setter
        public byte GetId()
        {
            return this._id;
        }

        public void SetId(byte id)
        {
            this._id = id;
        }

        public AccountBO GetCustomer()
        {
            return this._customer;
        }

        public void SetCustomer(AccountBO customer)
        {
            this._customer = customer;
        }

        public List<ProductSelection> GetProductSelections()
        {
            return _products;
        }

        public void SetProductSelections(List<ProductSelection> selections)
        {
            this._products = selections;
        }

        public void AddProductSelection(ProductSelection selection)
        {
            _products.Add(selection);
        }

        public Shippment GetShippment()
        {
            return this._shipping;
        }

        public void SetShippment(Shippment shipping)
        {
            this._shipping = shipping;
        }

        public byte GetQuantity()
        {
            return this._totalQuantity;
        }

        public void SetQuantity(byte quantity)
        {
            this._totalQuantity = quantity;
        }
        public decimal GetShippingCost()
        {
            return this._totalShippingCost;
        }

        public void SetShippingCost(decimal cost)
        {
            this._totalShippingCost = cost;
        }
        public decimal GetTax()
        {
            return this._totalTaxes;
        }

        public void SetTax(decimal tax)
        {
            this._totalTaxes = tax;
        }
        public decimal GetTotal()
        {
            return this._totalAmount;
        }

        public void SetTotal(decimal total)
        {
            this._totalAmount = total;
        }
        public DateTime GetOrderDate()
        {
            return this._orderDate;
        }

        public void SetOrderDate(DateTime date)
        {
            this._orderDate = date;
        }
        public DateTime GetPaymentDate()
        {
            return this._paymentDate;
        }

        public void SetPaymentDate(DateTime date)
        {
            this._paymentDate = date;
        }
        public string GetEmail()
        {
            return this._email;
        }

        public void SetEmail(string email)
        {
            this._email = email;
        }
        public bool GetStatus()
        {
            return this._status;
        }

        public void SetStatus(bool status)
        {
            this._status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is Invoice invoice &&
                   _id == invoice._id &&
                   EqualityComparer<AccountBO>.Default.Equals(_customer, invoice._customer) &&
                   EqualityComparer<List<ProductSelection>>.Default.Equals(_products, invoice._products) &&
                   EqualityComparer<Shippment>.Default.Equals(_shipping, invoice._shipping) &&
                   _totalQuantity == invoice._totalQuantity &&
                   _totalShippingCost == invoice._totalShippingCost &&
                   _totalTaxes == invoice._totalTaxes &&
                   _totalAmount == invoice._totalAmount &&
                   _orderDate == invoice._orderDate &&
                   _paymentDate == invoice._paymentDate &&
                   _email == invoice._email &&
                   _status == invoice._status;
        }

        public override int GetHashCode()
        {
            var hashCode = 147119704;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<AccountBO>.Default.GetHashCode(_customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProductSelection>>.Default.GetHashCode(_products);
            hashCode = hashCode * -1521134295 + EqualityComparer<Shippment>.Default.GetHashCode(_shipping);
            hashCode = hashCode * -1521134295 + _totalQuantity.GetHashCode();
            hashCode = hashCode * -1521134295 + _totalShippingCost.GetHashCode();
            hashCode = hashCode * -1521134295 + _totalTaxes.GetHashCode();
            hashCode = hashCode * -1521134295 + _totalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + _orderDate.GetHashCode();
            hashCode = hashCode * -1521134295 + _paymentDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_email);
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            return hashCode;
        }

        //constructor
        public Invoice()
        {
            _products = new List<ProductSelection>();
        }

        public Invoice(byte id, AccountBO customer, List<ProductSelection> products, Shippment shipping, byte totalQuantity, decimal totalShippingCost, 
            decimal totalTaxes, decimal totalAmount, DateTime orderDate, DateTime paymentDate, string email)
        {
            _id = id;
            _customer = customer;
            _products = products;
            _shipping = shipping;
            _totalQuantity = totalQuantity;
            _totalShippingCost = totalShippingCost;
            _totalTaxes = totalTaxes;
            _totalAmount = totalAmount;
            _orderDate = orderDate;
            _paymentDate = paymentDate;
            _email = email;
        }

        public Invoice(byte id, AccountBO customer, List<ProductSelection> products, Shippment shipping, byte totalQuantity, decimal totalShippingCost, decimal totalTaxes, 
            decimal totalAmount, DateTime orderDate, DateTime paymentDate, string email, bool status) : this(id, customer, products, shipping, totalQuantity, totalShippingCost, totalTaxes, totalAmount, orderDate, paymentDate, email)
        {
            _status = status;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}