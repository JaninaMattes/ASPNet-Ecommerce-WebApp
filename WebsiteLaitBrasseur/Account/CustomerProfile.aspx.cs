using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Account
{
    public partial class CustomerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SaveButton_Click(sender, e);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            /*Label_Message.Text = "Changes are saved successfully.";*/
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {

        }
    }
}