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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Session["AdminID"] == null)
                {
<<<<<<< HEAD
                    AccountBL BL = new AccountBL();
=======
                    string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Admin"] + "LoginAdmin.aspx";

                    Response.Redirect(url);
                }
                else
                {
                    int adminID = Convert.ToInt32(this.Session["AdminID"]);
>>>>>>> 02dd0317ad930a777a90cd6fa37e43ac294e14da
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