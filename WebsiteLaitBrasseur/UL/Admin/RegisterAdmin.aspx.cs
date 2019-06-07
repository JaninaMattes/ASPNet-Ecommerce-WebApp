using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Configuration;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class RegisterAdmin : System.Web.UI.Page
    {
        AccountBL BL = new AccountBL();
        private int confirmationID;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblRegResult.Visible = false;

            //Redirectionin HTTPS
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx";
                Response.Redirect(url);
            }

            //Remove authentication variables if already logged
            if (this.Session["Admin"] != null)
            {
                this.Session.Remove("Email");
                this.Session.Remove("AdminID");
                this.Session.Remove("DateInit");
            }

        }

        /// <summary>
        /// Check information enter by user are correct
        /// </summary>
        /// <returns>
        /// 0:Database Error
        /// 1:Valid
        /// 2:Password requirement issue
        /// 3:email invalid
        /// 4:email already taken
        /// </returns>
        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Initialization
                byte isAdmin = 1; //admin 
                byte status = 0; //per default not suspendet user
                var imgPath = " "; //as there is no profile img
                int check = -1;
                Random random = new Random();
                confirmationID = random.Next();
                lblRegResult.Text = " ";

                try
                {
                    check = BL.CreateAccount(TextEmail.Text.Trim(), TextPassword.Text.Trim(), TextFirstName.Text.Trim(),
                    TextLastName.Text.Trim(), TextBirthday.Text.Trim(), TextPhone.Text.Trim(), imgPath, status, isAdmin, confirmationID);
                    Debug.Write("Register Admin / Check Value : " + check);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                    check = -1;
                }

                switch (check)
                {
                    case 0:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "Database error.";
                        break;
                    case 1:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-success";
                        lblRegResult.Text = "Password and email are correct.";
                        MailSender(confirmationID);
                        break;
                    case 2:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "The password format does not meet the requirements.";
                        break;
                    case 3:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "The email format is wrong.";
                        break;
                    case 4:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "The email is already taken.";
                        break;
                    default:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "Error in account creation. Try later"; //TODO explain requirements
                        Debug.Write("Check : out of values");
                        break;
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx");
        }


        /// <summary>
        /// Creation and sending of the confirmation Email:
        /// Get the email from the new account
        /// Send the ConfId in a link toVerification Page by email
        /// </summary>
        /// <param name="confirmationID"></param>
        private void MailSender(int confirmationID)
        {
            BL.GetCustomer(TextEmail.Text.Trim()).SetConfirmationID(confirmationID);
            string confID = confirmationID.ToString();

            if (confID != null)
            {
                //Mail sending procedure

                //Message creation (To / From/ link to verification)
                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(TextEmail.Text, "Request for Verification"));
                mm.From = new MailAddress("webProgProjUon@gmail.com");
                mm.Body = "<a href='https://localhost:44314/UL/Admin/VerificationPage.aspx?ConfID=" + confID + " '> click here to verify</a>";
                mm.IsBodyHtml = true;
                mm.Subject = "Verification";

                //SMTP client initialization (gmail with projet address)
                SmtpClient smcl = new SmtpClient();
                smcl.Host = "smtp.gmail.com";
                smcl.Port = 587;
                smcl.Credentials = new NetworkCredential("webProgProjUon@gmail.com", "clementjanina");
                smcl.EnableSsl = true;
                smcl.Send(mm);

                lblRegResult.CssClass = "text-success";
                lblRegResult.Text = "A confirmation email has been sent.";
            }
            else
                lblRegResult.Text = "There is a problem with your email.";

        }
    }
}