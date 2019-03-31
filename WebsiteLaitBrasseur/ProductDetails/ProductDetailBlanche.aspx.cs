using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur
{
    public partial class ProductDetailBlanche : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SizeValue_TextChanged(object sender, EventArgs e)
        {
            if (SizeValue.Text == "33cl")
            {
                PriceValue.Text = "1.5 €";
            }

            else if (SizeValue.Text == "75cl")
            {
                PriceValue.Text = "4 €";
            }
            
        }
    }
}