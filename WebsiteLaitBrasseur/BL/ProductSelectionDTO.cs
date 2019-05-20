using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class ProductSelectionDTO
    {
        //private properties
        private int _id;
        private ProductDTO _selection;
        //private InvoiceDTO _invoice;
        private int _quantity;
        private decimal _origPrice;
        private int _origSize;

        //getter and setter
        public int GetID()
        {
            return this._id;
        }

        public void SetID(int id)
        {
            this._id = id;
        }

        public ProductDTO GetProduct()
        {
            return this._selection;
        }

        public void SetProduct(ProductDTO select)
        {
            this._selection = select;
        }

        public int GetQuantity()
        {
            return this._quantity;
        }

        public void SetQuantity(int quantity)
        {
            this._quantity = quantity;
        }

        public decimal GetOrigPrice()
        {
            return this._origPrice;
        }

        public void SetOrigPrice(decimal price)
        {
            this._origPrice = price;
        }

        public int GetOrigSize()
        {
            return this._origSize;
        }

        public void SetOrigSize(int size)
        {
            this._origSize = size;
        }

        //constructor
        public ProductSelectionDTO()
        {
        }

        public ProductSelectionDTO(int id, ProductDTO selection, int quantity, decimal origPrice, int origSize)
        {
            _id = id;
            _selection = selection;
            _quantity = quantity;
            _origPrice = origPrice;
            _origSize = origSize;
        }

        public override bool Equals(object obj)
        {
            return obj is ProductSelectionDTO selection &&
                   _id == selection._id &&
                   EqualityComparer<ProductDTO>.Default.Equals(_selection, selection._selection) &&
                   _quantity == selection._quantity &&
                   _origPrice == selection._origPrice;
        }

        public override int GetHashCode()
        {
            var hashCode = -692213418;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ProductDTO>.Default.GetHashCode(_selection);
            hashCode = hashCode * -1521134295 + _quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + _origPrice.GetHashCode();
            return hashCode;
        }
    }
}