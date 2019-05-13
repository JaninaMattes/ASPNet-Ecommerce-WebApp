using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class ShippmentDAL
    {
        //create
        public bool Create(byte id, string company, DateTime arrivalDate, DateTime postageDate, decimal cost)
        {
            try
            {
                //insert into database
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
            Shippment shipper = new Shippment();
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
        public Shippment FindBy(byte id)
        {
            Shippment shipper;
            try
            {
                shipper = new Shippment();
                //find entry in database where id = XY
                return shipper;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        public Shippment FindBy(string name)
        {
            Shippment shipper;
            try
            {
                shipper = new Shippment();
                //find entry in database where name = XY
                return shipper;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }


        public Shippment FindBy(DateTime arrivalDat)
        {
            Shippment shipper;
            try
            {
                shipper = new Shippment();
                //find entry in database where date = XY
                return shipper;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }


        public Shippment FindBy(decimal cost)
        {
            Shippment shipper;
            try
            {
                shipper = new Shippment();
                //find entry in database where cost = XY
                return shipper;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;



        }
    }
}