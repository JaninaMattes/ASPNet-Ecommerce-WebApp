using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                /*Fill the shopping history table with data from the backend 
                 * and bind these to the datafields*/
                BindGridList();
                /*Fill the label with accurat item number*/
                BindTableLabel();
                /*Fill the user profiel information*/
                BindProfileTextBox();
            }

            DeleteButton_Click(sender, e);
            SaveButton_Click(sender, e);

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            /*save all input information from values and send it to server*/
            //string myname = Request.Form["first_name_txt"];
            //...firstName = Request.Form["FirstnameTextbox"];
        }

        /*Fill the shopping history table with data from the backend 
         * and bind these to the datafields*/
        protected void BindGridList()
        {
            ShoppingTable.DataSource = getShoppingList();
            ShoppingTable.DataBind();
        }


        /*Fill the label with accurat item number*/
        /*Fill the label with accurat item number*/
        protected void BindTableLabel()
        {
            List<ShoppingListItem> shoppingLs = getShoppingList();
            if (shoppingLs.LongCount<ShoppingListItem>() > 0)
            {
                tableShoppingHistoryLabel.Text = "Your shopping history has " + shoppingLs.LongCount<ShoppingListItem>();
            }
        }


        /*Fill the label with accurat item number*/
        protected void BindProfileTextBox()
        {

            /*Textboxes with editable section information*/
            TextFirstname.Text = getUserData().firstName;
            TextLastname.Text = getUserData().lastName;
            //UsernameTextBox.Text = getUserData().userName;
            TextPhone.Text = getUserData().phoneNo;
            TextBirthday.Text = getUserData().birthdate;
            TextEmail.Text = getLoginData().email;

            /*Textboxes with editable section information*/
            TextAddress1.Text = getAddressData().streetName;
            TextCity.Text = getAddressData().cityName;
            CountryDropDownList.Text = getAddressData().country;
            TextAddressnumber.Text = getAddressData().streetNo;
            TextZip.Text = getAddressData().postCode;
        }

        /*Dummy data for demonstration purpose*/
        protected Customer getUserData()
        {
            Customer customer = new Customer(11110, "Marcus", "Miller", "MillerMarcus92", "+6194563221", "1992-02-15");
            return customer;
        }

        /*Dummy data for demonstration purpose*/
        protected Login getLoginData()
        {
            Login login = new Login(11111, "marcus.miller@gmail.com", "Xw1234%12");
            return login;
        }

        /*Dummy data for demonstration purpose*/
        protected Address getAddressData()
        {
            Address address = new Address(000012, "University Dr.", "130", "Newcastle", "2300", "Australia");
            return address;
        }

        /*Dummy data for demonstration purpose*/
        protected List<ShoppingListItem> getShoppingList()
        {
            List<ShoppingListItem> shoppingLs = new List<ShoppingListItem>();
            ShoppingListItem ls = new ShoppingListItem(1234, 25.00f, "2019-02-01", "2019-02-25");
            shoppingLs.Add(ls);
            ls = new ShoppingListItem(1235, 25.00f, "2019-01-01", "2019-01-30");
            shoppingLs.Add(ls);
            ls = new ShoppingListItem(1236, 100.00f, "2018-12-01", "2018-12-30");
            shoppingLs.Add(ls);
            return shoppingLs;
        }

        /*Dummy data for demo purpose, to fill the aspx fields until database is connected*/
        public class ShoppingListItem
        {
            public int invoiceNumber { get; set; }
            public float totalAmount { get; set; }
            public string orderDate { get; set; }
            public string arrivalDate { get; set; }

            public ShoppingListItem(int id, float totalAmount, string orderDate, string arrivalDate)
            {
                this.invoiceNumber = id;
                this.totalAmount = totalAmount;
                this.orderDate = orderDate;
                this.arrivalDate = arrivalDate;
            }
        }

        public class Customer
        {
            public int userId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string userName { get; set; }
            public string phoneNo { get; set; }
            public string birthdate { get; set; }

            public Customer(int userId, string firstName, string lastName, string userName, string phoneNo, string birthdate)
            {
                this.userId = userId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.userName = userName;
                this.phoneNo = phoneNo;
                this.birthdate = birthdate;
            }
        }

        public class Address
        {
            public int addressId { get; set; }
            public string streetName { get; set; }
            public string streetNo { get; set; }
            public string cityName { get; set; }
            public string postCode { get; set; }
            public string country { get; set; }

            public Address(int addressId, string streetName, string streetNo, string cityName, string postCode, string country)
            {
                this.addressId = addressId;
                this.streetName = streetName;
                this.streetNo = streetNo;
                this.cityName = cityName;
                this.postCode = postCode;
                this.country = country;
            }
        }

        public class Login
        {
            public int loginId { get; set; }
            public string email { get; set; }
            public string password { get; set; }

            public Login(int loginId, string email, string password)
            {
                this.loginId = loginId;
                this.email = email;
                this.password = password;
            }
        }

    }
}