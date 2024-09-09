using FinTech.Data;
using System;
using System.Linq;
using FinTech.Common;

namespace FinTech.Logic
{
    public class AuthenticationBL
    {
        public bool Register(UserDTO userDto)
        {
            if (!InputValidationHelper.IsValidName(userDto.FirstName))
            {
                throw new ArgumentException(ErrorMessages.InvalidFirstName);
            }

            if (!InputValidationHelper.IsValidEmail(userDto.Email))
            {
                throw new ArgumentException(ErrorMessages.InvalidUserEmail);
            }

            if (!InputValidationHelper.IsValidPhone(userDto.Phone))
            {
                throw new ArgumentException(ErrorMessages.InvalidPhoneNumber);
            }

            if (!InputValidationHelper.IsValidDOB(userDto.DateOfBirth))
            {
                throw new ArgumentException(ErrorMessages.InvalidDateOfBirth);
            }

            if (!InputValidationHelper.AreSame(userDto.Password, userDto.ConfirmPassword))
            {
                throw new ArgumentException(ErrorMessages.PasswordMismatch);
            }

            User user = new User(userDto);

            DataContext.User.Add(user);
            return true;
        }


        public UserDTO Login(string strEmail, string strPassword)
        {
            if (!InputValidationHelper.IsValidEmail(strEmail))
            {
                throw new ArgumentException(ErrorMessages.InvalidUserEmail);  
            }

            if (!InputValidationHelper.IsValidPassword(strPassword))
            {
                throw new ArgumentException(ErrorMessages.InvalidPassword);  
            }

            var user = DataContext.User.FirstOrDefault(u => u.Email == strEmail);

            if (user == null )
            {
                throw new ArgumentException(ErrorMessages.UserNotFound);  
            }

            if (user.Password != strPassword)
            {
                throw new ArgumentException(ErrorMessages.InvalidPassword);
            }

            return user.GetUserDTO();
        }
    }
}