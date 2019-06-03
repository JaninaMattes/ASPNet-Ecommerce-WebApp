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
                if (this.Session["CustID"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Login.aspx"); ;
                }

                try
                {
                    var segments = Request.GetFriendlyUrlSegments();
                    string result = segments[0];
                    if (result == null) { Debug.Write("\nError Url Friendly"); } //DEBUG 

                    this.Session["attempt"] = 0;
                    if (this.Session["CustID"] != null && result != null)     //Test customer is authentified OK ; else => redirection login  
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
                catch(Exception ex)
                {
                    ex.GetBaseException();
                }
            }
        }
    }
}