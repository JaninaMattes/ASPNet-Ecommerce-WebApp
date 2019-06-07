using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class ShippmentDTO
    {

        //private properties
        private int id;
        private string company = "";
        private string type = "";
        private int deliveryTime = 0;
        private decimal cost;
        private int status = 0;

        //getter and setter
        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public string GetCompany()
        {
            return this.company;
        }

        public void SetCompany(string company)
        {
            this.company = company;
        }

        public string GetShipType()
        {
            return this.type;
        }

        public void SetType(string type)
        {
            this.type = type;
        }

        public int GetDeliveryTime()
        {
            return this.deliveryTime;
        }

        public void SetDeliveryTime(int days)
        {
            this.deliveryTime = days;
        }

        public decimal GetCost()
        {
            return this.cost;
        }

        public void SetCost(decimal cost)
        {
            this.cost = cost;
        }

        public int GetStatus()
        {
            return this.status;
        }

        public void SetStatus(int status)
        {
            this.status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is ShippmentDTO dTO &&
                   id == dTO.id &&
                   company == dTO.company &&
                   type == dTO.type &&
                   deliveryTime == dTO.deliveryTime &&
                   cost == dTO.cost &&
                   status == dTO.status;
        }

        public override int GetHashCode()
        {
            var hashCode = 402499420;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(company);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + deliveryTime.GetHashCode();
            hashCode = hashCode * -1521134295 + cost.GetHashCode();
            hashCode = hashCode * -1521134295 + status.GetHashCode();
            return hashCode;
        }

        // constructor

        public ShippmentDTO(int id, string company, string type, int deliveryTime, decimal cost)
        {
            this.id = id;
            this.company = company;
            this.type = type;
            this.deliveryTime = deliveryTime;
            this.cost = cost;
        }

        public ShippmentDTO(int id, string company, string type, int deliveryTime, decimal cost, int status) : 
            this(id, company, type, deliveryTime, cost)
        {
            this.status = status;
        }

        public ShippmentDTO()
        {
        }
    }
}