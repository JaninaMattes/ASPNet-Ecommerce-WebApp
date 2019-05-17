using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class LoginDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);

        /// <summary>
        /// check in the database if the user is already existent
        /// if a user exists already in the database a result > 0 is expected.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Check(string email, string password)
        {
            int result = 0;
            string queryString = "SELECT COUNT(1) FROM dbo.Login WHERE email=@email AND password=@password";


            try
            {

                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("value returned " + result.ToString());
                }
             } catch (Exception e)
            {
                e.ToString();
                e.GetBaseException();
                Debug.Print(e.ToString());

            }
            return result;
        }
        //------------ CREATE ------------------------
        /// <summary>
        /// after the CRUD principle for databases create
        /// a new log in with only email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Create(string email, string password)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            //when account is created after Login, the login id needs to be set
            string queryString = "INSERT INTO Login(dbo.Login.email, dbo.Login.confirm, dbo.Login.password) " +
                "VALUES('@email', '@confirm', '@password')";
            string queryAutoIncr = "SELECT TOP(1) dbo.Login.loginID FROM Login ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@confirm", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    cmd.ExecuteNonQuery(); //returns (number of rows affected) if successfull                    
                }
                ///find the last manipulated id due to autoincrement and return it
                using (SqlCommand command = new SqlCommand(queryAutoIncr, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //won't need a while, since it will only retrieve one row
                    reader.Read();
                    //here is your data
                    result = (int)reader["loginID"];                    
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

        //update
        public bool UpdateEmail(byte id, string email)
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

        public bool UpdatePw(byte id, string password)
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
        //does the login email already exist
        public Login FindBy(byte id)
        {
            Login lg;
            try
            {
                lg = new Login();
                //find entry in database where id = XY
                return lg;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //does the login already exist
        public Login FindBy(string email)
        {
            Login lg;
            try
            {
                lg = new Login();
                //find entry in database where id = XY
                return lg;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

    }
}