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
    public class AddressDAL : IAddressDataAccess
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
        /// This function inserts the values and returns the ID of the newly 
        /// created Address entry in the database.
        /// </summary>
        /// <param name="cityID"></param>
        /// <param name="streetName"></param>
        /// <param name="streetNo"></param>
        /// <param name="addressType"></param>
        /// <returns>Address ID</returns>

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(int cityID, string streetName, string streetNo, string addressType)
        {
            Debug.Print("AddressDAL: / Insert/ ");
            int result = 0;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Address(dbo.Address.cityID, dbo.Account.streetName, " +
                "dbo.Account.streetNo, dbo.Account.addressType) " +
                "VALUES(@cityID, @streetName, @streetNo, @addressType)";
            string queryAutoIncr = "SELECT TOP(1) dbo.Address.addressID FROM dbo.Address ORDER BY 1 DESC";
            try
            {

                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@cityID", SqlDbType.Int).Value = cityID;
                        cmd.Parameters.AddWithValue("@streetName", SqlDbType.VarChar).Value = streetName;
                        cmd.Parameters.AddWithValue("@streetNo", SqlDbType.VarChar).Value = streetNo;
                        cmd.Parameters.AddWithValue("@addressType", SqlDbType.VarChar).Value = addressType;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    }
                }

                ///find the last manipulated id due to autoincrement and return it

                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryAutoIncr, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        //won't need a while, since it will only retrieve one row
                        reader.Read();
                        //this is the id of the newly created data field
                        result = Convert.ToInt32(reader["addressID"]);
                        Debug.Print("AddressDAL: / Insert AddressID/ " + result);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print("AddressDAL / Insert / Exception\n");
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the complete information within a table.
        /// </summary>
        /// <param name="addressID"></param>
        /// <param name="cityID"></param>
        /// <param name="streetName"></param>
        /// <param name="streetNo"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateAddress(int addressID, int cityID, string streetName, string streetNo, string addressType)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Address SET cityID = @cityID, " +
                "streetName = @streetName, streetNo = @streetNo, addressType = @addressType " +
                "WHERE addressID = @addressID";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@addressID", SqlDbType.Int).Value = addressID;
                        cmd.Parameters.AddWithValue("@cityID", SqlDbType.Int).Value = cityID;
                        cmd.Parameters.AddWithValue("@streetName", SqlDbType.VarChar).Value = streetName;
                        cmd.Parameters.AddWithValue("@streetNo", SqlDbType.VarChar).Value = streetNo;
                        cmd.Parameters.AddWithValue("@addressType", SqlDbType.VarChar).Value = addressType;
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
        /// Find a specific Address by its uniquely identifying ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public AddressDTO FindBy(int id)
        {
            AddressDTO address;
            CityDTO city;
            string queryString = "SELECT * FROM dbo.Address WHERE addressID = @id";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            address = new AddressDTO();
                            city = new CityDTO();
                            address = address = GenerateAddress(reader, address, city);
                            //return product instance as data object 
                            Debug.Print("AddressDAL: /FindByID/ " + address.GetID());
                            return address;
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
        /// Find all address type = HOME
        /// Find all address type = WORK
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public AddressDTO FindBy(string type)
        {
            AddressDTO address;
            CityDTO city;
            string queryString = "SELECT * FROM dbo.Address WHERE addressType = @type";

            try
            {
                // The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            address = new AddressDTO();
                            city = new CityDTO();
                            address = GenerateAddress(reader, address, city);
                            //return product instance as data object 
                            Debug.Print("AddressDAL: /FindByType/ " + address.ToString());
                            return address;
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

        private static AddressDTO GenerateAddress(SqlDataReader reader, AddressDTO address, CityDTO city)
        {
            city.SetId(Convert.ToInt32(reader["cityID"]));
            address.SetCity(city);
            address.SetID(Convert.ToInt32(reader["addressID"]));
            address.SetStreetName(reader["streetName"].ToString());
            address.SetStreetNo(reader["streetNo"].ToString());
            address.SetType(reader["addressType"].ToString());
            return address;
        }
    }
}
