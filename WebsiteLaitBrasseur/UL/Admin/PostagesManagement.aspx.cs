using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class PostagesOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {    
                BindPostages();

                BindPostageLabel();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            //DataTable and DataRow initialization
            int i = PostageTable.Rows.Count;
            DataTable dtPostage = getDataTable();
            DataRow newRow = dtPostage.NewRow();

            //Informations recuperated from textBox and add to the new Row
            newRow["ProviderID"] = i;
            newRow["ProviderName"] = TextAddProvider.Text;
            newRow["CostPerUnit"] = TextAddCost.Text;
            dtPostage.Rows.Add(newRow);

            //Cast the dataTable in the gridview and bind the informations
            PostageTable.DataSource = dtPostage;
            PostageTable.DataBind();
            BindPostageLabel();

        }

        ////Grid methods
            //-RowEditing
            //-RowCancelingEdit
            //-RowUpdating
            //-RowDeleting

        //Row Editing 
        protected void PostageTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PostageTable.EditIndex = e.NewEditIndex;
            BindPostages();

        }

        //Canceling of edition of a row
        protected void PostageTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PostageTable.EditIndex = -1;
            BindPostages();
            lblError.Text = "";
            lblInfo.Text = "";

        }

        //Row Updating
        protected void PostageTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //DataTable and DataRow initiallization
            DataTable dtPostage = getDataTable();
            GridViewRow row = PostageTable.Rows[e.RowIndex];

            //Update the values.
            dtPostage.Rows[row.DataItemIndex]["ProviderName"] = ((TextBox)(row.FindControl("TextProviderName"))).Text;
            dtPostage.Rows[row.DataItemIndex]["CostPerUnit"] = ((TextBox)(row.FindControl("TextCost"))).Text;

            //Reset the edit index.
            PostageTable.EditIndex = -1;

            //Bind data to the GridView control.
            PostageTable.DataSource = dtPostage;
            PostageTable.DataBind();



        }

        //Row Deleting
        protected void PostageTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Index of grid recuperation
            int index = Convert.ToInt32(e.RowIndex);

            //Make the row invisible (Fake suppression)
            PostageTable.Rows[index].Visible = false;
        }


        ////Data creation methods  
            //-getDataTable
            //-BindPostages
            //-BindPostageLabel
            //-postage class

        protected DataTable getDataTable()
        {
            //DataTable initialization
            DataTable dtPostage = new DataTable();

            //Colmuns declaration
            dtPostage.Columns.Add("ProviderID");
            dtPostage.Columns.Add("ProviderName");
            dtPostage.Columns.Add("CostPerUnit");

            //Filling of DataTable with informations existing
            for (int i = 0; i < PostageTable.Rows.Count; i++)
            {
                DataRow dr = dtPostage.NewRow();
                dr["ProviderID"] = PostageTable.Rows[i].Cells[0].Text;
                dr["ProviderName"] = PostageTable.Rows[i].Cells[1].Text;
                dr["CostPerUnit"] = PostageTable.Rows[i].Cells[2].Text;

                dtPostage.Rows.Add(dr);
            }
            return dtPostage;
        }

        protected void BindPostages()
        {
            PostageTable.DataSource = getPostage();     //GridView datasource creation with getPostage
            PostageTable.DataBind();                    //Link datasource to gridview

        }

        //Bind of beginning label informing about the number postage options
        protected void BindPostageLabel()
        {
            if (PostageTable.Rows.Count > 0)
            {
                lblPostageList.Text = "There is " + PostageTable.Rows.Count + " postage options";
            }
        }

        //Postage option list creation
        protected List<Postage> getPostage()
        {
            List<Postage> postageLs = new List<Postage>();
            Postage ls = new Postage(0, "Hermes", 4.95);
            postageLs.Add(ls);
            ls = new Postage(1, "Hermes Express", 20.95);
            postageLs.Add(ls);
            ls = new Postage(2, "PDHL", 15.95);
            postageLs.Add(ls);
            ls = new Postage(2, "PDHL Express", 23.95);
            postageLs.Add(ls);
            ls = new Postage(2, "Postando", 4.95);
            postageLs.Add(ls);

            return postageLs;


        }

        // Postage class + builder
        public class Postage
        {
            public int ProviderID { get; set; }
            public string ProviderName { get; set; }
            public double CostPerUnit { get; set; }

            public Postage(int providerID, string providerName, double cost)
            {
                this.ProviderID = providerID;
                this.ProviderName = providerName;
                this.CostPerUnit = cost;
            }
        }








    }
}