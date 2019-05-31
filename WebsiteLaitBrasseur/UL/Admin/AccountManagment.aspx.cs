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
        readonly AccountBL BL = new AccountBL();
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
                BL.UpdateStatus(UserListTable.Rows[e.RowIndex].Cells[3].Text, status);
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
            try
            {
                var customers = BL.GetAllCustomers();
                UserListTable.DataSource = GetDataTable(customers);
                UserListTable.DataBind();
                lblUserList.Text = "There is " + UserListTable.Rows.Count + " registered customer";
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
           
        }

        protected void BindDataAdmin()
        {
            try
            {
                var admins = BL.GetAllAdmins();
                AdminListTable.DataSource = GetDataTable(admins);
                AdminListTable.DataBind();
                lblAdminList.Text = "There is " + AdminListTable.Rows.Count + " registered admin";
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        protected DataTable GetDataTable(IEnumerable<AccountDTO> ListAccount)
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

            foreach (AccountDTO customer in ListAccount)
            { 
                DataRow dr = dtUser.NewRow();
                dr["ID"] = customer.GetID();
                dr["Firstname"] = customer.GetFirstName();
                dr["Lastname"] = customer.GetLastName();
                dr["Email"] = customer.GetEmail();
                dr["PhoneNo"] = customer.GetPhoneNo();
                dr["IsConfirmed"] = customer.GetIsConfirmed();
                if (customer.GetStatus() == 1) { dr["Status"] = "Suspended";}
                else { dr["Status"] = "Active"; }               

                dtUser.Rows.Add(dr);

            }
            return dtUser;
        }

        protected void UserListTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


    }
}