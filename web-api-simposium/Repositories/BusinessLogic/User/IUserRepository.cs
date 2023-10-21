using web_api_simposium.Models.Operations;
using web_api_simposium.Models.Responses;

namespace web_api_simposium.Repositories.BusinessLogic.User
{
    public interface IUserRepository
    {
        Task<GenericResponse<GenericCrud>> UserRegistrationAsync(UserRegistration user);
        Task<GenericResponse<UserLoginResponse>> UserValidationAsync(UserValidation user);
    }
}
