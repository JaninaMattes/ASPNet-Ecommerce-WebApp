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


        public int CreateProduct(int size, decimal price, List<SizeDTO> details, string name, string type, string producer, string longInfo, string shortInfo, string imgPath,
            int stock, int status)
        {
            int result = 0;
            try

            {
                //Product part
                result = DB.Insert(name, type, producer, longInfo, shortInfo, imgPath, stock, status);
                if (result != 0)
                {
                    foreach (SizeDTO s in details)
                    {
                        SB.Insert(s.GetSize(), s.GetPrice(), result);
                    }
                }
                else
                {
                    Debug.Print("Error, the returned ID is " + result);
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception in ProductBL");
                e.GetBaseException();
            }
            return result;
        }


        public int CreateProduct2(int size, decimal price, string name, string type, string producer, string longInfo, string shortInfo, string imgPath, int stock, int status)
        {
            int result = 0;
            try

            {
                //Product part
                result = DB.Insert(name, type, producer, longInfo, shortInfo, imgPath, stock, status);
                if (result == 0) { Debug.Print("Error in product insertion, the returned ID is " + result); }

                //Size Part
                result = SB.Insert(size, price, result);
                if (result == 0) { Debug.Print("Error in size insertion, the returned ID is " + result); }
            }

            catch (Exception e)
            {
                Debug.Print("Exception in ProductBL");
                e.GetBaseException();
            }
            return result;
        }




        /// <summary>
        /// Using this function means that
        /// later on the fields in the DB need 
        /// to be explicitly updated.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int CreateProduct(List<SizeDTO> details, string name, string type, int status)
        {
            int result = 0;
            try
            {
                //if this function is used, the fields need to be updated later
                result = DB.Insert(name, type, " ", " ", " ", " ", 0, status);
                if (result != 0)
                {
                    foreach (SizeDTO s in details)
                    {
                        SB.Insert(s.GetSize(), s.GetPrice(), result);
                    }
                }
                else
                {
                    Debug.Print("Error, the returned ID is " + result);
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception in ProductBL");
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Using this function means that
        /// later on the fields in the DB need 
        /// to be explicitly updated.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int CreateProduct(List<SizeDTO> details, string shortInfo, string longInfo, string producer, string imgPath)
        {
            int result = 0;
            try
            {
                //if this function is used, the fields need to be updated later
                result = DB.Insert(" ", " ", producer, longInfo, shortInfo, imgPath, 0, 0);
                if (result != 0)
                {
                    foreach (SizeDTO s in details)
                    {
                        SB.Insert(s.GetSize(), s.GetPrice(), result);
                    }
                }
                else
                {
                    Debug.Print("Error, the returned ID is " + result);
                }

            }
            catch (Exception e)
            {
                Debug.Print("Exception in ProductBL");
                e.GetBaseException();
            }
            return result;
        }

        public ProductDTO GetProduct(int id)
        {
            ProductDTO product = new ProductDTO();
            List<SizeDTO> list = new List<SizeDTO>();
            try
            {
                product = DB.FindBy(id);
                list = SB.FindByProduct(id);
                product.SetDetails(list);
                
                //TODO: if product is suspendet status = 1 
                //needs to be greyed out or not visible to customer
            }
            catch (Exception e)
            {
                Debug.Print("Exception in ProductBL");
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
        /// Update only certain information
        /// the return value should be > 0 if 
        /// the changes were successfull.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="details"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Update(int productID, List<SizeDTO> details, string name, string type, int status)
        {
            ProductDTO product = new ProductDTO();
            int result = 0;
            try
            {                
                result = DB.Update(productID, name, type, status);
                product = DB.FindBy(result);
                    foreach (SizeDTO s in details)
                {
                    result = SB.UpdateSize(s.GetID(), s.GetSize(), s.GetPrice(), product.GetId());
                }                
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }           
            return result;
        }

        /// <summary>
        /// Update only certain information
        /// the return value should be > 0 if 
        /// the changes were successfull.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="size"></param>
        /// <param name="price"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Update2(int productID, int size, decimal price, string name, string type, int stock, int status)
        {
            ProductDTO product = new ProductDTO();
            int result = 0;
            try
            {
                result = DB.Update2(productID, name, type,stock, status);
                SB.UpdateSize2(productID, size, price);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }



        /// <summary>
        /// Update only certain information
        /// the return value should be > 0 if 
        /// the changes were successfull.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateItem(int productID, string name, string type, int status)
        {
            ProductDTO product = new ProductDTO();
            int result = 0;
            try
            {
                result = DB.Update(productID, name, type, status);
                product = DB.FindBy(result);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update only certain information
        /// the return value should be > 0 if 
        /// the changes were successfull.
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="details"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Update(int productID, List<SizeDTO> details, string shortInfo, string longInfo, string producer, string imgPath)
        {
            ProductDTO product = new ProductDTO();
            int result = 0;
            try
            {
                result = DB.Update(productID, shortInfo, longInfo, producer, imgPath);
                product = DB.FindBy(result);
                foreach (SizeDTO s in details)
                {
                    result = SB.UpdateSize(s.GetID(), s.GetSize(), s.GetPrice(), product.GetId());
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update not only product but also its size in the DB
        /// If a product int the sortiment has changed compeletely.
        /// Result will be > 1 if all product sizes have been successfully e
        /// updated into the DB. 
        /// </summary>
        /// <param name="details"></param>
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
        public int UpdateAll(List<SizeDTO> details, int productID, string name, string type, string producer, string longInfo, string shortInfo, string imgPath,
           int stock, int status)
        {
            int result = 0;
            try
            {
                result = DB.UpdateAll(productID, name, type, producer, longInfo, shortInfo, imgPath, stock, status);
                if (result != 0)
                {
                    foreach (SizeDTO s in details)
                    {
                        result += SB.UpdateSize(s.GetID(), s.GetSize(), s.GetPrice(), productID);
                    }
                }
                else
                {
                    Debug.Print("Error, the returned result is " + result);
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
           
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

        /// <summary>
        /// Update only the size in a product
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public int ChangeSize(int productID, List<SizeDTO>details)
        {
            int result = 0;
            try
            {
                foreach (SizeDTO size in details)
                {
                    result = SB.UpdateSize(size.GetID(), size.GetSize(), size.GetPrice(), productID);
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }
    }
}