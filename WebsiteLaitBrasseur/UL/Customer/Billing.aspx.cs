using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Billing : System.Web.UI.Page
    {
        AccountBL blAccount = new AccountBL();
        AddressBL blAddress = new AddressBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Redirection if not login
            if (this.Session["CustID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                string emailCustomer = Convert.ToString(this.Session["Email"]);

                //Bind profile data
                BindData(emailCustomer);

            }
        }

        protected void CartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Cart.aspx");
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string emailCustomer = Convert.ToString(this.Session["Email"]);
            //update User Profile
            var fName = TextFirstname.Text;
            var lName = TextLastname.Text;
            var phoneNo = TextPhone.Text;
            var res1 = blAccount.UpdateNamePhone(emailCustomer, fName, lName,phoneNo);
            Debug.Print("Billing aspx: /Save Button / Update User Info " + res1);

            //update Address
            var streetName = TextAddress.Text;
            var zipCode = TextZip.Text;
            var cityName = TextCity.Text;
            var streetNo = TextAddressnumber.Text;
            var addressType = "Home"; //TODO add field in UI
            var res2 = blAddress.UpdateAddress(emailCustomer, zipCode, cityName, streetName, streetNo, addressType);
            Debug.Print("Billing aspx: /Save Button / Update Address Info " + res2);

            if (res1 == 1) { lblResultNamePhone.CssClass = "text-success"; lblResultNamePhone.Text += "Name and phone modified with success"; }
            else { lblResultNamePhone.CssClass = "text-danger"; lblResultNamePhone.Text += "Error during Name&Phone update"; }
            if (res2 == 1) { lblResultAddress.CssClass = "text-success"; lblResultAddress.Text += "Address modified with success"; }
            else { lblResultAddress.CssClass = "text-danger"; lblResultAddress.Text += "Error during Address update"; }
        }


        //Fill the label with accurat item number
        protected void BindData(string emailCustomer)
        {
            //Textboxes with editable section information
            TextFirstname.Text = GetUserData(emailCustomer).GetFirstName();
            TextLastname.Text = GetUserData(emailCustomer).GetLastName();
            TextPhone.Text = GetUserData(emailCustomer).GetPhoneNo();

            //Textboxes with editable section information
            if (GetAddressData(emailCustomer) != null)
            {
                TextAddress.Text = GetAddressData(emailCustomer).GetStreetName();
                TextCity.Text = GetAddressData(emailCustomer).GetCity().GetCity();
                CountryDropDownList.Text = GetAddressData(emailCustomer).GetCountry();
                TextAddressnumber.Text = GetAddressData(emailCustomer).GetStreetNo().Trim();
                TextZip.Text = GetAddressData(emailCustomer).GetCity().GetZip().Trim();
            }
            else
            {
                TextAddress.Text = "Please add street";
                TextCity.Text = "Please add city";
                CountryDropDownList.Text = " ";
                TextAddressnumber.Text = "Please add number";
                TextZip.Text = "Please add post code";
            }
        }




        // Get all data from DB
        protected AccountDTO GetUserData(string email)
        {
            AccountDTO customer = new AccountDTO();
            try
            {
                customer = blAccount.GetCustomer(email);
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
                address = blAddress.FindAddress(email);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return address;
        }
    }
}
