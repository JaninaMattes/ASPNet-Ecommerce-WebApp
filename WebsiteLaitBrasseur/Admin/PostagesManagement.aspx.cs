using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class PostagesOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTableLabel();

                BindPostages();
            }
        }



        protected void PostageTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            lblError.Text = "Error : Database not connected";

        }


        protected void PostageTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblError.Text = "Error : Database not connected";
        }



        protected void BindPostages()
        {
            PostageTable.DataSource = getPostage();
            PostageTable.DataBind();
        }

        protected void BindTableLabel()
        {
            List<Postage> postageLs = getPostage();
            if (postageLs.LongCount<Postage>() > 0)
            {
                lblPostageList.Text = "There is " + postageLs.LongCount<Postage>() + " postage options";
            }
        }


        protected List<Postage> getPostage()
        {
            List<Postage> postageLs= new List<Postage>();
            Postage ls = new Postage(0, "Provider1", 2.50);
            postageLs.Add(ls);
            ls = new Postage(1, "Provider2", 5.0);
            postageLs.Add(ls);
            ls = new Postage(2, "Provider3", 7.0);
            postageLs.Add(ls);

            return postageLs;


        }

        public class Postage
        {
            public int ProviderID { get; set; }
            public string ProviderName { get; set; }
            public double CostPerUnit { get; set;}

            public Postage (int providerID, string providerName, double cost)
            {
                this.ProviderID = providerID;
                this.ProviderName = providerName;
                this.CostPerUnit = cost;
            }
        }


    }
}