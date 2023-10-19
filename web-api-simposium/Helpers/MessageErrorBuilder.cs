using web_api_simposium.Models.Responses;

namespace web_api_simposium.Helpers
{
    public static class MessageErrorBuilder
    {
        public static GenericResponseData GenerateError(string innerException)
        {
            return new GenericResponseData
            {
                Type = "danger",
                Title = "Error",
                Message = "Error inesperado, intente de nuevo o contacte a soporte",
                InnerException = innerException
            };
        }
    }
}
