using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Configuration;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Register : System.Web.UI.Page
    {
        private int confirmationID;

        AccountBL bl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRegResult.Visible = false;

            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Register.aspx";
                Response.Redirect(url);
            }

            if (this.Session["CustID"] != null)
            {
                this.Session.Remove("Email");
                this.Session.Remove("CustID");
                this.Session.Remove("DateInit");
            }
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                byte isAdmin = 0; //customer 
                byte status = 0; //per default not suspendet user
                var imgPath = " "; //as there is no profile img
                Random random = new Random();
                confirmationID = random.Next();
                lblRegResult.Text = " ";

                var check = bl.CreateAccount(TextEmail.Text.Trim(), TextPassword.Text.Trim(), TextFirstName.Text.Trim(),
                   TextLastName.Text.Trim(), TextBirthday.Text.Trim(), TextPhone.Text.Trim(), imgPath, status, isAdmin, confirmationID);
                Debug.Write("Register Customer / Check Value : " + check);

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
                        lblRegResult.Text = "Error in account creation. Try later"; 
                        Debug.Write("Check : out of values");
                        break;
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
        }

        private void MailSender(int confirmationID)
        {
            bl.GetCustomer(TextEmail.Text.Trim()).SetConfirmationID(confirmationID);
            string confID = confirmationID.ToString();

            if (confID != null)
            {
                //Mail sending procedure

                //Message creation (To / From/ link to verification)
                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(TextEmail.Text, "Request for Verification"));
                mm.From = new MailAddress("webProgProjUon@gmail.com");
                mm.Body = "<a href='https://localhost:44314/UL/Customer/ConfirmationPage.aspx?ConfID=" + confID + " '> click here to verify </a>";
                mm.IsBodyHtml = true;
                mm.Subject = "Verification";
                try
                {
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
                catch (SmtpException e)
                {
                    e.GetBaseException();
                }
            }
            else
                lblRegResult.Text = "There is a problem with your email.";
        }
    }
}