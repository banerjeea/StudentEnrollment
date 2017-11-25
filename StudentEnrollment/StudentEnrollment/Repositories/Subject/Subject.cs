using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentEnrollment.Repositories.DB;

namespace StudentEnrollment.Repositories.Subject
{
    public class Subject : ISubject
    {
        private readonly IDbContext _dbContext;

        public Subject(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSubject(Models.Subject sub)
        {
            if (sub.StudentEmail == null)
            {
                sub.StudentEmail = new List<string>();
            }
            await _dbContext.Subjects().InsertOneAsync(sub);
        }

        /// <summary>
        /// Get subjects
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Subject>> GetSubjects()
        {
            var list = new List<Models.Subject>();
            using (var cursor = await _dbContext.Subjects().FindAsync(Builders<Models.Subject>.Filter.Empty))
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

        public async Task<(int Count, bool updated)> UpdateSubject(Models.Subject sub)
        {
            //check if theatre exists
            var count = await _dbContext.Theatres().Find(x => x.Name == sub.Lecture.Theatre).CountAsync();

            if (count > 0)
            {

                var result = await _dbContext.Subjects()
                    .FindOneAndUpdateAsync(
                        Builders<Models.Subject>.Filter.Eq(e => e.Name, sub.Name),
                        Builders<Models.Subject>.Update.Set(e => e.Lecture, sub.Lecture)
                    );

                return result != null ? (1, true) : (1, false);
            }

            return (0, false);
        }
    }
}
