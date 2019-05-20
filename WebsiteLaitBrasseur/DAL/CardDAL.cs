using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.DAL
{
    public class CardDAL
    {
        //Get connection string from web.config file and create sql connection
        readonly SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
        //TODO
    }
}