using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentEnrollment.Repositories.DB;

namespace StudentEnrollment.Repositories.Theatre
{
    public class Theatre : ITheatre
    {
        private readonly IDbContext _dbContext;

        public Theatre(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTheatre(Models.Theatre thea)
        {
            await _dbContext.Theatres().InsertOneAsync(thea);
        }

        public async Task<IEnumerable<Models.Theatre>> GetTheatres()
        {
            var list = new List<Models.Theatre>();
            using (var cursor = await _dbContext.Theatres().FindAsync(Builders<Models.Theatre>.Filter.Empty))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        list.Add(document);
                    }
                }
            }
            return list;

        }
    }
}
