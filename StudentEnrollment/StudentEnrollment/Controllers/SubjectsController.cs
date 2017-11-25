using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Repositories.Subject;

namespace StudentEnrollment.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsController : Controller
    {
        public ISubject Subject;

        public SubjectsController(ISubject subject)
        {
            Subject = subject;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Subject value)
        {
            try
            {
                await Subject.AddSubject(value);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            try
            {
                return new ObjectResult(await Subject.GetSubjects());

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
