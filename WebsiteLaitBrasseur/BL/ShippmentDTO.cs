using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class ShippmentDTO
    {

        //private properties
        private int _id;
        private string _company = "";
        private string _type = "";
        private DateTime _arrivalDate;
        private DateTime _postageDate;
        private decimal _cost;
        private int _status = 0;

        //getter and setter
        public int GetID()
        {
            return this._id;
        }

        public void SetID(int id)
        {
            this._id = id;
        }

        public string GetCompany()
        {
            return this._company;
        }

        public void SetCompany(string company)
        {
            this._company = company;
        }

        public string GetShipType()
        {
            return this._type;
        }

        public void SetType(string type)
        {
            this._type = type;
        }
        public DateTime GetArrival()
        {
            return this._arrivalDate;
        }

        public void SetArrival(DateTime date)
        {
            this._arrivalDate = date;
        }
        public DateTime GetPostage()
        {
            return this._postageDate;
        }

        public void SetPostage(DateTime date)
        {
            this._postageDate = date;
        }
        public decimal GetCost()
        {
            return this._cost;
        }

        public void SetCost(decimal cost)
        {
            this._cost = cost;
        }

        public int GetStatus()
        {
            return this._status;
        }

        public void SetStatus(int status)
        {
            this._status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is ShippmentDTO shippment &&
                   _id == shippment._id &&
                   _company == shippment._company &&
                   _arrivalDate == shippment._arrivalDate &&
                   _postageDate == shippment._postageDate &&
                   _cost == shippment._cost &&
                   _status == shippment._status;
        }

        public override int GetHashCode()
        {
            var hashCode = -1975167387;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_company);
            hashCode = hashCode * -1521134295 + _arrivalDate.GetHashCode();
            hashCode = hashCode * -1521134295 + _postageDate.GetHashCode();
            hashCode = hashCode * -1521134295 + _cost.GetHashCode();
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            return hashCode;
        }

        //constructor
        public ShippmentDTO()
        {
          
        }

        public ShippmentDTO(byte id, string company, string type, DateTime arrivalDate, DateTime postageDate, decimal cost)
        {
            _id = id;
            _company = company;
            _type = type;
            _arrivalDate = arrivalDate;
            _postageDate = postageDate;
            _cost = cost;
        }

        public ShippmentDTO(byte id, string company, string type, DateTime arrivalDate, DateTime postageDate, decimal cost, int status) : this(id, company, type, arrivalDate, postageDate, cost)
        {
            this._status = status;
        }
    }
}