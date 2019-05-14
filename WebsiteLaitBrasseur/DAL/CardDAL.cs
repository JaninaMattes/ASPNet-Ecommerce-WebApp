using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.DAL
{
    //Get connection string from web.config file and create sql connection
    SqlConnection con = new SqlConnection(SqlDataAccess.ConnectionString);
    public class CardDAL
    {
        //TODO
    }
}