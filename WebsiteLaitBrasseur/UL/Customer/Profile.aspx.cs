﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Profile : System.Web.UI.Page
    {
        AccountBL BL = new AccountBL();
        AddressBL ABL = new AddressBL();
        InvoiceBL IBL = new InvoiceBL();

        IEnumerable<InvoiceDTO> invoices = new List<InvoiceDTO>();

        string SESSION_VAR; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CustID"] == null)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Login.aspx";

                Response.Redirect(url);
            }
            if (!Page.IsPostBack)
            {
                SESSION_VAR = Convert.ToString(this.Session["email"]);
                //SESSION_VAR = "janina.mattes@gmail.com";
                //Bind profile data
                BindProfileData();
                //Shopping history
                BindDataInvoices();
            }
        }

        protected void BindData()
        {
            //Account
            //Account init
            AccountDTO account = new AccountDTO();
            account = BL.GetCustomer(SESSION_VAR);
            Debug.Print($"Profile.aspx / Customer found {account.GetID()}");
            //BindData
            TextFirstname.Text = account.GetFirstName();
            TextLastname.Text = account.GetLastName();
            TextPhone.Text = account.GetPhoneNo();
            TextBirthday.Text = account.GetBirthdate().ToString(); //WARNING : issue format
            TextEmail.Text = account.GetEmail();

            if (account.GetAddress() != null)
            {
                Debug.Print($"Profile.aspx / Address found {account.GetAddress().GetID()}");
                //Address 
                //Address init
                AddressDTO address = new AddressDTO();
                address = ABL.FindAddress(account.GetID());
                if (address != null)
                {
                    //BindData
                    Debug.Write("\n Street name:  " + address.GetStreetName()); //DEBUG
                    TextAddress1.Text = address.GetStreetName();
                    Debug.Write("\n City: " + address.GetCity().GetCity()); //DEBUG
                    TextCity.Text = address.GetCity().GetCity();
                    Debug.Write("\n Country: " + address.GetCountry()); //DEBUG
                    CountryDropDownList.Text = address.GetCountry();
                    Debug.Write("\n Number :" + address.GetStreetNo()); //DEBUG
                    TextAddressnumber.Text = address.GetStreetNo();
                    Debug.Write("\n Zip  : " + address.GetCity().GetZip()); //DEBUG
                    TextZip.Text = address.GetCity().GetZip();
                }
            }            
            else
            {
                Debug.Print("No address found");
                //BindData
                TextAddress1.Text = "Please add streetname";
                TextCity.Text = "Please add city";
                CountryDropDownList.Text = "Please add country";
                TextAddressnumber.Text = "Please add addressno";
                TextZip.Text = "Please add zipcode";
            }            


            //ShoppingTable
            //List invoices init            
            invoices = IBL.FindInvoices(SESSION_VAR);
            Debug.Write("Invoices infos : " + invoices.Count());

            //BindData
            ShoppingTable.DataSource = getDataTable();
            ShoppingTable.DataBind();

            //Label update
            tableShoppingHistoryLabel.Text = "Your shopping history has " + ShoppingTable.Rows.Count + " items.";
        }

        //Useless?
        protected DataTable getDataTable()
        {
            //DataTable initialization
            DataTable dtShoppingTable = new DataTable();

            //Colmuns declaration
            dtShoppingTable.Columns.Add("ID");
            dtShoppingTable.Columns.Add("TotalQuantity");
            dtShoppingTable.Columns.Add("TotalShippinCost");
            dtShoppingTable.Columns.Add("TotalTaxes");
            dtShoppingTable.Columns.Add("TotalAmount");
            dtShoppingTable.Columns.Add("OrderDate");
            dtShoppingTable.Columns.Add("PaymentDate");
            dtShoppingTable.Columns.Add("ArrivalDate");
            dtShoppingTable.Columns.Add("PostageDate");
            dtShoppingTable.Columns.Add("Status");

            List<InvoiceDTO> invoiceList = invoices.ToList<InvoiceDTO>();
            foreach (InvoiceDTO i in invoiceList) { 
                DataRow dr = dtShoppingTable.NewRow();
                dr["ID"] = i.GetID();
                dr["TotalQuantity"] = i.GetTotal();
                dr["TotalShippinCost"] = i.GetShippingCost();
                dr["TotalTaxes"] = i.GetTax();
                dr["PaymentDate"] = i.GetPaymentDate();
                dr["ArrivalDate"] = i.GetArrivalDate();
                dr["PostageDate"] = i.GetPostDate();
                dr["Status"] = i.GetStatus();

                dtShoppingTable.Rows.Add(dr);
            }
            return dtShoppingTable;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
             // suspend the user dont delete
             int status = 1;
             BL.UpdateStatus(SESSION_VAR, status);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //update User Profile
            var email = TextEmail.Text;
            var fName = TextFirstname.Text;
            var lName = TextLastname.Text;
            var birthDate = TextBirthday.Text;
            var phoneNo = TextPhone.Text;
            var imgPath = ProfilePicture.ImageUrl;
            //var password = TextPassword.Text;
            var res1 = BL.Update(email,fName, lName,birthDate, phoneNo, imgPath);
            Debug.Print("Profile aspx: /Save Button / Update User Info " + res1);
            //update Address
            var streetName = TextAddress1.Text;
            var zipCode = TextZip.Text;
            var cityName = TextCity.Text;
            var streetNo = TextAddressnumber.Text;
            var addressType = "Home"; //TODO add field in UI
            var res2 = ABL.UpdateAddress(email, zipCode, cityName, streetName, streetNo, addressType);
            Debug.Print("Profile aspx: /Save Button / Update Address Info " + res2);
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
        }
        
        /*Fill the label with accurat item number*/
        protected void BindTableLabel()
        {
            IEnumerable<InvoiceDTO> transactions = GetShoppingList(SESSION_VAR);
            if (transactions.LongCount<InvoiceDTO>() > 0)
            {
                tableShoppingHistoryLabel.Text = $"Your shopping history has {transactions.LongCount<InvoiceDTO>()} items.";
            }
        }

        //Fill the label with accurat item number
        protected void BindProfileData()
        {
            if(GetUserData(SESSION_VAR).GetImgPath().Equals(" "))
            {                
                ProfilePicture.ImageUrl = "/Images/defaultImg.jpg";
                Debug.Print($"No image found - default image under { ProfilePicture.ImageUrl.ToString()} used");
            }
            ProfilePicture.ImageUrl = GetUserData(SESSION_VAR).GetImgPath();
            //Textboxes with editable section information
            TextFirstname.Text = GetUserData(SESSION_VAR).GetFirstName();
            TextLastname.Text = GetUserData(SESSION_VAR).GetLastName();
            TextPhone.Text = GetUserData(SESSION_VAR).GetPhoneNo();
            //TextBirthday.Text = Convert.ToDateTime(GetUserData(SESSION_VAR).GetBirthdate()).ToString();
            TextEmail.Text = GetUserData(SESSION_VAR).GetEmail();
            TextName.Text = GetUserData(SESSION_VAR).GetFirstName() + " " + GetUserData(SESSION_VAR).GetLastName();

            //Textboxes with editable section information
            if (GetAddressData(SESSION_VAR) != null)
            {
                TextAddress1.Text = GetAddressData(SESSION_VAR).GetStreetName();
                TextCity.Text = GetAddressData(SESSION_VAR).GetCity().GetCity();
                CountryDropDownList.Text = GetAddressData(SESSION_VAR).GetCountry();
                TextAddressnumber.Text = GetAddressData(SESSION_VAR).GetStreetNo();
                TextZip.Text = GetAddressData(SESSION_VAR).GetCity().GetZip();
            }
            else
            {
                TextAddress1.Text = "Please add street";
                TextCity.Text = "Please add city";
                CountryDropDownList.Text = " ";
                TextAddressnumber.Text = "Please add number";
                TextZip.Text = "Please add post code";
            }           
           
        }

        protected void BindDataInvoices()
        {
            try
            {
                IEnumerable<InvoiceDTO> invoices = new List<InvoiceDTO>();
                invoices = IBL.FindInvoices(SESSION_VAR);
                AccountDTO customer = new AccountDTO();
                customer = BL.GetCustomer(SESSION_VAR);
                ShoppingTable.DataSource = GetDataTable(invoices);
                ShoppingTable.DataBind();

                if (invoices.Count() > 0)
                {
                    tableShoppingHistoryLabel.Text = $"The transactionlist of {customer.GetFirstName()} " +
                        $"{customer.GetLastName()} has {invoices.Count()} items.";
                }
                else
                {
                    tableShoppingHistoryLabel.Text = "The transactionlist is empty.";
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }


        protected DataTable GetDataTable(IEnumerable<InvoiceDTO> invoices)
        {
            //DataTable initialization
            DataTable dtInvoice = new DataTable();

            //Colmuns declaration
            dtInvoice.Columns.Add("InvoiceNumber");
            dtInvoice.Columns.Add("Quantity");
            dtInvoice.Columns.Add("TotalAmount");
            dtInvoice.Columns.Add("OrderDate");
            dtInvoice.Columns.Add("ArrivalDate");
            dtInvoice.Columns.Add("PaymentStatus");
            dtInvoice.Columns.Add("PaymentDate");

            foreach (InvoiceDTO invoice in invoices)
            {
                DataRow dr = dtInvoice.NewRow();
                dr["InvoiceNumber"] = invoice.GetID();
                dr["Quantity"] = invoice.GetQuantity();
                dr["TotalAmount"] = invoice.GetTotal();
                dr["OrderDate"] = invoice.GetOrderDate();
                dr["ArrivalDate"] = invoice.GetArrivalDate();
                dr["PaymentDate"] = invoice.GetPaymentDate();
                if (invoice.GetStatus() == 1)
                {
                    dr["PaymentStatus"] = "Paied";
                }
                else
                {
                    dr["PaymentStatus"] = "Open";
                }
                dtInvoice.Rows.Add(dr);
            }
            return dtInvoice;
        }

        // Get all data from DB
        protected AccountDTO GetUserData(string email)
        {
            AccountDTO customer = new AccountDTO();
            try
            {               
                customer = BL.GetCustomer(email);               
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return customer;
        }

        // Get all data from DB
        protected AddressDTO GetAddressData(string email)
        {
            AddressDTO address = new AddressDTO();
            try
            {                
                address = ABL.FindAddress(email);                
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return address;
        }

        // Get all data from DB
        protected IEnumerable<InvoiceDTO> GetShoppingList(string email)
        {
            IEnumerable<InvoiceDTO> transactions = new List<InvoiceDTO>();
            try {            
            transactions = IBL.FindInvoices(email);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return transactions;
        }      
    }
}