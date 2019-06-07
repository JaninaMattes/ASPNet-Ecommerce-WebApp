using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class ProductSelectionBL
    {
        ProductSelectionDAL DB = new ProductSelectionDAL();
        Product_ProdSelectionDAL PDB = new Product_ProdSelectionDAL();

        /// <summary>
        /// TODO Check the logic of shopping => Customer can only buy if product is availbale
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <param name="quantity"></param>
        /// <param name="origSize"></param>
        /// <param name="origPrice"></param>
        /// <returns></returns>
        public int Create(int invoiceID, int productID, int quantity, int origSize, decimal origPrice)
        {
            int result = 0;
            try
            {
                result = DB.Insert(invoiceID, quantity, origSize, origPrice);
                if (result > 0) { PDB.Insert(productID, result); }                
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Write(e.ToString());
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
                Debug.Write(e.ToString());
            }
            return results;
        }

    }
}