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
    public class PaymentDAL
    {
        //Get connection string from web.config file and create sql connection
        SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);

        /// <summary>
        /// This function inserts a new payment object persistent into the DB
        /// Returns the value of the PaymentID
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="paymentDate"></param>
        /// <param name="accountID"></param>
        /// <param name="invoiceID"></param>
        /// <returns>Int PaymentID</returns>
        public int Insert(decimal totalAmount, DateTime paymentDate, int accountID, int invoiceID)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Payment(dbo.Payment.invoiceID, dbo.Payment.accountID, dbo.Payment.amount, dbo.Payment.paymentDate) " +
                "VALUES(@invoiceID, @accountID, @amount, '@paymentDate')";
            string queryAutoIncr = "SELECT TOP(1) dbo.Payment.paymentID FROM dbo.Payment ORDER BY 1 DESC";
            try
            {
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@invoiceID", invoiceID);
                    cmd.Parameters.AddWithValue("@accountID", accountID);
                    cmd.Parameters.AddWithValue("@amount", totalAmount);
                    cmd.Parameters.AddWithValue("@paymentDate", paymentDate);
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
                    result = (Int32)reader["paymentID"];
                    Debug.Print("PaymentDAL: /Insert/ " + result.ToString());
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
        /// Find a specific Payment by its ID
        /// Return the found Payment Instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PaymentDTO FindBy(int id)
        {
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
            string queryString = "SELECT * FROM dbo.Payment WHERE paymentID=@id";

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
                            account = new AccountDTO();
                            invoice = new InvoiceDTO();
                            payment = new PaymentDTO();
                            account.SetAccountID((int)reader["accountID"]);
                            invoice.SetID((int)reader["invoiceID"]);
                            payment.SetCustomer(account);
                            payment.SetInvoice(invoice);
                            payment.SetID((int)reader["paymentID"]);
                            payment.SetPaymentDate((DateTime)reader["paymentDate"]);
                            //return product instance as data object 
                            Debug.Print("PaymentDAL: /FindByID/ " + payment.ToString());
                            return payment;
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
       /// Find specific Payments of a certain date.
       /// </summary>
       /// <param name="paymentDate"></param>
       /// <returns></returns>
        public PaymentDTO FindBy(DateTime paymentDate)
        {
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
            string queryString = "SELECT * FROM dbo.Payment WHERE paymentDate=@paymentDate";

            try
            {
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@paymentDate", paymentDate);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new AccountDTO();
                            invoice = new InvoiceDTO();
                            payment = new PaymentDTO();
                            account.SetAccountID((int)reader["accountID"]);
                            invoice.SetID((int)reader["invoiceID"]);
                            payment.SetCustomer(account);
                            payment.SetInvoice(invoice);
                            payment.SetID((int)reader["paymentID"]);
                            payment.SetPaymentDate((DateTime)reader["paymentDate"]);
                            //return product instance as data object 
                            Debug.Print("PaymentDAL: /FindByDate/ " + payment.ToString());
                            return payment;
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
        /// Find all Payments per specific customer.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<PaymentDTO> FindByCustomer(int accountID)
        {
            string queryString = "SELECT * FROM dbo.Payment WHERE accountID=@accountID";
            List<PaymentDTO> results = new List<PaymentDTO>();
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
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
                                account = new AccountDTO();
                                invoice = new InvoiceDTO();
                                payment = new PaymentDTO();
                                account.SetAccountID((int)reader["accountID"]);
                                invoice.SetID((int)reader["invoiceID"]);
                                payment.SetCustomer(account);
                                payment.SetInvoice(invoice);
                                payment.SetID((int)reader["paymentID"]);
                                payment.SetPaymentDate((DateTime)reader["paymentDate"]);
                                //return product instance as data object 
                                Debug.Print("PaymentDAL: /FindByCustomer/ " + payment.ToString());

                                //add data objects to result-list 
                                results.Add(payment);
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

        public List<PaymentDTO> FindAll()
        {
            string queryString = "SELECT * FROM dbo.Payment";
            List<PaymentDTO> results = new List<PaymentDTO>();
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
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
                                account = new AccountDTO();
                                invoice = new InvoiceDTO();
                                payment = new PaymentDTO();
                                account.SetAccountID((int)reader["accountID"]);
                                invoice.SetID((int)reader["invoiceID"]);
                                payment.SetCustomer(account);
                                payment.SetInvoice(invoice);
                                payment.SetID((int)reader["paymentID"]);
                                payment.SetPaymentDate((DateTime)reader["paymentDate"]);
                                //return product instance as data object 
                                Debug.Print("PaymentDAL: /FindByAll/ " + payment.ToString());

                                //add data objects to result-list 
                                results.Add(payment);
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