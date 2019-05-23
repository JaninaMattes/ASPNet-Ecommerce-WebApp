using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using static WebsiteLaitBrasseur.Account.Profile; //TODO check this

namespace WebsiteLaitBrasseur.BL
{
    public class AccountDTO
    {
        //private properties
        private int _id;
        private string _email = "";
        private string _password = "";
        private int _isConfirmed = 0;
        private string _firstName = "";
        private string _lastName = "";
        private string _birthDate = "";
        private string _phoneNo = "";
        private string _imgPath = "";
        private int _status = 0;
        private int _isAdmin = 0;
        private List<InvoiceDTO> _invoiceList = new List<InvoiceDTO>();
        private AddressDTO _address;

        //getter and setter
        public int GetID()
        {
            return this._id;
        }

        public void SetID(int id)
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

        public string GetPW()
        {
            return this._password;
        }

        public void SetPw(string pw)
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

        public List<InvoiceDTO> GetInvoices()
        {
            return this._invoiceList;
        }

        public void SetInvoices(List<InvoiceDTO> invoices)
        {
            this._invoiceList = invoices;
        }

        public void AddInvoice(InvoiceDTO invoice)
        {
            this._invoiceList.Add(invoice);
        }

        public AddressDTO GetAddress()
        {
            return this._address;
        }

        public void SetAddress(AddressDTO address)
        {
            this._address = address;
        }

        //constructor
        public AccountDTO()
        {

        }

        public AccountDTO(byte id, string email, string pw)
        {
            _id = id;
            _email = email;
        }

        public AccountDTO(byte id, string email, string password, string firstName, 
            string lastName, string birthDate, string phoneNo, int status, int isAdmin, AddressDTO address) : 
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

        public AccountDTO(byte id, string email, int isConfirmed, string firstName, string lastName, 
            string birthDate, string phoneNo, string imgPath, int status, int isAdmin, List<InvoiceDTO> invoiceList, AddressDTO address)
        {
            _id = id;
            _email = email;
            _isConfirmed = isConfirmed;
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
            return obj is AccountDTO bO &&
                   _id == bO._id &&
                   _email == bO._email &&
                   _isConfirmed == bO._isConfirmed &&
                   _firstName == bO._firstName &&
                   _lastName == bO._lastName &&
                   _birthDate == bO._birthDate &&
                   _phoneNo == bO._phoneNo &&
                   _imgPath == bO._imgPath &&
                   _status == bO._status &&
                   _isAdmin == bO._isAdmin &&
                   EqualityComparer<List<InvoiceDTO>>.Default.Equals(_invoiceList, bO._invoiceList) &&
                   EqualityComparer<AddressDTO>.Default.Equals(_address, bO._address);
        }

        public override int GetHashCode()
        {
            var hashCode = -111360723;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_email);
            hashCode = hashCode * -1521134295 + _isConfirmed.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_lastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_birthDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_phoneNo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_imgPath);
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            hashCode = hashCode * -1521134295 + _isAdmin.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<InvoiceDTO>>.Default.GetHashCode(_invoiceList);
            hashCode = hashCode * -1521134295 + EqualityComparer<AddressDTO>.Default.GetHashCode(_address);
            return hashCode;
        }
    }
}