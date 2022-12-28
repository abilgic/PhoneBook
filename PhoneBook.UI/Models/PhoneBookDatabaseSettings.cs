namespace PhoneBook.UI.Models
{
    public class PhoneBookDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PhoneBookCollectionName { get; set; } = null!;
    }
}
