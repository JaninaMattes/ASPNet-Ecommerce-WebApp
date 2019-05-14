using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class LogInDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection con = new SqlConnection(SqlDataAccess.ConnectionString);
        //create
        public bool Create(byte id, string email, string password, Account user)
        {
            try
            {
                //insert into database
                //insert account simultaneously into database
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
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