using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class Product
    {
        //private member
        private int _id;
        private string _name = "";
        private string _type = "";
        private string _producer = "";
        private float _unitSize;
        private decimal _price;
        private string _info = "";
        private string _shortInfo = "";
        private string _imgPath = "";
        private int _stock;
        private int _status = 0;

        //getter and setter
        public int GetId()
        {
            return this._id;
        }

        public void SetId(int id)
        {
            this._id = id;
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public string GetProductType()
        {
            return _type;
        }

        public void SetType(string type)
        {
            this._type = type;
        }

        public string GetProducer()
        {
            return _producer;
        }

        public void SetProducer(string producer)
        {
            this._producer = producer;
        }

        public float GetUnit()
        {
            return _unitSize;
        }

        public void SetUnit(float unit)
        {
            this._unitSize = unit;
        }


        public decimal GetPrice()
        {
            return _price;
        }

        public void SetPrice(decimal price)
        {
            this._price = price;
        }

        public string GetInfo()
        {
            return _info;
        }

        public void SetInfo(string info)
        {
            this._info = info;
        }

        public string GetShortInfo()
        {
            return _shortInfo;
        }

        public void SetShortInfo(string info)
        {
            this._shortInfo = info;
        }

        public string GetImgPath()
        {
            return _imgPath;
        }

        public void SetImgPath(string imgPath)
        {
            this._imgPath = imgPath;
        }

        public int GetStock()
        {
            return _stock;
        }

        public void SetStock(int amount)
        {
            this._stock = amount;
        }

        public int GetStatus()
        {
            return _status;
        }

        public void SetStatus(int status)
        {
            this._status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   _id == product._id &&
                   _name == product._name &&
                   _type == product._type &&
                   _producer == product._producer &&
                   _unitSize == product._unitSize &&
                   _price == product._price &&
                   _info == product._info &&
                   _shortInfo == product._shortInfo &&
                   _imgPath == product._imgPath &&
                   _stock == product._stock &&
                   _status == product._status;
        }

        public override int GetHashCode()
        {
            var hashCode = -869496770;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_producer);
            hashCode = hashCode * -1521134295 + _unitSize.GetHashCode();
            hashCode = hashCode * -1521134295 + _price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_info);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_shortInfo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_imgPath);
            hashCode = hashCode * -1521134295 + _stock.GetHashCode();
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            return hashCode;
        }

        //constructor
        public Product()
        {
        }

        public Product(byte id, string name, string type, string producer, float unitSize, decimal price, string info, string shortInfo)
        {
            _id = id;
            _name = name;
            _type = type;
            _producer = producer;
            _unitSize = unitSize;
            _price = price;
            _info = info;
            _shortInfo = shortInfo;
        }

        public Product(byte id, string name, string type, string producer, float unitSize, decimal price, string info, string shortInfo, string imgPath, byte stock) 
            : this(id, name, type, producer, unitSize, price, info, shortInfo)
        {
            _imgPath = imgPath;
            _stock = stock;
        }

        public Product(byte id, string name, string type, string producer, float unitSize, decimal price, string info, string shortInfo, string imgPath, byte stock, bool status) : this(id, name, type, producer, unitSize, price, info, shortInfo, imgPath, stock)
        {
            _status = status;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}