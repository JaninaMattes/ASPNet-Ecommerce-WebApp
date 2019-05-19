using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class InvoiceBL
    {
        InvoiceDAL DB = new InvoiceDAL();
        AccountDAL AB = new AccountDAL();
        ShippmentDAL SB = new ShippmentDAL();
        ProductSelectionDAL PB = new ProductSelectionDAL();

        /// <summary>
        /// As soon as the customer hits the buy product button 
        /// and pays the item or chooses to pay later the 
        /// invoice is created.
        /// Returns the InvoiceID
        /// </summary>
        /// <param name="email"></param>
        /// <param name="shippingID"></param>
        /// <param name="products"></param>
        /// <returns>Int InvoiceID</returns>
        public int CreateInvoice(string email, int shippingID, List<ProductSelectionDTO> products, int paymentStatus)
        {
            AccountDTO customer = new AccountDTO();
            ShippmentDTO deliverer = new ShippmentDTO();
            int result = 0;
            customer = new AccountDTO();
            customer = AB.FindBy(email);
            if(customer != null)
            {
                deliverer = SB.FindBy(shippingID);
                if (deliverer != null)
                {                   
                    //set current time when Invoice is created
                    DateTime orderDate = DateTime.Now;
                    DateTime paymentDate;
                    DateTime arrivalDate = DateTime.Now.AddDays(deliverer.GetDeliveryTime());
                    DateTime postageDate = DateTime.Now.AddDays(2);
                    //calculate all other values for the invoice
                    int totalWeight = CalculateWeight(products);
                    decimal totalShippingCost = deliverer.GetCost() + (decimal)0.1 * totalWeight;
                    int totalQuantity = CalculateQuantity(products);
                    decimal totalProductCost = CalculateProductCost(products);
                    decimal totalTaxes = CalculateTax(totalProductCost);
                    decimal totalAmount = totalTaxes + totalProductCost + totalShippingCost;

                    if (paymentStatus == 1)
                    {
                        //if payment has not been directly done
                        paymentDate = DateTime.Now;
                    }
                    else
                    {
                        //Business Rule: Payment in 30 days
                        paymentDate = DateTime.Now.AddDays(30);
                    }
                    //insert into DB
                    result = DB.Insert(customer.GetID(), deliverer.GetID(), totalQuantity, totalShippingCost, totalProductCost, totalTaxes,
                        totalAmount, orderDate, paymentDate, arrivalDate, postageDate, paymentStatus, email);
                }
                else
                {
                    throw new EmptyRowException($"The entry for {shippingID} was not found.");
                }
            } else
            {
                throw new EmptyRowException($"The entry for {email} was not found.");
            }
            return result;
        }

        /// <summary>
        /// Update the payment status and set
        /// an invoice to "paied"
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public int SetAsPaied(int invoiceID)
        {
            int result = 0;
            int paymentStatus = 1;
            result = DB.Update(invoiceID, paymentStatus);
            return result;
        }

        /// <summary>
        /// Find all invoices of one Customer.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<InvoiceDTO> FindInvoices(string email)
        {
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(email);
            List<InvoiceDTO> result = new List<InvoiceDTO>();
            if (customer != null)
            {
                result = DB.FindAllByCustomer(customer.GetID());
            }            
            return result;
        }

        /// <summary>
        /// Find all invoices in the DB
        /// </summary>
        /// <returns></returns>
        public List<InvoiceDTO> FindInvoices()
        {
            List<InvoiceDTO> result = new List<InvoiceDTO>();
            result = DB.FindAll();
            return result;
        }

        /// <summary>
        /// Find all paied invoices per Customer that are 
        /// paymentStatus = 0 (unpaied) OR
        /// paymentStatus = 1 (paied)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<InvoiceDTO> FindPaied(string email)
        {
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(email);
            int status = 1;
            List<InvoiceDTO> result = new List<InvoiceDTO>();
            if (customer != null)
            {
                result = DB.FindByStatus(customer.GetID(), status);
            }
            return result;
        }

        /// <summary>
        /// Find all unpaied invoices per Customer that are 
        /// paymentStatus = 0 (unpaied) OR
        /// paymentStatus = 1 (paied)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<InvoiceDTO> FindUnPaied(string email)
        {
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(email);
            int status = 0;
            List<InvoiceDTO> result = new List<InvoiceDTO>();
            if (customer != null)
            {
                result = DB.FindByStatus(customer.GetID(), status);
            }
            return result;
        }


        private int CalculateWeight(List<ProductSelectionDTO> products)
        {
            int totalWeight = 0;
            foreach(ProductSelectionDTO p in products)
            {
                totalWeight += p.GetOrigSize() * p.GetQuantity();
            }
            return totalWeight;
        }

        private int CalculateQuantity(List<ProductSelectionDTO> products)
        {
            int totalQuantity = 0;
            foreach (ProductSelectionDTO p in products)
            {
                totalQuantity += p.GetQuantity();
            }
            return totalQuantity;
        }

        private decimal CalculateProductCost(List<ProductSelectionDTO> products)
        {
            decimal totalProductCost = 0;
            foreach (ProductSelectionDTO p in products)
            {
                totalProductCost += (decimal)(p.GetOrigPrice() * p.GetQuantity());
            }
            return totalProductCost;
        }

        private decimal CalculateTax(decimal cost)
        {
            decimal taxCost = (decimal)((int)cost * 0.1);
            return taxCost;
        }
    }
}