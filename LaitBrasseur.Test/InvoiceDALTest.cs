using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebsiteLaitBrasseur.DAL;

namespace LaitBrasseur.Test
{
    [TestClass]
    public class InvoiceDALTest
    {
        private InvoiceDAL DB = new InvoiceDAL();

        private const int invoiceID = 3;
        private const int accountID = 3;
        private const int quantity = 10;
        private const int shippID = 1;
        private const decimal sCost = 10;
        private const decimal pCost = 40;
        private const decimal tax = 5;
        private const decimal total = 5;
        private const string orderDate = "2019-02-30";
        private const string payDate = "2019-02-30";
        private const string postDate = "2019-02-30";
        private const string arrivalDate = "2019-02-30";
        private const byte status = 1;
        private const string mail = "miriam.miller@gmail.com";

        private const string Expected = "miriam.miller@gmail.com";

        [TestMethod]
        public void CreateInvoice()
        {
            var id = DB.Insert(accountID, shippID, quantity, sCost, pCost, tax, total, Convert.ToDateTime(orderDate), Convert.ToDateTime(payDate), Convert.ToDateTime(arrivalDate), Convert.ToDateTime(postDate), status, mail);
            var result = DB.FindBy(id);
            Assert.AreEqual(Expected, result.GetEmail());
        }

        [TestMethod]
        public void GetInvoice()
        {
            var result = DB.FindBy(invoiceID);
            Assert.AreEqual(Expected, result.GetEmail());
        }
    }
}
