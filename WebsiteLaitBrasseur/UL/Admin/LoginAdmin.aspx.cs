using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Security.Cryptography;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        AccountBL bl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Debug.Write("Avant fonction"); //DEBUG
            string password = "123456";
            HashPassword(password);
            Debug.Write("\nSortie Fonction"); //DEBUG*/
            LblErrorMessage.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            AccountBL BL = new AccountBL();

            var isCorrect = BL.IsAdminLoginCorrect(TextEmail.Text.Trim(), TextPassword.Text.Trim());
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
                    Response.Redirect("/UL/Admin/Default.aspx");
                    break;
                case 2:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "You are not registered as admin."; //Add link?
                    break;
                case 3:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Password is incorrect.";
                    break;
                case 4:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Username is incorrect.";
                    break;
                case 5:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Login is not confirmed. Please find confirmation link in email.";                    
                    break;
                case 6:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "User is suspendet.";
                    break;
                default:
                    break;
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Admin/RegisterAdmin.aspx");
        }

        private void SessionInit()
        {
            Session["Email"] = TextEmail.Text.Trim();
            Session["AdminID"] = bl.GetCustomer(TextEmail.Text.Trim()).GetID();
            Session["DateInit"] = DateTime.Now;         
        }
    }
}