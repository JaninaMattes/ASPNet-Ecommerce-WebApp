using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class SizeDTO
    {
        private int _id;
        private int _size;
        private decimal _price;
        private ProductDTO _product;

        //getter and setter
        public int GetID()
        {
            return this._id;
        }

        public void SetID(int id)
        {
            this._id = id;
        }

        public int GetSize()
        {
            return this._size;
        }

        public void SetSize(int size)
        {
            this._size = size;
        }

        public decimal GetPrice()
        {
            return this._price;
        }

        public void SetPrice(decimal price)
        {
            this._price = price;
        }

        public ProductDTO GetProduct()
        {
            return this._product;
        }

        public void SetProduct(ProductDTO product)
        {
            this._product = product;
        }

        public SizeDTO()
        {
        }

        public SizeDTO(int id, int size, decimal price, ProductDTO product)
        {
            _id = id;
            _size = size;
            _price = price;
            _product = product;
        }
    }
}