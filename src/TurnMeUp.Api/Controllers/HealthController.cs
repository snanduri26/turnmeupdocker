using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurnMeUp.Api.Models;

namespace TurnMeUp.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult GetHealth()
        {
            var healthCheck = new HealthCheckResponse { status = "Healthy", timestamp = DateTime.Now };
            return Ok(healthCheck);
        }

        [HttpGet("v1/info")]
        public IActionResult GetServiceInfo()
        {
            var serviceInfo = new ServiceInfo
            {
                service = "Turn Me Up v2-new",
                environment = "Development",
                version = "v2 - new",
                runtime = ".NET 9.0",
                region = "Local Docker"
            };

            return Ok(serviceInfo);
        }

        


    }
}
