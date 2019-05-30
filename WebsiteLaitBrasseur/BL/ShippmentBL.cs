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
        public int Create(string type, int deliveryTime, string company, decimal cost, Byte status)
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
        public int ChangeStatus(int delivererID, Byte status)
        {
            int result = 0;
            try
            {
                result = DB.Update(delivererID, status);
                Debug.Print("ShippmentBL: /Change Status/ " + result);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }


        public int UpdateAll(int delivererID, string company, string type, int deliveryTime, decimal cost, Byte status)
        {
            int result = 0;
            try
            {
                result = DB.UpdateAll(delivererID, type, deliveryTime, company, cost, status);
                Debug.Print("ShippmentBL: /Update All/ " + result);
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
        public IEnumerable<ShippmentDTO> GetAvailablePostServices()
        {
            IEnumerable<ShippmentDTO> result = new List<ShippmentDTO>();
            Byte status = 0;
            try
            {
                result = DB.FindAllBy(status);
                Debug.Print("ShippmentBL: /Find All Available/ " + result);
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
        public IEnumerable<ShippmentDTO> GetSuspendetPostService()
        {
            IEnumerable<ShippmentDTO> result = new List<ShippmentDTO>();
            Byte status = 1;
            try
            {
                result = DB.FindAllBy(status);
                Debug.Print("ShippmentBL: /Find All Suspendet/ " + result);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }

        internal void UpdateAll(object p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find all services.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShippmentDTO> GetAllPostServices()
        {
            IEnumerable<ShippmentDTO> result = new List<ShippmentDTO>();
            try
            {
                result = DB.FindAll();
                Debug.Print("ShippmentBL: /Find All/ found: " + result.Count());
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return result;
        }
    }
}