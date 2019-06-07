using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class LogoutAdmin : System.Web.UI.Page
    {
        AccountBL BL = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Redirection if not login
                if (this.Session["AdminID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx");
                }
                else
                {
                    //Get user information to display his name
                    int adminID = Convert.ToInt32(this.Session["AdminID"]);
                    AccountDTO account = new AccountDTO();
                    account = BL.GetCustomer(adminID);
                    lblGoodBye.Text = $"Good Bye {account.GetFirstName()} {account.GetLastName()}";

                    //Session variable cleaning
                    this.Session.Remove("AdminID");
                    this.Session.Remove("Email");
                    this.Session.Remove("DateInit");
                }
            }
            catch (Exception ex)
            {
                lblGoodBye.Text = "Good bye ";
                Debug.Write(ex.ToString());
            }
        }
    }
}