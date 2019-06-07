using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class ProductDTO
    {
        //private member
        private int id;
        private string name = "";
        private string type = "";
        private string producer = "";
        private string longInfo = "";
        private string shortInfo = "";
        private string imgPath = "";
        private int stock = 0;
        private int status = 0;
        private List<SizeDTO> details; // size + price

        //getter and setter
        public int GetId()
        {
            return this.id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetProductType()
        {
            return type;
        }

        public void SetType(string type)
        {
            this.type = type;
        }

        public string GetProducer()
        {
            return producer;
        }

        public void SetProducer(string producer)
        {
            this.producer = producer;
        }


        public string GetInfo()
        {
            return longInfo;
        }

        public void SetInfo(string info)
        {
            this.longInfo = info;
        }

        public string GetShortInfo()
        {
            return shortInfo;
        }

        public void SetShortInfo(string info)
        {
            this.shortInfo = info;
        }

        public string GetImgPath()
        {
            return imgPath;
        }

        public void SetImgPath(string imgPath)
        {
            this.imgPath = imgPath;
        }

        public int GetStock()
        {
            return stock;
        }

        public void SetStock(int amount)
        {
            this.stock = amount;
        }

        public int GetStatus()
        {
            return status;
        }

        public void SetStatus(int status)
        {
            this.status = status;
        }

        public List<SizeDTO> GetDetails()
        {
            return details;
        }

        public void SetDetails(List<SizeDTO> details)
        {
            this.details = details;
        }

        public override bool Equals(object obj)
        {
            return obj is ProductDTO product &&
                   id == product.id &&
                   name == product.name &&
                   type == product.type &&
                   producer == product.producer &&
                   longInfo == product.longInfo &&
                   shortInfo == product.shortInfo &&
                   imgPath == product.imgPath &&
                   stock == product.stock &&
                   status == product.status;
        }

        public override int GetHashCode()
        {
            var hashCode = -869496770;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(producer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(longInfo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(shortInfo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(imgPath);
            hashCode = hashCode * -1521134295 + stock.GetHashCode();
            hashCode = hashCode * -1521134295 + status.GetHashCode();
            return hashCode;
        }

        //constructor
        public ProductDTO()
        {
        }

        public ProductDTO(int id, string name, string type, string producer, string info, string shortInfo, 
            string imgPath, int stock, int status)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.producer = producer;
            this.longInfo = info;
            this.shortInfo = shortInfo;
            this.imgPath = imgPath;
            this.stock = stock;
            this.status = status;
        }

        public ProductDTO(int id, string name, string type, string producer, string info, string shortInfo, string imgPath, 
            int stock, int status, List<SizeDTO> details) : this(id, name, type, producer, info, shortInfo, imgPath, stock, status)
        {
            this.details = details;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}