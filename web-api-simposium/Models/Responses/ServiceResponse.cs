namespace web_api_simposium.Models.Responses
{
    public class ServiceResponse
    {
        public bool HasError { get; set; }
        public string? Message { get; set; }
        public dynamic? Results { get; set; }
    }
}
