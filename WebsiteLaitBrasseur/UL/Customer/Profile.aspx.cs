using System;
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

        string emailCustomer; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CustID"] == null)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Login.aspx";

                Response.Redirect(url);
            }
            if (!Page.IsPostBack)
            {
                emailCustomer = Convert.ToString(this.Session["email"]);
                //emailCustomer = "janina.mattes@gmail.com";
                //Bind profile data
                BindProfileData();
                //Shopping history
                BindDataInvoices();
            }
        }

 
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            BL.UpdateImgPath(Convert.ToString(this.Session["email"]), TextImageLink.Text);
            Debug.Write("Profile / Image Update / apres  update"); //DEBUG
           
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            // suspend the user dont delete
            int status = 1;
            BL.UpdateStatus(emailCustomer, status);
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
            var res1 = BL.Update(email, fName, lName, birthDate, phoneNo, imgPath);
            Debug.Print("Profile aspx: /Save Button / Update User Info " + res1);

            //update Address
            var streetName = TextAddress1.Text;
            var zipCode = TextZip.Text;
            var cityName = TextCity.Text;
            var streetNo = TextAddressnumber.Text;
            var addressType = "Home"; //TODO add field in UI
            var res2 = ABL.UpdateAddress(email, zipCode, cityName, streetName, streetNo, addressType);
            Debug.Print("Profile aspx: /Save Button / Update Address Info " + res2);

            if (res1 == 1) { lblResultUserInfo.CssClass = "text-success"; lblResultUserInfo.Text += "User informations modified with success"; }
            else { lblResultUserInfo.CssClass = "text-danger"; lblResultUserInfo.Text += "Error during user information update"; }
            if (res2 == 1) { lblResultAddress.CssClass = "text-success"; lblResultAddress.Text += "Address modified with success"; }
            else { lblResultAddress.CssClass = "text-danger"; lblResultAddress.Text += "Error during Address update"; }
        }


        /*Fill the label with accurat item number*/
        protected void BindTableLabel()
        {
            IEnumerable<InvoiceDTO> transactions = GetShoppingList(emailCustomer);
            if (transactions.LongCount<InvoiceDTO>() > 0)
            {
                tableShoppingHistoryLabel.Text = $"Your shopping history has {transactions.LongCount<InvoiceDTO>()} items.";
            }
        }

        //Fill the label with accurat item number
        protected void BindProfileData()
        {
            if(GetUserData(emailCustomer).GetImgPath().Equals(" "))
            {                
                ProfilePicture.ImageUrl = "/Images/defaultImg.jpg";
                Debug.Print($"No image found - default image under { ProfilePicture.ImageUrl.ToString()} used");
            }
            ProfilePicture.ImageUrl = GetUserData(emailCustomer).GetImgPath();

            //Textboxes with editable section information
            TextFirstname.Text = GetUserData(emailCustomer).GetFirstName();
            TextLastname.Text = GetUserData(emailCustomer).GetLastName();
            TextPhone.Text = GetUserData(emailCustomer).GetPhoneNo();
            var birthdate = GetUserData(emailCustomer).GetBirthdate();
            TextBirthday.Text = birthdate.ToString("yyyy-MM-dd");
            TextEmail.Text = GetUserData(emailCustomer).GetEmail();

            //Textboxes with editable section information
            if (GetAddressData(emailCustomer) != null)
            {
                TextAddress1.Text = GetAddressData(emailCustomer).GetStreetName();
                TextCity.Text = GetAddressData(emailCustomer).GetCity().GetCity();
                CountryDropDownList.Text = GetAddressData(emailCustomer).GetCountry();
                TextAddressnumber.Text = GetAddressData(emailCustomer).GetStreetNo().Trim();
                TextZip.Text = GetAddressData(emailCustomer).GetCity().GetZip().Trim();
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
                invoices = IBL.FindInvoices(emailCustomer);
                AccountDTO customer = new AccountDTO();
                customer = BL.GetCustomer(emailCustomer);
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