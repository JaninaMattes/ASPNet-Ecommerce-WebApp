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

        public ProductDTO GetProduct(int id)
        {
            ProductDTO product = new ProductDTO();
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

        public List<ProductDTO> GetProducts(string type)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            try
            {
                results = db.FindByType(type);
                //TODO: if product is suspendet status = 0 
                //needs to be greyed out or not visible to customer
                for (int i = 0; i < results.Count(); i++)
                {
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("products found--" + results[i].GetId());
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> results = new List<ProductDTO>();
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