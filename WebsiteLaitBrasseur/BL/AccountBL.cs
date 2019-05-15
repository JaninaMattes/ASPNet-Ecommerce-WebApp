using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class AccountBL
    {
        /// <summary>
        /// create new login and simultaneously C:\Users\Janina\Documents\DEV\LaitBrasseur-WebStore\WebsiteC:\Users\Janina\Documents\DEV\LaitBrasseur-WebStore\WebsiteLaitBrasseur\BL\BO\Account.csLaitBrasseur\BL\BO\Account.cs
        /// the correct account that belongs to a login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void createAccount(Login login, string firstName, string lastName, string birthDate, string phoneNo, Int16 status, Int16 isAdmin)
        {
            try
            {
                AccountDAL dAL = new AccountDAL();
                dAL.Create(login, firstName, lastName, birthDate, phoneNo, status, isAdmin);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }
    }
}