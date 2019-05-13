using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.Account;

namespace WebsiteLaitBrasseur.BL
{
    public class LogIn
    {
        //properties
        private byte _id;
        private string _email;
        private string _password;
        private Account _user;

        //getter and setter
        public int GetId()
        {
            return this._id;
        }

        public void SetId(byte id)
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

        public Account GetAccount()
        {
            return this._user;
        }

        //constructor
        public LogIn(byte id, string email, string pw)
        {
            this._id = id;
            this._email = email;
            this._password = pw;
        }

        public LogIn(byte id, string email, string password, Account user) : this(id, email, password)
        {
            _user = user;
        }

        public override bool Equals(object obj)
        {
            return obj is LogIn @in &&
                   _id == @in._id &&
                   _email == @in._email &&
                   _password == @in._password;
        }

        public override int GetHashCode()
        {
            var hashCode = -2103507968;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_password);
            return hashCode;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}