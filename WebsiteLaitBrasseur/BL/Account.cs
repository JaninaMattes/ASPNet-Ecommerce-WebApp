using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class Account
    {
        //private properties
        private byte _id;
        private string _firstName;
        private string _lastName;
        private string _birthDate;
        private string _phoneNo;
        private string _imgPath;
        private bool _status = false;
        private bool _isAdmin = false;
        private List<Invoice> _invoiceList = new List<Invoice>();
        private Address _address;

        //getter and setter
        public int GetAccountId()
        {
            return this._id;
        }

        public void SetAccountID(byte id)
        {
            this._id = id;
        }

        public string GetFirstName()
        {
            return this._firstName;
        }

        public void SetFirstName(string fname)
        {
            this._firstName = fname;
        }

        public string GetLastName()
        {
            return this._lastName;
        }

        public void SetLastName(string lname)
        {
            this._lastName = lname;
        }

        public string GetBirthdate()
        {
            return this._birthDate;
        }

        public void SetBirthdate(string date)
        {
            this._birthDate = date;
        }

        public string GetPhoneNo()
        {
            return this._phoneNo;
        }

        public void SetPhoneNo(string phoneNo)
        {
            this._phoneNo = phoneNo;
        }

        public string GetImgPath()
        {
            return this._imgPath;
        }

        public void SetImgPath(string imgPath)
        {
            this._imgPath = imgPath;
        }

        public bool GetStatus()
        {
            return this._status;
        }

        public void SetStatus(bool status)
        {
            this._status = status;
        }

        public bool GetIsAdmin()
        {
            return this._isAdmin;
        }

        public void SetIsAdmin(bool isAdmin)
        {
            this._isAdmin = isAdmin;
        }

        public List<Invoice> GetInvoices()
        {
            return this._invoiceList;
        }

        public void SetInvoices(List<Invoice> invoices)
        {
            this._invoiceList = invoices;
        }

        public void AddInvoice(Invoice invoice)
        {
            this._invoiceList.Add(invoice);
        }

        public Address GetAddress()
        {
            return this._address;
        }

        public void SetAddress(Address address)
        {
            this._address = address;
        }

        //constructor
       public Account()
        {

        }

        public Account(byte id, string fname, string lname, string birthdate, string phoneNo)
        {
            this._id = id;
            this._firstName = fname;
            this._lastName = lname;
            this._birthDate = birthdate;
            this._phoneNo = phoneNo;
            //new accounts are per default not suspendet
            this._status = true; 
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}