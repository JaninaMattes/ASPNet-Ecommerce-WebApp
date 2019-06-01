using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class ConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Request.QueryString["ConfID"] != null))
                {
                    string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Login.aspx";
                    Response.Redirect(url);
                }
                //User informations recuperated from cookie
                //TODO
                //select * from account where ConfID == Request.QueryString["ConfID"] && IsConfirmed==false
                //Account.GetEmail
                //bl.UpdateIsConfirmed(email)
                /*if( (Request.QueryString["ConfID"] == this.Session["ConfID"].ToString()))
                {
                    AccountBL bl = new AccountBL();

                    if (bl.UpdateIsConfirmed(this.Session["emailRegister"].ToString()) == 1)
                    {
                        lblRegistrationResult.Text = " you are well registered";
                    }
                    else
                    {
                        lblRegistrationResult.Text = "Issue during verification";
                    }                  
                    
                }*/

            }
        }
    }
}