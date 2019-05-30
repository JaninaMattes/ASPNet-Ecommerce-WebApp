using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    [DataObject(true)]
    public class SizeDAL: ISizeDataAccess
    {
        //Get connection string from web.config file and create sql connection
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LaitBrasseurDB"].ConnectionString;
            }
        }

        /// <summary>
        /// Insert new value into DB
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="isConfirmed"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="birthdate"></param>
        /// <param name="phoneNo"></param>
        /// <param name="imgPath"></param>
        /// <param name="status"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(int size, decimal price, int productID)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Size(dbo.Size.productID, dbo.Size.unitSize, dbo.Size.unitPrice) " +
                "VALUES(@productID, @size, @price )";
            string queryAutoIncr = "SELECT TOP(1) dbo.Size.sizeID FROM dbo.Size ORDER BY 1 DESC";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@size", SqlDbType.Int).Value = size;
                        cmd.Parameters.AddWithValue("@price", SqlDbType.Decimal).Value = price;
                        cmd.Parameters.AddWithValue("@productID", SqlDbType.Int).Value = productID;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    }
                }

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    ///find the last manipulated id due to autoincrement and return it
                    using (SqlCommand cmd = new SqlCommand(queryAutoIncr, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        //won't need a while, since it will only retrieve one row
                        reader.Read();
                        //this is the id of the newly created data field
                        result = Convert.ToInt32(reader["sizeID"]);
                        Debug.Print("SizeDAL: /Insert ID/ " + result.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                result = 0;
                Debug.Write("SizeDAL / Exception"); //DEBUG
                e.GetBaseException();
            }
            return result;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateSize(int id, int size, decimal price, int productID)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Size SET unitSize = @size, unitPrice = @price, productID = @productID WHERE sizeID = @id";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.AddWithValue("@size", SqlDbType.Int).Value = size;
                        cmd.Parameters.AddWithValue("@price", SqlDbType.Decimal).Value = price;
                        cmd.Parameters.AddWithValue("@productID", SqlDbType.Int).Value = productID;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateSize2(int productID, int size, decimal price)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Size SET unitSize = @size, unitPrice = @price WHERE productID = @id";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = productID;
                        cmd.Parameters.AddWithValue("@size", SqlDbType.Int).Value = size;
                        cmd.Parameters.AddWithValue("@price", SqlDbType.Decimal).Value = price;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }


        /// <summary>
        /// Find one specific entrance in the DB
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public SizeDTO FindByID(int sizeID)
        {
            SizeDTO size;
            ProductDTO product;
            string queryString = "SELECT * FROM dbo.Size WHERE sizeID = @sizeID";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@sizeID", SqlDbType.Int).Value = sizeID;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            size = new SizeDTO();
                            product = new ProductDTO();
                            size = GenerateDetail(reader, product, size);
                            //return product instance as data object 
                            Debug.Print("SizeDAL: /FindByProduct/ " + size.GetID().ToString());
                            return size;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            return null;
        }

        /// <summary>
        /// Find all sizes that are associated with one specific product.
        /// These can then later be shown in a drop down menue.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SizeDTO> FindByProduct(int productID)
        {
            SizeDTO size;
            ProductDTO product;
            List<SizeDTO> results = new List<SizeDTO>();
            string queryString = "SELECT * FROM dbo.Size WHERE productID = @id";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = productID;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            size = new SizeDTO();
                            product = new ProductDTO();
                            size = GenerateDetail(reader, product, size);
                            //return product instance as data object 
                            Debug.Print("SizeDAL: /FindByProduct/ " + size.GetID().ToString());
                            results.Add(size);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all sizes and their prices available in the DB.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SizeDTO> FindAll()
        {
            SizeDTO size;
            ProductDTO product;
            List<SizeDTO> results = new List<SizeDTO>();
            string queryString = "SELECT * FROM dbo.Size";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            size = new SizeDTO();
                            product = new ProductDTO();
                            size = GenerateDetail(reader, product, size);
                            //return product instance as data object 
                            Debug.Print("SizeDAL: /FindByAll/ " + size.GetID().ToString());
                            results.Add(size);
                        }                            
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Get the price of a product in function of its size.
        /// <param name="productID" , size="UnitSize"></param>
        /// <returns>Price</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public SizeDTO FindPriceBySize(int productID, int sizeProduct)
        {
            SizeDTO size;
            ProductDTO product;
            string queryString = "SELECT * FROM dbo.Size WHERE unitSize = @unitSize AND productID = @id";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@unitSize", SqlDbType.Decimal).Value = sizeProduct;
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = productID;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            size = new SizeDTO();
                            product = new ProductDTO();
                            size = GenerateDetail(reader, product, size);
                            //return product instance as data object 
                            Debug.Print("SizeDAL: /FindByProduct/ " + size.GetID().ToString());
                            return size;
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

        private static SizeDTO GenerateDetail(SqlDataReader reader, ProductDTO product, SizeDTO size)
        {
            product.SetId(Convert.ToInt32(reader["productID"]));
            size.SetProduct(product);
            size.SetID(Convert.ToInt32(reader["sizeID"]));
            size.SetPrice(Convert.ToDecimal(reader["unitPrice"]));
            size.SetSize(Convert.ToInt32(reader["unitSize"]));
            return size;
        }
    }
}