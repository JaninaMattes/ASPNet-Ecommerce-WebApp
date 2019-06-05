using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Cart : System.Web.UI.Page
    {
        ProductBL blProduct = new ProductBL();
        ShippmentBL blShippment = new ShippmentBL();
        IEnumerable<ShippmentDTO> listShippment = new List<ShippmentDTO>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        ///Buttons          
        protected void CreditCardButton_Click(object sender, EventArgs e)
        {
            if (this.Session["CustID"] != null)
            {
                if ( ((List<ProductSelectionDTO>)(this.Session["Cart"])).Count != 0)
                {
                    if (PostagesTable.SelectedIndex >= 0)
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/CardPayment.aspx");
                    }
                    else { lblValidation.Text = "Please select a Postage Option"; }
                }
                else { lblValidation.Text = "Your cart is empty"; }

            }
            else { lblValidation.Text = "Please authenticate yourself"; }

        }


        protected void ChangeAddressButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["SecurePath"] + "/UL/Customer/Billing.aspx"); 
        }

        ///GridView commands

        protected void CartTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            { 
                int index = e.RowIndex;
                ((List<ProductSelectionDTO>)(this.Session["Cart"])).RemoveAt(index);
                BindData();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }
        }


        protected void CartTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Setup of the Quantity DropDownList with the selected value by the Customer
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the ID of the product
                int id = Convert.ToInt32(e.Row.Cells[0].Text);

                //Get the stock of the product by ID
                int stock = blProduct.GetProduct(id).GetStock();

                //Find the DropDownList in the Row.
                DropDownList ddlQuantity = (e.Row.FindControl("DDLQuantity") as DropDownList);

                //Fill the DropDownList with the values possible (stock)
                for (int i = 1; i < stock; i++)
                {
                    ddlQuantity.Items.Add(i.ToString());
                }

                //Value selected by Customer recuperation from Cart
                List<ProductSelectionDTO> cart = (List<ProductSelectionDTO>)(this.Session["Cart"]);

                //Get the quantity selected by customer in Cart[with index RowIndex] and set it as the selected value
                ddlQuantity.Items.FindByValue(cart[e.Row.RowIndex].GetQuantity().ToString()).Selected = true;

                //Set Total Price
                //Total Price update
                decimal price = Convert.ToDecimal(((Label)e.Row.FindControl("lblPrice")).Text);
                decimal quantity = Convert.ToDecimal(((DropDownList)(e.Row.FindControl("DDLQuantity"))).SelectedValue);
                price = quantity * price;
                ((Label)e.Row.FindControl("lblTotalPrice")).Text = (price).ToString();
            }
        }


        protected void PostagesTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Color the selected row
            foreach (GridViewRow row in PostagesTable.Rows)
            {
                if (row.RowIndex == PostagesTable.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    decimal shippingCostPerItem = Convert.ToDecimal(((Label)row.FindControl("lblCost")).Text);
                    decimal productNumber = CartTable.Rows.Count;
                    lblPostageValue.Text = (shippingCostPerItem * productNumber).ToString();

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
                Calcul();
            }
        }


        ///DataBinding
        protected void BindData()
        {
            //Postages options
            BindPostages();

            //Cart content
                //Cart recuperation
            List<ProductSelectionDTO> cart = (List<ProductSelectionDTO>)(this.Session["Cart"]);
            CartTable.Columns[0].Visible = true;            //ID column visible for the Binding
            CartTable.DataSource = getDataTableCart(cart);
            CartTable.DataBind();
            CartTable.Columns[0].Visible = false;
            Calcul();

            if (cart.Count == 0)
            {
                lblResult.Text=("Your cart is empty");
                AmountLabels.Visible = false;
            }
            else
            {
                AmountLabels.Visible = true;
            }
        }

        protected DataTable getDataTableCart(List<ProductSelectionDTO> cart)
        {
            //DataTable initialization
            DataTable dtCart = new DataTable();

            //Colmuns declaration
            dtCart.Columns.Add("ID");
            dtCart.Columns.Add("Image");
            dtCart.Columns.Add("Name");
            dtCart.Columns.Add("Size");
            dtCart.Columns.Add("Price");
            dtCart.Columns.Add("Quantity");

            foreach (ProductSelectionDTO p in cart)
            {
                try
                {
                    p.GetID();
                    DataRow dr = dtCart.NewRow();

                    dr["ID"] = p.GetProduct().GetId();
                    dr["Image"] = p.GetProduct().GetImgPath();
                    dr["Name"] = p.GetProduct().GetName();
                    dr["Size"] = p.GetOrigSize();
                    dr["Price"] = p.GetOrigPrice();

                    dtCart.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    Debug.Write(ex.ToString());
                }
            }
            return dtCart;
        }

        protected void BindPostages()
        {
            try
            {
                listShippment = blShippment.GetAvailablePostServices();
                PostagesTable.DataSource = getDataTablePostages();
                PostagesTable.DataBind();
                lblPostageValue.Text = "";
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }
        }

        protected DataTable getDataTablePostages()
        {
            //DataTable initialization
            DataTable dtPostage = new DataTable();

            //Colmuns declaration
            dtPostage.Columns.Add("Company");
            dtPostage.Columns.Add("DeliveryTime");
            dtPostage.Columns.Add("Cost");

            if (listShippment != null)
            {
                foreach (ShippmentDTO s in listShippment)
                {
                    DataRow dr = dtPostage.NewRow();

                    dr["Company"] = s.GetCompany();
                    dr["DeliveryTime"] = s.GetDeliveryTime();
                    dr["Cost"] = s.GetCost();

                    dtPostage.Rows.Add(dr);
                }
            }
            return dtPostage;
        }

        protected void DDLQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Row data recuperation
            DropDownList ddlQuantity = sender as DropDownList;
            int newQuantity = Convert.ToInt32(ddlQuantity.SelectedValue);
            GridViewRow row = (GridViewRow)ddlQuantity.Parent.Parent;
            decimal price = Convert.ToDecimal(( (Label) row.FindControl("lblPrice") ).Text);

            //Cart recuperation
            List<ProductSelectionDTO> cart = (List<ProductSelectionDTO>)(this.Session["Cart"]);

            //Modification of the Quantity in the cart          
            cart[row.RowIndex].SetQuantity(newQuantity);

            //Cart update
            this.Session["Cart"] = cart;

            //Total Price update
            price = ((decimal)newQuantity) * price;
            ((Label)row.FindControl("lblTotalPrice")).Text = (price).ToString();

            Calcul();
        }

        private void Calcul()
        {
            try
            {
                decimal amount = 0;
                decimal tax = (Convert.ToDecimal(lblTaxValue.Text) / 100);

                for (int i = 0; i < CartTable.Rows.Count; i++)
                {
                    amount += Convert.ToDecimal(((Label)CartTable.Rows[i].FindControl("lblTotalPrice")).Text);
                }
                lblAmountValue.Text = Convert.ToString(amount);

                if (lblPostageValue.Text != "" )
                {
                    if (lblAmountValue.Text != "")
                    {
                        decimal sCost = Convert.ToDecimal(lblPostageValue.Text);
                        TotalCostValue.Text = Convert.ToString((amount + sCost) + tax * (amount + sCost));
                    }
                }
                else
                {
                    TotalCostValue.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }

        }

    }
}