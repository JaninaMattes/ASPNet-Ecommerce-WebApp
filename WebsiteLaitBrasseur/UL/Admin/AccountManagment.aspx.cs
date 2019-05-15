using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class AccountManagment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserLabel();
                BindCustomer();
            }
        }

        ////Grid methods
            //Status modification : activate/ suspend
        protected void UserListTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = UserListTable.Rows[index];
            if (row.Cells[5].Text.ToString() == "False") { row.Cells[5].Text = "True"; }
            else if (row.Cells[5].Text.ToString() == "True") { row.Cells[5].Text = "False"; }
        }

            //redirection to transanctions history page
        protected void UserListTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Index of grid recuperation
            int index = Convert.ToInt32(e.NewEditIndex);

            //Row recuperation
            GridViewRow row = UserListTable.Rows[index];

            //UserID recuperation
            string userID = row.Cells[0].Text.ToString();

            Response.Redirect("/UL/Admin/Transactions.aspx?custid=" + userID);
        }



        ////Data creation methods  + postage class

        protected void BindCustomer()
        {
            UserListTable.DataSource = getCustomer();
            UserListTable.DataBind();
        }

            //Bind of beginning label informing about the number of customer
        protected void BindUserLabel()
        {
            List<Customer> customerLs = getCustomer();
            if (customerLs.LongCount<Customer>() > 0)
            {
                lblUserList.Text = "There is " + customerLs.LongCount<Customer>() + " registered customer";
            }
        }

            //Customer list creation
        protected List<Customer> getCustomer(){
            List<Customer> customerLs = new List<Customer>();
            Customer customer = new Customer(11110, "Marcus", "Miller", "Marc.M@gmail.com", "+6194563221",  false);
            customerLs.Add(customer);
            customer = new Customer(11111, "Maria", "Doberthy", "MariaDB@gmail.com", "0455236874", false);
            customerLs.Add(customer);
            customer = new Customer(11112, "Jean", "Labit", "JLB@outlook.com", "0452456789", false);
            customerLs.Add(customer);
            return customerLs;
        }

            // Customer class + builder
        public class Customer
        {
            public int userId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string phoneNo { get; set; }
            public bool isSuspended { get; set; }

            public Customer(int userId, string firstName, string lastName, string email, string phoneNo, bool isSuspended)
            {
                this.userId = userId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.email= email;
                this.phoneNo = phoneNo;
                this.isSuspended = isSuspended;
            }
        }


    }
}