using FinTech.Data;
using System;
using System.Linq;
using FinTech.Common;

namespace FinTech.Logic
{
    public class AuthenticationBL
    {
        public User Login(Guid userID, string strPassword)
        {
            if (userID == Guid.Empty)
            {
                throw new ArgumentException(ErrorMessages.InvalidUserID);
            }

            if (string.IsNullOrEmpty(strPassword) || strPassword.Length < 8)
            {
                throw new ArgumentException(ErrorMessages.InvalidLoginPassword);
            }

            var user = DataContext.Users.FirstOrDefault(u => u.UserID == userID && u.Password == strPassword);

            if (user == null)
            {
                throw new ArgumentException(ErrorMessages.UserNotFound);
            }

            return user;
        }

        public bool Register(UserDTO userDto)
        {
            if (DataContext.Users.Any(u => u.Phone == userDto.Phone))
            {
                throw new ArgumentException(ErrorMessages.UserAlreadyExists);
            }

            if (string.IsNullOrEmpty(userDto.Phone) || userDto.Phone.Length != 10 || !userDto.Phone.All(char.IsDigit))
            {
                throw new ArgumentException(ErrorMessages.InvalidPhoneNumber);
            }

            if (string.IsNullOrEmpty(userDto.Password) || userDto.Password.Length < 8)
            {
                throw new ArgumentException(ErrorMessages.InvalidPassword);
            }

            if (string.IsNullOrEmpty(userDto.FirstName) || string.IsNullOrEmpty(userDto.LastName))
            {
                throw new ArgumentException(ErrorMessages.InvalidName);
            }

            if (userDto.DateOfBirth >= DateTime.Today)
            {
                throw new ArgumentException(ErrorMessages.InvalidDateOfBirth);
            }

            var user = new User
            {
                UserID = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Phone = userDto.Phone,
                DateOfBirth = userDto.DateOfBirth,
                AddressLine = userDto.AddressLine,
                City = userDto.City,
                State = userDto.State,
                PinCode = userDto.PinCode,
                Password = userDto.Password,
                AccountType = userDto.AccountType
            };

            DataContext.Users.Add(user);
            return true;
        }
    }
}

