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
    public class ShippmentDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
        /// <summary>
        /// To Insert another Shipping company into the DB
        /// a status = 0 means the company is available
        /// a status = 1 means that the shipping service is deactivated.
        /// Customers don't have access to companies that are deactivated and as 
        /// such can't see this companies in the selection for a shipping service.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="deliveryTime"></param>
        /// <param name="company"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="postageDate"></param>
        /// <param name="cost"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Insert(string type, int deliveryTime, string company, decimal cost, int status)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO Shippment(dbo.Shippment.shipType, dbo.Shippment.estimatedTime, dbo.Shippment.shipCompany, " +
                "dbo.Shippment.shipCost, dbo.Shippment.status) " +
                "VALUES('@shipType', @deliveryTime, '@shipCompany', @shipCost, @status)";
            //query the last updated ID, which will be the id inserted by the above statement
            string queryAutoincID = "SELECT TOP(1) dbo.Shippment.shippingID FROM dbo.Shippment ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@shipType", type);
                    cmd.Parameters.AddWithValue("@deliveryTime", deliveryTime);
                    cmd.Parameters.AddWithValue("@shipCompany", company);
                    cmd.Parameters.AddWithValue("@shipCost", cost);
                    cmd.Parameters.AddWithValue("@status", status);                    
                    connection.Open();
                    cmd.ExecuteNonQuery(); //returns the number of affected rows in the DB 
                }
                ///find the last manipulated id due to autoincrement and return it
                using (SqlCommand command = new SqlCommand(queryAutoincID, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //won't need a while, since it will only retrieve one row
                    reader.Read();
                    //this is the id of the newly created data field
                    result = (Int32)reader["accountID"];
                    Debug.Print("ShippmentDAL: /Insert/ " + result.ToString());
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
        public bool Update(byte id, bool status)
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

        public bool Update(byte id, DateTime arrivalDate)
        {
            try
            {
                //update arrivalDate in database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, decimal cost)
        {
            try
            {
                //update arrivalDate in database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, string company, DateTime arrivalDate, DateTime postageDate, decimal cost, bool status)
        {
            ShippmentDTO shipper = new ShippmentDTO();
            try
            {
                //update into database where id = XY
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //read
        public ShippmentDTO FindBy(byte id)
        {
            ShippmentDTO shipper;
            try
            {
                shipper = new ShippmentDTO();
                //find entry in database where id = XY
                return shipper;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        public ShippmentDTO FindBy(string name)
        {
            ShippmentDTO shipper;
            try
            {
                shipper = new ShippmentDTO();
                //find entry in database where name = XY
                return shipper;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        public ShippmentDTO FindBy(decimal cost)
        {
            ShippmentDTO shipper;
            try
            {
                shipper = new ShippmentDTO();
                //find entry in database where cost = XY
                return shipper;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        //find all shipping companies available
        public List<ShippmentDTO> FindBy(DateTime arrivalDate)
        {
            ShippmentDTO shippment;
            List<ShippmentDTO> list = new List<ShippmentDTO>();
            try
            {
                shippment = new ShippmentDTO();
                //find entry in database where id = XY
                list.Add(shippment);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        //find all shipping companies available
        public List<ShippmentDTO> FindAll()
        {
            string queryString = "SELECT * FROM dbo.Account";
            List<ShippmentDTO> results = new List<ShippmentDTO>();
            ShippmentDTO deliverer;
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                deliverer = new ShippmentDTO();
                                deliverer.SetID((int)reader["shippingID"]);
                                deliverer.Set
                                account.SetEmail(reader["email"].ToString());
                                account.SetFirstName(reader["firstName"].ToString());
                                account.SetLastName(reader["lastName"].ToString());
                                account.SetBirthdate(reader["birthDate"].ToString());
                                account.SetPhoneNo(reader["phone"].ToString());
                                account.SetImgPath(reader["imgPath"].ToString());
                                account.SetIsAdmin((int)reader["isAdmin"]);
                                account.SetIsConfirmed((int)reader["isConfirmed"]);
                                account.SetStatus((int)reader["status"]);
                                //return product instance as data object 
                                Debug.Print("AccountDAL: /FindAllUserBy/ " + account.ToString());

                                //add data objects to result-list 
                                results.Add(account);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
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
    }
}