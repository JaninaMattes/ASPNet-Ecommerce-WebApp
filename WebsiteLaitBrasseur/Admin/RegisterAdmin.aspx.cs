using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class RegisterAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                /*Set up a cookie with user informations*/
                DateTime expiry = DateTime.Now.AddMinutes(5);
                SetCookie("email", TextEmail.Text, expiry);         //Improvement: give user as argument
                MailSender();
            }

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/LoginAdmin.aspx");
        }

        private void SetCookie(string name, string value, DateTime expiry)
        {
            HttpCookie cookieVerifRegistration = new HttpCookie(name, value);
            cookieVerifRegistration.Expires = expiry;
            Response.Cookies.Add(cookieVerifRegistration);
        }

        private void MailSender()
        {
            HttpCookie email = Request.Cookies["email"];    //Cookie recuperation

            if (email != null)
            {
                //Message creation (To / From/ link to verification)
                MailMessage mm = new MailMessage();                                         
                mm.To.Add(new MailAddress(TextEmail.Text, "Request for Verification"));
                mm.From = new MailAddress("webProgProjUon@gmail.com");
                mm.Body = "<a href='http://localhost:54429//Admin/VerificationPage.aspx?email=" + email.Value + " '> click here to verify </a>" ;
                mm.IsBodyHtml = true;
                mm.Subject = "Verification";

                //SMTP client initialization (gmail with projet address)
                SmtpClient smcl = new SmtpClient();
                smcl.Host = "smtp.gmail.com";
                smcl.Port = 587;
                smcl.Credentials = new NetworkCredential("webProgProjUon@gmail.com", "clementjanina");
                smcl.EnableSsl = true;
                smcl.Send(mm);

                lblRegResult.Text = "A confirmation email has been sent.";
            }
            else
                lblRegResult.Text = "There is a problem with your email.";


        }
    }
}