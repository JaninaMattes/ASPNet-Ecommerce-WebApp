using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web;
using WebsiteLaitBrasseur.DAL;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Timers;

namespace WebsiteLaitBrasseur.BL
{
    public class AccountBL
    {
        private AccountDAL DB = new AccountDAL();
        private static int count = 0;

        /// <summary>
        /// Register a new User and create an account. 
        /// An admin has isAdmin = 1, a customer has isAdmin = 0
        /// 
        /// Check correctness:
        /// a) Email is not correct in terms of not valid -> return 1
        /// b) Password string is not correct in terms of business rules and security -> return 2
        /// c) Everything is correct return 0 and store isConfirmed value with 1 in database
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public int CreateAccount(string email, string password, string firstName, string lastName, 
            string birthDate, string phoneNo, string imgPath, int status, int isAdmin)
        {
            int isCorrect = 0;
            try
            {
                int isConfirmed = 0;
                //check if format of email is correct && it doesnt already exist in DB 
                //else return = 1
                if (IsValidEmail(email) && (DB.FindLoginEmail(email) != 1))
                {
                //check if the email address is an existing mail
                    if (IsEmailValid(email) == false)
                    {
                        return isCorrect = 1; //is not correct
                    }
                }
                //check if format of password is correct else return = 2
                if (!IsValidPassword(password))
                {
                    return isCorrect = 2; //is not correct
                }
                //if both are correct return 0
                if (isCorrect == 0)
                {
                    //encrypt the password before it is sent to the DB
                    password = this.HashPassword(password);
                    Debug.Print("AccountBL / Password hashed " + password.ToString());
                    //returns the created Account ID as integer value
                    DB.Insert(email, password, isConfirmed, firstName, lastName, birthDate, phoneNo, imgPath, status, isAdmin); //Need Debug
                }                
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return isCorrect;
        }

        /// <summary>
        /// Function to check if password and email address are
        /// correctly entered in a textbox.
        /// Business Rules:
        /// a) Password and Username are not correct return = 0
        /// b) Password and Username are correct and exist return = 1
        /// c) Password is incorrect return = 2
        /// d) Username is incorrect return = 3
        /// e) User is suspendet = 4, don't allow login
        /// f) User is suspendet for 1 hour then reset = 5
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int IsLoginCorrect(string email, string password)
        {           
            int isCorrect = 0;
            string hashPW = password; //= HashPassword(password);
            if(count == 3)
            {
                // 5 = suspend the user
                isCorrect = 5;
                //Call timer
                StartTimer();
            }
            try
            {
                if (DB.FindLoginEmail(email) != 1)
                {
                    // 3 = email is not correct
                    return isCorrect = 3; 
                }
                if (DB.FindLoginPW(hashPW) != 1)
                {
                    // 2 = password is not correct
                    return isCorrect = 2; 
                }
                if (isUserSuspendet(email) == true)
                {
                    // 4 = user is suspendet
                    return isCorrect = 4; 
                }
                else
                {
                    //check if login is correct AND user already exists in database
                    // 1 = user exists in DB and email and PW are correct
                    isCorrect = DB.FindLoginCred(email, hashPW);
                    Debug.Print("AccountBL / value returned " + isCorrect.ToString());
                }

                //count the login attempts
                count++;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return isCorrect;
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
        public int UpdateStatus(string email, int status)
        {
            int result = 0;
            if (status >= 0 && status <= 1)
            {
                result = DB.UpdateStatus(email, status);
                Debug.Print("AccountBL / value returned " + result.ToString());
            }
            else
            {
                throw new InputInvalidException("The user input is invalid.");
            }
            return result;
        } 

        public int UpdateIsConfirmed(string email)
        {
            int result = 0;
            result=DB.UpdateIsConfirmed(email);
            Debug.Print("AccountBL / update is confirmed " + result.ToString());

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
            int IsCorrect = 0;

            //TODO isConfirmed

            AccountDTO customer = new AccountDTO();
            string saltedPassword;
            if (IsValidEmail(mail))
            {
                customer = DB.FindBy(mail);
                Debug.Print("AccountBL / UpdateAll value returned " + customer.ToString());
            }
            else
            {   //email is not correct => 2
                IsCorrect = 2;
                throw new InputInvalidException("The email is not valid");
            }
            if (IsValidPassword(password))
            {
                saltedPassword = HashPassword(password);
                //if update was successfull => 1
                IsCorrect = DB.UpdateAll(customer.GetID(), mail, saltedPassword, firstName, lastName, birthDate, phoneNo, imgPath);
            }
            else
            {
                //password is not correct => 3
                IsCorrect = 3;
                throw new InputInvalidException("The password is not valid");
            }
            Debug.Print("AccountBL / UpdateAll correction: " + IsCorrect);
            return IsCorrect;
        }

        /// <summary>
        /// Find all Customers in DB.
        /// </summary>
        /// <returns></returns>
        public List<AccountDTO> GetAllCustomers()
        {
            int isAdmin = 0;
            List<AccountDTO> results = new List<AccountDTO>();
            results = DB.FindAllUserBy(isAdmin);
            return results;
        }

        /// <summary>
        /// Find all Admins in DB.
        /// </summary>
        /// <returns></returns>
        public List<AccountDTO> GetAllAdmins()
        {
            int isAdmin = 1;
            List<AccountDTO> results = new List<AccountDTO>();
            results = DB.FindAllUserBy(isAdmin);
            return results;
        }

        /// <summary>
        /// Check if a user is suspendet.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool isUserSuspendet(string email)
        {
            AccountDTO customer = new AccountDTO();
            customer = DB.FindBy(email);
            int status = customer.GetStatus();
            Debug.Print("AccountBL: /isUserSuspendet/status " + customer.GetStatus());
            if (customer != null && status != 1)
            {
                return false;       //isSuspended=0 ;false
            }
            else if (customer != null && status != 0)
            {
                return true;   //isSuspended=1 ;true
            }
            else
            {
                throw new ArgumentNullException($"No customer found for {email}");
            }
        }

        /// <summary>
        /// Timer to set the counter back
        /// and allow user to log in again.
        /// </summary>
        private void StartTimer()
        {
            count = 0;
            //TODO
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
            string MatchPasswordRules =  "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,}$";
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
        /// Source Stackoverflow: https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string HashPassword(string password)
        {
            byte[] salt;
            string savedPasswordHash;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //get hash value
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            //combine both
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //return the created hash password
            return savedPasswordHash = Convert.ToBase64String(hashBytes); 
        }
    }
}