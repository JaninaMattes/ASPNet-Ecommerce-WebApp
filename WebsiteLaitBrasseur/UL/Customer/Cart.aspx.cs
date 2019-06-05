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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Debug.Write("\nIsNotPostBack :BindData \n"); //DEBUG
                BindData();
            }

        }

        ///Buttons          
        protected void saveButton_Click(object sender, EventArgs e)
        {
            ((TextBox)(CartTable.FindControl("lblTotalPrice"))).Text = ((DropDownList)(CartTable.FindControl("DDLQuantity"))).Text;
            //TODO

            //Variables initialization
            Decimal sCost = Convert.ToDecimal(2.5);
            //if (PostageDropDownList.SelectedItem.Value == "1") { sCost = Convert.ToDecimal(2.5);}
            //if (PostageDropDownList.SelectedItem.Value == "2") { sCost = Convert.ToDecimal(5); }
            //if (PostageDropDownList.SelectedItem.Value == "3") { sCost = Convert.ToDecimal(7.5); }

            //var pBrune = Convert.ToDecimal(PriceBrune.Text) ;
            //var pBlonde = Convert.ToDecimal(PriceBlonde.Text);
            //var pBlanche = Convert.ToDecimal(PriceBlanche.Text);
            //var pCarreEst = Convert.ToDecimal(PriceCheese.Text);

            //var qBrune = Convert.ToDecimal(QuantityBrune.Text);
            //var qBlonde = Convert.ToDecimal(QuantityBlonde.Text);
            //var qBlanche = Convert.ToDecimal(QuantityBlanche.Text);
            //var qCarreEst = Convert.ToDecimal(QuantityCheese.Text);


            //var tax = (Convert.ToDecimal(TaxValue.Text) /100 );

            ////Calcul of total values
            //var totBrune = pBrune * qBrune;
            //var totBlonde = pBlonde * qBlonde;
            //var totBlanche = pBlanche * qBlanche;
            //var totCarreEst = pCarreEst * qCarreEst;
            //var amount = totBrune + totBlonde + totBlanche + totCarreEst;

            ////Conversion (Int => String) + attribution to labels
            //TotalBrune.Text = Convert.ToString(totBrune);
            //TotalBlonde.Text = Convert.ToString(totBlonde);
            //TotalBlanche.Text = Convert.ToString(totBlanche);
            //TotalCheese.Text = Convert.ToString(totCarreEst);
            //AmountValue.Text = Convert.ToString(amount);
            //TotalCostValue.Text = Convert.ToString( (amount + sCost) + tax*(amount + sCost));

        }


        protected void CreditCardButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Customer/CardPayment.aspx");
        }

        protected void PaypalButton_Click(object sender, EventArgs e)
        {

        }

        protected void ChangeAddressButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UL/Customer/Billing.aspx");
        }

        ///GridView commands
        protected void CartTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void CartTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void CartTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void CartTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Debug.Write("\nRowDataBound \n"); //DEBUG
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

                }
        }

        ///DataBinding
        protected void BindData()
        {
            //Cart recuperation
            List<ProductSelectionDTO> cart = (List<ProductSelectionDTO>)(this.Session["Cart"]);

            if (cart.Count == 0)
            {
                lblResult.Text=("Your cart is empty");
            }
            else
            {
                CartTable.Columns[0].Visible = true;            //ID column visible for the Binding
                CartTable.DataSource = getDataTable(cart);
                CartTable.DataBind();
                CartTable.Columns[0].Visible = false;
            }
        }

        protected DataTable getDataTable(List<ProductSelectionDTO> cart)
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

        }


    }
}