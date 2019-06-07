using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class CityDTO
    {
        private int id;
        private string zipCode = "";
        private string cityName = "";

        public int GetId()
        {
            return this.id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetZip()
        {
            return this.zipCode;
        }

        public void SetZip(string zip)
        {
            this.zipCode = zip;
        }

        public string GetCity()
        {
            return this.cityName;
        }

        public void SetCity(string city)
        {
            this.cityName = city;
        }

    }
}