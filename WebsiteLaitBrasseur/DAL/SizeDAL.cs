using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.DAL
{
    public class SizeDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);
    }
}