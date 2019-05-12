using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class ProductSelection
    {
        //private properties
        private byte _id;
        private Product _selection;
        private int _quantity;
        private decimal _origPrice;

        //getter and setter
        public byte GetId()
        {
            return this._id;
        }

        public void SetId(byte id)
        {
            this._id = id;
        }

        public Product GetSelection()
        {
            return this._selection;
        }

        public void SetSelection(Product select)
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


        //constructor
        public ProductSelection()
        {
        }

        public ProductSelection(byte id, Product selection, int quantity, decimal origPrice)
        {
            _id = id;
            _selection = selection;
            _quantity = quantity;
            _origPrice = origPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is ProductSelection selection &&
                   _id == selection._id &&
                   EqualityComparer<Product>.Default.Equals(_selection, selection._selection) &&
                   _quantity == selection._quantity &&
                   _origPrice == selection._origPrice;
        }

        public override int GetHashCode()
        {
            var hashCode = -692213418;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Product>.Default.GetHashCode(_selection);
            hashCode = hashCode * -1521134295 + _quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + _origPrice.GetHashCode();
            return hashCode;
        }
    }
}