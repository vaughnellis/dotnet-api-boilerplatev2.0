using DotnetApiBoilerplatev2._0.Common;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApiBoilerplatev2._0.Controllers
{
    [ServiceFilter(typeof(CustomExceptionFilter))]
    public class ControllerBase : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult HealthCheck()
        {
            return Ok("health check ok");
        }
    }
}
