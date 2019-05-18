using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class RegisterAdmin : System.Web.UI.Page
    {
        AccountBL bl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
           //TODO
        }
        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var isAdmin = 1;
                bl.createAccount(); //TODO

                //variable session creation
                Session["email"] = TextEmail.Text.Trim();
                MailSender();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Admin/LoginAdmin.aspx");
        }

        private void MailSender()
        {
            string email = this.Session["email"].ToString(); ;    //Cookie recuperation

            if (email != null)
            {
                lblRegResult.Text = "A confirmation email has been sent.";

                //Mail sending procedure
                /*
                //Message creation (To / From/ link to verification)
                MailMessage mm = new MailMessage();                                         
                mm.To.Add(new MailAddress(TextEmail.Text, "Request for Verification"));
                mm.From = new MailAddress("webProgProjUon@gmail.com");
                mm.Body = "<a href='http://localhost:54429//UL/Admin/VerificationPage.aspx?email=" + email + " '> click here to verify </a>" ;
                mm.IsBodyHtml = true;
                mm.Subject = "Verification";

                //SMTP client initialization (gmail with projet address)
                SmtpClient smcl = new SmtpClient();
                smcl.Host = "smtp.gmail.com";
                smcl.Port = 587;
                smcl.Credentials = new NetworkCredential("webProgProjUon@gmail.com", "clementjanina");
                smcl.EnableSsl = true;
                smcl.Send(mm);
                */
            }
            else
                lblRegResult.Text = "There is a problem with your email.";


        }
    }
}