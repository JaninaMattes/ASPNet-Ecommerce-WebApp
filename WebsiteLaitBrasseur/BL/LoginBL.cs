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
        /// <summary>
        /// create new login and simultaneously 
        /// the correct account that belongs to a login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void createLogin(string email, string password)
        {
            LoginDAL lg = new LoginDAL();
            try
            {
                lg.Create(email, password);
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
        }
    }
}