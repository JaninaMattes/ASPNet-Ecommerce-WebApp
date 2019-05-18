using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class ShippmentDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
        //create
        public int Create(string type, string company, DateTime arrivalDate, DateTime postageDate, decimal cost)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO Shippment(dbo.Shippment.shipType, dbo.Shippment.shipCompany, " +
                "dbo.Shippment.arrivalDate, dbo.Shippment.postageDate, dbo.Shippment.shipCost ) " +
                "VALUES('@shipType', '@shipCompany', '@arrivalDate', '@postageDate', @shipCost)";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@shipType", type);
                    cmd.Parameters.AddWithValue("@shipCompany", company);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                    cmd.Parameters.AddWithValue("@postageDate", postageDate);
                    cmd.Parameters.AddWithValue("@shipCost", cost);
                    connection.Open();
                    result = cmd.ExecuteNonQuery();
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
    }
}