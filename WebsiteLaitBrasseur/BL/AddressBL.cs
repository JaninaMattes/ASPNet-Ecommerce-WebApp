using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class AddressBL
    {
        private AddressDAL DB = new AddressDAL();
        private CityDAL CB = new CityDAL();

        /// <summary>
        /// Create a new Address when user is registered 
        /// and ships the first time.
        /// Business Rules:
        /// If operation failed result = 0
        /// If operation successfull result = 1
        /// If zip Code wrong result = 2
        /// </summary>
        /// <param name="zipCode"></param>
        /// <param name="cityName"></param>
        /// <param name="streetName"></param>
        /// <param name="streetNo"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public int CreateAddress(string zipCode, string cityName, string streetName, string streetNo, string addressType)
        {
            int result = 0;
            if (IsPostCodeValid(zipCode))
            {
                int cityID = CB.Insert(zipCode, cityName);
                result = DB.Insert(cityID, streetName, streetNo, addressType);
            }
            else
            {
                result = 2;
            }
            return result;
        }

        private bool IsPostCodeValid(string postCode)
        {
            Regex postCodeValidation = new Regex(@"^[0234567]\d{4}$");
            if (postCodeValidation.Match(postCode).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}