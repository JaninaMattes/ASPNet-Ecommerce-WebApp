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
    public class AddressDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);

        /// <summary>
        /// This function inserts the values and returns the ID of the newly 
        /// created Address entry in the database.
        /// </summary>
        /// <param name="cityID"></param>
        /// <param name="streetName"></param>
        /// <param name="streetNo"></param>
        /// <param name="addressType"></param>
        /// <returns>Address ID</returns>
        public int Insert(int cityID, string streetName, string streetNo, string addressType)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Address(dbo.Address.cityID, dbo.Account.streetName, dbo.Account.streetNo, dbo.Account.addressType)" +
                "VALUES(@cityID, '@streetName', '@streetNo', '@addressType')";
            string queryAutoIncr = "SELECT TOP(1) dbo.Address.addressID FROM dbo.Address ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@cityID", cityID);
                    cmd.Parameters.AddWithValue("@streetName", streetName);
                    cmd.Parameters.AddWithValue("@streetNo", streetNo);
                    cmd.Parameters.AddWithValue("@addressType", addressType);
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
                    result = (Int32)reader["addressID"];
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
        /// Update the complete information within a table.
        /// </summary>
        /// <param name="addressID"></param>
        /// <param name="cityID"></param>
        /// <param name="streetName"></param>
        /// <param name="streetNo"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public int UpdateAddress(int addressID, int cityID, string streetName, string streetNo, string addressType)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Address SET cityID = @cityID, " +
                "streetName = @streetName, streetNo = @streetNo, addressType = @addressType WHERE addressID = @addressID";
            try
            {
                //update into database where email = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.Parameters.AddWithValue("@cityID", cityID);
                    cmd.Parameters.AddWithValue("@streetName", streetName);
                    cmd.Parameters.AddWithValue("@streetNo", streetNo);
                    cmd.Parameters.AddWithValue("@addressType", addressType);
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
        /// Find a specific Address by its uniquely identifying ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AddressDTO FindBy(int id)
        {
            AddressDTO address;
            CityDTO city;
            string queryString = "SELECT * FROM dbo.Address WHERE addressID=@id";

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
                            address = new AddressDTO();
                            city = new CityDTO();
                            city.SetId((int)reader["cityID"]);
                            address.SetCity(city);
                            address.SetCountry(reader["country"].ToString());
                            address.SetID((int)reader["addressID"]);
                            address.SetStreetName(reader["streetName"].ToString());
                            address.SetType(reader["addressType"].ToString());

                            //return product instance as data object 
                            Debug.Print("AddressDAL: /FindByID/ " + address.ToString());
                            return address;
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
        /// Find all address type = HOME
        /// Find all address type = WORK
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public AddressDTO FindBy(string type)
        {
            AddressDTO address;
            CityDTO city;
            string queryString = "SELECT * FROM dbo.Address WHERE addressType=@type";

            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@type", type);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            address = new AddressDTO();
                            city = new CityDTO();
                            city.SetId((int)reader["cityID"]);
                            address.SetCity(city);
                            address.SetCountry(reader["country"].ToString());
                            address.SetID((int)reader["addressID"]);
                            address.SetStreetName(reader["streetName"].ToString());
                            address.SetType(reader["addressType"].ToString());

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
                Debug.Print(e.ToString());
            }
            return null;
        }
    }
}