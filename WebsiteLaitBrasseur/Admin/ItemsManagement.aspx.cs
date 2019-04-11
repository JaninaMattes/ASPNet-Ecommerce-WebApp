using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur.Admin
{
    public partial class ItemsManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindItems();
            }
        }


        //Bind of beginning label informing about the number items
        protected void BindItemsLabel()
        {
            if (ItemListTable.Rows.Count > 0)
            {
                //lblPostageList.Text = "There are " + ItemListTable.Rows.Count + " items.";
            }
        }


        protected void AddButton_Click(object sender, EventArgs e)
        {
            lblError.Text = "Error : Database connection";
        }

        protected void PostageTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblInfo.Text = "Click again to modify";
        }

        protected void PostageTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Index of grid recuperation
            int index = Convert.ToInt32(e.RowIndex);

            //Make the row invisible (Fake suppression)
            ItemListTable.Rows[index].Visible = false;
        }


        protected void ItemListTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ItemListTable.EditIndex = -1;
            BindItems();
            lblError.Text = "";
            lblInfo.Text = "";
        }

        protected void BindItems()
        {
            var db = new DAL.DemoDatabase();
            var products = db.GetProducts();

            ItemListTable.DataSource = products;
            ItemListTable.DataBind();
        }

    }
}