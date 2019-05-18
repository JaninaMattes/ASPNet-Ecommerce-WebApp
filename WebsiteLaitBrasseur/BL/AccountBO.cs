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
        private string _email = "";
        private int _isConfirmed = 0;
        private string _password = "";
        private string _firstName = "";
        private string _lastName = "";
        private string _birthDate = "";
        private string _phoneNo = "";
        private string _imgPath = "";
        private int _status = 0;
        private int _isAdmin = 0;
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
        public string GetEmail()
        {
            return this._email;
        }

        public void SetEmail(string email)
        {
            this._email = email;
        }

        public string GetPassword()
        {
            return this._password;
        }

        public void SetPassword(string pw)
        {
            this._password = pw;
        }

        public int GetIsConfirmed()
        {
            return this._isConfirmed;
        }

        public void SetIsConfirmed(int isConf)
        {
            this._isConfirmed = isConf;
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

        public int GetStatus()
        {
            return this._status;
        }

        public void SetStatus(int status)
        {
            this._status = status;
        }

        public int GetIsAdmin()
        {
            return this._isAdmin;
        }

        public void SetIsAdmin(int isAdmin)
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
        public AccountBO()
        {

        }

        public AccountBO(byte id, string email, string pw)
        {
            _id = id;
            _email = email;
            _password = pw;
        }

        public AccountBO(byte id, string email, string password, string firstName, 
            string lastName, string birthDate, string phoneNo, int status, int isAdmin, Address address) : 
            this(id, email, password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
            _phoneNo = phoneNo;
            _status = status;
            _isAdmin = isAdmin;
            _address = address;
        }

        public AccountBO(byte id, string email, int isConfirmed, string password, string firstName, string lastName, 
            string birthDate, string phoneNo, string imgPath, int status, int isAdmin, List<Invoice> invoiceList, Address address)
        {
            _id = id;
            _email = email;
            _isConfirmed = isConfirmed;
            _password = password;
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
            _phoneNo = phoneNo;
            _imgPath = imgPath;
            _status = status;
            _isAdmin = isAdmin;
            _invoiceList = invoiceList;
            _address = address;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is AccountBO bO &&
                   _id == bO._id &&
                   _email == bO._email &&
                   _isConfirmed == bO._isConfirmed &&
                   _password == bO._password &&
                   _firstName == bO._firstName &&
                   _lastName == bO._lastName &&
                   _birthDate == bO._birthDate &&
                   _phoneNo == bO._phoneNo &&
                   _imgPath == bO._imgPath &&
                   _status == bO._status &&
                   _isAdmin == bO._isAdmin &&
                   EqualityComparer<List<Invoice>>.Default.Equals(_invoiceList, bO._invoiceList) &&
                   EqualityComparer<Address>.Default.Equals(_address, bO._address);
        }

        public override int GetHashCode()
        {
            var hashCode = -111360723;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_email);
            hashCode = hashCode * -1521134295 + _isConfirmed.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_lastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_birthDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_phoneNo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_imgPath);
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            hashCode = hashCode * -1521134295 + _isAdmin.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Invoice>>.Default.GetHashCode(_invoiceList);
            hashCode = hashCode * -1521134295 + EqualityComparer<Address>.Default.GetHashCode(_address);
            return hashCode;
        }
    }
}