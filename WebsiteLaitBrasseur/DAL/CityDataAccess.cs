using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface ICityDataAccess
    {
        int Insert(string zipCode, string cityName);
        int UpdateCity(int cityID, string zipCode, string cityName);
        BL.CityDTO FindBy(int id);
        BL.CityDTO FindBy(string name);
    }
}
