using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblErrorMessage.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            LoginBL bl = new LoginBL();


            if (bl.Check(TextEmail.Text.Trim(), TextPassword.Text.Trim()))
            {
                //variable session creation
                //session is a dictionary inside ASP.NET
                Session["email"] = TextEmail.Text.Trim();
                Response.Redirect("/UL/Admin/Default.aspx");
            }
            else
            {
                LblErrorMessage.Visible = true;
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Admin/RegisterAdmin.aspx");
        }
    }
}