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

    }
}