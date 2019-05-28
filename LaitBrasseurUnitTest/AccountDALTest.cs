using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebsiteLaitBrasseur.BL;
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
        private const int ExpectedVal = 1;
        private const string ExpectedEmail = "miriam.miller@gmail.com";

        AccountDAL DB = new AccountDAL();

        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LaitBrasseurDB"].ConnectionString;
            }
        }

        [TestMethod]
        public void TestConnection(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State);
            }
        }

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

        [TestMethod]
        public void GetAccounts()
        {
            var account = DB.FindAll();
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void UpdateAccount()
        {
            var row = DB.Update(id, email, fname, lname, birthdate, phoneNo, imgPath);
            Assert.AreEqual(ExpectedVal, row);
        }
    }
}
