using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            MailSender();
        }

        private void MailSender()
        {
            string body = TextName.Text + ", " + TextEmail.Text + "\nObject : " + TextObject.Text + "\n " + TextMessage.Text;

            //Mail sending procedure

            //Message creation (To / From/ link to verification)
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(TextEmail.Text));
            mm.From = new MailAddress("contact@lait-brasseur.com");
            mm.Body = body;
            mm.IsBodyHtml = true;
            mm.Subject = "Verification";

            //SMTP client initialization (gmail with projet address)
            SmtpClient smcl = new SmtpClient();
            smcl.Host = "smtp.gmail.com";
            smcl.Port = 587;
            smcl.Credentials = new NetworkCredential("webProgProjUon@gmail.com", "clementjanina");
            smcl.EnableSsl = true;
            smcl.Send(mm);

            ResultLabel.CssClass = "text-success";
            ResultLabel.Text = "Your message has been delivered";
        }
    }
}