using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace SerilogExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;
        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("static")]
        public IActionResult GetStaticClass()
        { 
            Log.Information("statik class merhaba Sedat Bozdoğan");
            return Ok();
        }

        [HttpGet("ioc")]
        public IActionResult GetIOCLogger()
        { 
            _logger.LogInformation("microsoft ilogger sınıfı içeriği.merhaba Sedat Bozdoğan");
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Merhaba Sedat Bozdoğan");

            string fullName = "Sedat Bozdoğan";
            _logger.LogWarning("Merhaba {fullName}", fullName);

            User user = new User()
            {
                Name = "Sedat",
                Surname = "Bozdoğan"
            };
            _logger.LogError("Merhaba {@user}",user);

            return Ok(user);
        }

    }
}
