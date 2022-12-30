using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReportWebApi.Models;

namespace ReportWebApi.Services
{  
    public class ReportService
    {
        private readonly IMongoCollection<Contact> _ReportCollection;
        public ReportService(IOptions<ReportDatabaseSettings> ReportDatabaseSettings)
        {
            var mongoClient = new MongoClient(
           ReportDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                ReportDatabaseSettings.Value.DatabaseName);

            _ReportCollection = mongoDatabase.GetCollection<Contact>(
                ReportDatabaseSettings.Value.PhoneBookCollectionName);
        }

        public async Task<List<Contact>> GetAsync() =>
        await _ReportCollection.Find(_ => true).ToListAsync();

        public async Task<Contact?> GetAsync(string id) =>
            await _ReportCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Contact newBook) =>
            await _ReportCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Contact updatedBook) =>
            await _ReportCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _ReportCollection.DeleteOneAsync(x => x.Id == id);
        public async Task<bool> DeleteAsync(string id)
        {
            var deleteResult = await _ReportCollection.DeleteOneAsync(x => x.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
