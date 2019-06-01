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

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Register : System.Web.UI.Page
    {
        private int confirmationID;

        AccountBL bl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRegResult.Visible = false;
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                byte isAdmin = 0; //customer 
                byte status = 0; //per default not suspendet user
                var imgPath = " "; //as there is no profile img
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
                        MailSender();
                        Session["emailRegister"] = TextEmail.Text.Trim(); //TODO
                        break;
                    case 2:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "The password format does not meet the requirements."; //TODO explain requirements
                        break;
                    case 3:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "The email format is wrong.";
                        break;                        
                    case 4:
                        lblRegResult.Visible = true;
                        lblRegResult.CssClass = "text-danger";
                        lblRegResult.Text = "The email is already taken."; //TODO explain requirements
                        break;
                    default:
                        break;
                }                
            }

            Response.Redirect("/UL/Customer/Login.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Customer/Logout.aspx");
        }

        private void MailSender()
        {
            //variable session creation
            Random random = new Random();
            Session["ConfID"] = random.Next();
            confirmationID = random.Next();

            string confID = this.Session["ConfID"].ToString();    //Cookie recuperation

            if (confID != null)
            {
                //Mail sending procedure

                //Message creation (To / From/ link to verification)
                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(TextEmail.Text, "Request for Verification"));
                mm.From = new MailAddress("webProgProjUon@gmail.com");
                mm.Body = "<a href='http://localhost:54429//UL/Admin/VerificationPage.aspx?ConfID=" + confID + " '> click here to verify </a>";
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