using System;
using FinTech.Common;

namespace FinTech.Data
{
    public class User
    {
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }

        public User(UserDTO user)
        {
            UserID = Guid.NewGuid();
            AccountID = Guid.NewGuid();
            FirstName = user.FirstName;
            LastName = user.LastName;
            Phone = user.Phone;
            DateOfBirth = user.DateOfBirth;
            AddressLine = user.AddressLine;
            City = user.City;
            State = user.State;
            PinCode = user.PinCode;
            Password = user.Password;
            AccountType = user.AccountType;
        }
        public UserDTO GetUserDTO()
        {
            return new UserDTO
            {
                UserID = UserID,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                DateOfBirth = DateOfBirth,
                AddressLine = AddressLine,
                City = City,
                State = State,
                PinCode = PinCode
            };
        }
    }
}