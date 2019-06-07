using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Security.Cryptography;
using System.Configuration;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        AccountBL bl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LblErrorMessage.Visible = false;

            //Redirection HTTPS if not
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx";
                Response.Redirect(url);
            }

            //Remove authentication variables if already logged
            if (this.Session["AdminID"] != null)
            {
                this.Session.Remove("Email");
                this.Session.Remove("AdminID");
                this.Session.Remove("DateInit");
            }
        }

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <returns>
        /// 0:doesn't exist
        /// 1:Valid
        /// 2:Not Admin
        /// 3:Password incorrect
        /// 4:Username incorrect
        /// 5:Not confirmed
        /// 6:suspended
        /// 7:error during check with DB information
        /// </returns>
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            int isCorrect=-1;

            //Check the correspondence with the data in the DB
            try
            {
                isCorrect = bl.IsAdminLoginCorrect(TextEmail.Text.Trim(), TextPassword.Text.Trim());
            }
            catch(Exception ex)
            {
                isCorrect = -1;
                Debug.Write(ex.ToString());
            }

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
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/Default.aspx");
                    break;
                case 2:
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "You are not registered as admin."; 
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
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = "Error Database.";
                    break;
            }
        }

        //Redirection to Register
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/RegisterAdmin.aspx");
        }

        /// <summary>
        /// Initialize the session variables Email/ID/Datetime of connection
        /// </summary>
        private void SessionInit()
        {
            Session["Email"] = TextEmail.Text.Trim();
            Session["AdminID"] = bl.GetCustomer(TextEmail.Text.Trim()).GetID();
            Session["DateInit"] = DateTime.Now;
        }
    }
}