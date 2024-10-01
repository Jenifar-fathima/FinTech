using System;
namespace FinTech.Common
{
    public class UserDTO
    {
        public Guid UserID { get; set; }
        public Guid AccountID {  get; set; }
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
        public string ConfirmPassword { get; set; }
        public AccountType AccountType { get; set; }
    }
}