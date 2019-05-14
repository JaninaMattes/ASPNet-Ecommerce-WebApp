using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class LoginDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
        //create
        public int Create(string email, string password)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            //when account is created after Login, the login id needs to be set
            string queryString = "INSERT INTO Login(dbo.Login.email, dbo.Login.confirm, dbo.Login.password) " +
                "VALUES('@email', '@confirm', '@password')";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@confirm", email);
                    connection.Open();
                    result = cmd.ExecuteNonQuery(); //returns (number of rows affected) if successfull 
                    return result;
                }
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