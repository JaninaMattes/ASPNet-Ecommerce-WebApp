using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteLaitBrasseur
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            //Variables initialization
            var pBrune = Convert.ToDecimal(PriceBrune.Text) ;
            var pBlonde = Convert.ToDecimal(PriceBlonde.Text);
            var pBlanche = Convert.ToDecimal(PriceBlanche.Text);
            var pCarreEst = Convert.ToDecimal(PriceCheese.Text);

            var qBrune = Convert.ToDecimal(QuantityBrune.Text);
            var qBlonde = Convert.ToDecimal(QuantityBlonde.Text);
            var qBlanche = Convert.ToDecimal(QuantityBlanche.Text);
            var qCarreEst = Convert.ToDecimal(QuantityCheese.Text);

            var sCost = Convert.ToDecimal(ShippingCostValue.Text);
            var tax = (Convert.ToDecimal(TaxValue.Text) /100 );

            //Calcul of total values
            var totBrune = pBrune * qBrune;
            var totBlonde = pBlonde * qBlonde;
            var totBlanche = pBlanche * qBlanche;
            var totCarreEst = pCarreEst * qCarreEst;
            var amount = totBrune + totBlonde + totBlanche + totCarreEst;

            //Conversion (Int => String) + attribution to labels
            TotalBrune.Text = Convert.ToString(totBrune);
            TotalBlonde.Text = Convert.ToString(totBlonde);
            TotalBlanche.Text = Convert.ToString(totBlanche);
            TotalCheese.Text = Convert.ToString(totCarreEst);
            AmountValue.Text = Convert.ToString(amount);
            TotalCostValue.Text = Convert.ToString( (amount + sCost) + tax*(amount + sCost));

        }


        protected void CreditCardButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CardPayment.aspx");
        }

        protected void PaypalButton_Click(object sender, EventArgs e)
        {

        }

        protected void ChangeAddressButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Billing.aspx");
        }
    }
}