using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IAccountDataAccess
    {
        int Insert(string email, string password, int isConfirmed, string fname, string lname, string birthdate, string phoneNo, string imgPath, int status, int isAdmin);
        int UpdateStatus(string email, int status);
        int UpdateUsername(string email, string fName, string lName);
        int UpdatePhoneNo(string email, string phoneNo);
        int UpdateAddress(string email, int addressID);
        int UpdateImg(string email, string imgPath);
        int UpdateIsConfirmed(string email, int confirmed);
        int UpdateAll(int accountID, string email, string password, string fname, string lname, string birthdate, string phoneNo, string imgPath);
        BL.AccountDTO FindBy(int id);
        BL.AccountDTO FindBy(string email);
        List<BL.AccountDTO> FindAllUserBy(int isAdmin);
        List<BL.AccountDTO> FindAll();
        List<BL.AccountDTO> FindByStatus(int status);
        BL.AccountDTO FindByName(string fname, string lname);
        int FindLoginCred(string email, string password);
        int FindLoginEmail(string email);
        int FindLoginPW(string password);
    }
}
