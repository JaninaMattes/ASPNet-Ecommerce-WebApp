using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using static WebsiteLaitBrasseur.Account.Profile; //TODO check this

namespace WebsiteLaitBrasseur.BL
{
    public class AccountBO
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
        private Login _login;

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

        public Login GetLogin()
        {
            return this._login;
        }

        public void SetLogin(Login login)
        {
            this._login = login;
        }

        //constructor
        public AccountBO()
        {

        }

        public AccountBO(byte id, Login login)
        {
            _id = id;
            _login = login;
        }

        public AccountBO(byte id, Login login, string fname, string lname, string birthdate, string phoneNo)
        {
            this._id = id;
            this._login = login;
            this._firstName = fname;
            this._lastName = lname;
            this._birthDate = birthdate;
            this._phoneNo = phoneNo;
            //new accounts are per default not suspendet
            this._status = true;
        }

        public AccountBO(byte id, Login login, string firstName, string lastName, string birthDate, string phoneNo, string imgPath, bool status, bool isAdmin) : this(id, login, firstName, lastName, birthDate, phoneNo)
        {
            this._imgPath = imgPath;
            this._status = true;
            this._isAdmin = isAdmin;
        }

        public AccountBO(byte id, Login login, string firstName, string lastName, string birthDate, string phoneNo, string imgPath, bool status, bool isAdmin, Address address) : this(id, login, firstName, lastName, birthDate, phoneNo, imgPath, status, isAdmin)
        {
            this._address = address;
        }

        public AccountBO(byte id, Login login, string firstName, string lastName, string birthDate, string phoneNo, string imgPath, bool status, bool isAdmin, List<Invoice> invoiceList, Address address) : this(id, login, firstName, lastName, birthDate, phoneNo, imgPath, status, isAdmin)
        {
            this._invoiceList = invoiceList;
            this._address = address;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is AccountBO account &&
                   _id == account._id &&
                   _firstName == account._firstName &&
                   _lastName == account._lastName &&
                   _birthDate == account._birthDate &&
                   _phoneNo == account._phoneNo &&
                   _imgPath == account._imgPath &&
                   _status == account._status &&
                   _isAdmin == account._isAdmin &&
                   EqualityComparer<List<Invoice>>.Default.Equals(_invoiceList, account._invoiceList) &&
                   EqualityComparer<Address>.Default.Equals(_address, account._address) &&
                   EqualityComparer<Login>.Default.Equals(_login, account._login);
        }

        public override int GetHashCode()
        {
            var hashCode = 97198024;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_lastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_birthDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_phoneNo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_imgPath);
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            hashCode = hashCode * -1521134295 + _isAdmin.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Invoice>>.Default.GetHashCode(_invoiceList);
            hashCode = hashCode * -1521134295 + EqualityComparer<Address>.Default.GetHashCode(_address);
            hashCode = hashCode * -1521134295 + EqualityComparer<Login>.Default.GetHashCode(_login);
            return hashCode;
        }
    }
}