using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Account
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            /*Label1.Text = TextLogin.Text + " " + TextPassword.Text + " you are logged in.";*/
            if (IsValid)
            {
                DateTime expiry = DateTime.Now.AddMinutes(5);
                SetCookie("email", TextEmail.Text, expiry);
            }
            Response.Redirect("/Default.aspx");
        }


        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Register.aspx");
        }

        private void SetCookie(string name, string value , DateTime expiry)
        {
            HttpCookie cookieUser = new HttpCookie(name, value);
            cookieUser.Expires = expiry;
            Response.Cookies.Add(cookieUser);
        }
    }
}

