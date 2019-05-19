using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class ProductSelectionBL
    {
        ProductSelectionDAL DB = new ProductSelectionDAL();

        /// <summary>
        /// TODO Check the logic of shopping
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <param name="quantity"></param>
        /// <param name="origSize"></param>
        /// <param name="origPrice"></param>
        /// <returns></returns>
        public int Create(int invoiceID, int quantity, int origSize, decimal origPrice)
        {
            int result = 0;
            try
            {
                result = DB.Insert(invoiceID, quantity, origSize, origPrice);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Get all available Sizes per product.
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public List<ProductSelectionDTO> GetProducts(int invoiceID)
        {
            List<ProductSelectionDTO> results = new List<ProductSelectionDTO>();
            try
            {
                results = DB.FindAllPerInvoice(invoiceID);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        //TODO
    }
}