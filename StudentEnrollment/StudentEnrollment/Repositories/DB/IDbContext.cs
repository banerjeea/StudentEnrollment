using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace StudentEnrollment.Repositories.DB
{
    public interface IDbContext
    {
        IMongoCollection<Models.Subject> Subjects();
    }
}
