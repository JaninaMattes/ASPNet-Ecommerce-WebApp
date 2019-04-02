using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class RegisterAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            Label1.Text = TextUsername.Text + ", you are an admin of LaitBrasseur Website";
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Default.aspx");
        }
    }
}