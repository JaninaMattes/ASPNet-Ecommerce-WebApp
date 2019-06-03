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
            if (this.Session["custID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
            }
            try {
                //session informations
                string email = this.Session["Email"].ToString();
                if (email != null)
                {
                    AccountBL BL = new AccountBL();
                    AccountDTO account = new AccountDTO();
                    account = BL.GetCustomer(email);
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