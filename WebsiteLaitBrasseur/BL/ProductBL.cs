using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    /// <summary>
    /// Implements the complete business logic for 
    /// Products offered in the web/ecommerce store
    /// </summary>
    public class ProductBL
    {
        private readonly ProductDAL db = new ProductDAL();

        public Product GetProduct(int id)
        {
            Product product = new Product();
            try
            {
                product = db.FindBy(id);
                //TODO: if product is suspendet status = 1 
                //needs to be greyed out or not visible to customer
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return product;
        }

        public List<Product> GetProducts(string type)
        {
            List<Product> results = new List<Product>();
            try
            {
                results = db.FindByType(type);
                //TODO: if product is suspendet status = 1 
                //needs to be greyed out or not visible to customer
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> results = new List<Product>();
            try
            {
                results = db.FindAll(); 
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }
    }
}