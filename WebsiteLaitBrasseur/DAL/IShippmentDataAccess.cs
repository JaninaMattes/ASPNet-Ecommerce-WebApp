using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IShippmentDataAccess
    {
        int Insert(string type, int deliveryTime, string company, decimal cost, Byte status);
        int Update(int id, Byte status);
        int Update(int id, decimal shipCost);
        int UpdateAll(int id, string type, int deliveryTime, string company, decimal cost, Byte status);
        BL.ShippmentDTO FindBy(int id);
        BL.ShippmentDTO FindBy(string name);
        IEnumerable<BL.ShippmentDTO> FindAllBy(Byte status);
        IEnumerable<BL.ShippmentDTO> FindAll();
    }
}
