using Dapper;
using web_api_simposium.Models.Queries;
using web_api_simposium.Models.Responses;

namespace web_api_simposium.Services
{
    public interface IDapperService
    {
        Task<ServiceResponse> ExecuteStoredProcedureAsync<T>(StoredProcedureData qData, DynamicParameters parameters,bool hasArray = false);
    }
}
