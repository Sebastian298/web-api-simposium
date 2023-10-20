namespace web_api_simposium.Models.Queries
{
    public class StoredProcedureData
    {
        public StoredProcedureData(string schemaName, string name, string idConnectionString)
        {
            this.SchemaName = schemaName;
            this.Name = name;
            this.IdConnectionString = idConnectionString;
        }
        public string SchemaName { get; set; }
        public string Name { get; set; }
        public string IdConnectionString { get; set; }
    }
}
