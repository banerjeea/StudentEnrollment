using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Repositories.Enrollment;

namespace StudentEnrollment.Controllers
{
    [Produces("application/json")]
    [Route("api/Enrollments")]
    public class EnrollmentsController : Controller
    {
        public IEnrollment Enroll;

        public EnrollmentsController(IEnrollment enroll)
        {
            Enroll = enroll;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Enrollment value)
        {
            try
            {
                var result = await Enroll.UpdateEnrollment(value);
                if (!result.subject)
                    return BadRequest("Subject doesn't exist");
                if (!result.updated)
                    return BadRequest("Student doesn't exist");
                if (result.reachedTheatreCap)
                    return BadRequest("Lecture Theatre is full");

                return Ok("Successfully Enrolled");

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
                return new ObjectResult(await Enroll.GetEnrollments());

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}