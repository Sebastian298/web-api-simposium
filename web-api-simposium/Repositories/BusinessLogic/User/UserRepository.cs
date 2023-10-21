using Dapper;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using web_api_simposium.Helpers;
using web_api_simposium.Models.Authentications;
using web_api_simposium.Models.Operations;
using web_api_simposium.Models.Responses;
using web_api_simposium.Services;

namespace web_api_simposium.Repositories.BusinessLogic.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDapperService _dapperService;
        private readonly IJwtService _jwtService;

        public UserRepository(IConfiguration configuration, IDapperService dapperService, IJwtService jwtService)
        {
            _configuration = configuration;
            _dapperService = dapperService;
            _jwtService = jwtService;
        }
        public async Task<GenericResponse<GenericCrud>> UserRegistrationAsync(UserRegistration user)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "storedProcedureSettings:user:userRegistration");
                var parameters = new DynamicParameters();
                parameters.Add("Name", user.Name, DbType.String);
                parameters.Add("LastName", user.LastName, DbType.String);
                parameters.Add("Email", user.Email, DbType.String);
                parameters.Add("Password", Cryptography.ConvertToHash(user.Password), DbType.String);

                var result = await _dapperService.ExecuteStoredProcedureAsync<GenericCrud>(spData, parameters);

                if (!result.HasError)
                {
                    return result.Results!.Success
                        ? new GenericResponse<GenericCrud> { StatusCode = 201, Content = result.Results }
                        : new GenericResponse<GenericCrud> { StatusCode = 500, Message = MessageErrorBuilder.GenerateError(result.Results.Exception) };
                }

                return new GenericResponse<GenericCrud> { StatusCode = 500, Message = MessageErrorBuilder.GenerateError(result.Message ?? "") };
            }
            catch (Exception ex)
            {
                return new GenericResponse<GenericCrud> { StatusCode = 500, Message = MessageErrorBuilder.GenerateError(ex.Message) };
            }
        }


        public async Task<GenericResponse<UserLoginResponse>> UserValidationAsync(UserValidation user)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "storedProcedureSettings:user:userValidation");
                var parameters = new DynamicParameters();
                parameters.Add("Email", user.Email, DbType.String);
                parameters.Add("Password", Cryptography.ConvertToHash(user.Password), DbType.String);

                var result = await _dapperService.ExecuteStoredProcedureAsync<UserLoginResponse>(spData, parameters);

                if (!result.HasError)
                {
                    //if (result.Results!.Success)
                    //{
                    //    TokenData tokenData = new()
                    //    {
                    //        UserId = result.Results!.Id.ToString(),
                    //    };
                    //    var responseService = _jwtService.GenerateToken(tokenData, "tallerApiKey");
                    //    string tokenSend = new JwtSecurityTokenHandler().WriteToken(responseService);
                    //    return new GenericResponse<UserLoginResponse>()
                    //    {
                    //        StatusCode = 200,
                    //        Content = result.Results,
                    //        Token = tokenSend
                    //    };

                    //}
                    //else
                    //{
                    //    return new GenericResponse<UserLoginResponse> { StatusCode = 404, Content = result.Results };
                    //}

                    return result.Results!.Success
                        ? new GenericResponse<UserLoginResponse> { StatusCode = 200, Content = result.Results }
                        : new GenericResponse<UserLoginResponse> { StatusCode = 404, Content = result.Results };
                }

                return new GenericResponse<UserLoginResponse> { StatusCode = 500, Message = MessageErrorBuilder.GenerateError(result.Message ?? "") };
            }
            catch (Exception ex)
            {
                return new GenericResponse<UserLoginResponse> { StatusCode = 500, Message = MessageErrorBuilder.GenerateError(ex.Message) };
            }
        }
    }
}