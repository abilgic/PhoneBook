namespace ReportWebApi.Models
{
    public class ReportDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PhoneBookCollectionName { get; set; } = null!;
    }
}
