using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class CityDTO
    {
        private int _id;
        private string _zipCode = "";
        private string _cityName = "";

        public int GetId()
        {
            return this._id;
        }

        public void SetId(int id)
        {
            this._id = id;
        }

        public string GetZip()
        {
            return this._zipCode;
        }

        public void SetZip(string zip)
        {
            this._zipCode = zip;
        }

        public string GetCity()
        {
            return this._cityName;
        }

        public void SetCity(string city)
        {
            this._cityName = city;
        }

    }
}