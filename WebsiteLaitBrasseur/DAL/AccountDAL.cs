using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class AccountDAL
    {
        //create
        public bool Create(byte id, string fname, string lname, string birthdate, string phoneNo)
        {
            try
            {
                bool status = true;
                //insert into database 
                //status = true(not suspendet)/false(suspendet)
                //isAdmin = true / false
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Create(byte id, string fname, string lname, string birthdate, string phoneNo, bool status, bool isAdmin)
        {
            try
            {
                //insert into database 
                //status = true(not suspendet)/false(suspendet)
                //isAdmin = true / false
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Create(byte id, string fname, string lname, string birthdate, string phoneNo, bool status, bool isAdmin, Address address)
        {
            try
            {
                //insert into database 
                //status = true(not suspendet)/false(suspendet)
                //isAdmin = true / false
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update
        public bool Update(byte id, bool status)
        {
            try
            {
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, string phoneNo)
        {
            try
            {
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, Address address)
        {
            try
            {
                //update into database where id = XY to status suspendet(false) or enabled(true) 
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, string imgPath)
        {
            try
            {
                //update into database where id = XY and set new image
                //e.g. after three false log in attempts / upaied bills
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, string fname, string lname, string birthdate, string phoneNo, bool status, bool isAdmin, Address address)
        {
            try
            {
                //insert into database 
                //status = true(not suspendet)/false(suspendet)
                //isAdmin = true / false
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //read
        //find one specific person in the database
        public Account FindBy(byte id)
        {
            Account account;
            try
            {
                account = new Account();
                //find entry in database where id = XY
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }
        //find all admins in the database
        public Account FindBy(bool isAdmin)
        {
            Account account;
            try
            {
                account = new Account();
                //find entry in database where isAdmin = true (Admin) else Customer
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        public Account FindByStatus(bool status)
        {
            Account account;
            try
            {
                account = new Account();
                //find entry in database where status = suspendet/enabled
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find person in database by name
        public Account FindBy(string fname, string lname)
        {
            Account account;
            try
            {
                account = new Account();
                //find entry in database where name = fname + lname
                return account;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

    }
}