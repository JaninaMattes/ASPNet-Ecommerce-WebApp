using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    [DataObject(true)]
    public class PaymentDAL
    {
        //Get connection string from web.config file and create sql connection
        readonly SqlConnection connection = new SqlConnection(SqlDataAccess.ConnectionString);

        /// <summary>
        /// This function inserts a new payment object persistent into the DB
        /// Returns the value of the PaymentID
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="paymentDate"></param>
        /// <param name="accountID"></param>
        /// <param name="invoiceID"></param>
        /// <returns>Int PaymentID</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(decimal totalAmount, DateTime paymentDate, int accountID, int invoiceID)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Payment(dbo.Payment.invoiceID, dbo.Payment.accountID, dbo.Payment.amount, dbo.Payment.paymentDate) " +
                "VALUES(@invoiceID, @accountID, @amount, @paymentDate)";
            string queryAutoIncr = "SELECT TOP(1) dbo.Payment.paymentID FROM dbo.Payment ORDER BY 1 DESC";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //insert into database
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@invoiceID", SqlDbType.Int).Value = invoiceID;
                    cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = accountID;
                    cmd.Parameters.AddWithValue("@amount", SqlDbType.Int).Value = totalAmount;
                    cmd.Parameters.AddWithValue("@paymentDate", SqlDbType.Date).Value = paymentDate;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                }

                ///find the last manipulated id due to autoincrement and return it
                using (SqlCommand command = new SqlCommand(queryAutoIncr, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    //won't need a while, since it will only retrieve one row
                    reader.Read();
                    //this is the id of the newly created data field
                    result = Convert.ToInt32(reader["paymentID"]);
                    Debug.Print("PaymentDAL: /Insert ID/ " + result);
                }
                return result;
            }
            catch (Exception e)
            {
                result = 0;
                e.GetBaseException();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Find a specific Payment by its ID
        /// Return the found Payment Instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public PaymentDTO FindBy(int id)
        {
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
            string queryString = "SELECT * FROM dbo.Payment WHERE paymentID=@id";

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new AccountDTO();
                            invoice = new InvoiceDTO();
                            payment = new PaymentDTO();
                            payment = GeneratePayment(reader, account, payment, invoice);
                            //return product instance as data object 
                            Debug.Print("PaymentDAL: /FindBy/ " + payment.GetId());
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
            finally
            {
                connection.Close();
            }
            return null;
        }

        /// <summary>
        /// Find specific Payments of a certain date.
        /// </summary>
        /// <param name="paymentDate"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public PaymentDTO FindBy(DateTime paymentDate)
        {
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
            string queryString = "SELECT * FROM dbo.Payment WHERE paymentDate=@paymentDate";

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@paymentDate", paymentDate);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new AccountDTO();
                            invoice = new InvoiceDTO();
                            payment = new PaymentDTO();
                            payment = GeneratePayment(reader, account, payment, invoice);
                            //return product instance as data object 
                            Debug.Print("PaymentDAL: /FindBy/ " + payment.GetId());
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
            finally
            {
                connection.Close();
            }
            return null;
        }

        /// <summary>
        /// Find all Payments per specific customer.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<PaymentDTO> FindByCustomer(int accountID)
        {
            string queryString = "SELECT * FROM dbo.Payment WHERE accountID=@accountID";
            List<PaymentDTO> results = new List<PaymentDTO>();
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    cmd.Parameters.AddWithValue("@accountID", accountID);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                account = new AccountDTO();
                                invoice = new InvoiceDTO();
                                payment = new PaymentDTO();
                                payment = GeneratePayment(reader, account, payment, invoice);
                                //return product instance as data object 
                                Debug.Print("PaymentDAL: /FindByCustomer/ " + payment.GetId());

                                //add data objects to result-list 
                                results.Add(payment);
                            }
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
            finally
            {
                connection.Close();
            }
            return results;
        }

        /// <summary>
        /// Find all Payment informaiton in the DB.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<PaymentDTO> FindAll()
        {
            string queryString = "SELECT * FROM dbo.Payment";
            List<PaymentDTO> results = new List<PaymentDTO>();
            PaymentDTO payment;
            AccountDTO account;
            InvoiceDTO invoice;
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //find entry in database where id = XY
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                account = new AccountDTO();
                                invoice = new InvoiceDTO();
                                payment = new PaymentDTO();
                                payment = GeneratePayment(reader, account, payment, invoice);
                                //return product instance as data object 
                                Debug.Print("PaymentDAL: /FindByAll/ " + payment.GetId());

                                //add data objects to result-list 
                                results.Add(payment);
                            }
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
            finally
            {
                connection.Close();
            }
            return results;
        }

        private static PaymentDTO GeneratePayment(SqlDataReader reader, AccountDTO account, PaymentDTO payment, InvoiceDTO invoice)
        {
            account.SetAccountID(Convert.ToInt32(reader["accountID"]));
            invoice.SetID(Convert.ToInt32(reader["invoiceID"]));
            payment.SetCustomer(account);
            payment.SetInvoice(invoice);
            payment.SetID(Convert.ToInt32(reader["paymentID"]));
            payment.SetID(Convert.ToInt32(reader["amount"]));
            payment.SetPaymentDate(Convert.ToDateTime(reader["paymentDate"]));
            return payment;
        }
    }
}