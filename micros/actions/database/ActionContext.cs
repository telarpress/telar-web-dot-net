using Actions.Config;
using Actions.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Actions.Database
{
    public class ActionContext
    {
        private readonly IMongoDatabase _database;

        public ActionContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Actions.Models.Action> Actions => _database.GetCollection<Actions.Models.Action>("Actions");
    }
}
