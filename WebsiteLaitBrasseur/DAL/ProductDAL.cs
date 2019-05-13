using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class ProductDAL
    {
        //create
        public bool Create(byte id, string name, string type, string producer, float unitSize, 
            decimal price, string info, string shortInf)
        {
            try
            {
                //insert into database
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Create(byte id, string name, string type, string producer, float unitSize, decimal price, string info, 
            string shortInfo, string imgPath, byte stock, bool status)
        {
            try
            {
                //insert into database
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update
        //set status available or unavailable if product is not in store
        public bool Update(byte id, bool status)
        {
            try
            {
                //update into database where id = XY to status disabled(false) or enabled(true)
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update stock amount
        public bool Update(byte id, byte stock)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update product image
        public bool UpdateImg(byte id, string imgPath)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update producer
        public bool UpdateProducer(byte id, string producer)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update title/name
        public bool UpdateName(byte id, string name)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update short info
        public bool UpdateShortInfo(byte id, string longInfo)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update long info
        public bool UpdateLongInfo(byte id, string longInfo)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update complete info
        public bool Update(byte id, string longInfo, string shortInfo)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update unit size
        public bool Update(byte id, float unitSize)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update price
        public bool Update(byte id, decimal price)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update complete product 
        public bool Update(byte id, string name, string type, string producer, float unitSize, decimal price, string longInfo,
            string shortInfo, string imgPath, byte stock, bool status)
        {
            try
            {
                //update into database where id = XY to status disabled(false) or enabled(true)
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //read
        public Product FindBy(byte id)
        {
            Product product;
            try
            {
                product = new Product();
                //find entry in database where id = XY
                return product;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find a product by type 
        public List<Product> FindByType(string type)
        {
            Product product;
            List<Product> list = new List<Product>();
            try
            {
                product = new Product();
                //find entry in database where id = XY
                list.Add(product);
                
                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find a product by name 
        public List<Product> FindByName(string name)
        {
            Product product;
            List<Product> list = new List<Product>();
            try
            {
                product = new Product();
                //find entry in database where id = XY
                list.Add(product);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find a product by producer 
        public List<Product> FindByProducer(string producer)
        {
            Product product;
            List<Product> list = new List<Product>();
            try
            {
                product = new Product();
                //find entry in database where id = XY
                list.Add(product);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find a product by price
        public List<Product> FindByPrice(decimal price)
        {
            Product product;
            List<Product> list = new List<Product>();
            try
            {
                product = new Product();
                //find entry in database where id = XY
                list.Add(product);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find all products 
        public List<Product> FindAll()
        {
            Product product;
            List<Product> list = new List<Product>();
            try
            {
                product = new Product();
                //find entry in database where id = XY
                list.Add(product);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }
    }
}