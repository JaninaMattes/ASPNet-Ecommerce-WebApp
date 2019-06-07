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
    public partial class Logout : System.Web.UI.Page
    {
        AccountBL BL = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Redirection if not login
            if (this.Session["custID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
            }
            try
            {
                string email = this.Session["Email"].ToString();

                //session information check
                if (email != null)
                {
                    AccountBL BL = new AccountBL();
                    AccountDTO account = new AccountDTO();
                    account = BL.GetCustomer(email);
                    lblGoodBye.Text = $"Good Bye {account.GetFirstName()} {account.GetLastName()}";

                    //Session variable removing
                    this.Session.Remove("CustID");
                    this.Session.Remove("Email");
                    this.Session.Remove("DateInit");

                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                lblGoodBye.Text = "Good bye";
            }
        }
    }
}