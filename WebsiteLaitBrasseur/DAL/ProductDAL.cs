﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class ProductDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
        /// <summary>
        /// Insert new product into DB
        /// Returns integer value of ProductID
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="producer"></param>
        /// <param name="longInfo"></param>
        /// <param name="shortInfo"></param>
        /// <param name="imgPath"></param>
        /// <param name="stock"></param>
        /// <param name="status"></param>
        /// <returns>Int ProductID</returns>
        public int Insert(string name, string type, string producer, string longInfo, string shortInfo, string imgPath,
            int stock, int status)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Product(dbo.Product.pName, dbo.Product.pType, dbo.Product.producer, " +
                "dbo.Product.longInfo, dbo.Product.shortInfo, dbo.Product.imgPath, dbo.Product.inStock, dbo.Product.pStatus) " +
                "VALUES('@name', '@type', '@producer', '@longInfo', '@shortInfo', '@imgPath', @stock, @status)";
            string queryAutoIncr = "SELECT TOP(1) dbo.Product.productID FROM dbo.Product ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@mame", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@producer", producer);
                    cmd.Parameters.AddWithValue("@longInfo", longInfo);
                    cmd.Parameters.AddWithValue("@shortInfo", shortInfo);
                    cmd.Parameters.AddWithValue("@imgPath", imgPath);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }

                ///find the last manipulated id due to autoincrement and return it
                using (SqlCommand command = new SqlCommand(queryAutoIncr, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //won't need a while, since it will only retrieve one row
                    reader.Read();
                    //this is the id of the newly created data field
                    result = (Int32)reader["accountID"];
                    Debug.Print("ProductDAL: /Insert/ " + result.ToString());
                }
                return result;
            }
            catch (Exception e)
            {
                result = 0;
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Change the status of a product from available to unavailable
        /// This can be set by the administrator or if a product is out of stock.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateStatus(int id, int status)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET status = @status WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the stock of a product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateStock(int id, int stock)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET inStock = @stock WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the image path to set new image.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public int UpdateImg(int id, string imgPath)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET imgPath = @imgPath WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@imgPath", imgPath);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the producer name.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="producer"></param>
        /// <returns></returns>
        public int UpdateProducer(uint id, string producer)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET producer = @producer WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@producer", producer);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the title / name of the product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int UpdateName(int id, string name)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET pName = @name WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="longInfo"></param>
        /// <returns></returns>
        public int UpdateLongInfo(int id, string longInfo)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET longInfo = @longInfo WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@longInfo", longInfo);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shortInfo"></param>
        /// <returns></returns>
        public int UpdateShortInfo(int id, string shortInfo)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET shortInfo = @shortInfo WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@shortInfo", shortInfo);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update all product information.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="producer"></param>
        /// <param name="longInfo"></param>
        /// <param name="shortInfo"></param>
        /// <param name="imgPath"></param>
        /// <param name="stock"></param>
        /// <param name="status"></param>
        /// <returns></returns>        
        public int UpdateAll(int id, string name, string type, string producer, string longInfo, string shortInfo, string imgPath,
            int stock, int status)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product SET pName = @name, pType = @type, producer = @producer," +
                " longInfo = @longInfo, shortInfo = @shortInfo, imgPath = @imgPath, stock = @stock, pStatus = @status" +
                " WHERE productID = @id";
            try
            {
                //update into database where status = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@pNAme", name);
                    cmd.Parameters.AddWithValue("@pType", type);
                    cmd.Parameters.AddWithValue("@producer", producer);
                    cmd.Parameters.AddWithValue("@longInfo", longInfo);
                    cmd.Parameters.AddWithValue("@shortInfo", shortInfo);
                    cmd.Parameters.AddWithValue("@imgPath", imgPath);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@pStatus", status);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Find one specific product by its unique ID.
        /// The product needs to be added with size and price.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductDTO FindBy(int id)
        {
            string queryString = "SELECT * FROM dbo.Product WHERE productID=@id";
            ProductDTO product;
            try
            {                
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {                        
                        if (reader.Read())
                        {
                            product = new ProductDTO();
                            product.SetId((int)reader["productID"]);
                            product.SetName(reader["pName"].ToString());
                            product.SetType(reader["pType"].ToString());
                            product.SetProducer(reader["producer"].ToString());
                            product.SetInfo(reader["longInfo"].ToString());
                            product.SetShortInfo(reader["shortInfo"].ToString());
                            product.SetImgPath(reader["imgPath"].ToString());
                            product.SetStock((int)reader["inStock"]);
                            product.SetStatus((int)reader["pStatus"]);
                            //return product instance as data object 
                            Debug.Print("ProductDAL: /FindByID/ " + product.ToString());
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

        /// <summary>
        /// Find products by type and return them
        /// The sizes of each product needs to be added.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ProductDTO> FindByType(string type)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            string queryString = "SELECT * FROM dbo.Product WHERE pType=@type";
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@type", type);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductDTO product = new ProductDTO();
                                product.SetId((int)reader["productID"]);
                                product.SetName(reader["pName"].ToString());
                                product.SetType(reader["pType"].ToString());
                                product.SetProducer(reader["producer"].ToString());
                                product.SetInfo(reader["longInfo"].ToString());
                                product.SetShortInfo(reader["shortInfo"].ToString());
                                product.SetImgPath(reader["imgPath"].ToString());
                                product.SetStock((int)reader["inStock"]);
                                product.SetStatus((int)reader["pStatus"]);
                                //add data objects to result-list 
                                Debug.Print("ProductDAL: /FindByType/ " + product.ToString());
                                results.Add(product);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
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

        /// <summary>
        /// Find products by the name string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ProductDTO> FindByName(string name)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            string queryString = "SELECT * FROM dbo.Product WHERE pName=@name";
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@pName", name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductDTO product = new ProductDTO();
                                product.SetId((int)reader["productID"]);
                                product.SetName(reader["pName"].ToString());
                                product.SetType(reader["pType"].ToString());
                                product.SetProducer(reader["producer"].ToString());
                                product.SetInfo(reader["longInfo"].ToString());
                                product.SetShortInfo(reader["shortInfo"].ToString());
                                product.SetImgPath(reader["imgPath"].ToString());
                                product.SetStock((int)reader["inStock"]);
                                product.SetStatus((int)reader["pStatus"]);
                                //add data objects to result-list 
                                Debug.Print("ProductDAL: /FindByName/ " + product.ToString());
                                results.Add(product);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
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

        /// <summary>
        /// Find a specific productrange by a producer.
        /// </summary>
        /// <param name="producer"></param>
        /// <returns></returns>
        public List<ProductDTO> FindByProducer(string producer)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            string queryString = "SELECT * FROM dbo.Product WHERE producer=@producer";
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@producer", producer);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductDTO product = new ProductDTO();
                                product.SetId((int)reader["productID"]);
                                product.SetName(reader["pName"].ToString());
                                product.SetType(reader["pType"].ToString());
                                product.SetProducer(reader["producer"].ToString());
                                product.SetInfo(reader["longInfo"].ToString());
                                product.SetShortInfo(reader["shortInfo"].ToString());
                                product.SetImgPath(reader["imgPath"].ToString());
                                product.SetStock((int)reader["inStock"]);
                                product.SetStatus((int)reader["pStatus"]);
                                Debug.Print("ProductDAL: /FindByProducer/ " + product.ToString());
                                //add data objects to result-list 
                                results.Add(product);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
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

        /// <summary>
        /// Find all active products that have not been
        /// suspendet form the Product List.
        /// pStatus = 1 is active
        /// pStatus = 0 is inactive
        /// </summary>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public List<ProductDTO> FindActiveProducts(int pStatus)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            string queryString = "SELECT * FROM dbo.Product WHERE pStatus=@pStatus";
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@pStatus", pStatus);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductDTO product = new ProductDTO();
                                product.SetId((int)reader["productID"]);
                                product.SetName(reader["pName"].ToString());
                                product.SetType(reader["pType"].ToString());
                                product.SetProducer(reader["producer"].ToString());
                                product.SetInfo(reader["longInfo"].ToString());
                                product.SetShortInfo(reader["shortInfo"].ToString());
                                product.SetImgPath(reader["imgPath"].ToString());
                                product.SetStock((int)reader["inStock"]);
                                product.SetStatus((int)reader["pStatus"]);
                                Debug.Print("ProductDAL: /FindByStatus/ " + product.ToString());
                                //add data objects to result-list 
                                results.Add(product);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
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

        public List<ProductDTO> FindActiveProducts(int pStatus, string type)
        {
            List<ProductDTO> results = new List<ProductDTO>();
            string queryString = "SELECT * FROM dbo.Product WHERE pStatus=@pStatus AND pType = @type";
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@pStatus", pStatus);
                    cmd.Parameters.AddWithValue("@pType", type);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductDTO product = new ProductDTO();
                                product.SetId((int)reader["productID"]);
                                product.SetName(reader["pName"].ToString());
                                product.SetType(reader["pType"].ToString());
                                product.SetProducer(reader["producer"].ToString());
                                product.SetInfo(reader["longInfo"].ToString());
                                product.SetShortInfo(reader["shortInfo"].ToString());
                                product.SetImgPath(reader["imgPath"].ToString());
                                product.SetStock((int)reader["inStock"]);
                                product.SetStatus((int)reader["pStatus"]);
                                Debug.Print("ProductDAL: /FindByStatus/ " + product.ToString());
                                //add data objects to result-list 
                                results.Add(product);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
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

        /// <summary>
        /// Find all products that are in the DB
        /// The suspendet and not suspendet products 
        /// are included.
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> FindAll()
        {            
            List<ProductDTO> results = new List<ProductDTO>();
            string queryString = "SELECT * FROM dbo.Product";
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductDTO product = new ProductDTO();
                                product.SetId((int)reader["productID"]);
                                product.SetName(reader["pName"].ToString());
                                product.SetType(reader["pType"].ToString());
                                product.SetProducer(reader["producer"].ToString());
                                product.SetInfo(reader["longInfo"].ToString());
                                product.SetShortInfo(reader["shortInfo"].ToString());
                                product.SetImgPath(reader["imgPath"].ToString());
                                product.SetStock((int)reader["inStock"]);
                                product.SetStatus((int)reader["pStatus"]);
                                //add data objects to result-list 
                                Debug.Print("ProductDAL: /FindAll/ " + product.ToString());
                                results.Add(product);
                            }

                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
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
    }
}