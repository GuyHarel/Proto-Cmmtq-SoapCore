using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSoapAuthBasicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILoggingManager _logger;
        private readonly IConfiguration _configuration;

        public LoggingController(ILoggingManager logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }

        [HttpGet]
        [Route("/Log")]
        public ActionResult Get()
        {
            var Test_var1 = _configuration.GetSection("Test:Var1").Value;
            var chaineHeure = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            _logger.LogInformation("/Log information");
            _logger.LogError("/Log error");

            return new JsonResult(new { result = "ok", Test_var1 = Test_var1 }) { ContentType = "application/json" };
        }
    }
}
