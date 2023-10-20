namespace web_api_simposium.Models.Responses
{
    public class GenericResponse<T>
    {
        public int StatusCode { get; set; }
        public T? Content { get; set; }
        public GenericResponseData? Message { get; set; }
        public string? Token { get; set; }
    }

    public class GenericResponseData
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string InnerException { get; set; } = string.Empty;
    }

}
