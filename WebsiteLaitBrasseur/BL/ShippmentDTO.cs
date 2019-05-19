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
        private int _deliveryTime = 0;
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

        public string GetDeliveryTime()
        {
            return this._deliveryTime;
        }

        public void SetDeliveryTime(int days)
        {
            this._deliveryTime = days;
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
            return obj is ShippmentDTO dTO &&
                   _id == dTO._id &&
                   _company == dTO._company &&
                   _type == dTO._type &&
                   _deliveryTime == dTO._deliveryTime &&
                   _cost == dTO._cost &&
                   _status == dTO._status;
        }

        public override int GetHashCode()
        {
            var hashCode = 402499420;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_company);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_type);
            hashCode = hashCode * -1521134295 + _deliveryTime.GetHashCode();
            hashCode = hashCode * -1521134295 + _cost.GetHashCode();
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            return hashCode;
        }

        public ShippmentDTO(int id, string company, string type, int deliveryTime, decimal cost)
        {
            _id = id;
            _company = company;
            _type = type;
            _deliveryTime = deliveryTime;
            _cost = cost;
        }

        public ShippmentDTO(int id, string company, string type, int deliveryTime, decimal cost, int status) : 
            this(id, company, type, deliveryTime, cost)
        {
            _status = status;
        }
    }
}