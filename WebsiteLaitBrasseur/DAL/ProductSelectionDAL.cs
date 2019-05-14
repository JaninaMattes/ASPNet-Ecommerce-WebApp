using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.BL;

namespace WebsiteLaitBrasseur.DAL
{
    //Get connection string from web.config file and create sql connection
    SqlConnection con = new SqlConnection(SqlDataAccess.ConnectionString);
    public class ProductSelectionDAL
    {
        //create
        public bool Create(byte id, Product selection, int quantity, decimal origPrice)
        {
            //string sql = 
            try
            {
                //insert into database
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //update
        public bool Update(byte id, Product selection)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, int quantity)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        public bool Update(byte id, decimal origPrice)
        {
            try
            {
                //update into database where id = XY 
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return false;
        }

        //find all shipping companies available
        public List<ProductSelection> FindAll()
        {
            ProductSelection selection;
            List<ProductSelection> list = new List<ProductSelection>();
            try
            {
                selection = new ProductSelection();
                //find entry in database where id = XY
                list.Add(selection);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        public List<ProductSelection> FindAllPerCustomer(byte id)
        {
            ProductSelection selection;
            List<ProductSelection> list = new List<ProductSelection>();
            try
            {
                selection = new ProductSelection();
                //find entry in database where id = XY
                list.Add(selection);

                //after all products are retrieved from DB
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
    }
}