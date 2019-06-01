using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class AddressBL
    {
        private AccountDAL AB = new AccountDAL();
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
            try
            {
                int cityID = CB.Insert(zipCode, cityName);
                result = DB.Insert(cityID, streetName, streetNo, addressType);
                Debug.Print("AddressBL: /Insert/ " + result);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }                
            return result;
        }

        /// <summary>
        /// Update an address and the city in the DB
        /// Business Rules:
        /// if failed result = 0
        /// if successfull result = 1
        /// if zipCode invalid result = 2
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="zipCode"></param>
        /// <param name="cityName"></param>
        /// <param name="streetName"></param>
        /// <param name="streetNo"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public int UpdateAddress(string email, string zipCode, string cityName, string streetName, string streetNo, string addressType)
        {
            Debug.Print("AddressBL: /Update Address: / enter in function");
            int result = 0;                      
            try
            {
                AccountDTO customer = new AccountDTO();
                customer = AB.FindBy(email);                
                //if address already exists
                if (customer.GetAddress() != null)
                {
                    AddressDTO address = new AddressDTO();
                    address = DB.FindBy(customer.GetAddress().GetID());
                    CB.UpdateCity(address.GetCity().GetId(), zipCode, cityName);
                    result = DB.UpdateAddress(address.GetID(), address.GetCity().GetId(), streetName, streetNo, addressType);
                    Debug.Print("AddressBL: /Update Address: / " + result);
                }
                else
                {
                    //if address doesnt exist yet
                    var cityID = CB.Insert(zipCode, cityName);
                    var addressID = DB.Insert(cityID, streetName, streetNo, addressType);
                    result = AB.UpdateAddress(email, addressID);
                    Debug.Print("AddressBL: /Insert Address: / " + result);
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }            
            return result;
        }

        /// <summary>
        /// Find an address of a customer.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public AddressDTO FindAddress(int accountID)
        {            
            AccountDTO customer = new AccountDTO();
            AddressDTO address = new AddressDTO();
            customer = AB.FindBy(accountID);
            if (customer != null)
            {                
                CityDTO city = new CityDTO();
                address = DB.FindBy(customer.GetAddress().GetID());
                city = CB.FindBy(address.GetCity().GetId());
                address.SetCity(city);
                Debug.Print("AddressBL: /FindAddress/ " + address.GetID());
                Debug.Print("AddressBL: /StreetName/ " + address.GetStreetName());
                Debug.Print("AddressBL: /StreetNo/ " + address.GetStreetNo());
                Debug.Print("AddressBL: /CityName/ " + address.GetCity().GetCity());
            }
            else
            {
                throw new EmptyRowException("No result found.");
            }
            
            return address;
        }

        public AddressDTO FindAddress(string email)
        {
            AddressDTO address = new AddressDTO();
            AccountDTO customer = new AccountDTO();
            try
            {
                customer = AB.FindBy(email);
                if (customer != null)
                {
                    CityDTO city = new CityDTO();
                    address = DB.FindBy(customer.GetAddress().GetID());
                    if (address != null)
                    {
                        city = CB.FindBy(address.GetCity().GetId());
                        address.SetCity(city);
                        Debug.Print("AddressBL: /FindAddress/ " + address.GetID());
                        Debug.Print("AddressBL: /StreetName/ " + address.GetStreetName());
                        Debug.Print("AddressBL: /StreetNo/ " + address.GetStreetNo());
                        // Debug.Print("AddressBL: /CityName/ " + address.GetCity().GetCity());
                        return address;
                    }
                    else
                    {
                        throw new EmptyRowException("No result found.");
                    }
                }
                else
                {
                    throw new EmptyRowException("No result found.");
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }         
            return null;
        }

        /// <summary>
        /// Check if the post code is any valid.
        /// </summary>
        /// <param name="postCode"></param>
        /// <returns></returns>
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