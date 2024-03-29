﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        ProductDAL PPB = new ProductDAL();

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
        public int CreateInvoice(string email, int shippingID, List<ProductSelectionDTO> products, decimal shippingCost, decimal totalAmount, decimal taxValue, decimal finalCost)
        {
            AccountDTO customer = new AccountDTO();
            ShippmentDTO deliverer = new ShippmentDTO();
            int result = 0;
            int paymentStatus = 0;

            try
            {
                customer = AB.FindBy(email);
                if (customer != null)
                {
                    deliverer = SB.FindBy(shippingID);
                    if (deliverer != null)
                    {
                        //set current time when Invoice is created
                        DateTime orderDate = DateTime.Now;
                        DateTime paymentDate = DateTime.Now;
                        DateTime arrivalDate = DateTime.Now.AddDays(deliverer.GetDeliveryTime());
                        DateTime postageDate = DateTime.Now;

                        int totalQuantity = CalculateQuantity(products);

                        //calculate all other values for the invoice
                        /*int totalWeight = CalculateWeight(products);
                        decimal totalShippingCost = deliverer.GetCost() + (decimal)0.1 * totalWeight;
                        decimal totalShippingCost = ;
                        decimal totalProductCost = CalculateProductCost(products);
                        decimal totalTaxes = CalculateTax(totalProductCost);
                        decimal totalAmount = totalTaxes + totalProductCost + totalShippingCost;*/

                        //UpdateProductInfo(products);

                        //insert into DB
                        result = DB.Insert(customer.GetID(), deliverer.GetID(), totalQuantity, shippingCost, finalCost, taxValue,
                            totalAmount, orderDate.ToString(), paymentDate.ToString(), arrivalDate.ToString(), postageDate.ToString(), paymentStatus, email);
                    }
                    else
                    {
                        throw new EmptyRowException($"The entry for {shippingID} was not found.");
                    }
                }
                else
                {
                    throw new EmptyRowException($"The entry for {email} was not found.");
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Write(e.ToString());
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
        /// Update the payment status and set
        /// an invoice to "Cancelled"
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public int SetAsCancelled(int invoiceID)
        {
            int result = 0;
            int paymentStatus = 2;
            result = DB.Update(invoiceID, paymentStatus);
            return result;
        }
        /// <summary>
        /// Find all invoices of one Customer.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IEnumerable<InvoiceDTO> FindInvoices(string email)
        {
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(email);
            IEnumerable<InvoiceDTO> result = new List<InvoiceDTO>();
            if (customer != null)
            {
                result = DB.FindByCustomer(customer.GetID());
            }            
            return result;
        }

        /// <summary>
        /// Find all invoices of one Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<InvoiceDTO> FindInvoices(int id)
        {
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(id);
            IEnumerable<InvoiceDTO> result = new List<InvoiceDTO>();
            if (customer != null)
            {
                result = DB.FindByCustomer(customer.GetID());
            }
            return result;
        }

        /// <summary>
        /// Find a specific invoice of a customer.
        /// Returns List of Invoice but contains 1 element
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="invoiceID"></param>
        /// <returns>List of Invoice but contains 1 element</returns>
        public List<InvoiceDTO> FindInvoiceByID(int customerID, int invoiceID)
        {
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(customerID);
            List<InvoiceDTO> result = new List<InvoiceDTO>();
            if (customer != null)
            {
                result = DB.FindByCustomer(customer.GetID(), invoiceID);
            }
            return result;
        }

        /// <summary>
        /// Find all invoices in the DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InvoiceDTO> FindInvoices()
        {
           IEnumerable<InvoiceDTO> result = new List<InvoiceDTO>();
            result = DB.GetInvoices();
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
        public IEnumerable<InvoiceDTO> FindPaied(string email)
        {
            int status = 1;

            AccountDTO customer = new AccountDTO();
            IEnumerable<InvoiceDTO> results = new List<InvoiceDTO>();

            customer = AB.FindBy(email);            
            if (customer != null)
            {
                results = DB.FindByStatus(customer.GetID(), status);
            }
            return results;
        }

        /// <summary>
        /// Find all unpaied invoices per Customer that are 
        /// paymentStatus = 0 (unpaied) OR
        /// paymentStatus = 1 (paied)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public IEnumerable<InvoiceDTO> FindUnPaied(string email)
        {
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(email);
            int status = 0;
            IEnumerable<InvoiceDTO> result = new List<InvoiceDTO>();
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

        private int UpdateProductInfo(List<ProductSelectionDTO> products)
        {
            int result = 0;
            ProductDTO product = new ProductDTO();
            try
            {
                int stock = 0;
                foreach (ProductSelectionDTO p in products)
                {
                    product = PPB.FindBy(p.GetProduct().GetId());
                    stock = product.GetStock() - p.GetQuantity();
                    result = PPB.UpdateStock(p.GetProduct().GetId(), stock);
                    if (stock == 1)
                    {
                        //suspend the product if the stock is too low
                        PPB.UpdateStatus(p.GetProduct().GetId(), 1);
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            
            return result;
        }

        public int UpdateStockProductSelection(int invoiceID,List<ProductSelectionDTO> cart, bool reverse)
        {
            int result = 0;
            ProductDTO product = new ProductDTO();
            ProductSelectionBL blProdSel = new ProductSelectionBL();
            try
            {
                int stock = 0;
                foreach (ProductSelectionDTO p in cart)
                {
                    if (reverse == false)
                    {
                        //Product Selection creation
                        blProdSel.Create(invoiceID, p.GetProduct().GetId(), p.GetQuantity(), p.GetOrigSize(), p.GetOrigPrice());

                        //Stock update
                        product = PPB.FindBy(p.GetProduct().GetId());
                        stock = product.GetStock() - p.GetQuantity();
                        result = PPB.UpdateStock(p.GetProduct().GetId(), stock);
                        Debug.Write("InvoiceBL / UpdateStock/ stock : "+stock); //DEBUG
                        if (stock == 1)
                        {
                            //suspend the product if the stock is too low
                            
                            PPB.UpdateStatus(p.GetProduct().GetId(), 0);
                            Debug.Write("InvoiceBL / UpdateStock/ status: " + p.GetProduct().GetStatus()); //DEBUG
                        }
                    }
                    else
                    {
                        //Stock update
                        product = PPB.FindBy(p.GetProduct().GetId());
                        stock = product.GetStock() + p.GetQuantity();
                        result = PPB.UpdateStock(p.GetProduct().GetId(), stock);

                        if (product.GetStatus() == 0 && product.GetStock() > 1)
                        {
                            PPB.UpdateStatus(p.GetProduct().GetId(), 1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Write(e.ToString());
            }

            Debug.Write("\nSortie UpdateStock : result(modif stock) =  " + result);
            return result;
        }
    }
}