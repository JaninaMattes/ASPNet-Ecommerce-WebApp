using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class InvoiceDTO
    {
        //private properties
        private byte _id;
        private AccountDTO _customer;
        private List<ProductSelectionDTO> _products;
        private ShippmentDTO _shipping;
        private byte _totalQuantity;
        private decimal _totalShippingCost;
        private decimal _totalTaxes;
        private decimal _totalAmount;
        private DateTime _orderDate;
        private DateTime _paymentDate;
        private string _email ="";
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

        public AccountDTO GetCustomer()
        {
            return this._customer;
        }

        public void SetCustomer(AccountDTO customer)
        {
            this._customer = customer;
        }

        public List<ProductSelectionDTO> GetProductSelections()
        {
            return _products;
        }

        public void SetProductSelections(List<ProductSelectionDTO> selections)
        {
            this._products = selections;
        }

        public void AddProductSelection(ProductSelectionDTO selection)
        {
            _products.Add(selection);
        }

        public ShippmentDTO GetShippment()
        {
            return this._shipping;
        }

        public void SetShippment(ShippmentDTO shipping)
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
            return obj is InvoiceDTO invoice &&
                   _id == invoice._id &&
                   EqualityComparer<AccountDTO>.Default.Equals(_customer, invoice._customer) &&
                   EqualityComparer<List<ProductSelectionDTO>>.Default.Equals(_products, invoice._products) &&
                   EqualityComparer<ShippmentDTO>.Default.Equals(_shipping, invoice._shipping) &&
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
            hashCode = hashCode * -1521134295 + EqualityComparer<AccountDTO>.Default.GetHashCode(_customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProductSelectionDTO>>.Default.GetHashCode(_products);
            hashCode = hashCode * -1521134295 + EqualityComparer<ShippmentDTO>.Default.GetHashCode(_shipping);
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
        public InvoiceDTO()
        {
            _products = new List<ProductSelectionDTO>();
        }

        public InvoiceDTO(byte id, AccountDTO customer, List<ProductSelectionDTO> products, ShippmentDTO shipping, byte totalQuantity, decimal totalShippingCost, 
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

        public InvoiceDTO(byte id, AccountDTO customer, List<ProductSelectionDTO> products, ShippmentDTO shipping, byte totalQuantity, decimal totalShippingCost, decimal totalTaxes, 
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