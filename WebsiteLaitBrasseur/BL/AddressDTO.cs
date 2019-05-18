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
        private string _zipCode = "";
        private string _city = "";

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
            return this._city;
        }

        public void SetCity(string city)
        {
            this._city = city;
        }

        public override bool Equals(object obj)
        {
            return obj is AddressDTO address &&
                   _id == address._id &&
                   _streetName == address._streetName &&
                   _streetNo == address._streetNo &&
                   _country == address._country &&
                   _zipCode == address._zipCode &&
                   _city == address._city;
        }

        public override int GetHashCode()
        {
            var hashCode = 1259783260;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_streetName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_streetNo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_zipCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_city);
            return hashCode;
        }

        //constructor
        public AddressDTO()
        {

        }

        public AddressDTO(byte id, string streetName, string streetNo, string country, string zipCode, string city)
        {
            _id = id;
            _streetName = streetName;
            _streetNo = streetNo;
            _country = country;
            _zipCode = zipCode;
            _city = city;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}