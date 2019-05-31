using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Configuration;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class ItemsManagement : System.Web.UI.Page
    {
        IEnumerable<ProductDTO> productList = new List<ProductDTO>();
        ProductBL BL = new ProductBL();
        SizeBL SBL = new SizeBL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminID"] == null)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Admin"] + "LoginAdmin.aspx";

                Response.Redirect(url);
            }
            if (!IsPostBack)
            {
                //Initialize Data elements (Gridview / DataSource )
                BindData();
            }
        }


        protected void BindData()
        {
            productList = BL.GetAllProducts();
            List<ProductDTO> asList = productList.ToList();
            ItemListTable.DataSource = GetDataTable(asList);
            ItemListTable.DataBind();
            lblItemList.Text ="There is " + ItemListTable.Rows.Count + " items in the list.";         
        }


        protected DataTable GetDataTable(List<ProductDTO> productList)
        {
            //DataTable initialization
            DataTable dtItem = new DataTable();
            IEnumerable<SizeDTO> enumerable = new List<SizeDTO>();

            //Colmuns declaration
            dtItem.Columns.Add("ID");
            dtItem.Columns.Add("Name");
            dtItem.Columns.Add("Type");
            dtItem.Columns.Add("Size");
            dtItem.Columns.Add("Price");
            dtItem.Columns.Add("Stock");
            dtItem.Columns.Add("Status");

            foreach (ProductDTO p in productList)
            {               
                enumerable = SBL.GetDetails(p.GetId());
                List<SizeDTO> asList = enumerable.ToList();

                for (int i = 0;  i < asList.Count(); i++)
                {
                    DataRow dr = dtItem.NewRow();
                    dr["ID"] = p.GetId();
                    dr["Name"] = p.GetName();
                    dr["Type"] = p.GetProductType();
                    dr["Size"] = asList[i].GetSize();
                    dr["Price"] = asList[i].GetPrice();
                    dr["Stock"] = p.GetStock();
                    dr["Status"] = p.GetStatus();

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
            int productID = Convert.ToInt32(ItemListTable.Rows[e.RowIndex].Cells[0].Text);
            string url = ConfigurationManager.AppSettings["SecurePath"] + ConfigurationManager.AppSettings["Admin"] + "DetailPageAdmin.aspx?id=" + productID;
            Response.Redirect(url);

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
                TextBox newName = ItemListTable.Rows[e.RowIndex].FindControl("TextEditProductName") as TextBox;
                DropDownList ddlType = ItemListTable.Rows[e.RowIndex].FindControl("DDLProductType") as DropDownList;
                TextBox newSize = ItemListTable.Rows[e.RowIndex].FindControl("TextEditSize") as TextBox;
                TextBox newPrice = ItemListTable.Rows[e.RowIndex].FindControl("TextEditPrice") as TextBox;
                TextBox newStock = ItemListTable.Rows[e.RowIndex].FindControl("TextEditStock") as TextBox;
                DropDownList ddlStatus = ItemListTable.Rows[e.RowIndex].FindControl("DDLStatus") as DropDownList;

                BL.Update2(ID,Convert.ToInt32(newSize.Text), Convert.ToDecimal(newPrice.Text), newName.Text, ddlType.Text, Convert.ToInt32(newStock.Text), Convert.ToInt16(ddlStatus.Text));

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

                    BL.CreateProduct2(Convert.ToInt32(newSize.Text), Convert.ToDecimal(newPrice.Text) , newName.Text , ddlType.Text , "" , "" , "" ,"" ,  Convert.ToInt32(newStock.Text) , Convert.ToInt16(ddlStatus.Text) ) ;
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
                ItemListTable.ShowFooter = false;
                BindData();
            }
            if (e.CommandArgument.ToString() == "FakeDelete")
            {
                //TODO if time
            }
        }
    }
}
    


