using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class InvoiceDTO
    {
        //private properties
        private int _id;
        private AccountDTO _customer;
        private List<ProductSelectionDTO> _products;
        private ShippmentDTO _shipping;
        private int _totalQuantity;
        private decimal _totalShippingCost;
        private decimal _totalTaxes;
        private decimal _totalAmount;
        private DateTime _orderDate;
        private DateTime _paymentDate;
        private DateTime _arrivalDate;
        private DateTime _postageDate;
        private string _email ="";
        private int _paymentStatus = 0;

        //getter and setter
        public int GetID()
        {
            return this._id;
        }

        public void SetID(int id)
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

        public int GetQuantity()
        {
            return this._totalQuantity;
        }

        public void SetQuantity(int quantity)
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

        public DateTime GetPostDate()
        {
            return this._postageDate;
        }

        public void SetPostDate(DateTime date)
        {
            this._postageDate = date;
        }

        public DateTime GetArrivalDate()
        {
            return this._arrivalDate;
        }

        public void SetArrivalDate(DateTime date)
        {
            this._arrivalDate = date;
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
        public int GetStatus()
        {
            return this._paymentStatus;
        }

        public void SetStatus(int status)
        {
            this._paymentStatus = status;
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
            decimal totalAmount, DateTime orderDate, DateTime paymentDate, string email, int status) : this(id, customer, products, shipping, totalQuantity, totalShippingCost, totalTaxes, totalAmount, orderDate, paymentDate, email)
        {
            _paymentStatus = status;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceDTO dTO &&
                   _id == dTO._id &&
                   EqualityComparer<AccountDTO>.Default.Equals(_customer, dTO._customer) &&
                   EqualityComparer<List<ProductSelectionDTO>>.Default.Equals(_products, dTO._products) &&
                   EqualityComparer<ShippmentDTO>.Default.Equals(_shipping, dTO._shipping) &&
                   _totalQuantity == dTO._totalQuantity &&
                   _totalShippingCost == dTO._totalShippingCost &&
                   _totalTaxes == dTO._totalTaxes &&
                   _totalAmount == dTO._totalAmount &&
                   _orderDate == dTO._orderDate &&
                   _paymentDate == dTO._paymentDate &&
                   _email == dTO._email &&
                   _paymentStatus == dTO._paymentStatus;
        }

        public override int GetHashCode()
        {
            var hashCode = 382889966;
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
            hashCode = hashCode * -1521134295 + _paymentStatus.GetHashCode();
            return hashCode;
        }
    }
}