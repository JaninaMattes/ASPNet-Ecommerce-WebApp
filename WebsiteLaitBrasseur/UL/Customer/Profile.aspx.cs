﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Data;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Profile : System.Web.UI.Page
    {
        AccountBL DB = new AccountBL();
        InvoiceBL BL = new InvoiceBL();

        string SESSION_VAR; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SESSION_VAR = HttpContext.Current.Session["Email"].ToString();
                //SESSION_VAR = "janina.mattes@gmail.com";
                /*Fill the shopping history table with data from the backend 
                 * and bind these to the datafields*/

                /*Fill the user profiel information*/

                BindProfileData();
                //Shopping history
                BindDataInvoices();

            }

            DeleteButton_Click(sender, e);
            SaveButton_Click(sender, e);

        }

        //Useless?
        protected void BindData()
        {
            //Account
            //Account init
            account = blAccount.GetCustomer(SESSION_VAR);

            //BindData
            TextFirstname.Text = account.GetFirstName();
            TextLastname.Text = account.GetLastName();
            TextPhone.Text = account.GetPhoneNo();
            TextBirthday.Text = account.GetBirthdate(); //WARNING : issue format
            TextEmail.Text = account.GetEmail();

            //Address 
            //Address init
            address = blAddress.FindAddress(account.GetID());

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


            //ShoppingTable
            //List invoices init
            LI = blInvoice.FindInvoices(SESSION_VAR);
            Debug.Write("Invoices infos : " + LI.Count);

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

            for (int i = 0; i < LI.Count; i++)
            {
                DataRow dr = dtShoppingTable.NewRow();
                dr["ID"] = LI[i].GetID();
                dr["TotalQuantity"] = LI[i].GetTotal();
                dr["TotalShippinCost"] = LI[i].GetShippingCost();
                dr["TotalTaxes"] = LI[i].GetTax();
                dr["PaymentDate"] = LI[i].GetPaymentDate();
                dr["ArrivalDate"] = LI[i].GetArrivalDate();
                dr["PostageDate"] = LI[i].GetPostDate();
                dr["Status"] = LI[i].GetStatus();


                dtShoppingTable.Rows.Add(dr);

            }
            return dtShoppingTable;
        }




        protected void DeleteButton_Click(object sender, EventArgs e)
        {
             // suspend the user dont delete
             int status = 1;
             DB.UpdateStatus(SESSION_VAR, status);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var email = TextEmail.Text;
            var fName = TextFirstname.Text;
            var lName = TextLastname.Text;
            var birthDate = TextBirthday.Text;
            var phoneNo = TextPhone.Text;
            var imgPath = ProfilePicture.ImageUrl;
            //var password = TextPassword.Text;
            var result = DB.Update(email,fName, lName,birthDate, phoneNo, imgPath);
            Debug.Print("Profile aspx: /Save Button / Update " + result);
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
        }

        /*Fill the shopping history table with data from the backend 
         * and bind these to the datafields*/
        protected void BindGridList()
        {
            //ShoppingTable.DataSource = GetShoppingList(SESSION_VAR);
            //ShoppingTable.DataBind();
        }


        /*Fill the label with accurat item number*/
        protected void BindTableLabel()
        {
            IEnumerable<InvoiceDTO> transactions = GetShoppingList(SESSION_VAR);
            if (transactions.LongCount<InvoiceDTO>() > 0)
            {
                tableShoppingHistoryLabel.Text = "Your shopping history has " + transactions.LongCount<InvoiceDTO>() + " items.";
            }
        }


        /*Fill the label with accurat item number*/
        protected void BindProfileData()
        {
            if(GetUserData(SESSION_VAR).GetImgPath().Equals(" "))
            {
                ProfilePicture.ImageUrl = "~/UL/Images/defaultImg.jpg";
            }
            ProfilePicture.ImageUrl = GetUserData(SESSION_VAR).GetImgPath();
            /*Textboxes with editable section information*/
            TextFirstname.Text = GetUserData(SESSION_VAR).GetFirstName();
            TextLastname.Text = GetUserData(SESSION_VAR).GetLastName();
            TextPhone.Text = GetUserData(SESSION_VAR).GetPhoneNo();
            //TextBirthday.Text = Convert.ToDateTime(GetUserData(SESSION_VAR).GetBirthdate()).ToString();
            TextEmail.Text = GetUserData(SESSION_VAR).GetEmail();
            TextName.Text = GetUserData(SESSION_VAR).GetFirstName() + " " + GetUserData(SESSION_VAR).GetLastName();

            /*Textboxes with editable section information*/
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
                invoices = BL.FindInvoices(SESSION_VAR);
                AccountDTO customer = new AccountDTO();
                customer = DB.GetCustomer(SESSION_VAR);
                ShoppingTable.DataSource = GetDataTable(invoices);
                ShoppingTable.DataBind();

                if (invoices.Count() > 0)
                {
                    tableShoppingHistoryLabel.Text = $"The transactionlist of {customer.GetFirstName()} " +
                        $"{customer.GetLastName()} has {invoices.Count()} items.";
                }
                else
                {
                    tableShoppingHistoryLabel.Text = $"The transactionlist is empty.";
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





        /*Dummy data for demonstration purpose*/
        protected AccountDTO GetUserData(string email)
        {
            AccountDTO customer = new AccountDTO();
            AccountBL BL = new AccountBL();
            customer = BL.GetCustomer(email);
            return customer;
        }
        
        /*Dummy data for demonstration purpose*/
        protected AddressDTO GetAddressData(string email)
        {
            AddressBL BL = new AddressBL();
            AddressDTO address = new AddressDTO();
            address = BL.FindAddress(email);
            return address;
        }

        /*Dummy data for demonstration purpose*/
        protected IEnumerable<InvoiceDTO> GetShoppingList(string email)
        {
            //ProductSelectionBL BL = new ProductSelectionBL();
            InvoiceBL BL = new InvoiceBL();
            IEnumerable<InvoiceDTO> transactions = new List<InvoiceDTO>();
            transactions = BL.FindInvoices(email);
            return transactions;
        }      
    }
}