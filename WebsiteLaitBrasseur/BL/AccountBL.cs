using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;
using WebsiteLaitBrasseur.DAL;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace WebsiteLaitBrasseur.BL
{
    public class AccountBL
    {
        private readonly AccountDAL DB = new AccountDAL();
        private static int saltLengthLimit = 32;
        private static byte[] salt;


        /// <summary>
        /// Register a new User and create an account. 
        /// An admin has isAdmin = 1, a customer has isAdmin = 0
        /// 
        /// Check correctness:
        /// a) Email is already used => return 4
        /// b) Email is not correct in terms of not valid => return 3
        /// c) Password string is not correct in terms of business rules and security => return 2
        /// d) Everything is correct => return 1
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public int CreateAccount(string email, string password, string firstName, string lastName, 
            string birthDate, string phoneNo, string imgPath, byte status, byte isAdmin, int confirmationID)
        {
            int flag = 0;
            try
            {
                int isConfirmed = 0;
                //check if format of email is correct && it doesnt already exist in DB 
                //else return = 1
                if (DB.FindLoginEmail(email) == 1)
                {
                    //check if the email address is an existing mail
                    return flag = 4; //is not correct & exists already
                }
                if (!IsEmailValid(email))
                {                   
                    return flag = 3; //is not correct
                }
                //check if format of password is correct else return = 2
                if (!IsValidPassword(password))
                {
                    return flag = 2; //is not correct
                }
                //if both are correct flag remains 0
                if (flag == 0)
                {
                    //encrypt the password before it is sent to the DB
                    //password = this.HashPassword(password);
                    //Debug.Print("AccountBL / Password hashed " + password.ToString());
                    //returns the created Account ID as integer value
                    if (status != 0) { status = 0; }
                    //generate hashed password to store in DB with salt 
                    var md5 = GenerateSaltedHash(password);
                    flag = DB.Insert(email, md5, salt, isConfirmed, firstName, lastName, birthDate, phoneNo, imgPath, status, isAdmin, confirmationID); 

                    //Flag return new customer ID ?  need flag=1 if ok to have check=1 => registration validate
                    if (flag >4 ) { flag=1 ; }
                }                
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return flag;
        }

        /// <summary>
        /// Function to check if password and email address are
        /// correctly entered in a textbox.
        /// Business Rules:
        /// a) Password and Username are not correct return = 0
        /// b) Password and Username are correct and exist return = 1
        /// c) User is no-admin return = 2
        /// d) Password is incorrect return = 3
        /// e) Username is incorrect return = 4
        /// f) User is suspendet = 5, don't allow login
        /// g) User is suspendet for 1 hour then reset = 5  
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int IsAdminLoginCorrect(string email, string password)
        {
            int flag = 0;
            
            try
            {
                //get stored values from DB to check PW
                var account = DB.FindBy(email);
                var salt = account.GetSalt();
                var hashPW = GenerateSaltedHash(password, salt);

                if (IsUserSuspendet(email) == true)
                {
                    // 6 = user is suspendet
                    return flag = 6;
                }
                else if (!IsUserConfirmed(email))
                {
                    // 5 = usr email is not confirmed
                    return flag = 5;
                }
                else if (DB.FindLoginEmail(email) != 1)

                {
                    // 3 = email is not correct
                    return flag = 4; 
                }
                else if (IsUserSuspendet(email) == true)
                {
                    // 4 = user is suspendet
                    return flag = 4;
                }
                else if (DB.FindLoginPW(hashPW) == 0)
                {
                    // 2 = password is not correct
                    return flag = 3; 
                }
                else if (!IsUserAdmin(email))
                {
                    // 4 = user is not entitled to log in as admin
                    return flag = 2;
                }               
                else
                {
                    //check if login is correct AND user already exists in database
                    // 1 = user exists in DB and email and PW are correct
                    flag = DB.FindLoginCred(email, hashPW); // 1 = user and password are in DB
                    Debug.Print($"AccountBL / value returned {flag}");
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return flag;
        }

        /// <summary>
        /// Function to check if password and email address are
        /// correctly entered in a textbox.
        /// Business Rules:
        /// a) Password and Username are not correct return = 0
        /// b) Password and Username are correct and exist return = 1
        /// c) User is no customer return = 2
        /// d) Password is incorrect return = 3
        /// e) Email is incorrect return = 4
        /// f) User is suspendet = 5, don't allow login
        /// g) User is suspendet for 1 hour then reset = 5  
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int IsCustomerLoginCorrect(string email, string password)
        {
            int flag = 0;

            try
            {
                //get stored values from DB to check PW
                var account = DB.FindBy(email);
                var salt = account.GetSalt();
                var hashPW = GenerateSaltedHash(password, salt);

                if (IsUserSuspendet(email) == true)
                {
                    // 5 = user is suspendet
                    return flag = 5;
                }
                else if (DB.FindLoginEmail(email) != 1)
                {
                    // 4 = email is not correct
                    return flag = 4;
                }
                else if (DB.FindLoginPW(hashPW) == 0)
                {
                    // 3 = password is not correct
                    return flag = 3;
                }
                else if (IsUserAdmin(email))
                {
                    // 2 = user is not entitled to log in as customer
                    return flag = 2;
                }
                else
                {
                    //check if login is correct AND user already exists in database
                    // 1 = user exists in DB and email and PW are correct
                    flag = DB.FindLoginCred(email, hashPW); // 1 = user and password are in DB
                    Debug.Print($"AccountBL / value returned {flag}");
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return flag;
        }

        /// <summary>
        /// First add new Address and then use returning ID
        /// to set the new address as well as reference in Account.
        /// Returns the value of the effected rows.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="addressID"></param>
        /// <returns></returns>
        public int AddAddress(string email, int addressID)
        {
            int result = 0;
            if ((DB.FindLoginEmail(email) == 1) && addressID > 0)
            {
                result = DB.UpdateAddress(email, addressID);
                Debug.Print("AccountBL / value returned " + result.ToString());
            }
            else
            {
                throw new InputInvalidException("The input value is invalid.");
            }
            return result;
        }

       /// <summary>
       /// Suspend or reaccredit a user.
       /// When successfull the result = 1
       /// </summary>
       /// <param name="accountID"></param>
       /// <param name="status"></param>
       /// <returns>int result</returns>
        public int UpdateStatus(string email, byte status)
        {
            int result = 0;
            if (status == 0 || status == 1)
            {
                result = DB.UpdateStatus(email, status);
                Debug.Print("AccountBL / Status Update / value returned " + result);
            }
            else
            {
                throw new InputInvalidException("The user input is invalid.");
            }
            return result;
        }

        /// <summary>
        /// Change the path of the image of an user
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="imgPath"></param>
        /// <returns>int result</returns>
        public int UpdateImgPath(string email, string imgPath)
        {
            int result = 0;
            try
            {
                result = DB.UpdateImg(email, imgPath);
                Debug.Print("AccountBL / Update ImgPath / value returned " + result);
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }


            
            return result;
        }


        /// <summary>
        /// Confirmed an user
        /// When successfull the result = 1
        /// <param name="email"></param>
        /// <returns>int result</returns>
        public int UpdateIsConfirmed(string email)
        {
            var result = DB.UpdateIsConfirmed(email,1);
            Debug.Print("AccountBL / update is confirmed " + result);

            return result;
        }

        /// <summary>
        /// Business Rules
        /// If email is not correct return => 2
        /// If password is not correct return => 3
        /// 
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        /// <param name="phoneNo"></param>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public int UpdateAll(string mail, string password, string firstName, string lastName,
            string birthDate, string phoneNo, string imgPath)
        {
            int flag;

            AccountDTO customer = new AccountDTO();
            if (IsValidEmail(mail))
            {
                customer = DB.FindBy(mail);
                Debug.Print("AccountBL / UpdateAll value returned " + customer.ToString());
            }
            else
            {   //email is not correct => 2
                flag = 2;
                throw new InputInvalidException("The email is not valid");
            }
            
            //if update was successfull => 1
            flag = DB.UpdateAll(customer.GetID(), mail, firstName, lastName, birthDate, phoneNo, imgPath);

            Debug.Print("AccountBL / UpdateAll correction: " + flag);
            return flag;
        }

        /// <summary>
        /// Update all values in user profile.
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        /// <param name="phoneNo"></param>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public int Update(string mail, string firstName, string lastName,
            string birthDate, string phoneNo, string imgPath)
        {
            int flag;
            AccountDTO customer = new AccountDTO();
            
            if (IsValidEmail(mail))
            {
                customer = DB.FindBy(mail);
                Debug.Print("AccountBL / Update value returned " + customer.ToString());
            }
            else
            {   //email is not correct => 2
                return flag = 2;
            }
            //if update was successfull => 1
            flag = DB.Update(customer.GetID(), mail, firstName, lastName, birthDate, phoneNo, imgPath);

            Debug.Print("AccountBL / Update correction: " + flag);
            return flag;
        }

        public int UpdateNamePhone(string email, string firstName, string lastName, string phoneNo)
        {
            int flag=0;
            AccountDTO customer = new AccountDTO();
            try
            {
                flag = DB.UpdateUsername(email, firstName, lastName);
                Debug.Print("\nAccountBL / UpdateNamePhone/  flag1: " + flag);  //DEBUG

                flag = DB.UpdatePhoneNo(email, phoneNo);
                Debug.Print("\nAccountBL / UpdateNamePhone/  flag2: " + flag);   //DEBUG           
            }catch(Exception ex)
            {
                ex.GetBaseException();
                Debug.Write(ex.ToString());
            }
            return flag;
        }


        /// <summary>
        /// Update the user password in DB.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UpdatePassword(string email, string password)
        {
            int result = 0;
            if (IsValidPassword(password))
            {
                try
                {
                    var pw = GenerateByteArr(password);
                    var md5 = GenerateSaltedHash(pw, salt);

                    //return value 1 if DB update successfull
                    result = DB.UpdatePassword(email, md5);
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                }
             }
            return result;
        }

        /// <summary>
        /// Find single customer in DB
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public AccountDTO GetCustomer(string email)
        {
            AccountDTO customer = new AccountDTO();
            try
            {
                customer = DB.FindBy(email);
                Debug.Print("AccountBL / Customer ID: " + customer.GetID());
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Write(e.ToString());
            }
            return customer;
        }

        /// <summary>
        /// Find single customer in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AccountDTO GetCustomer(int id)
        {
            AccountDTO customer = new AccountDTO();
            try
            {
                customer = DB.FindBy(id);
                Debug.Print("AccountBL / Customer ID: " + customer.GetID());
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Write(e.ToString());
            }
            return customer;
        }

        /// <summary>
        /// Find single customer in DB
        /// </summary>
        /// <param name="confID"></param>
        /// <returns></returns>
        public AccountDTO GetCustomerByConfID(int confID)
        {
            AccountDTO customer = new AccountDTO();
            try
            {
                customer= DB.FindByConfID(confID);
                Debug.Print("AccountBL / Conf ID: " + customer.GetConfirmationID());
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.Write(e.ToString());
            }
            return customer;
        }

        /// <summary>
        /// Find all Customers in DB.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountDTO> GetAllCustomers()
        {
            byte isAdmin = 0;
            IEnumerable<AccountDTO> results = new List<AccountDTO>();
            results = DB.FindAllUserBy(isAdmin);
            return results;
        }

        /// <summary>
        /// Find all Admins in DB.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountDTO> GetAllAdmins()
        {
            byte isAdmin = 1;
            IEnumerable<AccountDTO> results = new List<AccountDTO>();
            results = DB.FindAllUserBy(isAdmin);
            return results;
        }

        /// <summary>
        /// Check if a user is suspendet.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsUserSuspendet(string email)
        {
            Debug.Print("AccountBL: /isUserSuspendet/avant " ); //DEBUG
            AccountDTO customer = new AccountDTO();
            customer = DB.FindBy(email);
            int status = customer.GetStatus();      
            Debug.Print($"AccountBL: /isUserSuspendet/status {status}");
            if (status == 0)
            {
                Debug.Print($"AccountBL: / User not-suspendet / status {status}");
                return false;       //isSuspended=0 ;false
            }
            else if (status == 1)
            {
                Debug.Print($"AccountBL: / User suspendet / status {status}");
                return true;   //isSuspended=1 ;true
            }
            else
            {
                throw new ArgumentNullException($"No customer found for {email}");
            }
        }

        /// <summary>
        /// Check if a user email is confirmed.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsUserConfirmed(string email)
        {
            AccountDTO customer = new AccountDTO();
            customer = DB.FindBy(email);
            int isConfirmed = customer.GetIsConfirmed();
            Debug.Print("AccountBL: /isUserConfirmed/ isConfirmed " + customer.GetIsConfirmed());
            if (customer != null && isConfirmed == 0)
            {
                return false;       //isconfirmed=0 ;false
            }
            else if (customer != null && isConfirmed == 1)
            {
                return true;   //isconfirmed=1 ;true
            }
            else
            {
                throw new ArgumentNullException($"No customer found for {email}");
            }
        }

        /// <summary>
        /// Check if a user is suspendet.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsUserAdmin(string email)
        {
            AccountDTO customer = new AccountDTO();
            try
            {
                customer = DB.FindBy(email);
                Debug.Print("AccountBL: /isUserAdmin/ isAdmin " + customer.GetIsAdmin());
                if (customer.GetIsAdmin() == 1)
                {
                    return true;       //isconfirmed=0 ;false
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            return false;          
        }

        /// <summary>
        /// Check if the added email address is valid
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        private bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// source https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        /// Check if email format is correct and return a boolean value for true/false
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                e.GetBaseException();
                return false;
            }
            catch (ArgumentException e)
            {
                e.GetBaseException();
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// function to check if a password is correct entered in the textfield
        /// this returns a true or false value if the business rules are kept correctly
        /// Rules for the Password are:
        /// * avoid spaces in the string
        /// * Length: Maximum 10 characters
        /// * UpperCase: at least one uppercase letter
        /// * LowerCase: at least one lowercase letter
        /// * Number: at least one number
        /// </summary>
        /// <param name="password"></param>
        /// <returns>boolean value</returns>
        private bool IsValidPassword(string password)
        {
            string MatchPasswordRules = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9#?!@$%^&*-]).{8,}$";
            if (password != null) return Regex.IsMatch(password, MatchPasswordRules);
            else return false;
        }

        /// <summary>
        /// Additional enum to store values from 
        /// PasswordAdvisor class
        /// </summary>

        private enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        /// <summary>
        /// Check quality of password
        /// source: https://stackoverflow.com/questions/12899876/checking-strings-for-a-strong-enough-password
        /// </summary>
        private class PasswordAdvisor
        {
            public static PasswordScore CheckStrength(string password)
            {
                int score = 0;

                if (password.Length < 1)
                    return PasswordScore.Blank;
                if (password.Length < 4)
                    return PasswordScore.VeryWeak;
                if (password.Length >= 8)
                    score++;
                if (password.Length >= 12)
                    score++;
                if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)       
                    score++;
                if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
                  Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                    score++;
                if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                    score++;

                return (PasswordScore)score;
            }
        }

        /// <summary>
        /// Create salt.
        /// </summary>
        /// <returns></returns>
        private static byte[] GetSalt()
        {
            return GetSalt(saltLengthLimit);
        }

        /// <summary>
        /// Create random Salt: 
        /// source https://codereview.stackexchange.com/questions/93614/salt-generation-in-c
        /// </summary>
        /// <param name="maximumSaltLength"></param>
        /// <returns></returns>
        private static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        /// <summary>
        /// Generate new salted hash.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static byte[] GenerateSaltedHash(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        /// <summary>
        /// Compare two byte arrays against each other.
        /// Note that the euqality operator cant be used.
        /// source: https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp
        /// </summary>
        /// <param name="PW1_md5"></param>
        /// <param name="PW2_md5"></param>
        /// <returns></returns>
        private static bool CompareByteArrays(byte[] PW1_md5, byte[] PW2_md5)
        {
            if (PW1_md5.Length != PW2_md5.Length)
            {
                return false;
            }

            for (int i = 0; i < PW1_md5.Length; i++)
            {
                if (PW1_md5[i] != PW2_md5[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Generate a byte array from string.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static byte[] GenerateByteArr(string password)
        {
            return Encoding.ASCII.GetBytes(password);
        }

        /// <summary>
        /// Generate a salted Hash.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static byte[] GenerateSaltedHash(string password)
        {
            salt = GetSalt();
            var pw = GenerateByteArr(password);
            var md5 = GenerateSaltedHash(pw, salt);
            return md5;
        }

        /// <summary>
        /// Generate a salted Hash.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static byte[] GenerateSaltedHash(string password, byte[] salt)
        {
            var pw = GenerateByteArr(password);
            var md5 = GenerateSaltedHash(pw, salt);
            return md5;
        }
    }
}