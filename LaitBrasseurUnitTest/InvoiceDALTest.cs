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
        private DateTime orderDate = DateTime.Now;
        private DateTime payDate = DateTime.Now;
        private DateTime postDate = DateTime.Now;
        private DateTime arrivalDate = DateTime.Now;
        private const byte status = 1;
        private const string mail = "miriam.miller@gmail.com";

        private const string Expected = "miriam.miller@gmail.com";
        private const int ExpectedInt = 1;

        [TestMethod]
        public void CreateInvoice()
        {
            var id = DB.Insert(accountID, shippID, quantity, sCost, pCost, tax, total, 
                Convert.ToString(orderDate), Convert.ToString(payDate), Convert.ToString(arrivalDate), 
                Convert.ToString(postDate), status, mail);
            var result = DB.GetInvoiceBy(id);
            Assert.AreEqual(ExpectedInt, id);
            Assert.AreEqual(Expected, result.GetEmail());
        }

        [TestMethod]
        public void GetInvoice()
        {
           var result = DB.GetInvoiceBy(invoiceID);
           Assert.AreEqual(Expected, result.GetEmail());
        }
    }
}