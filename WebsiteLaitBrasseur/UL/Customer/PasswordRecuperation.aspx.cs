using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class PasswordRecuperation : System.Web.UI.Page
    {
        AccountBL blAcc = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["RecupID"] != null)  )                         //Test if url contain recupID token
            {
                string[] strRecupValues = (string[])(this.Session["RecupValues"]);  //Session values recuperation   

                if ((Request.QueryString["RecupID"] == strRecupValues[0]))          //Test if RecupID from URL = RecupID from Session       
                {
                    this.Session["EmailRecuperation"] = strRecupValues[1];          //Customer email is put in another varaible session
                }
                else  //Redirection
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
                }
            }
            else   //Redirection
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
            }

        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            //Update password in DB
            int result=-1;
            result = blAcc.UpdatePassword(this.Session["EmailRecuperation"].ToString(), TextPassword.Text);

            //Display result
            if (result == 1) { lblResult.CssClass = "text-success"; lblResult.Text = "New Password updates with success"; }
            else if (result == 0) { lblResult.CssClass = "text-danger"; lblResult.Text = "Invalid new password"; }
            else { lblResult.CssClass = "text-danger"; lblResult.Text = "Error during treatment of the new password"; }

            //Session variables removing
            this.Session.Remove("RecupValues");
            this.Session.Remove("EmailRecuperation");
        }
    }
}