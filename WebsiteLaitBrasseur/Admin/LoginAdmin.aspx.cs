using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            /*Label1.Text = TextLogin.Text + " " + TextPassword.Text + " you are logged in.";*/
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/RegisterAdmin.aspx");
        }
    }
}