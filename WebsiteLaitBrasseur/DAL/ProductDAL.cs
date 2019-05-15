using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class ProductDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
        //create
        public bool Create(uint id, string name, string type, string producer, float unitSize, 
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

        public bool Create(uint id, string name, string type, string producer, float unitSize, decimal price, string info, 
            string shortInfo, string imgPath, uint stock, bool status)
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
        public bool Update(uint id, bool status)
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
        public bool Update(uint id, uint stock)
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
        public bool UpdateImg(uint id, string imgPath)
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
        public bool UpdateProducer(uint id, string producer)
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
        public bool UpdateName(uint id, string name)
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
        public bool UpdateShortInfo(uint id, string longInfo)
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
        public bool UpdateLongInfo(uint id, string longInfo)
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
        public bool Update(uint id, string longInfo, string shortInfo)
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
        public bool Update(uint id, float unitSize)
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
        public bool Update(uint id, decimal price)
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
        public bool Update(uint id, string name, string type, string producer, float unitSize, decimal price, string longInfo,
            string shortInfo, string imgPath, uint stock, bool status)
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
        public Product FindBy(int id)
        {
            string queryString = "SELECT * FROM dbo.Product WHERE productID=@id";
            Product product;
            try
            {                
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {                        
                        if (reader.Read())
                        {
                            product = new Product();
                            product.SetId((int)reader["productID"]);
                            product.SetName(reader["pName"].ToString());
                            product.SetType(reader["pType"].ToString());
                            product.SetProducer(reader["producer"].ToString());
                            product.SetUnit((float)reader["unitSize"]);
                            product.SetPrice((decimal)reader["unitPrice"]);
                            product.SetInfo(reader["longInfo"].ToString());
                            product.SetShortInfo(reader["shortInfo"].ToString());
                            product.SetImgPath(reader["imgPath"].ToString());
                            product.SetStock((int)reader["inStock"]);
                            product.SetStatus((int)reader["pStatus"]);
                            //return product instance as data object 
                            return product;
                        }                         
                    }
                }   
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