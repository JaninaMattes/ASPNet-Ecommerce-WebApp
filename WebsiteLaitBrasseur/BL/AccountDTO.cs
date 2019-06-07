using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class AccountDTO
    {
        //private properties
        private int id;
        private string email = "";
        private byte[] passwordMd5;
        private byte[] salt;
        private byte isConfirmed = 0;
        private int confirmationID = 0;
        private string firstName = "";
        private string lastName = "";
        private DateTime birthDate;
        private string phoneNo = "";
        private string imgPath = "";
        private byte status = 0;
        private byte isAdmin = 0;
        private List<InvoiceDTO> invoices;
        private AddressDTO address;

        //getter and setter
        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }
        public string GetEmail()
        {
            return this.email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public byte[] GetPW()
        {
            return this.passwordMd5;
        }

        public void SetSalt(byte[] pw)
        {
            this.salt = pw;
        }

        public byte[] GetSalt()
        {
            return this.salt;
        }

        public void SetPw(byte[] pw)
        {
            this.passwordMd5 = pw;
        }

        public int GetIsConfirmed()
        {
            return this.isConfirmed;
        }

        public void SetIsConfirmed(byte isConf)
        {
            this.isConfirmed = isConf;
        }

        public int GetConfirmationID()
        {
            return this.confirmationID;
        }

        public void SetConfirmationID(int id)
        {
            this.confirmationID = id;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public void SetFirstName(string fname)
        {
            this.firstName = fname;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public void SetLastName(string lname)
        {
            this.lastName = lname;
        }

        public DateTime GetBirthdate()
        {
            return this.birthDate;
        }

        public void SetBirthdate(DateTime date)
        {
            this.birthDate = date;
        }

        public string GetPhoneNo()
        {
            return this.phoneNo;
        }

        public void SetPhoneNo(string phoneNo)
        {
            this.phoneNo = phoneNo;
        }

        public string GetImgPath()
        {
            return this.imgPath;
        }

        public void SetImgPath(string imgPath)
        {
            this.imgPath = imgPath;
        }

        public int GetStatus()
        {
            return this.status;
        }

        public void SetStatus(byte status)
        {
            this.status = status;
        }

        public byte GetIsAdmin()
        {
            return this.isAdmin;
        }

        public void SetIsAdmin(byte isAdmin)
        {
            this.isAdmin = isAdmin;
        }

        public List<InvoiceDTO> GetInvoices()
        {
            return this.invoices;
        }

        public void SetInvoices(List<InvoiceDTO> invoices)
        {
            this.invoices = invoices;
        }

        public void AddInvoice(InvoiceDTO invoice)
        {
            this.invoices.Add(invoice);
        }

        public AddressDTO GetAddress()
        {
            return this.address;
        }

        public void SetAddress(AddressDTO address)
        {
            this.address = address;
        }

        //constructor
        public AccountDTO()
        {

        }

        public AccountDTO(byte id, string email, string pw)
        {
            this.id = id;
            this.email = email;
        }

        public AccountDTO(byte id, string email, string password, string firstName, 
            string lastName, DateTime birthDate, string phoneNo, byte status, byte isAdmin, AddressDTO address) : 
            this(id, email, password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.phoneNo = phoneNo;
            this.status = status;
            this.isAdmin = isAdmin;
            this.address = address;
        }

        public AccountDTO(byte id, string email, byte isConfirmed, int confirmID, string firstName, string lastName, 
            DateTime birthDate, string phoneNo, string imgPath, byte status, byte isAdmin, List<InvoiceDTO> invoiceList, AddressDTO address)
        {
            this.id = id;
            this.email = email;
            this.isConfirmed = isConfirmed;
            confirmationID = confirmID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.phoneNo = phoneNo;
            this.imgPath = imgPath;
            this.status = status;
            this.isAdmin = isAdmin;
            invoices = invoiceList;
            this.address = address;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is AccountDTO bO &&
                   id == bO.id &&
                   email == bO.email &&
                   isConfirmed == bO.isConfirmed &&
                   firstName == bO.firstName &&
                   lastName == bO.lastName &&
                   birthDate == bO.birthDate &&
                   phoneNo == bO.phoneNo &&
                   imgPath == bO.imgPath &&
                   status == bO.status &&
                   isAdmin == bO.isAdmin &&
                   EqualityComparer<List<InvoiceDTO>>.Default.Equals(invoices, bO.invoices) &&
                   EqualityComparer<AddressDTO>.Default.Equals(address, bO.address);
        }

        public override int GetHashCode()
        {
            var hashCode = -111360723;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + isConfirmed.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(lastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime>.Default.GetHashCode(birthDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(phoneNo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(imgPath);
            hashCode = hashCode * -1521134295 + status.GetHashCode();
            hashCode = hashCode * -1521134295 + isAdmin.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<InvoiceDTO>>.Default.GetHashCode(invoices);
            hashCode = hashCode * -1521134295 + EqualityComparer<AddressDTO>.Default.GetHashCode(address);
            return hashCode;
        }
    }
}