using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class CardPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Customer/Cart.aspx");
        }
    }
}