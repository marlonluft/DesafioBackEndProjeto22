using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpenWeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperaturaController : ControllerBase
    {
        private readonly ILogger<TemperaturaController> _logger;

        public TemperaturaController(ILogger<TemperaturaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
