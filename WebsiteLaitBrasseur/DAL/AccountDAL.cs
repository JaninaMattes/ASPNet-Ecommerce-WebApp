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
    /// <summary>
    /// The Account DAL contains all sql commands
    /// to program against the database and 
    /// open the connection via an SQLConnection object. 
    /// </summary>
    public class AccountDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
        /// <summary>
        /// This function inserts data of the DTO persistantly into the DB
        /// The return value contains the autoincremented ID for the Account.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="birthdate"></param>
        /// <param name="phoneNo"></param>
        /// <param name="status"></param>
        /// <param name="isAdmin"></param>
        /// <returns>The id value of the account.</returns>
        public int Insert(string email, string password, int isConfirmed, string fname, string lname, string birthdate, string phoneNo, string imgPath, int status, int isAdmin)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Account(dbo.Account.email, dbo.Account.password, dbo.Account.isConfirmed, dbo.Account.firstName, " +
                "dbo.Account.lastName, dbo.Account.birthDate, dbo.Account.phone, dbo.Account.imgPath, dbo.Account.status, dbo.Account.isAdmin) " +
                "VALUES('@email', '@password', @isConfirmed, '@firstName', '@lastName', '@birthDate', '@phone', '@imgPath', @status, @isAdmin)";
            string queryAutoIncr = "SELECT TOP(1) dbo.Account.accountID FROM dbo.Account ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", fname);
                    cmd.Parameters.AddWithValue("@isConfirmed", isConfirmed);
                    cmd.Parameters.AddWithValue("@firstName", fname);
                    cmd.Parameters.AddWithValue("@lastName", lname);
                    cmd.Parameters.AddWithValue("@birthDate", birthdate);
                    cmd.Parameters.AddWithValue("@phone", phoneNo);
                    cmd.Parameters.AddWithValue("@imgPath", imgPath);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                    connection.Open();
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
                    result = (Int32) reader["accountID"];
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
               
            }
            return result;
        }

        public bool Create(byte id, string fname, string lname, string birthdate, string phoneNo, bool status, bool isAdmin, Address address)
        {
            try
            {
                //insert into database 
                //status = true(not suspendet)/false(suspendet)
                //isAdmin = true / false
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update
        public bool Update(byte id, bool status)
        {
            try
            {
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool UpdatePhoneNo(byte id, string phoneNo)
        {
            try
            {
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, Address address)
        {
            try
            {
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool UpdateImg(byte id, string imgPath)
        {
            try
            {
                //update into database where id = XY and set new image
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, string fname, string lname, string birthdate, string phoneNo, bool status, bool isAdmin, Address address)
        {
            try
            {
                //insert into database 
                //status = true(not suspendet)/false(suspendet)
                //isAdmin = true / false
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //read
        //find one specific person in the database
        public AccountBO FindBy(byte id)
        {
            AccountBO account;
            try
            {
                account = new AccountBO();
                //find entry in database where id = XY
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }
        //find all admins in the database
        public AccountBO FindBy(bool isAdmin)
        {
            AccountBO account;
            try
            {
                account = new AccountBO();
                //find entry in database where isAdmin = true (Admin) else Customer
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        public AccountBO FindByStatus(bool status)
        {
            AccountBO account;
            try
            {
                account = new AccountBO();
                //find entry in database where status = suspendet/enabled
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find person in database by name
        public AccountBO FindBy(string fname, string lname)
        {
            AccountBO account;
            try
            {
                account = new AccountBO();
                //find entry in database where name = fname + lname
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        /// <summary>
        /// Finds if login credentials exist in database
        /// if the credentials of a user exist the effected number of rows = 1 returned
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int FindLoginCred(string email, string password)
        {
            int result = 0;
            string queryString = "SELECT COUNT(1) FROM dbo.Account WHERE email=@email AND password=@password";

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
            }
            catch (Exception e)
            {
                e.ToString();
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// Find the entry for the email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int FindLoginEmail(string email)
        {
            int result = 0;
            string queryString = "SELECT COUNT(1) FROM dbo.Account WHERE email=@email";

            try
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("value returned " + result.ToString());
                }
            }
            catch (Exception e)
            {
                e.ToString();
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// Find the entry for the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public int FindLoginPW(string password)
        {
            int result = 0;
            string queryString = "SELECT COUNT(1) FROM dbo.Account WHERE password=@password";

            try
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("value returned " + result.ToString());
                }
            }
            catch (Exception e)
            {
                e.ToString();
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            return result;
        }
        
    }
}