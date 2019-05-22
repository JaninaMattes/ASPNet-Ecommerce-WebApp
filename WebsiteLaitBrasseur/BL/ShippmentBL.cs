using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class ShippmentBL
    {
        ShippmentDAL DB = new ShippmentDAL();
        
        /// <summary>
        /// Creates a new entry in the DB
        /// and returns the ID.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="deliveryTime"></param>
        /// <param name="company"></param>
        /// <param name="cost"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Create(string type, int deliveryTime, string company, decimal cost, int status)
        {
            int result = 0;
            try
            {
                result = DB.Insert(type, deliveryTime, company, cost, status);
                Debug.Print("ShippmentBL: /Create Entry/ " + result);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Update the status and suspend a deliverer. 
        /// </summary>
        /// <param name="delivererID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int ChangeStatus(int delivererID, int status)
        {
            int result = 0;
            try
            {
                result = DB.Update(delivererID, status);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }


        public int UpdateAll(int delivererID, string company, string type, int deliveryTime, decimal cost, int status)
        {
            int result = 0;
            try
            {
                result =DB.UpdateAll(delivererID, type, deliveryTime, company, cost, status);
                Debug.Write("ShippmentBL / UpdateAll / result :" + result);
            }
            catch (Exception e)
            {
                Debug.Write("ShippmentBL / UpdateAll / Exception : ");//DEBUG
                e.GetBaseException();
            }

            return result;
        }


        /// <summary>
        /// Find all availble services.
        /// </summary>
        /// <returns></returns>
        public List<ShippmentDTO> GetAvailablePostServices()
        {
            List<ShippmentDTO> result = new List<ShippmentDTO>();
            int status = 0;
            try
            {
                result = DB.FindAllBy(status);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Find all currently suspendet Services.
        /// </summary>
        /// <returns></returns>
        public List<ShippmentDTO> GetPostService()
        {
            List<ShippmentDTO> result = new List<ShippmentDTO>();
            int status = 1;
            try
            {
                result = DB.FindAllBy(status);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        /// <summary>
        /// Find all services.
        /// </summary>
        /// <returns></returns>
        public List<ShippmentDTO> GetAllPostServices()
        {
            List<ShippmentDTO> result = new List<ShippmentDTO>();
            try
            {
                result = DB.FindAll();
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }
    }
}