using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class PaymentDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection con = new SqlConnection(SqlDataAccess.ConnectionString);
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
        public PaymentDTO FindBy(byte id)
        {
            PaymentDTO payment;
            try
            {
                payment = new PaymentDTO();
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
        public PaymentDTO FindBy(DateTime paymentDate)
        {
            PaymentDTO payment;
            try
            {
                payment = new PaymentDTO();
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