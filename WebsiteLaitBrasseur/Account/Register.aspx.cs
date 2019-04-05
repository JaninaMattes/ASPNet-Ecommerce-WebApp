using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            Label1.Text = TextFirstName.Text + ", welcome in LaitBrasseur family !";
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Logout.aspx");
        }
    }
}