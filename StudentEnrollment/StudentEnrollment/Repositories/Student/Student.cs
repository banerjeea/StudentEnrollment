using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentEnrollment.Repositories.DB;

namespace StudentEnrollment.Repositories.Student
{
    public class Student : IStudent
    {
        private readonly IDbContext _dbContext;

        public Student(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddStudent(Models.Student stu)
        {
            if (stu.Enrollments == null)
            {
                stu.Enrollments = new List<string>();
            }
            await _dbContext.Students().InsertOneAsync(stu);
        }

        public async Task<IEnumerable<Models.Subject>> GetStudents()
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
    }
}
