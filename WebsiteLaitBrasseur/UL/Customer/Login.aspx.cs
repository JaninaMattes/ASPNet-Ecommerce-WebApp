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
        AccountBL BL = new AccountBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            LblErrorMessage.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            var isCorrect = BL.IsLoginCorrect(TextEmail.Text.Trim(), TextPassword.Text.Trim());
            switch (isCorrect)
            {
                case 0:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Password and Email don't exist. Please register.";
                    break;
                case 1:
                    //variable session creation
                    //session is a dictionary inside ASP.NET
                    Session["Email"] = TextEmail.Text.Trim();
                    Response.Redirect("/UL/Customer/Default.aspx");
                    break;
                case 2:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Password is incorrect.";
                    break;
                case 3:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Email address is incorrect.";
                    break;
                case 4:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "User is suspendet.";
                    break;
                default:
                    break;
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Customer/Register.aspx");
        }

    }
}

