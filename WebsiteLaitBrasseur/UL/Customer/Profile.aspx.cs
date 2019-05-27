using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Profile : System.Web.UI.Page
    {
        AccountBL DB = new AccountBL();
        string SESSION_VAR; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SESSION_VAR = HttpContext.Current.Session["Email"].ToString();
                //SESSION_VAR = "janina.mattes@gmail.com";
                /*Fill the shopping history table with data from the backend 
                 * and bind these to the datafields*/
                BindGridList();
                /*Fill the label with accurat item number*/
                BindTableLabel();
                /*Fill the user profiel information*/
                BindProfileData();
            }

            DeleteButton_Click(sender, e);
            SaveButton_Click(sender, e);

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
                ProfilePicture.ImageUrl = "~/UL/Images/defaultImg";
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