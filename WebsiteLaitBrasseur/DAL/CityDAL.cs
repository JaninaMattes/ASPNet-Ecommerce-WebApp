using System;
using System.ComponentModel;
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
        readonly SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);


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
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@zipCode", SqlDbType.VarChar).Value = zipCode;
                    cmd.Parameters.AddWithValue("@cityName", SqlDbType.VarChar).Value = cityName;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }

                ///find the last manipulated id due to autoincrement and return it
                using (SqlCommand command = new SqlCommand(queryAutoIncr, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    //won't need a while, since it will only retrieve one row
                    reader.Read();
                    //this is the id of the newly created data field
                    result = (Int32)reader["cityID"];
                    Debug.Print("CityDAL: / ID/ " + result);
                }
                return result;
            }
            catch (Exception e)
            {
                result = 0;
                e.GetBaseException();
            }
            finally
            {
                connection.Close();
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
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //update into database where email = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@cityID", SqlDbType.Int).Value = cityID;
                    cmd.Parameters.AddWithValue("@zipCode", SqlDbType.VarChar).Value = zipCode;
                    cmd.Parameters.AddWithValue("@cityName", SqlDbType.VarChar).Value = cityName;
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            finally
            {
                connection.Close();
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
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
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
            finally
            {
                connection.Close();
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
            CityDTO city;
            string queryString = "SELECT * FROM dbo.City WHERE cityName = @name";

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            city = new CityDTO();
                            city = GenerateCity(reader, city);
                            //return product instance as data object 
                            Debug.Print("CityDAL: /FindByName/ " + city.GetId());
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
            finally
            {
                connection.Close();
            }
            return null;
        }

        private static CityDTO GenerateCity(SqlDataReader reader, CityDTO city)
        {
            city.SetId(Convert.ToInt32(reader["cityID"]));
            city.SetCity(reader["cityName"].ToString());
            city.SetZip(reader["cityCode"].ToString());
            return city;
        }
    }
}