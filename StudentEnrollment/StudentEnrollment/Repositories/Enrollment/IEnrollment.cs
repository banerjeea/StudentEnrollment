using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Repositories.Enrollment
{
    public interface IEnrollment
    {
        Task<(bool subject, bool updated, bool reachedTheatreCap)> UpdateEnrollment(Models.Enrollment enroll);
        Task<IEnumerable<Models.Student>> GetEnrollments();
    }
}
