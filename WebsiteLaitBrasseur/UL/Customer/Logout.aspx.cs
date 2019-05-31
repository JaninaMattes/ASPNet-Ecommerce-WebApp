using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Logout : System.Web.UI.Page
    {
        AccountBL BL = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            try {
                //session informations recuperation
                string email = this.Session["email"].ToString();
                if (email != null)
                {
                    AccountBL BL = new AccountBL();
                    AccountDTO account = new AccountDTO();
                    account = BL.GetCustomer(email);
=======
            try
            {
                if (this.Session["custID"] == null)
                {
                    string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Login.aspx";

                    Response.Redirect(url);
                }
                else
                {
                    int custID = Convert.ToInt32(this.Session["custID"]);
                    AccountDTO account = new AccountDTO();
                    account = BL.GetCustomer(custID);
>>>>>>> 02dd0317ad930a777a90cd6fa37e43ac294e14da
                    lblGoodBye.Text = $"Good Bye {account.GetFirstName()} {account.GetLastName()}";
                    //Session variable removing
                    this.Session.Clear();
                }
            }
            catch
            {
                lblGoodBye.Text = "Good bye /Debug : Pas de session";
            }
        }
    }
}