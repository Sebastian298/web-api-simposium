using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using web_api_simposium.Helpers;
using web_api_simposium.Models.Operations;
using web_api_simposium.Models.Responses;
using web_api_simposium.Repositories.BusinessLogic.User;

namespace web_api_simposium.Controllers.BusinessLogic
{
    [ApiController]
    [Route("simposium-api/users")]
    [ApiExplorerSettings(GroupName = "Users")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly GenericResponse<JObject> _error = new();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration([FromBody] UserRegistration user)
        {
            try
            {
                var result = await _userRepository.UserRegistrationAsync(user);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> UserLogIn([FromBody] UserValidation user)
        {
            try
            {
                var result = await _userRepository.UserValidationAsync(user);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _error.StatusCode = 500;
                _error.Message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(_error.StatusCode, _error);
            }
        }
    }
}
