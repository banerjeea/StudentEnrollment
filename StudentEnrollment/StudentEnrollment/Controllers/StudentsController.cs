using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Repositories.Student;

namespace StudentEnrollment.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        public IStudent Student;

        public StudentsController(IStudent student)
        {
            Student = student;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Student value)
        {
            try
            {
                await Student.AddStudent(value);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}