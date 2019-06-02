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
    public partial class PasswordChanging : System.Web.UI.Page
    {
        AccountBL blAcc = new AccountBL();
        AccountDTO dtoAcc = new AccountDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CustID"] == null)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Customer"] + "Login.aspx";
                Response.Redirect(url);
            }
        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            //Test if password enter by user correspond to its password in DB
            string oldPassword = TextOldPassword.Text;
            int result = -1;
            result=blAcc.IsCustomerLoginCorrect(this.Session["email"].ToString(), oldPassword);


            if (result == 1)    //If password match
            {
                //Update password in DB
                result = blAcc.UpdatePassword(this.Session["email"].ToString(), TextPassword.Text);


                //Display result
                if (result == 1) { lblResult.CssClass = "text-success"; lblResult.Text = "New Password updates with success"; }
                else if (result == 0) { lblResult.CssClass = "text-danger"; lblResult.Text = "Invalid new password"; }
                else { lblResult.CssClass = "text-danger"; lblResult.Text = "Error during treatment of the new password"; }

            }
            //If password doesn't match
            else if (result == 3) { lblResult.CssClass="text-danger"; lblResult.Text = "Password doesn't match"; }
            else { lblResult.CssClass = "text-danger"; lblResult.Text = "Error during treatment"; }


            



        }

    }
}