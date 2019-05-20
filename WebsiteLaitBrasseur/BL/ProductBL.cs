using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    /// <summary>
    /// Implements the complete business logic for 
    /// Products offered in the web/ecommerce store
    /// </summary>
    public class ProductBL
    {
        private readonly ProductDAL DB = new ProductDAL();
        private readonly SizeDAL SB = new SizeDAL();

        public ProductDTO GetProduct(int id)
        {
            ProductDTO product = new ProductDTO();
            List<SizeDTO> list = new List<SizeDTO>();
            try
            {
                product = DB.FindBy(id);
                //list = SB.FindByProduct(id);
                //product.SetDetails(list);
                
                //TODO: if product is suspendet status = 1 
                //needs to be greyed out or not visible to customer
            }
            catch (Exception e)
            {
                Debug.Write("Dans productBL");
                e.GetBaseException();
            }
            return product;
        }
        /// <summary>
        /// Find all products of a certain type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ProductDTO> GetProducts(string type)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            List<SizeDTO> list = new List<SizeDTO>();
            try
            {
                results = DB.FindByType(type);                
                foreach (ProductDTO p in results)
                {
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("debugging--" + p);
                }
                
                //TODO: if product is suspendet status = 0 
                //needs to be greyed out or not visible to customer
                for (int i = 0; i < results.Count(); i++)
                {
                    list = SB.FindByProduct(results[i].GetId());
                    results[i].SetDetails(list);
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("ProductBL / products found / " + results[i].GetId());
                    results[i] = results[i];
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all active products in the system.
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAllActiveProducts()
        {
            List<ProductDTO> results = new List<ProductDTO>();
            List<SizeDTO> list = new List<SizeDTO>();
            int status = 1;
            try
            {
                results = DB.FindActiveProducts(status);
                for (int i = 0; i < results.Count(); i++)
                {
                    list = SB.FindByProduct(results[i].GetId());
                    results[i].SetDetails(list);
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("ProductBL / products found / " + results[i].GetId());
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all products that are active and from
        /// a specific type = 'Cheese' or 'Beer'
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ProductDTO> GetAllActiveProducts(string type)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            List<SizeDTO> list = new List<SizeDTO>();
            int status = 1;
            try
            {
                results = DB.FindActiveProducts(status, type);
                for (int i = 0; i < results.Count(); i++)
                {
                    list = SB.FindByProduct(results[i].GetId());
                    results[i].SetDetails(list);
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("ProductBL / products found / " + results[i].GetId());
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }
        
        /// <summary>
        /// Find all inactive products in the system.
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAllInactiveProducts()
        {
            List<ProductDTO> results = new List<ProductDTO>();
            List<SizeDTO> list = new List<SizeDTO>();
            int status = 0;
            try
            {
                results = DB.FindActiveProducts(status);
                for (int i = 0; i < results.Count(); i++)
                {
                    list = SB.FindByProduct(results[i].GetId());
                    results[i].SetDetails(list);
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("ProductBL / products found / " + results[i].GetId());
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all products in the DB.
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> results = new List<ProductDTO>();
            List<SizeDTO> list = new List<SizeDTO>();

            try
            {
                results = DB.FindAll();
                for (int i = 0; i < results.Count(); i++)
                {
                    list = SB.FindByProduct(results[i].GetId());
                    results[i].SetDetails(list);
                    //debugging purpose, will later remove
                    System.Diagnostics.Debug.WriteLine("ProductBL / products found / " + results[i].GetId());
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Update all product informations.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="producer"></param>
        /// <param name="longInfo"></param>
        /// <param name="shortInfo"></param>
        /// <param name="imgPath"></param>
        /// <param name="stock"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Update(int productID, string name, string type, string producer, string longInfo, string shortInfo, string imgPath,
            int stock, int status)
        {
            int result = 0;
            result = DB.UpdateAll(productID, name, type, producer, longInfo, shortInfo, imgPath, stock, status);
            return result;
        }

        /// <summary>
        /// Update the status of one product.
        /// status = 1 activated
        /// status = 0 deactivated
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int ChangeStatus(int productID, int status)
        {
            int result = 0;
            try
            {
                result = DB.UpdateStatus(productID, status);
            }catch(Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the stock available after customer 
        /// has pruchased a product.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int ChangeStock(int productID, int stock)
        {
            int result = 0;
            try
            {
                result = DB.UpdateStock(productID, stock);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }
    }
}