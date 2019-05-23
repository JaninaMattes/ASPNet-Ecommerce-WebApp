using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface ISizeDataAccess
    {
        int Insert(int size, decimal price, int productID);
        int UpdateSize(int id, int size, decimal price, int productID);
        int UpdateSize2(int productID, int size, decimal price);
        BL.SizeDTO FindByID(int sizeID);
        List<BL.SizeDTO> FindByProduct(int productID);
        BL.SizeDTO FindPriceBySize(int productID, int sizeProduct);
        List<BL.SizeDTO> FindAll();
    }
}
