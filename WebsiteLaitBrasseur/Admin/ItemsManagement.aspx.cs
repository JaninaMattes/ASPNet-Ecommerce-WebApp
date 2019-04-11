using System;
using System.Collections.Generic;
using System.Data;
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
                BindItemsLabel();
            }
        }


        //Bind of beginning label informing about the number items
        protected void BindItemsLabel()
        {
            if (ItemListTable.Rows.Count > 0)
            {
                lblItemList.Text = "There is " + ItemListTable.Rows.Count + " items";
            }
        }


        protected void AddButton_Click(object sender, EventArgs e)
        {
            //DataTable and DataRow initialization
            int i= ItemListTable.Rows.Count;
            DataTable dtItem = getDataTable();
            DataRow newrow = dtItem.NewRow();

            //Informations recuperated from textBox and add to the new Row
            newrow["id"]=i+1;
            newrow["productName"] =TextProductName.Text;
            newrow["productType"] = TypeList.SelectedItem.Text ;
            newrow["unit"] =TextUnit.Text;
            newrow["quantity"] =TextQuantity.Text;
            newrow["price"] =TextPrice.Text;
            newrow["available"] =AvailableList.SelectedItem.Text;
            dtItem.Rows.Add(newrow);

            //Cast the dataTable in the gridview and bind the informations
            ItemListTable.DataSource = dtItem;
            ItemListTable.DataBind();
            BindItemsLabel();
        }

        ////Grid Method
            //-RowEditing
            //-RowCancelingEdit
            //-RowUpdating
            //-RowDeleting

        protected void ItemListTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ItemListTable.EditIndex = e.NewEditIndex;
            BindItems();
        }

        protected void ItemListTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ItemListTable.EditIndex = -1;
            BindItems();
            lblError.Text = "";
            lblInfo.Text = "";
        }

        protected void ItemListTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //DataTable and DataRow initiallization
            DataTable dtItemList = getDataTable();
            GridViewRow row = ItemListTable.Rows[e.RowIndex];

            //Update the values.
            dtItemList.Rows[row.DataItemIndex]["productName"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
            dtItemList.Rows[row.DataItemIndex]["productType"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
                    //dtItemList.Rows[row.DataItemIndex]["productType"] = ((DropDownList)(row.Cells[2].Controls[0])).SelectedValue;
            dtItemList.Rows[row.DataItemIndex]["unit"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dtItemList.Rows[row.DataItemIndex]["quantity"] = ((TextBox)(row.Cells[4].Controls[0])).Text;
            dtItemList.Rows[row.DataItemIndex]["price"] = ((TextBox)(row.Cells[5].Controls[0])).Text;
            dtItemList.Rows[row.DataItemIndex]["available"] = ((TextBox)(row.Cells[6].Controls[0])).Text;
                    //dtItemList.Rows[row.DataItemIndex]["available"] = ((DropDownList)(row.Cells[6].Controls[0])).SelectedValue;


            //Reset the edit index.
            ItemListTable.EditIndex = -1;

            //Bind data to the GridView control.
            ItemListTable.DataSource = dtItemList;
            ItemListTable.DataBind();

        }

        protected void ItemListTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Index of grid recuperation
            int index = Convert.ToInt32(e.RowIndex);

            //Make the row invisible (Fake suppression)
            ItemListTable.Rows[index].Visible = false;

        }



        ////Data creation methods  
            //-getDataTable
            //-BindItems
        protected DataTable getDataTable()
        {
            //DataTable initialization
            DataTable dtItem = new DataTable();

            //Colmuns declaration
            dtItem.Columns.Add("id");
            dtItem.Columns.Add("productName");
            dtItem.Columns.Add("ProductType");
            dtItem.Columns.Add("unit");
            dtItem.Columns.Add("quantity");
            dtItem.Columns.Add("price");
            dtItem.Columns.Add("available");

            //Filling of DataTable with informations existing
            for (int i = 0; i < ItemListTable.Rows.Count; i++)
            {
                DataRow dr = dtItem.NewRow();
                dr["id"] = ItemListTable.Rows[i].Cells[0].Text;
                dr["productName"] = ItemListTable.Rows[i].Cells[1].Text;
                dr["productType"] = ItemListTable.Rows[i].Cells[2].Text;
                dr["unit"] = ItemListTable.Rows[i].Cells[3].Text;
                dr["quantity"] = ItemListTable.Rows[i].Cells[4].Text;
                dr["price"] = ItemListTable.Rows[i].Cells[5].Text;
                dr["available"] = ItemListTable.Rows[i].Cells[6].Text;

                dtItem.Rows.Add(dr);
            }
            return dtItem;
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