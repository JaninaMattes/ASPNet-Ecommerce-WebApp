using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteLaitBrasseur.DAL
{
    interface IAccountDataAccess
    {
        int Insert(string email, byte[] password, byte[] salt, int isConfirmed, string fname, string lname, string birthdate, string phoneNo, string imgPath, byte status, byte isAdmin, int confirmationID);
        int UpdateStatus(string email, byte status);
        int UpdateUsername(string email, string fName, string lName);
        int UpdatePhoneNo(string email, string phoneNo);
        int UpdateAddress(string email, int addressID);
        int UpdatePassword(string email, byte[] password);
        int UpdateImg(string email, string imgPath);
        int UpdateIsConfirmed(string email, byte confirmed);
        int UpdateAll(int accountID, string email, string fname, string lname, string birthdate, string phoneNo, string imgPath);
        BL.AccountDTO FindBy(int id);
        BL.AccountDTO FindBy(string email);
        IEnumerable<BL.AccountDTO> FindAllUserBy(byte isAdmin);
        IEnumerable<BL.AccountDTO> FindAll();
        IEnumerable<BL.AccountDTO> FindByStatus(byte status);
        BL.AccountDTO FindByName(string fname, string lname);
        int FindLoginCred(string email, byte[] password);
        int FindLoginEmail(string email);
        int FindLoginPW(byte[] password);
    }
}
