using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class AccountManagment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TransactionButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //ResultSave.Text = "The statut modification is save.";
        }

        public class Customer
        {
            public int userId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string userName { get; set; }
            public string phoneNo { get; set; }
            public string birthdate { get; set; }
            public int isSuspended { get; set; }

            public Customer(int userId, string firstName, string lastName, 
                string userName, string phoneNo, string birthdate, int isSuspended)
            {
                this.userId = userId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.userName = userName;
                this.phoneNo = phoneNo;
                this.birthdate = birthdate;
                this.isSuspended = isSuspended;
            }
        }
    }
}