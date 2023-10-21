using Dapper;
using System.Data;
using web_api_simposium.Helpers;
using web_api_simposium.Models.BusinessLogic;
using web_api_simposium.Models.Responses;
using web_api_simposium.Services;

namespace web_api_simposium.Repositories.BusinessLogic.Task
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDapperService _dapperService;
        private readonly IHttpContextAccessor _httpContext;

        public TaskRepository(IConfiguration configuration,IDapperService dapperService, IHttpContextAccessor httpContext)
        {
            _configuration = configuration;
            _dapperService = dapperService;
            _httpContext = httpContext;
        }
        public async Task<GenericResponse<GenericCrud>> TaskRegistration(TaskRegistration task)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "storedProcedureSettings:task:taskRegistration");
                var parameters = new DynamicParameters();
                var authorizationHeader = _httpContext.HttpContext.Request.Headers["Authorization"];
                var userId = Cryptography.GetUserIdByJwt(authorizationHeader);
                parameters.Add("UserId", userId, DbType.String);
                parameters.Add("Title", task.Title, DbType.String);
                parameters.Add("Description", task.Description, DbType.String);

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
    }
}
