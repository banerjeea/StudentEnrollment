using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Repositories.Student
{
    public interface IStudent
    {
        Task AddStudent(Models.Student stu);

    }
}
