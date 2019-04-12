﻿using System;
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
            if (IsValid)
            {
                Session.Add("email", TextEmail.Text);
            }
            Response.Redirect("/Admin/Default.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/RegisterAdmin.aspx");
        }
    }
}