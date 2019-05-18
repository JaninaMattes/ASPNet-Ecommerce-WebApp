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
        public bool Create(byte id, AccountDTO customer, List<ProductSelectionDTO> products, ShippmentDTO shipping, byte totalQuantity, decimal totalShippingCost,
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
        public ShippmentDTO FindBy(byte id)
        {
            ShippmentDTO shipper;
            try
            {
                shipper = new ShippmentDTO();
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
        public ShippmentDTO FindBy(AccountDTO customer)
        {
            ShippmentDTO shipper;
            try
            {
                shipper = new ShippmentDTO();
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
        public ShippmentDTO FindBy(AccountDTO customer, bool paymentStatus)
        {
            ShippmentDTO shipper;
            try
            {
                shipper = new ShippmentDTO();
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
        public InvoiceDTO FindBy(DateTime paymentDate)
        {
            InvoiceDTO invoice;
            try
            {
                invoice = new InvoiceDTO();
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
        public List<InvoiceDTO> FindAll()
        {
            InvoiceDTO invoice;
            List<InvoiceDTO> list = new List<InvoiceDTO>();
            try
            {
                invoice = new InvoiceDTO();
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
        public List<ProductSelectionDTO> FindAllPerCustomer(byte id)
        {
            ProductSelectionDTO selection;
            List<ProductSelectionDTO> list = new List<ProductSelectionDTO>();
            try
            {
                selection = new ProductSelectionDTO();
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