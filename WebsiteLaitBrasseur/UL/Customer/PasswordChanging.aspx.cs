using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class PasswordChanging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if ((Request.QueryString["RecupID"] != null)  )                         //Test if url contain recupID token
            {
                string[] strRecupValues = (string[])(this.Session["RecupValues"]);  //Session values recuperation   

                if ((Request.QueryString["RecupID"] == strRecupValues[0]))          //Test if RecupID from URL = RecupID from Session       
                {
                    this.Session["EmailRecuperation"] = strRecupValues[1];          //Customer email is put in another varaible session
                }
                else  //Redirection
                {
                    string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Login.aspx";
                    Response.Redirect(url);
                }
            }
            else   //Redirection
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Login.aspx";
                Response.Redirect(url);
            }*/

        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            //TODO : TEST password resistance

            //TODO : Update Password (slat generation + Hash(password+salt) + storage in DB)

            Session.Remove("RecupValues");
            Session.Remove("EmailRecuperation");
        }
    }
}