using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentEnrollment.Controllers
{
    [Produces("application/json")]
    [Route("api/HealthCheck")]
    public class HealthCheckController : Controller
    {
        public HttpStatusCode Get()
        {
            return new HttpResponseMessage().StatusCode;
        }
    }
}