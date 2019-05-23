using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IShippmentDataAccess
    {
        int Insert(string type, int deliveryTime, string company, decimal cost, int status);
        int Update(int id, int status);
        int Update(int id, decimal shipCost);
        int UpdateAll(int id, string type, int deliveryTime, string company, decimal cost, int status);
        BL.ShippmentDTO FindBy(int id);
        BL.ShippmentDTO FindBy(string name);
        List<BL.ShippmentDTO> FindAllBy(int status);
        List<BL.ShippmentDTO> FindAll();
    }
}
