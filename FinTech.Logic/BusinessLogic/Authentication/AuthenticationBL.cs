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
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.InvalidFirstName;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidEmail(userDto.Email))
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.InvalidUserEmail;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidPhone(userDto.Phone))
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.InvalidPhoneNumber;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidDOB(userDto.DateOfBirth))
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.InvalidDateOfBirth;
                return apiResponse;
            }

            if (!InputValidationHelper.AreSame(userDto.Password, userDto.ConfirmPassword))
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.PasswordMismatch;
                return apiResponse;
            }

            var user = new User(userDto);
            DataContext.User.Add(user);
            apiResponse.IsSuccess = true;
            apiResponse.Message = SuccessMessage.RegisterSuccess;
            return apiResponse;
        }

        public ApiResponse<UserDTO> Login(string strEmail, string strPassword)
        {
            var apiResponse = new ApiResponse<UserDTO>();

            if (!InputValidationHelper.IsValidEmail(strEmail))
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.InvalidUserEmail;
                return apiResponse;
            }

            if (!InputValidationHelper.IsValidPassword(strPassword))
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.InvalidPassword;
                return apiResponse;
            }

            var user = DataContext.User.FirstOrDefault(u => u.Email == strEmail && u.Password == strPassword);

            if (user == null)
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = ErrorMessages.UserNotFound;
                return apiResponse;
            }

            apiResponse.IsSuccess = true;
            apiResponse.Message = SuccessMessage.LoginSuccess;
            apiResponse.Result = user.GetUserDTO();
            return apiResponse;
        }
    }
}