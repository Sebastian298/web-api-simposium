using web_api_simposium.Models.BusinessLogic;
using web_api_simposium.Models.Responses;

namespace web_api_simposium.Repositories.BusinessLogic.Task
{
    public interface ITaskRepository
    {
        Task<GenericResponse<GenericCrud>> TaskRegistration(TaskRegistration task);
    }
}
