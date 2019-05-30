using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class SizeBL
    {
        SizeDAL DB = new SizeDAL();

        /// <summary>
        /// Create new details for one product.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="price"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public int CreateDetails(int size, decimal price, int productID)
        {
            int result = 0;
            try
            {
                result = DB.Insert(size, price, productID);
            }
            catch (Exception e)
            {
                Debug.Write("SizeBL / Exception"); //DEBUG
                e.GetBaseException();
            }
            return result;
        }


    

        /// <summary>
        /// Get the details of one single product.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public IEnumerable<SizeDTO> GetDetails(int productID)
        {
            IEnumerable<SizeDTO> results = new List<SizeDTO>();
            try
            {
                results = DB.FindByProduct(productID);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Get the price of a product in function of its size.
        /// <param name="productID" , size="UnitSize"></param>
        /// <returns>Price</returns>
        public decimal GetPriceBySize(int id, int size)
        {
            SizeDTO product = new SizeDTO();
            try
            {
                product = DB.FindPriceBySize(id, size);

            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return product.GetPrice();
        }
    }
}