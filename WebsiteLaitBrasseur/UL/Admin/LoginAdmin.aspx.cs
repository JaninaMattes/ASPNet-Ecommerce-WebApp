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
<<<<<<< HEAD
            AccountBL BL = new AccountBL();
=======
            
>>>>>>> 02dd0317ad930a777a90cd6fa37e43ac294e14da

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
                    SessionInit();
                    Response.Redirect("/UL/Admin/Default.aspx");
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
                    LblErrorMessage.Text = "Your account is currently suspended";
                    break;
                case 5:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Your email isn't confirmed";
                    break;
                case 6:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "You are not an admin, please join the Customer Login Page"; //Add link?
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
            Session["email"] = TextEmail.Text.Trim();
            Session["AdminID"] = bl.GetCustomer(TextEmail.Text.Trim()).GetID();
            Session["DateInit"] = DateTime.Now;         
        }



    }
}