using FinTech.Data;
using System.Linq;
using FinTech.Common;

namespace FinTech.Logic
{
    public class AuthenticationBL
    {
        public ApiResponse<bool> Register(UserDTO userDto)
        {
            var apiResponse = new ApiResponse<bool>();

            if (!InputValidationHelper.IsValidName(userDto.FirstName))
            {
                apiResponse.Message = AuthenticationMessages.InvalidFirstName;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidEmail(userDto.Email))
            {
                apiResponse.Message = AuthenticationMessages.InvalidUserEmail;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidPhone(userDto.Phone))
            {
                apiResponse.Message = AuthenticationMessages.InvalidPhoneNumber;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidDOB(userDto.DateOfBirth))
            {
                apiResponse.Message = AuthenticationMessages.InvalidDateOfBirth;
                return apiResponse;
            }

            if (!InputValidationHelper.AreSame(userDto.Password, userDto.ConfirmPassword))
            {
                apiResponse.Message = AuthenticationMessages.PasswordMismatch;
                return apiResponse;
            }

            var user = new User(userDto);
            DataContext.User.Add(user);
            apiResponse.IsSuccess = true;
            apiResponse.Message = AuthenticationMessages.RegisterSuccess;
            return apiResponse;
        }

        public ApiResponse<UserDTO> Login(string strEmail, string strPassword)
        {
            var apiResponse = new ApiResponse<UserDTO>();

            if (!InputValidationHelper.IsValidEmail(strEmail))
            {
                apiResponse.Message = AuthenticationMessages.InvalidUserEmail;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidPassword(strPassword))
            {
                apiResponse.Message = AuthenticationMessages.InvalidPassword;
                return apiResponse;
            }

            var user = DataContext.User.FirstOrDefault(u => u.Email == strEmail && u.Password == strPassword);

            if (user == null)
            {
                apiResponse.Message = AuthenticationMessages.UserNotFound;
                return apiResponse;
            }

            apiResponse.IsSuccess = true;
            apiResponse.Message = AuthenticationMessages.LoginSuccess;
            apiResponse.Result = user.GetUserDTO();
            return apiResponse;
        }
    }
}