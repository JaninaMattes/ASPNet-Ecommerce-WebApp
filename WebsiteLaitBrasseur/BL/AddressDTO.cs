using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class AddressDTO
    {
        private int _id;
        private string _streetName ="";
        private string _streetNo = "";
        private string _country = "";
        private string _type = "";
        private CityDTO _city;

        //getter and setter
        public int GetID()
        {
            return this._id;
        }

        public void SetID(int id)
        {
            this._id = id;
        }

        public string GetStreetName()
        {
            return this._streetName;
        }

        public void SetStreetName(string street)
        {
            this._streetName = street;
        }

        public string GetStreetNo()
        {
            return this._streetNo;
        }

        public void SetStringNo(string streetNo)
        {
            this._streetNo = streetNo;
        }

        public string GetCountry()
        {
            return this._country;
        }

        public void SetCountry(string country)
        {
            this._country = country;
        }

        public string GetAddressType()
        {
            return this._type;
        }

        public void SetType(string type)
        {
            this._type = type;
        }

        public CityDTO GetCity()
        {
            return this._city;
        }

        public void SetCity(CityDTO city)
        {
            this._city = city;
        }

        //constructor
        public AddressDTO()
        {

        }

        public AddressDTO(byte id, string streetName, string streetNo, string country, CityDTO city)
        {
            _id = id;
            _streetName = streetName;
            _streetNo = streetNo;
            _country = country;
            _city = city;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is AddressDTO dTO &&
                   _id == dTO._id &&
                   _streetName == dTO._streetName &&
                   _streetNo == dTO._streetNo &&
                   _country == dTO._country &&
                   EqualityComparer<CityDTO>.Default.Equals(_city, dTO._city);
        }

        public override int GetHashCode()
        {
            var hashCode = -1678693544;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_streetName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_streetNo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_country);
            hashCode = hashCode * -1521134295 + EqualityComparer<CityDTO>.Default.GetHashCode(_city);
            return hashCode;
        }
    }
}