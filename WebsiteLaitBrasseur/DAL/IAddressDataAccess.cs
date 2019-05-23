using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IAddressDataAccess
    {
        int Insert(int cityID, string streetName, string streetNo, string addressType);
        int UpdateAddress(int addressID, int cityID, string streetName, string streetNo, string addressType);
        BL.AddressDTO FindBy(int id);
        BL.AddressDTO FindBy(string type);
    }
}
