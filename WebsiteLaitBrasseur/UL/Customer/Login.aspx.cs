using System;
using System.Collections.Generic;
using System.Configuration;
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

            var isCorrect = BL.IsCustomerLoginCorrect(TextEmail.Text.Trim(), TextPassword.Text.Trim());
            switch (isCorrect)
            {
                case 0:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Password and Email don't exist. Please register.";
                    break;
                case 1:
                    //variable session creation
                    //session is a dictionary inside ASP.NET
                    SessionInit();
                    string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Default.aspx";
                    Response.Redirect(url);
                    break;
                case 2:
                    //if user is admin cant log in to customer page
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Not entitled to log in as customer. Please register";   //No time to display
                    Response.Redirect("/UL/Customer/Register.aspx");
                    break;
                case 3:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Password is incorrect.";
                    break;
                case 4:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Email is incorrect.";
                    break;
                case 5:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "User is suspendet.";
                    break;
                default: 
                    break;
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Register.aspx";
            Response.Redirect(url);

        }

        private void SessionInit()
        {
            Session["email"] = TextEmail.Text.Trim();
            Session["CustID"] = BL.GetCustomer(TextEmail.Text.Trim()).GetID();
            Session["DateInit"] = DateTime.Now;
        }
    }
}

