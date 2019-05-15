using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    /**
     * All applogic / business logic goes here
     */
    public class LoginBL
    {
        public bool Check(string email, string password)
        {
            LoginDAL login = new LoginDAL();
            try
            {
                int count = login.Check(email, password);
                Console.WriteLine("value returned " + count.ToString());
                //check if login is correct = user already exists in database
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        /// <summary>
        /// create new login and simultaneously 
        /// the correct account that belongs to a login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public int CreateLogin(string email, string password)
        {
            LoginDAL login = new LoginDAL();
            int column = 0;
            try
            {
                return column = login.Create(email, password);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return column;
        }
    }
}