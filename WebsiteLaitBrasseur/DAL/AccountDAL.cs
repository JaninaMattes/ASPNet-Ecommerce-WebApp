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
    /// <summary>
    /// The Account DAL contains all sql commands
    /// to program against the database and 
    /// open the connection via an SQLConnection object. 
    /// </summary>

    [DataObject(true)]
    public class AccountDAL : IAccountDataAccess
    {
        //Get connection string from web.config file and create sql connection
        readonly SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);

        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LaitBrasseurDB"].ConnectionString;
            }
        }
        /// <summary>
        /// New User Registration
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

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string email, string password, int isConfirmed, string fname, string lname, string birthdate,
            string phoneNo, string imgPath, int status, int isAdmin)
        {
            int result = -2;
            //no need to explicitely set id as autoincrement is used

            string queryString = "INSERT INTO dbo.Account(dbo.Account.email, dbo.Account.password, dbo.Account.isConfirmed, " +
                "dbo.Account.firstName, dbo.Account.lastName, dbo.Account.birthDate, dbo.Account.phone, dbo.Account.imgPath, " +
                "dbo.Account.status, dbo.Account.isAdmin) VALUES(@email, @password, @isConfirmed, @firstName, @lastName, " +
                "@birthDate, @phone, @imgPath, @status, @isAdmin)";

            string queryAutoIncr = "SELECT TOP(1) dbo.Account.accountID FROM dbo.Account ORDER BY 1 DESC";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                        cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = password;
                        cmd.Parameters.AddWithValue("@isConfirmed", SqlDbType.Int).Value = isConfirmed;
                        cmd.Parameters.AddWithValue("@firstName", SqlDbType.VarChar).Value = fname;
                        cmd.Parameters.AddWithValue("@lastName", SqlDbType.VarChar).Value = lname;
                        cmd.Parameters.AddWithValue("@birthDate", SqlDbType.Date).Value = birthdate;
                        cmd.Parameters.AddWithValue("@phone", SqlDbType.VarChar).Value = phoneNo;
                        cmd.Parameters.AddWithValue("@imgPath", SqlDbType.VarChar).Value = imgPath;
                        cmd.Parameters.AddWithValue("@status", SqlDbType.Int).Value = status;
                        cmd.Parameters.AddWithValue("@isAdmin", SqlDbType.Int).Value = isAdmin;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        var row = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                        Debug.Print("AccountDAL / Insert / cmd result : " + row);
                    }

                    ///find the last manipulated id due to autoincrement and return it
                    using (SqlCommand command = new SqlCommand(queryAutoIncr, con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        //won't need a while, since it will only retrieve one row
                        reader.Read();
                        //this is the id of the newly created data field
                        result = Convert.ToInt32(reader["accountID"]);
                        Debug.Print("AccountDAL: / ID/ " + result);
                    }
                }
            }
            catch (Exception e)
            {
                result = 0;
                Debug.Print("AccountDAL / Insert / Exception\n");
                e.GetBaseException();

            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Suspend a user account or reactivate a user account
        /// by setting the status = 1 (suspendet) status = 0 (activated)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateStatus(string email, int status)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET status = @status WHERE email = @email";
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
                    cmd.Parameters.AddWithValue("@status", SqlDbType.Bit).Value = status;
                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
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
        /// Update the user image of a user in the database.
        /// The user can be found via his unique email address.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="imgPath"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateUsername(string email, string fName, string lName)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET firstName = @fName, lastName = @lName WHERE email = @email";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@fName", SqlDbType.VarChar).Value = fName;
                    cmd.Parameters.AddWithValue("@lName", SqlDbType.VarChar).Value = lName;
                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
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
        /// Update the phone number of a user in the database
        /// The user can be found via passing over the email address
        /// </summary>
        /// <param name="email"></param>
        /// <param name="phoneNo"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdatePhoneNo(string email, string phoneNo)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET phone = @phoneNo WHERE email = @email";
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
                    cmd.Parameters.AddWithValue("@phone", SqlDbType.VarChar).Value = phoneNo;
                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
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
        /// Update the user address of a user in the database.
        /// The user can be found via his unique email address.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressID"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateAddress(string email, int addressID)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET addressID = @addressID WHERE email = @email";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.Parameters.AddWithValue("@email", email);
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
        /// Update the user image of a user in the database.
        /// The user can be found via his unique email address.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="imgPath"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateImg(string email, string imgPath)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET imgPath = @imgPath WHERE email = @email";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@imgPath", imgPath);
                    cmd.Parameters.AddWithValue("@email", email);
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

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateIsConfirmed(string email, int confirmed)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET isConfirmed = @isConfirmed WHERE email = @email";
            try
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@isConfirmed", confirmed);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    Debug.Print("AccountDAL: /Update Is confirmed/ result : " + result);
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

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateAll(int accountID, string email, string password, string fname, string lname,
            string birthdate, string phoneNo, string imgPath)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET email = @email, password = @password, " +
                "firstName = @firstName, lastName = @lastName, " +
                "birthDate = @birthDate, phone = @phoneNo, imgPath = @imgPath " +
                "WHERE accountID = @accountID";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = accountID;
                        cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                        cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = password;
                        cmd.Parameters.AddWithValue("@firstName", SqlDbType.VarChar).Value = fname;
                        cmd.Parameters.AddWithValue("@lastName", SqlDbType.VarChar).Value = lname;
                        cmd.Parameters.AddWithValue("@birthDate", SqlDbType.Date).Value = birthdate;
                        cmd.Parameters.AddWithValue("@phoneNo", SqlDbType.VarChar).Value = phoneNo;
                        cmd.Parameters.AddWithValue("@imgPath", SqlDbType.VarChar).Value = imgPath;
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

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int accountID, string email, string fname, string lname,
            string birthdate, string phoneNo, string imgPath)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Account SET email = @email, " +
                "firstName = @firstName, lastName = @lastName, " +
                "birthDate = @birthDate, phone = @phoneNo, imgPath = @imgPath " +
                "WHERE accountID = @accountID";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = accountID;
                        cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = email;
                        cmd.Parameters.AddWithValue("@firstName", SqlDbType.VarChar).Value = fname;
                        cmd.Parameters.AddWithValue("@lastName", SqlDbType.VarChar).Value = lname;
                        cmd.Parameters.AddWithValue("@birthDate", SqlDbType.Date).Value = birthdate;
                        cmd.Parameters.AddWithValue("@phoneNo", SqlDbType.VarChar).Value = phoneNo;
                        cmd.Parameters.AddWithValue("@imgPath", SqlDbType.VarChar).Value = imgPath;
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
        /// Find a specific user in the database by its 
        /// unique indentifier accountID
        /// This contains in addition the encrypted PW
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public AccountDTO FindBy(int accountID)
        {
            AccountDTO account;
            AddressDTO address;
            string queryString = "SELECT * FROM dbo.Account WHERE accountID = @accountID";

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = accountID;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            account = new AccountDTO();
                            address = new AddressDTO();
                            account = GenerateAccount(reader, account, address);
                            //return product instance as data object 
                            Debug.Print("AccountDAL: /FindByID/ " + account.GetID());
                            connection.Close();
                            return account;
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
        /// Read operation find a specific user in the database
        /// by selecting his unique email address to indentify the entry.
        /// This contains in addition the encrypted password of the user.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public AccountDTO FindBy(string email)
        {
            AccountDTO account;
            AddressDTO address;
            string queryString = "SELECT * FROM dbo.Account WHERE email = @email";

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();                    
                        if (reader.Read())
                        {
                            account = new AccountDTO();
                            address = new AddressDTO();
                            account = GenerateAccount(reader, account, address);
                            //return product instance as data object 
                            Debug.Print("AccountDAL: /FindByMail/ " + account.GetEmail().ToString());
                            connection.Close();
                            return account;
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
        /// Find all Admins in DB by passing isAdmin = 1 OR
        /// Find all Customer in DB by passing isAdmin = 0
        /// </summary>
        /// <param name="isAdmin"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<AccountDTO> FindAllUserBy(int isAdmin)
        {
            string queryString = "SELECT * FROM dbo.Account WHERE isAdmin = @isAdmin";
            List<AccountDTO> results = new List<AccountDTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@isAdmin", SqlDbType.Int).Value = isAdmin;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            AccountDTO account = new AccountDTO();
                            AddressDTO address = new AddressDTO();
                            account = GenerateAccount(reader, account, address);
                            //return product instance as data object 
                            Debug.Print("AccountDAL: /FindAllUserBy/ " + account.GetID().ToString());

                            //add data objects to result-list 
                            results.Add(account);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all user in the database 
        /// and return the list.
        /// </summary>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<AccountDTO> FindAll()
        {
            string queryString = "SELECT * FROM dbo.Account";
            List<AccountDTO> results = new List<AccountDTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            AccountDTO account = new AccountDTO();
                            AddressDTO address = new AddressDTO();
                            account = GenerateAccount(reader, account, address);
                            //return product instance as data object 
                            Debug.Print("AccountDAL: /FindAllUserBy/ " + account.GetID().ToString());
                            //add data objects to result-list 
                            results.Add(account);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all suspendet User by status = 1
        /// Find all not suspendet User by status = 0
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<AccountDTO> FindByStatus(int status)
        {
            string queryString = "SELECT * FROM dbo.Account WHERE status = @status";
            List<AccountDTO> results = new List<AccountDTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@status", SqlDbType.Int).Value = status;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            AccountDTO account = new AccountDTO();
                            AddressDTO address = new AddressDTO();
                            account = GenerateAccount(reader, account, address);
                            //return product instance as data object 
                            Debug.Print("AccountDAL: /FindAllUserBy/ " + account.GetID().ToString());
                            //add data objects to result-list 
                            results.Add(account);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        //find person in database by name
        [DataObjectMethod(DataObjectMethodType.Select)]
        public AccountDTO FindByName(string fname, string lname)
        {
            AccountDTO account = new AccountDTO();            
            string queryString = "SELECT * FROM dbo.Account WHERE firstName = @fname AND lastName = @lname";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            AddressDTO address = new AddressDTO();
                            account = GenerateAccount(reader, account, address);
                            //return product instance as data object 
                            Debug.Print("AccountDAL: /FindByName/ " + fname + " " + lname + " " + account.GetID().ToString());
                            
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
            return account;
        }

        /// <summary>
        /// Finds if login credentials exist in database
        /// if the credentials of a user exist the effected number of rows = 1 returned
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int FindLoginCred(string email, string password)
        {
            int result = 0;
            string queryString = "SELECT COUNT(1) FROM dbo.Account WHERE email = @email AND password = @password";

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.CommandType = CommandType.Text;
                    result = Convert.ToInt32(cmd.ExecuteScalar()); //is expected to return value 1 if successfull
                    Debug.Print("AccountDAL / FindLoginCred / value returned " + result.ToString());
                }
            }
            catch (Exception e)
            {
                e.ToString();
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Find the entry for the email address
        /// Will return a value of 1 if email is found in DB.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>int value = 1, if entry found in DB</returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int FindLoginEmail(string email)
        {
            int result = 0;
            string queryString = "SELECT COUNT(1) FROM dbo.Account WHERE email = @email";

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.CommandType = CommandType.Text;
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    Debug.Print("AccountDAL / FindLoginEmail / value returned " + result.ToString());
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                e.ToString();
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Find the entry for the password
        /// Will return a value of 1 if password is found in DB.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int FindLoginPW(string password)
        {
            int result = 0;
            string queryString = "SELECT COUNT(1) FROM dbo.Account WHERE password = @password";

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.CommandType = CommandType.Text;
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    Debug.Print("AccountDAL / FindLoginPW / value returned  " + result.ToString());
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                e.ToString();
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        private static AccountDTO GenerateAccount(SqlDataReader reader, AccountDTO account, AddressDTO address)
        {
            account.SetID(Convert.ToInt32(reader["accountID"]));
            address.SetID(Convert.ToInt32(reader["addressID"]));
            account.SetAddress(address);
            account.SetEmail(reader["email"].ToString());
            account.SetPw(reader["password"].ToString());
            account.SetFirstName(reader["firstName"].ToString());
            account.SetLastName(reader["lastName"].ToString());
            account.SetBirthdate(Convert.ToDateTime(reader["birthDate"]));
            account.SetPhoneNo(reader["phone"].ToString());
            account.SetImgPath(reader["imgPath"].ToString());
            account.SetIsAdmin(Convert.ToInt32(reader["isAdmin"]));
            account.SetIsConfirmed(Convert.ToInt32(reader["isConfirmed"]));
            account.SetStatus(Convert.ToInt32(reader["status"]));
            return account;
        }
    }
}