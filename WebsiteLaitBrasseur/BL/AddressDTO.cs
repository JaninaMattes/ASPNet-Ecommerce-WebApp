using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class AddressDTO
    {
        private int id;
        private string streetName ="";
        private string streetNo = "";
        private string country = "";
        private string type = "";
        private CityDTO city;

        //getter and setter
        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public string GetStreetName()
        {
            return this.streetName;
        }

        public void SetStreetName(string street)
        {
            this.streetName = street;
        }

        public string GetStreetNo()
        {
            return this.streetNo;
        }

        public void SetStreetNo(string streetNo)
        {
            this.streetNo = streetNo;
        }

        public string GetCountry()
        {
            return this.country;
        }

        public void SetCountry(string country)
        {
            this.country = country;
        }

        public string GetAddressType()
        {
            return this.type;
        }

        public void SetType(string type)
        {
            this.type = type;
        }

        public CityDTO GetCity()
        {
            return this.city;
        }

        public void SetCity(CityDTO city)
        {
            this.city = city;
        }

        //constructor
        public AddressDTO()
        {

        }

        public AddressDTO(byte id, string streetName, string streetNo, string country, CityDTO city)
        {
            this.id = id;
            this.streetName = streetName;
            this.streetNo = streetNo;
            this.country = country;
            this.city = city;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is AddressDTO dTO &&
                   id == dTO.id &&
                   streetName == dTO.streetName &&
                   streetNo == dTO.streetNo &&
                   country == dTO.country &&
                   EqualityComparer<CityDTO>.Default.Equals(city, dTO.city);
        }

        public override int GetHashCode()
        {
            var hashCode = -1678693544;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(streetName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(streetNo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(country);
            hashCode = hashCode * -1521134295 + EqualityComparer<CityDTO>.Default.GetHashCode(city);
            return hashCode;
        }
    }
}