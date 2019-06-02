using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class EmailRecuperation : System.Web.UI.Page
    {
        AccountBL BL = new AccountBL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (BL.GetCustomer(TextEmail.Text.Trim()) != null)
                {
                    MailSender();
                }


            }catch(Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }
        }

        private void MailSender()
        {
            try
            {
                //variable session creation
                Random random = new Random();   //Random Object creation
                int recupID = random.Next();    //Random int values attributes to recupID
                string strRecupID = recupID.ToString();    //conversion int=>string 
                Session["RecupValues"] = new string[] { strRecupID, TextEmail.Text.Trim() };    //RecupId and customer email are put in the same array assessions variables

                if (strRecupID != null)
                {
                    //Mail sending procedure

                    //Message creation (To / From/ link to verification)
                    MailMessage mm = new MailMessage();
                    mm.To.Add(new MailAddress(TextEmail.Text, "Request for New Password"));
                    mm.From = new MailAddress("webProgProjUon@gmail.com");
                    mm.Body = "<a href='https://localhost:44314/UL/Customer/PasswordRecuperation.aspx?RecupID=" + strRecupID + " '> click here to reinitialize your password </a>";
                    mm.IsBodyHtml = true;
                    mm.Subject = "Verification";

                    //SMTP client initialization (gmail with projet address)
                    SmtpClient smcl = new SmtpClient();
                    smcl.Host = "smtp.gmail.com";
                    smcl.Port = 587;
                    smcl.Credentials = new NetworkCredential("webProgProjUon@gmail.com", "clementjanina");
                    smcl.EnableSsl = true;
                    smcl.Send(mm);

                    lblResult.CssClass = "text-success";
                    lblResult.Text = "A recuperation email has been sent.";
                }
                else
                    lblResult.Text = "Internal error.";
            }
            catch(Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }

        }
    }
}