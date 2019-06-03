using System;
using System.Collections.Generic;
using System.Configuration;
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
                    int adminID = Convert.ToInt32(this.Session["AdminID"]);
                    AccountDTO account = new AccountDTO();
                    account = BL.GetCustomer(adminID);
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