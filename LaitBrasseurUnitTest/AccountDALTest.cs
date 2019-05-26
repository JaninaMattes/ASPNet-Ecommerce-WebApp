using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebsiteLaitBrasseur.DAL;

namespace LaitBrasseurUnitTest
{
    [TestClass]
    public class AccountDALTest
    {
        private const int id = 3;
        private const string email = "janinaAlica.mattes@gmail.com";
        private const string password = "XYZQASW1123";
        private const int isConfirmed = 1;
        private const string fname = "Janina";
        private const string lname = "Mattes";
        private const string birthdate = "1999-05-29";
        private const string phoneNo = "+6104834931";
        private const string imgPath = " ";
        private const int status = 1;
        private const int isAdmin = 0;

        private const int ExpectedID = 1;
        private const string ExpectedEmail = "miriam.miller@gmail.com";

        AccountDAL DB = new AccountDAL();

        [TestMethod]
        public void CreateAccount()
        {
            var id = DB.Insert(email, password, isConfirmed, fname, lname, birthdate, phoneNo, imgPath, status, isAdmin);           
            Assert.AreEqual(ExpectedID, id);
        }

        [TestMethod]
        public void GetAccount()
        {
            var account = DB.FindBy(id);
            Assert.AreEqual(ExpectedEmail, account.GetEmail());
        }
    }
}
