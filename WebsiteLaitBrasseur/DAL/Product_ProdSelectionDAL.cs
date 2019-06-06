using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.DAL
{
    [DataObject(true)]
    public class Product_ProdSelectionDAL
    {

        //Get connection string from web.config file and create sql connection
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LaitBrasseurDB"].ConnectionString;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(int productID, int selectionID)
        {
            int result = 0;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Product_ProdSelection(dbo.Product_ProdSelection.productID, dbo.Product_ProdSelection.selectionID) " +
                "VALUES(@productID, @selectionID)";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", SqlDbType.Int).Value = productID;
                        cmd.Parameters.AddWithValue("@selectionID", SqlDbType.Int).Value = selectionID;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    }
                }
                return result;
            }
            catch (Exception e)
            {
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
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateProduct(int selectionID, int productID)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Product_ProdSelection SET productID = @productID " +
                "WHERE selectionID = @selectionID";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@productID", productID);
                        cmd.Parameters.AddWithValue("@selectionID", selectionID);
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
    }
}