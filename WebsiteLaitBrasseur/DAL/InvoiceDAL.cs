using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class InvoiceDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection con = new SqlConnection(SqlDataAccess.ConnectionString);

        //create
        public bool Create(byte id, AccountDTO customer, List<ProductSelection> products, Shippment shipping, byte totalQuantity, decimal totalShippingCost,
            decimal totalTaxes, decimal totalAmount, DateTime orderDate, DateTime paymentDate, string email)
        {
            bool paymentStatus = false;
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
        public bool Update(byte id, bool paymentStatus)
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

        //find all bills by customer
        public Shippment FindBy(AccountDTO customer)
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

        //find all unpaied/paied bills per customer
        public Shippment FindBy(AccountDTO customer, bool paymentStatus)
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

        //find all invoices per paymentdate
        public Invoice FindBy(DateTime paymentDate)
        {
            Invoice invoice;
            try
            {
                invoice = new Invoice();
                //find entry in database where id = XY
                return invoice;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        //find all shipping companies available
        public List<Invoice> FindAll()
        {
            Invoice invoice;
            List<Invoice> list = new List<Invoice>();
            try
            {
                invoice = new Invoice();
                //find entry in database where id = XY
                list.Add(invoice);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        //find all invoices per customer id
        public List<ProductSelection> FindAllPerCustomer(byte id)
        {
            ProductSelection selection;
            List<ProductSelection> list = new List<ProductSelection>();
            try
            {
                selection = new ProductSelection();
                //find entry in database where id = XY
                list.Add(selection);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
    }
}