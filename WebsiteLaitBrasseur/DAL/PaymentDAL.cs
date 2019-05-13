using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class PaymentDAL
    {
        //create
        public bool Create(byte id, decimal totalAmount, DateTime paymentDate)
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
        public bool Update(byte id, decimal totalAmount)
        {
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

        public bool Update(byte id, DateTime paymentDate)
        {
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
        //find a specific transaction
        public Payment FindBy(byte id)
        {
            Payment payment;
            try
            {
                payment = new Payment();
                //find entry in database where id = XY
                return payment;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        //find transactions on a specific date
        public Payment FindBy(DateTime paymentDate)
        {
            Payment payment;
            try
            {
                payment = new Payment();
                //find entry in database where id = XY
                return payment;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
    }
}