using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class SizeDTO
    {
        private int id;
        private int size;
        private decimal price;
        private ProductDTO product;

        //getter and setter
        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public int GetSize()
        {
            return this.size;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }

        public decimal GetPrice()
        {
            return this.price;
        }

        public void SetPrice(decimal price)
        {
            this.price = price;
        }

        public ProductDTO GetProduct()
        {
            return this.product;
        }

        public void SetProduct(ProductDTO product)
        {
            this.product = product;
        }

        //constructor
        public SizeDTO()
        {
        }

        public SizeDTO(int id, int size, decimal price, ProductDTO product)
        {
            this.id = id;
            this.size = size;
            this.price = price;
            this.product = product;
        }
    }
}