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
        AccountBL bl = new AccountBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            LblErrorMessage.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var isCorrect = bl.IsCorrect(TextEmail.Text.Trim(), TextPassword.Text.Trim());

            //TODO switch case check password and email correct

                if (isCorrect == 0)
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

