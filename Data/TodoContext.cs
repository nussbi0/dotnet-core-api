using Microsoft.Extensions.Options;
using MongoDB.Driver;
using dotnet_core_api.Models;

namespace dotnet_core_api.Data
{
    public class TodoContext
    {
        private readonly IMongoDatabase _database = null;

        public TodoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Todo> Todos
        {
            get
            {
                return _database.GetCollection<Todo>("todos");
            }
        }
    }
}