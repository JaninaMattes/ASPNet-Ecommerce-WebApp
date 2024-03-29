﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    [DataObject(true)]
    public class ShippmentDAL: IShippmentDataAccess
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
        /// To Insert another Shipping company into the DB
        /// a status = 0 means the company is available
        /// a status = 1 means that the shipping service is deactivated.
        /// Customers don't have access to companies that are deactivated and as 
        /// such can't see this companies in the selection for a shipping service.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="deliveryTime"></param>
        /// <param name="company"></param>
        /// <param name="arrivalDate"></param>
        /// <param name="postageDate"></param>
        /// <param name="cost"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string type, int deliveryTime, string company, decimal cost, Byte status)
        {
            int result;
            //no need to explicitely set id as autoincrement is used
            string queryString = "INSERT INTO dbo.Shippment(dbo.Shippment.shipType, dbo.Shippment.estimatedTime, " +
                "dbo.Shippment.shipCompany, dbo.Shippment.shipCost, dbo.Shippment.status) " +
                "VALUES(@shipType, @deliveryTime, @shipCompany, @shipCost, @status)";
            //query the last updated ID, which will be the id inserted by the above statement
            string queryAutoincID = "SELECT TOP(1) dbo.Shippment.shippingID FROM dbo.Shippment ORDER BY 1 DESC";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@shipType", SqlDbType.VarChar).Value = type;
                        cmd.Parameters.AddWithValue("@deliveryTime", SqlDbType.Int).Value = deliveryTime;
                        cmd.Parameters.AddWithValue("@shipCompany", SqlDbType.VarChar).Value = company;
                        cmd.Parameters.AddWithValue("@shipCost", SqlDbType.Decimal).Value = cost;
                        cmd.Parameters.AddWithValue("@status", SqlDbType.TinyInt).Value = status;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        var value = cmd.ExecuteNonQuery(); //returns the number of affected rows in the DB 
                        Debug.Print("ShippmentDAL: /Insert/ " + value);
                    }
                }
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryAutoincID, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        //won't need a while, since it will only retrieve one row
                        reader.Read();
                        //this is the id of the newly created data field
                        result = Convert.ToInt32(reader["shippingID"]);
                        Debug.Print("ShippmentDAL: /Insert/ " + result.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                result = 0;
                e.GetBaseException();
            }            
            return result;
        }

        /// <summary>
        /// Update the company status if status = 0 active
        ///                              status = 1 inactive
        /// Inactive services cant be selected by the customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, Byte status)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Shippment SET status = @status WHERE shippingID = @id";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.AddWithValue("@status", SqlDbType.TinyInt).Value = status;
                        con.Open();
                        result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
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
        /// Update the shipping costs of a company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shipCost"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, decimal shipCost)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Shippment SET shipCost = @shipCost WHERE shippingID = @id";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.AddWithValue("@shipCost", shipCost);
                        con.Open();
                        result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
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
        /// Update all information of the shipping company
        /// </summary>
        /// <param name="type"></param>
        /// <param name="deliveryTime"></param>
        /// <param name="company"></param>
        /// <param name="cost"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateAll(int id, string type, int deliveryTime, string company, decimal cost, Byte status)
        {
            int result = 0;
            string queryString = "UPDATE dbo.Shippment SET shipType = @type, estimatedTime = @deliveryTime, " +
                "shipCost = @shipCost, shipCompany = @shipCompany, status = @status WHERE shippingID = @id";
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
                        cmd.Parameters.AddWithValue("@deliveryTime", SqlDbType.Int).Value = deliveryTime;
                        cmd.Parameters.AddWithValue("@shipCompany", SqlDbType.VarChar).Value = company;
                        cmd.Parameters.AddWithValue("@shipCost", SqlDbType.Decimal).Value = cost;
                        cmd.Parameters.AddWithValue("@status", SqlDbType.TinyInt).Value = status;
                        con.Open();
                        result = cmd.ExecuteNonQuery(); //returns amount of affected rows if successfull
                        Debug.Print("ShippmentDAL / UpdateAll / result :" + result);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print("ShippmentDAL / UpdateAll / Exception : " );//DEBUG
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Find one specific shipper/delivery service by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [DataObjectMethod(DataObjectMethodType.Update)]
        public ShippmentDTO FindBy(int id)
        {
            ShippmentDTO deliverer;
            string queryString = "SELECT * FROM dbo.Shippment WHERE shippingID = @id";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                   
                        if (reader.Read())
                        {
                            deliverer = new ShippmentDTO();
                            deliverer = deliverer = GenerateDeliverer(reader, deliverer);
                            //return product instance as data object 
                            Debug.Print("ShippmentDAL: /FindByID/ " + deliverer.GetID());
                            return deliverer;
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
        /// Find one specific shipping/delivery service
        /// by its company name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public ShippmentDTO FindBy(string name)
        {
            ShippmentDTO deliverer;
            string queryString = "SELECT * FROM dbo.Shippment WHERE shipCompany = @name";

            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            deliverer = new ShippmentDTO();
                            deliverer = deliverer = GenerateDeliverer(reader, deliverer);
                            //return product instance as data object 
                            Debug.Print("ShippmentDAL: /FindByID/ " + deliverer.GetID());
                            return deliverer;
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
        /// Find all shipping services that are
        /// currently available status = 0 OR
        /// currently suspendet status = 1
        /// </summary>
        /// <param name="status"></param>
        /// <returns>List<ShippmentDTO</returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public IEnumerable<ShippmentDTO> FindAllBy(Byte status)
        {
            string queryString = "SELECT * FROM dbo.Shippment WHERE status = @status";
            List<ShippmentDTO> results = new List<ShippmentDTO>();
            ShippmentDTO deliverer;
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            deliverer = new ShippmentDTO();
                            deliverer = GenerateDeliverer(reader, deliverer);
                            //return product instance as data object 
                            Debug.Print("ShippmentDAL: /FindByID/ " + deliverer.GetID());
                            //add data objects to result-list 
                            results.Add(deliverer);
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
        /// Find all shipping companies that are in the DB
        /// not dependent if they are avaiable or not.
        /// </summary>
        /// <returns></returns>

        [DataObjectMethod(DataObjectMethodType.Update)]
        public IEnumerable<ShippmentDTO> FindAll()
        {
            string queryString = "SELECT * FROM dbo.Shippment";
            List<ShippmentDTO> results = new List<ShippmentDTO>();
            ShippmentDTO deliverer;
            try
            {
                //The connection is automatically closed at the end of the using block.
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            deliverer = new ShippmentDTO();
                            deliverer = GenerateDeliverer(reader, deliverer);
                            //return product instance as data object 
                            Debug.Print("ShippmentDAL: /FindByID/ " + deliverer.GetID());
                            Debug.Print("ShippmentDAL: /FindByID/ " + deliverer.GetCompany());
                            //add data objects to result-list 
                            results.Add(deliverer);
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

        private static ShippmentDTO GenerateDeliverer(SqlDataReader reader, ShippmentDTO deliverer)
        {
            deliverer.SetID(Convert.ToInt32(reader["shippingID"]));
            deliverer.SetCompany(reader["shipCompany"].ToString());
            deliverer.SetCost(Convert.ToDecimal(reader["shipCost"]));
            deliverer.SetDeliveryTime(Convert.ToInt32(reader["estimatedTime"]));
            deliverer.SetStatus(Convert.ToInt32(reader["status"]));
            deliverer.SetType(reader["shipType"].ToString());
            return deliverer;
        }
    }
}