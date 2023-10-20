using web_api_simposium.Models.Queries;

namespace web_api_simposium.Helpers
{
    public static class JsonReader
    {
        public static StoredProcedureData GetConfigurationStoredProcedure(IConfiguration configuration, string repositoryKey)
        {
            return new(configuration[$"{repositoryKey}:connectionId"], configuration[$"{repositoryKey}:schemaName"], configuration[$"{repositoryKey}:spName"]);
        }

    }
}
