using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Configuration;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class VerificationPage : System.Web.UI.Page
    {
        // BL/DTO variables 
        AccountBL blAccount= new AccountBL();
        AccountDTO dtoAccount = new AccountDTO();

        //Redirection url
        string url = ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Request.QueryString["ConfID"] != null))
                {
                    int paramConfID = (Convert.ToInt32(Request.QueryString["ConfID"]));         //ConfID (URL parameter recuperation)
                    dtoAccount =blAccount.GetCustomerByConfID(paramConfID);                     //Admin recuperation

                    if (dtoAccount.GetConfirmationID() == 0) { lblRegistrationResult.Text = "Account already confirmed or ConfID invalid"; }  
                    else if ((paramConfID == dtoAccount.GetConfirmationID()))   //Test parameterConfID =?= ConfID in DB
                    {
                        if (blAccount.UpdateIsConfirmed(dtoAccount.GetEmail()) == 1)    //Update isConfirmed
                        {
                            lblRegistrationResult.Text = " you are well registered";
                        }
                        else
                        {
                            lblRegistrationResult.Text = "Issue during verification";
                        }
                    }
                    else { Response.Redirect(url); }
                }
                else   {Response.Redirect(url);}
            }
        }
    }
}