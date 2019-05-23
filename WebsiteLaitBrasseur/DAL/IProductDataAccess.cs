using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IProductDataAccess
    {
        int Insert(string name, string type, string producer, string longInfo, string shortInfo, string imgPath, int stock, int status);
        int UpdateStatus(int id, int status);
        int Update(int id, string name, string type, int status);
        int Update(int id, string name, string type, int stock, int status);
        int Update(int id, string shortInfo, string longInfo, string producer, string imgPath);
        int UpdateStock(int id, int stock);
        int UpdateImg(int id, string imgPath);
        int UpdateProducer(uint id, string producer);
        int UpdateName(int id, string name);
        int UpdateLongInfo(int id, string longInfo);
        int UpdateShortInfo(int id, string shortInfo);
        int UpdateAll(int id, string name, string type, string producer, string longInfo, string shortInfo, string imgPath, int stock, int status);
        BL.ProductDTO FindBy(int id);
        List<BL.ProductDTO> FindByType(string type);
        List<BL.ProductDTO> FindByName(string name);
        List<BL.ProductDTO> FindByProducer(string producer);
        List<BL.ProductDTO> FindActiveProducts(int pStatus);
        List<BL.ProductDTO> FindActiveProducts(int pStatus, string type);
        List<BL.ProductDTO> FindAll();
    }
}
