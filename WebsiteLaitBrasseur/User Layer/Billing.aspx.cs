﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreditCardButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User Layer/CardPayment.aspx");
        }
    }
}