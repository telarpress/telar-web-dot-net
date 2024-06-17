using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Profile.Models;
using Profile.Config;

namespace Profile.Database
{
    public class ProfileContext
    {
        private readonly IMongoDatabase _database;

        public ProfileContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<UserProfile> Profiles => _database.GetCollection<UserProfile>("Profiles");
    }
}
