using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string result="";
                if (this.Session["CustID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx"); ;
                }

                //Attempt reinitialization
                this.Session["attempt"] = 0;

                //Get id from url
                try
                {
                    var segments = Request.GetFriendlyUrlSegments();
                    result = segments[0];
                }
                catch(Exception ex)
                {
                    ex.GetBaseException();
                    Debug.Write(ex.ToString());
                    lblResult.Text = "Error URL";
                }

                //Test customer is authentified OK ; else => redirection login  
                if (this.Session["CustID"] != null && result != null)     
                {
                    if (result == "0")  //Denied
                    {

                        //TODO :
                        //Invoice Status cancel
                        //Rerverse updtae DB
                    }
                    else if (result == "1")  //Approved 
                    {
                        //TODO:
                        //Invoice staus : paied
                    }
                    else { lblResult.Text = "Error"; }
                }
                else
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx");
                }
            }
        }
    }
}