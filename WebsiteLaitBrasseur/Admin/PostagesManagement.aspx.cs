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
                BindPostageLabel();

                BindPostages();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            lblError.Text = "Error : database connection";
        }

        ////Grid methods
        //Row Deleting
        protected void PostageTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Index of grid recuperation
            int index = Convert.ToInt32(e.RowIndex);

            //Make the row invisible (Fake suppression)
            PostageTable.Rows[index].Visible = false;
        }

            //Row Editing 
        protected void PostageTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblInfo.Text = "Click again to modify";
        }

            //Row Updating (Non-functional)
        protected void PostageTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblError.Text = "Error : database connection";

            /*non functional
            //Index of grid recuperation
            int index = Convert.ToInt32(e.RowIndex);

            //Row recuperation
            GridViewRow row = PostageTable.Rows[index];

            //Non foncitonnel
            row.Cells[1].Text;
            */

        }

            //Canceling of edition of a row
        protected void PostageTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PostageTable.EditIndex = -1;
            BindPostages();
            lblError.Text = "";
            lblInfo.Text = "";

        }


        ////Data creation methods  + postage class

        protected void BindPostages()
        {
            PostageTable.DataSource = getPostage();
            PostageTable.DataBind();
        }

            //Bind of beginning label informing about the number postage options
        protected void BindPostageLabel()
        {
            List<Postage> postageLs = getPostage();
            if (postageLs.LongCount<Postage>() > 0)
            {
                lblPostageList.Text = "There is " + postageLs.LongCount<Postage>() + " postage options";
            }
        }

            //Postage option list creation
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
            
            // Postage class + builder
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