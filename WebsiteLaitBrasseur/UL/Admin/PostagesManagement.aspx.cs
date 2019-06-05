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
    public partial class PostagesOptions : System.Web.UI.Page
    {
        ShippmentBL BL = new ShippmentBL();
        IEnumerable<ShippmentDTO> listShippment = new List<ShippmentDTO>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Redirection if not login
            if (this.Session["AdminID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Admin/LoginAdmin.aspx");
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }


        protected DataTable getDataTable()
        {
            //DataTable initialization
            DataTable dtPostage = new DataTable();

            //Colmuns declaration
            dtPostage.Columns.Add("ID");
            dtPostage.Columns.Add("Company");
            dtPostage.Columns.Add("Type");
            dtPostage.Columns.Add("DeliveryTime");
            dtPostage.Columns.Add("Cost");
            dtPostage.Columns.Add("Status");

            if (listShippment != null)
            {
                foreach (ShippmentDTO s in listShippment)
                {
                    DataRow dr = dtPostage.NewRow();

                    dr["ID"] = s.GetID();
                    dr["Company"] = s.GetCompany();
                    dr["Type"] = s.GetShipType();
                    dr["DeliveryTime"] = s.GetDeliveryTime();
                    dr["Cost"] = s.GetCost();
                    dr["Status"] = s.GetStatus();

                    dtPostage.Rows.Add(dr);
                }
            }            
            return dtPostage;
        }


        protected void BindData()
        {
            try
            {
                listShippment = BL.GetAllPostServices();
                PostageTable.DataSource = getDataTable();
                PostageTable.DataBind();
                string helper;
                if (listShippment.Count() > 1)
                {
                    helper = "are";
                }
                else
                {
                    helper = "is";
                }
                lblPostageList.Text = $"There {helper} {listShippment.Count()} postage options.";
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
           
        }


        //////Grid methods
        //    //-RowEditing
        //    //-RowCancelingEdit
        //    //-RowUpdating
        //    //-RowDeleting


        protected void CancelInsertButton_Click(object sender, EventArgs e)
        {
            PostageTable.ShowFooter = false;
            BindData();
        }


        protected void AddButton_Click(object sender, EventArgs e)
        {
            PostageTable.ShowFooter = true;
            BindData();
        }

        //Row Deleting
        protected void PostageTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Byte status = 1; //suspendet
            //Index of grid recuperation
            int index = Convert.ToInt32(e.RowIndex);            
            int id = Convert.ToInt16(PostageTable.Rows[e.RowIndex].Cells[0].Text);

            //Fake deletion
            PostageTable.Rows[index].Visible = false;
            lblInfo.CssClass = "text-info";
            lblInfo.Text = "Not real deleting : The row is now invisible";
            lblError.Text = "";
            //change status of shippment company 
            // => delete = suspendet
            BL.ChangeStatus(id, status);
        }

        ////Row Editing 
        protected void PostageTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PostageTable.EditIndex = e.NewEditIndex;
            BindData();

        }

        //Canceling of edition of a row
        protected void PostageTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PostageTable.EditIndex = -1;
            BindData();
            lblError.Text = "";
            lblInfo.Text = "";

        }

        //Row Updating
        protected void PostageTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt16(PostageTable.Rows[e.RowIndex].Cells[0].Text);
                Debug.Write($"Postages / Update ID : {ID}");//DEBUG
                TextBox editCompany = PostageTable.Rows[e.RowIndex].FindControl("TextCompanyName") as TextBox;
                TextBox editType = PostageTable.Rows[e.RowIndex].FindControl("TextType") as TextBox;
                TextBox editDeliveryTime = PostageTable.Rows[e.RowIndex].FindControl("TextDeliveryTime") as TextBox;
                TextBox editCost = PostageTable.Rows[e.RowIndex].FindControl("TextCost") as TextBox;
                TextBox editStatus = PostageTable.Rows[e.RowIndex].FindControl("TextStatus") as TextBox;

                BL.UpdateAll(ID, editCompany.Text, editType.Text, Convert.ToInt32(editDeliveryTime.Text), Convert.ToDecimal(editCost.Text), Convert.ToByte(editStatus.Text));

                lblInfo.CssClass = "text-success";
                lblInfo.Text = $"Updated {editCompany.Text} successfully.";
                lblError.Text = "";
            }
            catch(Exception ex)
            {
                Debug.Write("Postages / Exception : \n");//DEBUG
                lblError.Text = "DataBase error";
                lblInfo.Text = "";
                ex.GetBaseException();
            }

            ////Reset the edit index.
            PostageTable.EditIndex = -1;
            BindData();
       }



        protected void PostageTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "Insert")
            {
                try
                {
                    TextBox newCompany = PostageTable.FooterRow.FindControl("TextAddCompany") as TextBox;
                    TextBox newType = PostageTable.FooterRow.FindControl("TextAddType") as TextBox;
                    TextBox newDeliveryTime = PostageTable.FooterRow.FindControl("TextAddDeliveryTime") as TextBox;
                    TextBox newCost = PostageTable.FooterRow.FindControl("TextAddCost") as TextBox;
                    TextBox newStatus = PostageTable.FooterRow.FindControl("TextAddStatus") as TextBox;

                    var result = BL.Create(newType.Text, Convert.ToInt32(newDeliveryTime.Text), newCompany.Text, Convert.ToDecimal(newCost.Text), Convert.ToByte(newStatus.Text));                   
                    PostageTable.ShowFooter = false;
                    BindData();
                    lblInfo.CssClass = "text-success";
                    lblInfo.Text = "insert achieved with success";
                    lblError.Text = "";

                }
                catch(Exception ex)
                {
                    ex.GetBaseException();
                    lblError.Text = "DataBase error";
                    lblInfo.Text = "";
                }
            }
        }
    }
}