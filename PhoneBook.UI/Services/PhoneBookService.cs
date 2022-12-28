using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PhoneBook.UI.Models;

namespace PhoneBook.UI.Services
{
    public class PhoneBookService
    {
        private readonly IMongoCollection<Contact> _phoneBookCollection;
        public PhoneBookService(IOptions<PhoneBookDatabaseSettings> phoneBookDatabaseSettings)
        {
            var mongoClient = new MongoClient(
           phoneBookDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                phoneBookDatabaseSettings.Value.DatabaseName);

            _phoneBookCollection = mongoDatabase.GetCollection<Contact>(
                phoneBookDatabaseSettings.Value.PhoneBookCollectionName);
        }

        public async Task<List<Contact>> GetAsync() =>
        await _phoneBookCollection.Find(_ => true).ToListAsync();

        public async Task<Contact?> GetAsync(string id) =>
            await _phoneBookCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Contact newBook) =>
            await _phoneBookCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Contact updatedBook) =>
            await _phoneBookCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _phoneBookCollection.DeleteOneAsync(x => x.Id == id);
        public async Task<bool> DeleteAsync(string id)
        {
            var deleteResult = await _phoneBookCollection.DeleteOneAsync(x => x.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
