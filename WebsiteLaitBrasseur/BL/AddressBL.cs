﻿using System;
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
            if (IsPostCodeValid(zipCode))
            {
                int cityID = CB.Insert(zipCode, cityName);
                result = DB.Insert(cityID, streetName, streetNo, addressType);
                Debug.Print("AddressBL: /Insert/ " + result.ToString());
            }
            else
            {
                result = 2;
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
            int result = 0;
            AccountDTO customer = new AccountDTO();
            AddressDTO address = new AddressDTO();
            if (IsPostCodeValid(zipCode))
            {
                customer = AB.FindBy(email);
                if (customer != null)
                {
                    address = DB.FindBy(customer.GetAddress().GetID());
                }
                if(address != null)
                {
                    CB.UpdateCity(address.GetCity().GetId(), zipCode, cityName);
                    result = DB.UpdateAddress(address.GetID(), address.GetCity().GetId(), streetName, streetNo, addressType);
                    Debug.Print("AddressBL: /Insert/ " + result.ToString());
                }                
            }
            else
            {
                result = 2;
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
            AddressDTO address = new AddressDTO();
            AccountDTO customer = new AccountDTO();
            customer = AB.FindBy(accountID);
            if (customer != null)
            {
                address = DB.FindBy(customer.GetAddress().GetID());
                Debug.Print("AddressBL: /FindAddress/ " + address.ToString());
            }
            else
            {
                throw new EmptyRowException("No result found.");
            }
            
            return address;
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