using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class InvoiceDTO
    {
        //private properties
        private int id;
        private AccountDTO customer;
        private List<ProductSelectionDTO> products;
        private ShippmentDTO shippingCompany;
        private int totalQuantity;
        private decimal totalShippingCost;
        private decimal totalTaxes;
        private decimal totalAmount;
        private DateTime orderDate;
        private DateTime paymentDate;
        private DateTime arrivalDate;
        private DateTime postageDate;
        private string email;
        private int paymentStatus = 0;

        //getter and setter
        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public AccountDTO GetCustomer()
        {
            return this.customer;
        }

        public void SetCustomer(AccountDTO customer)
        {
            this.customer = customer;
        }

        public List<ProductSelectionDTO> GetProductSelections()
        {
            return products;
        }

        public void SetProductSelections(List<ProductSelectionDTO> selections)
        {
            this.products = selections;
        }

        public void AddProductSelection(ProductSelectionDTO selection)
        {
            products.Add(selection);
        }

        public ShippmentDTO GetShippment()
        {
            return this.shippingCompany;
        }

        public void SetShippment(ShippmentDTO shipping)
        {
            this.shippingCompany = shipping;
        }

        public int GetQuantity()
        {
            return this.totalQuantity;
        }

        public void SetQuantity(int quantity)
        {
            this.totalQuantity = quantity;
        }
        public decimal GetShippingCost()
        {
            return this.totalShippingCost;
        }

        public void SetShippingCost(decimal cost)
        {
            this.totalShippingCost = cost;
        }
        public decimal GetTax()
        {
            return this.totalTaxes;
        }

        public void SetTax(decimal tax)
        {
            this.totalTaxes = tax;
        }
        public decimal GetTotal()
        {
            return this.totalAmount;
        }

        public void SetTotal(decimal total)
        {
            this.totalAmount = total;
        }
        public DateTime GetOrderDate()
        {
            return this.orderDate;
        }

        public void SetOrderDate(DateTime date)
        {
            this.orderDate = date;
        }

        public DateTime GetPostDate()
        {
            return this.postageDate;
        }

        public void SetPostDate(DateTime date)
        {
            this.postageDate = date;
        }

        public DateTime GetArrivalDate()
        {
            return this.arrivalDate;
        }

        public void SetArrivalDate(DateTime date)
        {
            this.arrivalDate = date;
        }

        public DateTime GetPaymentDate()
        {
            return this.paymentDate;
        }

        public void SetPaymentDate(DateTime date)
        {
            this.paymentDate = date;
        }
        public string GetEmail()
        {
            return this.email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }
        public int GetStatus()
        {
            return this.paymentStatus;
        }

        public void SetStatus(int status)
        {
            this.paymentStatus = status;
        }

        //constructor
        public InvoiceDTO()
        {
            products = new List<ProductSelectionDTO>();
        }

        public InvoiceDTO(byte id, AccountDTO customer, List<ProductSelectionDTO> products, ShippmentDTO shipping, byte totalQuantity, decimal totalShippingCost, 
            decimal totalTaxes, decimal totalAmount, DateTime orderDate, DateTime paymentDate, string email)
        {
            this.id = id;
            this.customer = customer;
            this.products = products;
            shippingCompany = shipping;
            this.totalQuantity = totalQuantity;
            this.totalShippingCost = totalShippingCost;
            this.totalTaxes = totalTaxes;
            this.totalAmount = totalAmount;
            this.orderDate = orderDate;
            this.paymentDate = paymentDate;
            this.email = email;
        }

        public InvoiceDTO(byte id, AccountDTO customer, List<ProductSelectionDTO> products, ShippmentDTO shipping, byte totalQuantity, decimal totalShippingCost, decimal totalTaxes, 
            decimal totalAmount, DateTime orderDate, DateTime paymentDate, string email, int status) : this(id, customer, products, shipping, totalQuantity, totalShippingCost, totalTaxes, totalAmount, orderDate, paymentDate, email)
        {
            paymentStatus = status;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceDTO dTO &&
                   id == dTO.id &&
                   EqualityComparer<AccountDTO>.Default.Equals(customer, dTO.customer) &&
                   EqualityComparer<List<ProductSelectionDTO>>.Default.Equals(products, dTO.products) &&
                   EqualityComparer<ShippmentDTO>.Default.Equals(shippingCompany, dTO.shippingCompany) &&
                   totalQuantity == dTO.totalQuantity &&
                   totalShippingCost == dTO.totalShippingCost &&
                   totalTaxes == dTO.totalTaxes &&
                   totalAmount == dTO.totalAmount &&
                   orderDate == dTO.orderDate &&
                   paymentDate == dTO.paymentDate &&
                   email == dTO.email &&
                   paymentStatus == dTO.paymentStatus;
        }

        public override int GetHashCode()
        {
            var hashCode = 382889966;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<AccountDTO>.Default.GetHashCode(customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProductSelectionDTO>>.Default.GetHashCode(products);
            hashCode = hashCode * -1521134295 + EqualityComparer<ShippmentDTO>.Default.GetHashCode(shippingCompany);
            hashCode = hashCode * -1521134295 + totalQuantity.GetHashCode();
            hashCode = hashCode * -1521134295 + totalShippingCost.GetHashCode();
            hashCode = hashCode * -1521134295 + totalTaxes.GetHashCode();
            hashCode = hashCode * -1521134295 + totalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + orderDate.GetHashCode();
            hashCode = hashCode * -1521134295 + paymentDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + paymentStatus.GetHashCode();
            return hashCode;
        }
    }
}