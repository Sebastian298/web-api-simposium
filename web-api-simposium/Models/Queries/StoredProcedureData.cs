namespace web_api_simposium.Models.Queries
{
    public class StoredProcedureData
    {
        public string SchemaName { get; set; }
        public string Name { get; set; }
        public string IdConnectionString { get; set; }

        public StoredProcedureData(string schemaName,string name,string idConnectionString)
        {
           this.SchemaName = schemaName;
           this.Name = name;
           this.IdConnectionString = idConnectionString;
        }
    }
}
