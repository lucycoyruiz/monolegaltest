using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Monolegal.Infrastructure.Settings;


namespace Monolegal.Infrastructure.Persistence
{
    public class MongoDbContext
    {

        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

    }
}
