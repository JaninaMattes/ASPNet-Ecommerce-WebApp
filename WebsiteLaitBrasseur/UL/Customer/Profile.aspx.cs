using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;
using System.Data;

namespace WebsiteLaitBrasseur.UL.Customer
{
    public partial class Profile : System.Web.UI.Page
    {
        AccountBL blAccount = new AccountBL();
        AddressBL blAddress = new AddressBL();
        InvoiceBL blInvoice = new InvoiceBL();

        AddressDTO address = new AddressDTO();
        AccountDTO account = new AccountDTO();
        List<InvoiceDTO> LI = new List<InvoiceDTO>();

        string SESSION_VAR = "miriam.miller@gmail.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //SESSION_VAR =HttpContext.Current.Session["Email"].ToString();

                /*Fill the shopping history table with data from the backend 
                 * and bind these to the datafields*/

                /*Fill the user profiel information*/
                BindData();
            }

            DeleteButton_Click(sender, e);
            SaveButton_Click(sender, e);

        }

        protected void BindData()
        {
            //Account
            //Account init
            account = blAccount.GetCustomer(SESSION_VAR);

            //BindData
            TextFirstname.Text = account.GetFirstName();
            TextLastname.Text = account.GetLastName();
            TextPhone.Text = account.GetPhoneNo();
            TextBirthday.Text = account.GetBirthdate(); //WARNING : issue format
            TextEmail.Text = account.GetEmail();

            //Address 
            //Address init
            address = blAddress.FindAddress(account.GetID());

            //BindData
            Debug.Write("\n Street name:  " + address.GetStreetName()); //DEBUG
            TextAddress1.Text = address.GetStreetName();
            Debug.Write("\n City: " + address.GetCity().GetCity()); //DEBUG
            TextCity.Text = address.GetCity().GetCity();
            Debug.Write("\n Country: " + address.GetCountry()); //DEBUG
            CountryDropDownList.Text = address.GetCountry();
            Debug.Write("\n Number :" + address.GetStreetNo()); //DEBUG
            TextAddressnumber.Text = address.GetStreetNo();
            Debug.Write("\n Zip  : " + address.GetCity().GetZip()); //DEBUG
            TextZip.Text = address.GetCity().GetZip();


            //ShoppingTable
            //List invoices init
            LI = blInvoice.FindInvoices(SESSION_VAR);
            Debug.Write("Invoices infos : " + LI.Count);

            //BindData
            ShoppingTable.DataSource = getDataTable();
            ShoppingTable.DataBind();


            //Label update
            tableShoppingHistoryLabel.Text = "Your shopping history has " + ShoppingTable.Rows.Count + " items.";



        }

        protected DataTable getDataTable()
        {
            //DataTable initialization
            DataTable dtShoppingTable = new DataTable();

            //Colmuns declaration
            dtShoppingTable.Columns.Add("ID");
            dtShoppingTable.Columns.Add("TotalQuantity");
            dtShoppingTable.Columns.Add("TotalShippinCost");
            dtShoppingTable.Columns.Add("TotalTaxes");
            dtShoppingTable.Columns.Add("TotalAmount");
            dtShoppingTable.Columns.Add("OrderDate");
            dtShoppingTable.Columns.Add("PaymentDate");
            dtShoppingTable.Columns.Add("ArrivalDate");
            dtShoppingTable.Columns.Add("PostageDate");
            dtShoppingTable.Columns.Add("Status");

            for (int i = 0; i < LI.Count; i++)
            {
                DataRow dr = dtShoppingTable.NewRow();
                dr["ID"] = LI[i].GetID();
                dr["TotalQuantity"] = LI[i].GetTotal();
                dr["TotalShippinCost"] = LI[i].GetShippingCost();
                dr["TotalTaxes"] = LI[i].GetTax();
                dr["PaymentDate"] = LI[i].GetPaymentDate();
                dr["ArrivalDate"] = LI[i].GetArrivalDate();
                dr["PostageDate"] = LI[i].GetPostDate();
                dr["Status"] = LI[i].GetStatus();


                dtShoppingTable.Rows.Add(dr);

            }
            return dtShoppingTable;
        }




        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            // suspend the user dont delete

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            AccountDTO customer = new AccountDTO();
            int result = 0;
            /*save all input information from values and send it to server*/
            //string myname = Request.Form["first_name_txt"];
            //...firstName = Request.Form["FirstnameTextbox"];
            //try
            //{
            //    customer = blAccount.GetCustomer(SESSION_VAR);
            //    customer.SetID(customer.GetID());
            //    // TODO
            //    result = blAccount.UpdateAll();
            //    //send to blAccount and update
            //    if (result > 0)
            //    {
            //        //give customer feedback by pop up 
            //        //--> Updates successfull
            //    }
            //}
            //catch (Exception e)
            //{
            //    e.GetBaseException();
            //}

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {

        }



    }
}