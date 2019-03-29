using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!String.IsNullOrEmpty(Request.QueryString["srch"])
            {
                //perform search and display results
            }*/
        }


        
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            /*
            var searchText = Server.UrlEncode(txtSearchMaster.Text);    // URL encode in case of special characters
            Response.Redirect("~/.aspx?srch=" + searchText);
            */
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {


        }

        protected void btnUserProfile_Click(object sender, EventArgs e)
        {


        }

    }
}