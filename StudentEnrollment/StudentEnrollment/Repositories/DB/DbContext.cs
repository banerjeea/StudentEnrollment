using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentEnrollment.Models;

namespace StudentEnrollment.Repositories.DB
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext(IOptions<DbSettings> dbSettings)
        {
            var client = new MongoClient(dbSettings.Value.ConnectionString);
            _database = client.GetDatabase(dbSettings.Value.Database);

        }

        public IMongoCollection<Models.Subject> Subjects()
        {
            return _database.GetCollection<Models.Subject>("Subjects");
        }

        public IMongoCollection<Models.Theatre> Theatres()
        {
            return _database.GetCollection<Models.Theatre>("Theatres");
        }
    }
}
