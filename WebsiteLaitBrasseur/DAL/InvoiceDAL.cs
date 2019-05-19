using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    public class InvoiceDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);

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
        public int Insert(int accountID, int shippingID, int totalQuantity, decimal totalShippingCost,
            decimal totalProductCost, decimal totalTaxes, decimal totalAmount, DateTime orderDate, DateTime paymentDate, 
            DateTime arrivalDate, DateTime postageDate, int paymentStatus, string customerMail, string email)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Invoice(dbo.Invoice.accountID, dbo.Invoice.shippingID, dbo.Invoice.totalQuantity, dbo.Invoice.shippingCost," +
                "dbo.Invoice.totalProductCost, dbo.Invoice.totalTax, dbo.Invoice.totalAmount, dbo.Invoice.orderDate, dbo.Invoice.paymentDate, dbo.Invoice.paymentStatus, " +
                "dbo.Invoice.customerMail, dbo.Invoice.arrivalDate, dbo.Invoice.postageDate) " +
                "VALUES(@accountID, @shippingID, @totalQuantity, @shippingCost, @totalProductCost, @totalTax, @totalAmount, '@orderDate', '@paymentDate', @paymentStatus" +
                "'@customerMail', '@arrivalDate', '@postageDate')";
            string queryAutoIncr = "SELECT TOP(1) dbo.Invoice.invoiceID FROM dbo.Invoice ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@accountID", accountID);
                    cmd.Parameters.AddWithValue("@shippingID", shippingID);
                    cmd.Parameters.AddWithValue("@totalQuantity", totalQuantity);
                    cmd.Parameters.AddWithValue("@shippingCost", totalShippingCost);
                    cmd.Parameters.AddWithValue("@totalProductCost", totalProductCost);
                    cmd.Parameters.AddWithValue("@totalTax", totalTaxes);
                    cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@orderDate", orderDate);
                    cmd.Parameters.AddWithValue("@paymentDate", paymentDate);
                    cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                    cmd.Parameters.AddWithValue("@customerMail", customerMail);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                    cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }

                ///find the last manipulated id due to autoincrement and return it
                using (SqlCommand command = new SqlCommand(queryAutoIncr, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //won't need a while, since it will only retrieve one row
                    reader.Read();
                    //this is the id of the newly created data field
                    result = (Int32)reader["invoiceID"];
                    Debug.Print("InvoiceDAL: /Insert/ " + result.ToString());
                }
                return result;
            }
            catch (Exception e)
            {
                result = 0;
                e.GetBaseException();
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
        public int Update(int id, bool paymentStatus)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Invoice SET paymentStatus = @paymentStatus WHERE invoiceID = @id";
            try
            {
                //update into database where id = XY 
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    Debug.Print("InvoiceDAL: /Update/ " + result.ToString());
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        //update
        public int UpdateDate(int id, bool arrivalDate)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Invoice SET arrivalDate = @arrivalDate WHERE invoiceID = @id";
            try
            {
                //update into database where id = XY 
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                    Debug.Print("InvoiceDAL: /UpdateDate/ " + result.ToString());
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
        public InvoiceDTO FindBy(int id)
        {
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;

            string queryString = "SELECT * FROM dbo.Invoice WHERE invoiceID=@id";

            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            invoice = new InvoiceDTO();
                            account = new AccountDTO();
                            shipping = new ShippmentDTO();

                            invoice.SetID((int)reader["invoiceID"]);
                            account.SetAccountID((int)reader["accountID"]);
                            shipping.SetID((int)reader["shippingID"]);
                            invoice.SetCustomer(account);
                            invoice.SetShippment(shipping);
                            invoice.SetEmail(reader["customerMail"].ToString());
                            invoice.SetOrderDate((DateTime)reader["orderDate"]);
                            invoice.SetPaymentDate((DateTime)reader["paymentDate"]);
                            invoice.SetArrivalDate((DateTime)reader["arrivaltDate"]);
                            invoice.SetPostDate((DateTime)reader["postageDate"]);
                            invoice.SetQuantity((int)reader["totalQuantity"]);
                            invoice.SetShippingCost((decimal)reader["shippingCost"]);
                            invoice.SetStatus((int)reader["paymentStatus"]);
                            invoice.SetTax((decimal)reader["totalTax"]);
                            invoice.SetTotal((decimal)reader["totalAmount"]);
                            
                            //return product instance as data object 
                            Debug.Print("InvoiceDAL: /FindBy/ " + invoice.ToString());
                            return invoice;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Print(e.ToString());
            }
            return null;
        }

        /// <summary>
        /// Find all bills (invoices) that belong to a certain customer
        /// And return all as a list.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<InvoiceDTO> FindByCustomer(int accountID)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE accountID=@accountID";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@accountID", accountID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                invoice = new InvoiceDTO();
                                account = new AccountDTO();
                                shipping = new ShippmentDTO();

                                invoice.SetID((int)reader["invoiceID"]);
                                account.SetAccountID((int)reader["accountID"]);
                                shipping.SetID((int)reader["shippingID"]);
                                invoice.SetCustomer(account);
                                invoice.SetShippment(shipping);
                                invoice.SetEmail(reader["customerMail"].ToString());
                                invoice.SetOrderDate((DateTime)reader["orderDate"]);
                                invoice.SetPaymentDate((DateTime)reader["paymentDate"]);
                                invoice.SetArrivalDate((DateTime)reader["arrivaltDate"]);
                                invoice.SetPostDate((DateTime)reader["postageDate"]);
                                invoice.SetQuantity((int)reader["totalQuantity"]);
                                invoice.SetShippingCost((decimal)reader["shippingCost"]);
                                invoice.SetStatus((int)reader["paymentStatus"]);
                                invoice.SetTax((decimal)reader["totalTax"]);
                                invoice.SetTotal((decimal)reader["totalAmount"]);
                                //return product instance as data object 
                                Debug.Print("AccountDAL: /FindInvoiceBy/ " + invoice.ToString());

                                //add data objects to result-list 
                                results.Add(invoice);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        /// <summary>
        /// Find all invoices that are paymentStatus = 0 (unpaied) OR
        ///                            paymentStatus = 1 (paied)
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="paymentStatus"></param>
        /// <returns></returns>
        public List<InvoiceDTO> FindByStatus(int accountID, int paymentStatus)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE accountID=@accountID AND paymentStatus=@paymentStatus";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@accountID", accountID);
                    cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                invoice = new InvoiceDTO();
                                account = new AccountDTO();
                                shipping = new ShippmentDTO();

                                invoice.SetID((int)reader["invoiceID"]);
                                account.SetAccountID((int)reader["accountID"]);
                                shipping.SetID((int)reader["shippingID"]);
                                invoice.SetCustomer(account);
                                invoice.SetShippment(shipping);
                                invoice.SetEmail(reader["customerMail"].ToString());
                                invoice.SetOrderDate((DateTime)reader["orderDate"]);
                                invoice.SetPaymentDate((DateTime)reader["paymentDate"]);
                                invoice.SetArrivalDate((DateTime)reader["arrivaltDate"]);
                                invoice.SetPostDate((DateTime)reader["postageDate"]);
                                invoice.SetQuantity((int)reader["totalQuantity"]);
                                invoice.SetShippingCost((decimal)reader["shippingCost"]);
                                invoice.SetStatus((int)reader["paymentStatus"]);
                                invoice.SetTax((decimal)reader["totalTax"]);
                                invoice.SetTotal((decimal)reader["totalAmount"]);
                                //return product instance as data object 
                                Debug.Print("AccountDAL: /FindInvoiceBy/ " + invoice.ToString());

                                //add data objects to result-list 
                                results.Add(invoice);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        //find all invoices per paymentdate
        public InvoiceDTO FindBy(DateTime paymentDate)
        {
            InvoiceDTO invoice;
            try
            {
                invoice = new InvoiceDTO();
                //find entry in database where id = XY
                return invoice;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        /// <summary>
        /// Find all possible invoices in the database
        /// </summary>
        /// <returns></returns>
        public List<InvoiceDTO> FindAll()
        {
            string queryString = "SELECT * FROM dbo.Invoice";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                invoice = new InvoiceDTO();
                                account = new AccountDTO();
                                shipping = new ShippmentDTO();

                                invoice.SetID((int)reader["invoiceID"]);
                                account.SetAccountID((int)reader["accountID"]);
                                shipping.SetID((int)reader["shippingID"]);
                                invoice.SetCustomer(account);
                                invoice.SetShippment(shipping);
                                invoice.SetEmail(reader["customerMail"].ToString());
                                invoice.SetOrderDate((DateTime)reader["orderDate"]);
                                invoice.SetPaymentDate((DateTime)reader["paymentDate"]);
                                invoice.SetArrivalDate((DateTime)reader["arrivaltDate"]);
                                invoice.SetPostDate((DateTime)reader["postageDate"]);
                                invoice.SetQuantity((int)reader["totalQuantity"]);
                                invoice.SetShippingCost((decimal)reader["shippingCost"]);
                                invoice.SetStatus((int)reader["paymentStatus"]);
                                invoice.SetTax((decimal)reader["totalTax"]);
                                invoice.SetTotal((decimal)reader["totalAmount"]);
                                //return product instance as data object 
                                Debug.Print("AccountDAL: /FindInvoiceBy/ " + invoice.ToString());

                                //add data objects to result-list 
                                results.Add(invoice);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        /// <summary>
        /// Find all invoices/bills which have a paymentStatus = 0 (not-paied)
        ///                                      paymentStatus = 1 (paied)
        /// </summary>
        /// <param name="paymentStatus"></param>
        /// <returns></returns>
        public List<InvoiceDTO> FindAllByStatus(int paymentStatus)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE paymentStatus=@paymentStatus";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                invoice = new InvoiceDTO();
                                account = new AccountDTO();
                                shipping = new ShippmentDTO();

                                invoice.SetID((int)reader["invoiceID"]);
                                account.SetAccountID((int)reader["accountID"]);
                                shipping.SetID((int)reader["shippingID"]);
                                invoice.SetCustomer(account);
                                invoice.SetShippment(shipping);
                                invoice.SetEmail(reader["customerMail"].ToString());
                                invoice.SetOrderDate((DateTime)reader["orderDate"]);
                                invoice.SetPaymentDate((DateTime)reader["paymentDate"]);
                                invoice.SetArrivalDate((DateTime)reader["arrivaltDate"]);
                                invoice.SetPostDate((DateTime)reader["postageDate"]);
                                invoice.SetQuantity((int)reader["totalQuantity"]);
                                invoice.SetShippingCost((decimal)reader["shippingCost"]);
                                invoice.SetStatus((int)reader["paymentStatus"]);
                                invoice.SetTax((decimal)reader["totalTax"]);
                                invoice.SetTotal((decimal)reader["totalAmount"]);
                                //return product instance as data object 
                                Debug.Print("AccountDAL: /FindInvoiceBy/ " + invoice.ToString());

                                //add data objects to result-list 
                                results.Add(invoice);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        /// <summary>
        /// Find all invoices per customer 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<InvoiceDTO> FindAllByCustomer(int accountID)
        {
            string queryString = "SELECT * FROM dbo.Invoice WHERE accountID=@accountID";
            List<InvoiceDTO> results = new List<InvoiceDTO>();
            InvoiceDTO invoice;
            AccountDTO account;
            ShippmentDTO shipping;
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@accountID", accountID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                invoice = new InvoiceDTO();
                                account = new AccountDTO();
                                shipping = new ShippmentDTO();

                                invoice.SetID((int)reader["invoiceID"]);
                                account.SetAccountID((int)reader["accountID"]);
                                shipping.SetID((int)reader["shippingID"]);
                                invoice.SetCustomer(account);
                                invoice.SetShippment(shipping);
                                invoice.SetEmail(reader["customerMail"].ToString());
                                invoice.SetOrderDate((DateTime)reader["orderDate"]);
                                invoice.SetPaymentDate((DateTime)reader["paymentDate"]);
                                invoice.SetArrivalDate((DateTime)reader["arrivaltDate"]);
                                invoice.SetPostDate((DateTime)reader["postageDate"]);
                                invoice.SetQuantity((int)reader["totalQuantity"]);
                                invoice.SetShippingCost((decimal)reader["shippingCost"]);
                                invoice.SetStatus((int)reader["paymentStatus"]);
                                invoice.SetTax((decimal)reader["totalTax"]);
                                invoice.SetTotal((decimal)reader["totalAmount"]);
                                //return product instance as data object 
                                Debug.Print("AccountDAL: /FindInvoiceBy/ " + invoice.ToString());

                                //add data objects to result-list 
                                results.Add(invoice);
                            }
                            return results;
                        }
                        else
                        {
                            throw new EmptyRowException();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
    }
}