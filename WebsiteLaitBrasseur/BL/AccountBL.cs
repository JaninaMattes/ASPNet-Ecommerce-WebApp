using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web;
using WebsiteLaitBrasseur.DAL;

namespace WebsiteLaitBrasseur.BL
{
    public class AccountBL
    {
        private AccountDAL dAL = new AccountDAL();

        /// <summary>
        /// create new login and simultaneously C:\Users\Janina\Documents\DEV\LaitBrasseur-WebStore\WebsiteC:\Users\Janina\Documents\DEV\LaitBrasseur-WebStore\WebsiteLaitBrasseur\BL\BO\Account.csLaitBrasseur\BL\BO\Account.cs
        /// the correct account that belongs to a login
        /// 
        /// Check correctness:
        /// a) Email is not correct in terms of not valid -> return 1
        /// b) Password string is not correct in terms of business rules and security -> return 2
        /// c) Everything is correct return 0 and store isConfirmed value with 1 in database
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public int createAccount(string email, string password, string firstName, string lastName, string birthDate, string phoneNo, string imgPath, int status, int isAdmin)
        {
            int isCorrect = 0;
            try
            {
                int isConfirmed = 0;
                //check if format of email is correct else return = 1
                if (IsValidEmail(email)) {
                //check if the email address is an existing mail
                if (IsEmailValid(email))
                    {
                        isConfirmed = 1; //is correct mail
                    }
                    else
                    {
                        return isCorrect = 1; //is not correct
                    }
                }
                //check if format of password is correct else return = 2
                if (IsValidPassword(password)) {
                    isCorrect = 0;
                } else {
                    return isCorrect = 2; //is not correct
                }
                //if both are correct return 0
                if (isCorrect == 0)
                {
                    dAL.Insert(email, password, isConfirmed, firstName, lastName, birthDate, phoneNo, imgPath, status, isAdmin);
                }                
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return isCorrect;
        }

        public bool IsCorrect(string email, string password)
        {
            LoginDAL login = new LoginDAL();
            try
            {
                int count = login.Check(email, password);
                Console.WriteLine("value returned " + count.ToString());
                //check if login is correct = user already exists in database
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
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
        public bool IsEmailValid(string emailaddress)
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

        public static bool IsValidEmail(string email)
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
                return false;
            }
            catch (ArgumentException e)
            {
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
        /// * Length: Minimum eight and maximum 10 characters
        /// * UpperCase: at least one uppercase letter
        /// * LowerCase: at least one lowercase letter
        /// * Number: at least one number
        /// * Special Character: at least one special character
        /// </summary>
        /// <param name="password"></param>
        /// <returns>boolean value</returns>
        public bool IsValidPassword(string password)
        {
            string MatchPasswordRules = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$";
            if (password != null) return Regex.IsMatch(password, MatchPasswordRules);
            else return false;
        }

        /// <summary>
        /// Additional enum to store values from 
        /// PasswordAdvisor class
        /// </summary>

        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        /// <summary>
        /// source: https://stackoverflow.com/questions/12899876/checking-strings-for-a-strong-enough-password
        /// </summary>
        public class PasswordAdvisor
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
    }
}