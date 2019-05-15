using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class LoginWebForm : System.Web.UI.Page
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
                //session is a dictionary inside ASP.NET
                Session["email"] = TextEmail.Text.Trim();
                Response.Redirect("/UL/Customer/Default.aspx");

                //variable session creation
                //Session.Add("email", TextEmail.Text);
                }
            else
            {
                LblErrorMessage.Visible = true;
            }            
        }


        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Customer/Register.aspx");
        }

    }
}

