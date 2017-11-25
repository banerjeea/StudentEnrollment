using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Repositories.Theatre;

namespace StudentEnrollment.Controllers
{
    [Produces("application/json")]
    [Route("api/Theatres")]
    public class TheatresController : Controller
    {
        public ITheatre Theatre;

        public TheatresController(ITheatre theatre)
        {
            Theatre = theatre;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Theatre value)
        {
            try
            {
                await Theatre.AddTheatre(value);
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
                return new ObjectResult(await Theatre.GetTheatres());

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}