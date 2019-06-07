using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class ProductSelectionDTO
    {
        //private properties
        private int id;
        private ProductDTO selection;
        private InvoiceDTO invoice;
        private int quantity;
        private decimal originalPrice;
        private int originalSize;

        //getter and setter
        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public ProductDTO GetProduct()
        {
            return this.selection;
        }

        public void SetProduct(ProductDTO select)
        {
            this.selection = select;
        }

        public InvoiceDTO GetInvoice()
        {
            return this.invoice;
        }

        public void SetInvoice(InvoiceDTO inv)
        {
            this.invoice = inv;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public decimal GetOrigPrice()
        {
            return this.originalPrice;
        }

        public void SetOrigPrice(decimal price)
        {
            this.originalPrice = price;
        }

        public int GetOrigSize()
        {
            return this.originalSize;
        }

        public void SetOrigSize(int size)
        {
            this.originalSize = size;
        }

        //constructor
        public ProductSelectionDTO()
        {
        }

        public ProductSelectionDTO(int id, ProductDTO selection, InvoiceDTO inv, int quantity, decimal origPrice, int origSize)
        {
            this.id = id;
            this.selection = selection;
            invoice = inv;
            this.quantity = quantity;
            originalPrice = origPrice;
            originalSize = origSize;
        }

        public override bool Equals(object obj)
        {
            return obj is ProductSelectionDTO selection &&
                   id == selection.id &&
                   EqualityComparer<ProductDTO>.Default.Equals(selection, selection.selection) &&
                   quantity == selection.quantity &&
                   originalPrice == selection.originalPrice;
        }

        public override int GetHashCode()
        {
            var hashCode = -692213418;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ProductDTO>.Default.GetHashCode(selection);
            hashCode = hashCode * -1521134295 + quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + originalPrice.GetHashCode();
            return hashCode;
        }
    }
}