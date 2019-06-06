using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    [DataObject(true)]
    public class InvoiceDAL: IInvoiceDataAccess
    {
        //Get connection string from web.config file and create sql connection
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LaitBrasseurDB"].ConnectionString;
            }
        }

        /// <summary>
        /// Insert a new Invoice into the DB
        /// ArrivalDate and PostageDate are calculated
        /// dependent on the shipping selected in the Business Logic Layer
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="shippingID"></param>
        /// <param name="totalQuantity"></param>
        /// <param name="totalShippingCost"></param>
        /// <param name="totalProductCost"></param>
        /// <param name="totalTaxes"></param>
        /// <param name="totalAmount"></param>
        /// <param name="orderDate"></param>
        /// <param name="paymentDate"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="postageDate"></param>
        /// <param name="pamymentStatus"></param>
        /// <param name="customerMail"></param>
        /// <param name="email"></param>
        /// <returns>Invoice ID</returns>

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(int accountID, int shippingID, int totalQuantity, decimal totalShippingCost,
            decimal totalProductCost, decimal totalTaxes, decimal totalAmount, string orderDate, string paymentDate, 
            string arrivalDate, string postageDate, int paymentStatus, string customerMail)
        {
            int result = 0;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Invoice(dbo.Invoice.accountID, dbo.Invoice.shippingID, dbo.Invoice.totalQuantity, dbo.Invoice.shippingCost, " +
                "dbo.Invoice.totalProductCost, dbo.Invoice.totalTax, dbo.Invoice.totalAmount, dbo.Invoice.orderDate, dbo.Invoice.paymentDate, dbo.Invoice.paymentStatus, " +
                "dbo.Invoice.customerMail, dbo.Invoice.arrivalDate, dbo.Invoice.postageDate) " +
                "VALUES(@accountID, @shippingID, @totalQuantity, @shippingCost, @totalProductCost, @totalTax, @totalAmount, @orderDate, @paymentDate, @paymentStatus, " +
                "@customerMail, @arrivalDate, @postageDate)";
            string queryAutoIncr = "SELECT TOP(1) dbo.Invoice.invoiceID FROM dbo.Invoice ORDER BY 1 DESC";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", SqlDbType.Decimal).Value = accountID;
                        cmd.Parameters.AddWithValue("@shippingID", SqlDbType.Decimal).Value = shippingID;
                        cmd.Parameters.AddWithValue("@totalQuantity", SqlDbType.Int).Value = totalQuantity;
                        cmd.Parameters.AddWithValue("@shippingCost", SqlDbType.Decimal).Value = totalShippingCost;
                        cmd.Parameters.AddWithValue("@totalProductCost", SqlDbType.Decimal).Value = totalProductCost;
                        cmd.Parameters.AddWithValue("@totalTax", SqlDbType.Decimal).Value = totalTaxes;
                        cmd.Parameters.AddWithValue("@totalAmount", SqlDbType.Decimal).Value = totalAmount;
                        cmd.Parameters.AddWithValue("@orderDate", SqlDbType.Date).Value = orderDate;
                        cmd.Parameters.AddWithValue("@paymentDate", SqlDbType.Date).Value = paymentDate;
                        cmd.Parameters.AddWithValue("@paymentStatus", SqlDbType.Int).Value = paymentStatus;
                        cmd.Parameters.AddWithValue("@customerMail", SqlDbType.VarChar).Value = customerMail;
                        cmd.Parameters.AddWithValue("@arrivalDate", SqlDbType.Date).Value = arrivalDate;
                        cmd.Parameters.AddWithValue("@postageDate", SqlDbType.Date).Value = postageDate;               
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        var row = cmd.ExecuteNonQuery(); //returns amount of effected rows if successfull
                        Debug.Print("InvoiceDAL: /Insert/ " + row);
                    }
                
                    using (SqlCommand cmd = new SqlCommand(queryAutoIncr, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        //won't need a while, since it will only retrieve one row
                        reader.Read();
                        //this is the id of the newly created data field
                        result = Convert.ToInt32(reader["invoiceID"]);
                        Debug.Print("InvoiceDAL: /Insert/ " + result);
                    }
                }
            }
            catch (Exception e)
            {
                result = 0;
                e.GetBaseException();
                Debug.Write(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// Update the payment status of a certain invoice
        /// in the database to paymentStatus = 1 (paied)
        ///                    paymentStatus = 0 (not-paied)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentStatus"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, int paymentStatus)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Invoice SET paymentStatus = @paymentStatus WHERE invoiceID = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@paymentStatus", SqlDbType.Int).Value = paymentStatus;
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                        Debug.Print("InvoiceDAL: /Update/ " + result.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        //update
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateDate(int id, string arrivalDate)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Invoice SET arrivalDate = @arrivalDate WHERE invoiceID = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@arrivalDate", SqlDbType.Date).Value = arrivalDate;
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                        Debug.Print("InvoiceDAL: /UpdateDate/ " + result.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Product selection needs to be added in Business Logic Layer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public InvoiceDTO GetInvoiceBy(int id)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE invoiceID = @id";
            InvoiceDTO invoice = new InvoiceDTO();

            try {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("invoiceID", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {                            
                            AccountDTO account = new AccountDTO();
                            ShippmentDTO shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            //return product instance as data object 
                            Debug.Print("InvoiceDAL: /FindByID/ " + invoice.GetID());
                        }
                    }
                }
            }         
            
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            return invoice;
        }

        /// <summary>
        /// Find all bills (invoices) that belong to a certain customer
        /// And return all as a list.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<InvoiceDTO> FindByCustomer(int accountID)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE accountID = @accountID";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = accountID;
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            Debug.Print("InvoiceDAL: /FindByCustomer/ " + invoice.GetID());
                            //add data objects to result-list 
                            results.Add(invoice);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find one that belong to a certain customer
        /// And return it.
        /// </summary>
        /// /// <param name="accountID"></param>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<InvoiceDTO> FindByCustomer(int accountID, int invoiceID)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE accountID = @accountID AND invoiceID=@invoiceID";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = accountID;
                        cmd.Parameters.AddWithValue("@invoiceID", SqlDbType.Int).Value = invoiceID;
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            Debug.Print("InvoiceDAL: /FindByCustomer/ " + invoice.GetID());
                            //add data objects to result-list 
                            results.Add(invoice);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all invoices that are paymentStatus = 0 (unpaied) OR
        ///                            paymentStatus = 1 (paied)
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="paymentStatus"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<InvoiceDTO> FindByStatus(int accountID, int paymentStatus)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE accountID = @accountID AND paymentStatus = @paymentStatus";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = accountID;
                        cmd.Parameters.AddWithValue("@paymentStatus", SqlDbType.Int).Value = paymentStatus;
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            Debug.Print("InvoiceDAL: /FindInvoiceByStatus/ " + invoice.GetID());
                            //add data objects to result-list 
                            results.Add(invoice);
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        //find all invoices per paymentdate
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<InvoiceDTO> GetInvoicesBy(string paymentDate)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE paymentDate = @paymentDate";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@paymentDate", SqlDbType.Date).Value = paymentDate;
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            Debug.Print("InvoiceDAL: /FindBy/ " + invoice.GetID());
                            //add data objects to result-list 
                            results.Add(invoice);                           
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all possible invoices in the database
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<InvoiceDTO> GetInvoices()
        {
            string queryString = "SELECT * FROM dbo.Invoice";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            Debug.Print("InvoiceDAL: /FindAll/ " + invoice.GetID());
                            //add data objects to result-list 
                            results.Add(invoice);                            
                        }                        
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all invoices/bills which have a paymentStatus = 0 (not-paied)
        ///                                      paymentStatus = 1 (paied)
        /// </summary>
        /// <param name="paymentStatus"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<InvoiceDTO> FindAllByStatus(int paymentStatus)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE paymentStatus = @paymentStatus";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            Debug.Print("InvoiceDAL: /FindAllBy/ " + invoice.GetID());
                            //add data objects to result-list 
                            results.Add(invoice);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        /// <summary>
        /// Find all invoices per customer 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<InvoiceDTO> FindAllByCustomer(int accountID)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE accountID = @accountID";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@accountID", accountID);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();
                            invoice = GenerateInvoice(reader, invoice, account, shipping);
                            //return product instance as data object 
                            Debug.Print("InvoiceDAL: /FindInvoiceBy/ " + invoice.GetID());
                            //add data objects to result-list 
                            results.Add(invoice);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return results;
        }

        private static InvoiceDTO GenerateInvoice(SqlDataReader reader, InvoiceDTO invoice, AccountDTO account, ShippmentDTO shipping)
        {
            invoice.SetID(Convert.ToInt32(reader["invoiceID"]));
            account.SetID(Convert.ToInt32(reader["accountID"]));
            shipping.SetID(Convert.ToInt32(reader["shippingID"]));
            invoice.SetCustomer(account);
            invoice.SetShippment(shipping);
            invoice.SetQuantity(Convert.ToInt32(reader["totalQuantity"]));
            invoice.SetShippingCost(Convert.ToDecimal(reader["shippingCost"]));
            invoice.SetTotal(Convert.ToDecimal(reader["totalProductCost"]));
            invoice.SetTax(Convert.ToDecimal(reader["totalTax"]));
            invoice.SetTotal(Convert.ToDecimal(reader["totalAmount"]));          
            invoice.SetOrderDate(Convert.ToDateTime(reader["orderDate"]));
            invoice.SetPaymentDate(Convert.ToDateTime(reader["paymentDate"]));
            invoice.SetStatus(Convert.ToInt32(reader["paymentStatus"]));
            invoice.SetEmail(reader["customerMail"].ToString());
            invoice.SetArrivalDate(Convert.ToDateTime(reader["arrivalDate"]));
            invoice.SetPostDate(Convert.ToDateTime(reader["postageDate"]));
            Debug.Print("InvoiceDAL: Invoice ID " + invoice.GetID());
            return invoice;
        }
    }
}