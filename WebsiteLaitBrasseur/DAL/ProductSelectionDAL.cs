using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class ProductSelectionDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);

        /// <summary>
        /// Insert a new ProductSelection Object to 
        /// store the original details of a purchased product.
        /// Returns integer value of ProductSelection ID
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <param name="quantity"></param>
        /// <param name="origPrice"></param>
        /// <returns>Int ProductSelection</returns>
        public int Insert(int invoiceID, int quantity, int origSize, decimal origPrice)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.ProductSelection(dbo.ProductSelection.invoiceID, dbo.ProductSelection.quantity, " +
                "dbo.ProductSelection.originalSize, dbo.ProductSelection.originalPrice)" +
                "VALUES(@invoiceID, @quantity, @originalSize, @originalPrice)";
            string queryAutoIncr = "SELECT TOP(1) dbo.ProductSelection.selectionID FROM dbo.ProductSelection ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@invoiceID", invoiceID);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@originalPrice", origPrice);
                    cmd.Parameters.AddWithValue("@originalSize", origSize);
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
                    result = (Int32)reader["paymentID"];
                    Debug.Print("ProductSelectionDAL: /Insert/ " + result.ToString());
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
        /// Needs to allow to insert also into the n:m table Product_ProdSelection
        /// The selectionID needs to be set explicitely after the first insertion.
        /// Returns the affected rows not the ID as the table has a combined FK/RK. 
        /// </summary>
        /// <param name="selectionID"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public int Insert(int selectionID, int productID)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Product_ProdSelection(dbo.Product_ProdSelection.productID, dbo.Product_ProdSelection.selectionID)" +
                "VALUES(@selectionID, @productID)";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@selectionID", selectionID);
                    cmd.Parameters.AddWithValue("@productID", productID);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                result = 0;
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// This returns the number of affected rows in the table.
        /// If success full the result = 1
        /// If not successfull the result = 0
        /// 
        /// If the product is updated in the Product_ProdSelection Table
        /// the original price in the ProductSelection Table needs to be
        /// updated as well.
        /// </summary>
        /// <param name="selectionID"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public int UpdateProduct(int selectionID, int productID)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product_ProdSelection SET productID = @productID WHERE selectionID = @selectionID";

            try
            {
                //update into database where id = XY 
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@productID", productID);
                    cmd.Parameters.AddWithValue("@selectionID", selectionID);
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
        /// Update the selected quantity in the database.
        /// On successfull operation the result = 1
        /// </summary>
        /// <param name="selectionID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int UpdateQuantity(int selectionID, int quantity)
        {
            int result = 0;
            string queryString = "UPDATE dbo.ProductSelection SET quantity = @quantity WHERE selectionID = @selectionID";

            try
            {
                //update into database where id = XY 
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@selectionID", selectionID);
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
        /// When the Product_ProdSelection table is updated with new products selected
        /// then the ProductSelection table needs to be updated also with the original 
        /// price to store these and freeze an old state of a product in the shopping 
        /// history.
        /// </summary>
        /// <param name="selectionID"></param>
        /// <param name="origPrice"></param>
        /// <returns></returns>
        public int Update(int selectionID, decimal origPrice)
        {
            int result = 0;
            string queryString = "UPDATE dbo.ProductSelection SET originalPrice = @originalPrice WHERE selectionID = @selectionID";

            try
            {
                //update into database where id = XY 
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@orirignalPrice", origPrice);
                    cmd.Parameters.AddWithValue("@selectionID", selectionID);
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
        /// When the Product_ProdSelection table is updated with new products selected
        /// then the ProductSelection table needs to be updated also with the original 
        /// price to store these and freeze an old state of a product in the shopping 
        /// history.
        /// </summary>
        /// <param name="selectionID"></param>
        /// <param name="origSize"></param>
        /// <returns></returns>
        public int Update(int selectionID, int origSize)
        {
            int result = 0;
            string queryString = "UPDATE dbo.ProductSelection SET originalSize = @originalSize WHERE selectionID = @selectionID";

            try
            {
                //update into database where id = XY 
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@orirignalSize", origSize);
                    cmd.Parameters.AddWithValue("@selectionID", selectionID);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        //find all shipping companies available
        public List<ProductSelectionDTO> FindAll()
        {
            ProductSelectionDTO selection;
            ProductDTO product;
            //do an innerjoin over the two tables to retrieve all values
            List<ProductSelectionDTO> results = new List<ProductSelectionDTO>();
            string queryString = "SELECT dbo.Product_ProdSelection.productID, dbo.ProductSelection.selectionID, " +
                "dbo.ProductSelection.invoiceID, dbo.ProductSelection.quantity, dbo.ProductSelection.originalSize, " +
                "dbo.ProductSelection.originalPrice FROM dbo.Product_ProdSelection " +
                "INNER JOIN dbo.ProductSelection ON dbo.Product_ProdSelection.selectionID = dbo.ProductSelection.selectionID";            
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                product = new ProductDTO();
                                selection = new ProductSelectionDTO();
                                product.SetId((int)reader["productID"]);
                                selection.SetID((int)reader["selectionID"]);
                                selection.SetProduct(product);
                                selection.SetOrigPrice((decimal)reader["originalPrice"]);
                                selection.SetOrigSize((int)reader["originalSize"]);
                                selection.SetQuantity((int)reader["quantity"]);
                                //return product instance as data object 
                                Debug.Print("ProductSelectionDAL: /FindAll/ " + selection.ToString());
                                //add data objects to result-list 
                                results.Add(selection);
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

        public List<ProductSelectionDTO> FindAllPerInvoice(int invoiceID)
        {

            ProductSelectionDTO selection;
            ProductDTO product;
            //do an innerjoin over the two tables to retrieve all values
            List<ProductSelectionDTO> results = new List<ProductSelectionDTO>();
            string queryString = "SELECT dbo.Product_ProdSelection.productID, dbo.ProductSelection.selectionID, " +
                "dbo.ProductSelection.invoiceID, dbo.ProductSelection.quantity, dbo.ProductSelection.originalSize, " +
                "dbo.ProductSelection.originalPrice FROM dbo.ProductSelection " +
                "INNER JOIN dbo.Product_ProdSelection ON dbo.ProductSelection.invoiceID =" + invoiceID;
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                product = new ProductDTO();
                                selection = new ProductSelectionDTO();
                                product.SetId((int)reader["productID"]);
                                selection.SetID((int)reader["selectionID"]);
                                selection.SetProduct(product);
                                selection.SetOrigPrice((decimal)reader["originalPrice"]);
                                selection.SetOrigSize((int)reader["originalSize"]);
                                selection.SetQuantity((int)reader["quantity"]);
                                //return product instance as data object 
                                Debug.Print("ProductSelectionDAL: /FindAllByInvoice/ " + selection.ToString());
                                //add data objects to result-list 
                                results.Add(selection);
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