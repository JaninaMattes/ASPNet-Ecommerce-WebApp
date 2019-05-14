using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.DAL
{
    public class AddressDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection con = new SqlConnection(SqlDataAccess.ConnectionString);

        //create
        public bool Create(byte id, string streetName, string streetNo, string country, string zipCode, string city)
        {
            try
            {
                bool status = true;
                //insert into database 

                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }
    }
}