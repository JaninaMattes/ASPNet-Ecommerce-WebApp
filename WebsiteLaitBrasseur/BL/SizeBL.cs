using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Get the details of one single product.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<SizeDTO> GetDetails(int productID)
        {
            List<SizeDTO> results = new List<SizeDTO>();
            try
            {
                results = DB.FindByProduct(productID);
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }
    }
}