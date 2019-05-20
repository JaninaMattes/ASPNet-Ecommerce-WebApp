using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class VerificationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //User informations recuperated from cookie
                if ((Request.QueryString["ConfID"] != null) && (Request.QueryString["ConfID"] == this.Session["ConfID"].ToString()))
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

                    
                }
                


            }
        }
    }
}