using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class ItemsManagement : System.Web.UI.Page
    {
        List<ProductDTO> LP = new List<ProductDTO>();
        List<SizeDTO> LS = new List<SizeDTO>();
        ProductBL blProd = new ProductBL();
        SizeBL blSize = new SizeBL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Initialize Data elements (Gridview / DataSource / session variable)
                BindData();

                //BindItemsLabel();
            }
        }


        protected void BindData()
        {
            LP = blProd.GetAllProducts();
            ItemListTable.DataSource = getDataTable(LP);
            ItemListTable.DataBind();

        }


        protected DataTable getDataTable(List<ProductDTO> LP)
        {
            //DataTable initialization
            DataTable dtItem = new DataTable();

            //Colmuns declaration
            dtItem.Columns.Add("ID");
            dtItem.Columns.Add("Name");
            dtItem.Columns.Add("Type");
            dtItem.Columns.Add("Size");
            dtItem.Columns.Add("Price");
            dtItem.Columns.Add("Stock");
            dtItem.Columns.Add("Status");

            for (int i = 0; i < LP.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    LS = LP[i].GetDetails();
                    DataRow dr = dtItem.NewRow();
                    dr["ID"] = LP[i].GetId();
                    dr["Name"] = LP[i].GetName();
                    dr["Type"] = LP[i].GetProductType();
                    dr["Size"] = LS[j].GetSize();
                    dr["Price"] = LS[j].GetPrice();
                    dr["Stock"] = LP[i].GetStock();
                    dr["Status"] = LP[i].GetStatus();

                    dtItem.Rows.Add(dr);
                }
            }
            return dtItem;
        }


        //////Grid methods
        //    //-RowEditing
        //    //-RowCancelingEdit
        //    //-RowUpdating
        //    //-RowDeleting


        protected void CancelInsertButton_Click(object sender, EventArgs e)
        {
            ItemListTable.ShowFooter = false;
            BindData();
        }


        protected void AddButton_Click(object sender, EventArgs e)
        {
            ItemListTable.ShowFooter = true;
            BindData();
        }

        //Row Deleting
        protected void ItemListTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Index of grid recuperation
            int index = Convert.ToInt32(e.RowIndex);

            //Fake deletion
            ItemListTable.Rows[index].Visible = false;
            lblInfo.CssClass = "text-info";
            lblInfo.Text = "Not real deleting : The row is now invisible";
            lblError.Text = "";
        }

        ////Row Editing 
        protected void ItemListTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ItemListTable.EditIndex = e.NewEditIndex;
            BindData();

        }

        //Canceling of edition of a row
        protected void ItemListTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ItemListTable.EditIndex = -1;
            BindData();
            lblError.Text = "";
            lblInfo.Text = "";

        }


        protected void ItemListTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt16(ItemListTable.Rows[e.RowIndex].Cells[0].Text);
                TextBox newName = ItemListTable.Rows[e.RowIndex].FindControl("TextName") as TextBox;
                DropDownList ddlType = ItemListTable.Rows[e.RowIndex].FindControl("DDLProductType") as DropDownList;
                TextBox newSize = ItemListTable.Rows[e.RowIndex].FindControl("TextSize") as TextBox;
                TextBox newPrice = ItemListTable.Rows[e.RowIndex].FindControl("TextPrice") as TextBox;
                TextBox newStock = ItemListTable.Rows[e.RowIndex].FindControl("TextStock") as TextBox;
                DropDownList ddlStatus = ItemListTable.Rows[e.RowIndex].FindControl("DDLStatus") as DropDownList;

                //

                lblInfo.CssClass = "text-success";
                lblInfo.Text = "Updated achived with success";
                lblError.Text = "";

            }
            catch (Exception ex)
            {
                Debug.Write("ItemsManagment / Exception : \n");//DEBUG
                lblError.Text = "DataBase error";
                lblInfo.Text = "";
                ex.GetBaseException();
            }
            ////Reset the edit index.
            ItemListTable.EditIndex = -1;
            BindData();
        }

        protected void ItemListTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "Insert")
            {
                try
                {
                    TextBox newName = ItemListTable.FooterRow.FindControl("TextAddName") as TextBox;
                    DropDownList ddlType = ItemListTable.FooterRow.FindControl("DDLProductAddType") as DropDownList;
                    TextBox newSize = ItemListTable.FooterRow.FindControl("TextAddSize") as TextBox;
                    TextBox newPrice = ItemListTable.FooterRow.FindControl("TextAddPrice") as TextBox;
                    TextBox newStock = ItemListTable.FooterRow.FindControl("TextAddStock") as TextBox;
                    DropDownList ddlStatus = ItemListTable.FooterRow.FindControl("DDLAddStatus") as DropDownList;

                    //Issue : product creation with only name/type/size/price/stock/status
                    //var result = blProd.CreateProduct(newSize.Text, Convert.ToDecimal(newPrice), ID,) ;
                    ItemListTable.ShowFooter = false;
                    BindData();
                    lblInfo.CssClass = "text-success";
                    lblInfo.Text = "insert achieved with success";
                    lblError.Text = "";

                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    lblError.Text = "DataBase error";
                    lblInfo.Text = "";
                }
            }
        }
    }
}

    
    


