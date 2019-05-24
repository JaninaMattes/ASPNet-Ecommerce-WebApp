using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Data;

namespace WebsiteLaitBrasseur.UL.Admin
{
    public partial class AccountManagment : System.Web.UI.Page
    {
        List<AccountDTO> LAC = new List<AccountDTO>();
        List<AccountDTO> LAA = new List<AccountDTO>();


        AccountBL bl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataCustomer();
                BindDataAdmin();

            }
        }

        ////Grid methods
        protected void UserListTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int status = 0;
                if (UserListTable.Rows[e.RowIndex].Cells[6].Text == "Active") { status = 0; }
                else if (UserListTable.Rows[e.RowIndex].Cells[6].Text == "Suspended") { status = 1; }
                else { lblError.Text = "Status invalid"; }

                bl.UpdateStatus(UserListTable.Rows[e.RowIndex].Cells[3].Text, status);

                BindDataCustomer();
            }
            catch(Exception ex)
            {
                ex.GetBaseException();
            }

        }

        //redirection to transanctions history page
        protected void UserListTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/UL/Admin/Transactions.aspx?custid=" + UserListTable.Rows[e.NewEditIndex].Cells[0].Text.ToString());
        }


        protected void BindDataCustomer()
        {
            LAC = bl.GetAllCustomers();
            UserListTable.DataSource = getDataTable(LAC);
            UserListTable.DataBind();
            lblUserList.Text = "There is " + UserListTable.Rows.Count + " registered customer";
            
        }

        protected void BindDataAdmin()
        {
            LAA = bl.GetAllAdmins();
            AdminListTable.DataSource = getDataTable(LAA);
            AdminListTable.DataBind();
            lblAdminList.Text = "There is " + AdminListTable.Rows.Count + " registered Admin";

        }


        protected DataTable getDataTable(List<AccountDTO> ListAccount)
        {
            //DataTable initialization
            DataTable dtUser = new DataTable();

            //Colmuns declaration
            dtUser.Columns.Add("ID");
            dtUser.Columns.Add("Firstname");
            dtUser.Columns.Add("Lastname");
            dtUser.Columns.Add("Email");
            dtUser.Columns.Add("PhoneNo");
            dtUser.Columns.Add("IsConfirmed");
            dtUser.Columns.Add("Status");

            for (int i = 0; i < ListAccount.Count; i++)
            { 
                DataRow dr = dtUser.NewRow();
                dr["ID"] = ListAccount[i].GetID();
                dr["Firstname"] = ListAccount[i].GetFirstName();
                dr["Lastname"] = ListAccount[i].GetLastName();
                dr["Email"] = ListAccount[i].GetEmail();
                dr["PhoneNo"] = ListAccount[i].GetPhoneNo();
                dr["IsConfirmed"] = ListAccount[i].GetIsConfirmed();
                if (ListAccount[i].GetStatus() == 1) { dr["Status"] = "Active";}
                else { dr["Status"] = "Suspended"; }
                

                dtUser.Rows.Add(dr);

            }
            return dtUser;
        }

        protected void UserListTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


    }
}