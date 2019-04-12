using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class VerificationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["email"] != null)
                {
                    string CustomerEmail = Request.QueryString["email"].ToString();             //User informations recuperated from cookie
                    lblRegistrationResult.Text = CustomerEmail + " you are well registered";
                }
                


            }
        }
    }
}