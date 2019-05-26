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
    public class CityDAL 
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
        public int Insert(string zipCode, string cityName)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.City(dbo.City.zipCode, dbo.City.cityName) " +
                "VALUES(@zipCode, @cityName)";
            string queryAutoIncr = "SELECT TOP(1) dbo.City.cityID FROM dbo.City ORDER BY 1 DESC";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@zipCode", SqlDbType.VarChar).Value = zipCode;
                        cmd.Parameters.AddWithValue("@cityName", SqlDbType.VarChar).Value = cityName;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        var row = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                        Debug.Print("CityDAL / Insert / cmd result : " + row);
                    }
                }
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    ///find the last manipulated id due to autoincrement and return it
                    using (SqlCommand command = new SqlCommand(queryAutoIncr, con))
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        //won't need a while, since it will only retrieve one row
                        reader.Read();
                        //this is the id of the newly created data field
                        result = (Int32)reader["cityID"];
                        Debug.Print("CityDAL: / ID/ " + result);
                    }
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

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateCity(int cityID, string zipCode, string cityName)
        {
            int result = 0;
            string queryString = "UPDATE dbo.City SET zipCode = @zipCode, cityName = @cityName " +
                "WHERE cityID = @cityID";
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@cityID", SqlDbType.Int).Value = cityID;
                        cmd.Parameters.AddWithValue("@zipCode", SqlDbType.VarChar).Value = zipCode;
                        cmd.Parameters.AddWithValue("@cityName", SqlDbType.VarChar).Value = cityName;
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
        /// Find the city by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public CityDTO FindBy(int id)
        {
            CityDTO city;
            string queryString = "SELECT * FROM dbo.City WHERE cityID = @id";

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            city = new CityDTO();
                            city = GenerateCity(reader, city);
                            //return product instance as data object 
                            Debug.Print("CityDAL: /FindByID/ " + city.GetId());
                            return city;
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
        /// Find City by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CityDTO FindBy(string name)
        {
            CityDTO city = new CityDTO();
            string queryString = "SELECT * FROM dbo.City WHERE cityName = @name";

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();                        
                        if (reader.Read())
                        {
                            city = GenerateCity(reader, city);
                            //return product instance as data object 
                            Debug.Print("CityDAL: /FindByName/ " + city.GetId());                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            
            return city;
        }

        private static CityDTO GenerateCity(SqlDataReader reader, CityDTO city)
        {
            city.SetId(Convert.ToInt32(reader["cityID"]));
            city.SetCity(Convert.ToString(reader["cityName"]));
            city.SetZip(Convert.ToString(reader["zipCode"]));
            return city;
        }
    }
}