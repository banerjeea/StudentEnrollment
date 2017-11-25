using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentEnrollment.Repositories.DB;

namespace StudentEnrollment.Repositories.Enrollment
{
    public class Enrollment : IEnrollment
    {
        private readonly IDbContext _dbContext;

        public Enrollment(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<(bool subject, bool updated, bool reachedTheatreCap)> UpdateEnrollment(Models.Enrollment enroll)
        {
            //check if subject exists
            var subresult = await _dbContext.Subjects()
                .FindOneAndUpdateAsync(
                    Builders<Models.Subject>.Filter.Eq(e => e.Name, enroll.Subject),
                    Builders<Models.Subject>.Update.Push(e => e.StudentEmail, enroll.Email)
                );

            if (subresult != null)
            {
                //check if theatre exists
                var theatre = await _dbContext.Theatres().Find(x => x.Name == subresult.Lecture.Theatre)
                    .FirstOrDefaultAsync();

                if (theatre != null && theatre.Capacity > 0)
                {
                    //reduce theatre capacity
                    var theatreResult = await _dbContext.Theatres()
                        .FindOneAndUpdateAsync(
                            Builders<Models.Theatre>.Filter.Eq(e => e.Name, subresult.Lecture.Theatre),
                            Builders<Models.Theatre>.Update.Set(e => e.Capacity, theatre.Capacity - 1)
                        );

                    var result = await _dbContext.Students()
                        .FindOneAndUpdateAsync(
                            Builders<Models.Student>.Filter.Eq(e => e.Email, enroll.Email),
                            Builders<Models.Student>.Update.Push(e => e.Enrollments, enroll.Subject)
                        );

                    return result != null ? (true, true, false) : (true, false, false);
                }
                return (false, false, true);
            }
            return (false, false, false);
        }


        public async Task<IEnumerable<Models.Student>> GetEnrollments()
        {
            var list = new List<Models.Student>();
            using (var cursor = await _dbContext.Students().FindAsync(Builders<Models.Student>.Filter.Empty))
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
