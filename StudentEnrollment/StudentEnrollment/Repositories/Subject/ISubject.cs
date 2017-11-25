using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Repositories.Subject
{
    public interface ISubject
    {
        Task AddSubject(Models.Subject sub);
        Task<IEnumerable<Models.Subject>> GetSubjects();
        Task<(int Count, bool updated)> UpdateSubject(Models.Subject sub);
    }
}
