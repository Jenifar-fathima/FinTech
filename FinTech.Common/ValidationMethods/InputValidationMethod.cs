using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinTech.Common
{
    public static class InputValidationHelper
    {
        public static bool IsValidPhone(string strPhone)
        {
            if (string.IsNullOrEmpty(strPhone) || strPhone.Length != 10 || !strPhone.All(char.IsDigit))
                return false;

            return true;
        }

        public static bool IsValidName(string strFirstName)
        {
            if (string.IsNullOrEmpty(strFirstName) || !strFirstName.All(char.IsLetter))
                return false;

            return true;
        }

        public static bool IsValidEmail(string strEmail)
        {
            string emailPattern = @"[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrEmpty(strEmail) || !Regex.IsMatch(strEmail, emailPattern))
                return false;

            return true;
        }

        public static bool IsValidDOB(DateTime dateOfBirth)
        {
            return dateOfBirth < DateTime.Today;
        }

        public static bool IsValidPassword(string strPassword)
        {
            if (string.IsNullOrEmpty(strPassword) || strPassword.Length < 8)
                return false;

            return true;
        }

        public static bool AreSame(string strText1, string strText2)
        {
            return strText1.Equals(strText2);
        }
    }
}