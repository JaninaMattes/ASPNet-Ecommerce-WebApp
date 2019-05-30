﻿using System;
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
    public partial class Transactions : System.Web.UI.Page
    {
        List<InvoiceDTO> LI = new List<InvoiceDTO>();
        InvoiceBL blInv = new InvoiceBL();
        AccountBL blCustomer = new AccountBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            var custID = Request.QueryString["custID"];
            int customerID;

            if (!string.IsNullOrEmpty(custID) && int.TryParse(custID, out customerID))
            {
                if (customerID == 11110) //Display Marcus' shopping history
                {
                    BindTableLabel();
                    BindGridList();
                }
            }
        }

        protected void BindData()
        {
            //LI = blInv.FindInvoices(blCustomer.GetCustomer());

        }

        protected DataTable getDataTable()
        {
            DataTable dtShopList = new DataTable();

            return dtShopList;
        }

        //Shopping history generation (Same in /Account/Profile.aspx)
        protected void BindGridList()
        {
            ShoppingTable.DataSource = getShoppingList();
            ShoppingTable.DataBind();
        }


        protected void BindTableLabel()
        {
            List<ShoppingListItem> shoppingLs = getShoppingList();
            if (shoppingLs.LongCount<ShoppingListItem>() > 0)
            {
                tableShoppingHistoryLabel.Text = "Your shopping history has " + shoppingLs.LongCount<ShoppingListItem>();
            }
        }

        protected List<ShoppingListItem> getShoppingList()
        {
            List<ShoppingListItem> shoppingLs = new List<ShoppingListItem>();
            ShoppingListItem ls = new ShoppingListItem(1234, 25.00f, "2019-02-01", "2019-02-25");
            shoppingLs.Add(ls);
            ls = new ShoppingListItem(1235, 25.00f, "2019-01-01", "2019-01-30");
            shoppingLs.Add(ls);
            ls = new ShoppingListItem(1236, 100.00f, "2018-12-01", "2018-12-30");
            shoppingLs.Add(ls);
            return shoppingLs;
        }


        public class ShoppingListItem
        {
            public int invoiceNumber { get; set; }
            public float totalAmount { get; set; }
            public string orderDate { get; set; }
            public string arrivalDate { get; set; }

            public ShoppingListItem(int id, float totalAmount, string orderDate, string arrivalDate)
            {
                this.invoiceNumber = id;
                this.totalAmount = totalAmount;
                this.orderDate = orderDate;
                this.arrivalDate = arrivalDate;
            }
        }
    }
}