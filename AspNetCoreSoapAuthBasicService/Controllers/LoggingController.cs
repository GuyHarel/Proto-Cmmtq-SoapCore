using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> _logger;
        //private readonly ILoggingManager _loggerManager;
        private readonly IConfiguration _configuration;

        public LoggingController( ILogger<LoggingController> logger,  /* ILoggingManager loggerManager,*/ IConfiguration configuration)
        {
            //_loggerManager = loggerManager;
            _configuration = configuration;
            _logger = logger;

        }

        [HttpGet]
        [Route("/Log")]
        public ActionResult Get()
        {
            //_loggerManager.LogInformation("/Log information");
            //_loggerManager.LogError("/Log error");

            _logger.LogInformation("/Log information");
            _logger.LogError("/Log error");
            _logger.LogWarning("/Log warning");

            return new JsonResult(new { result = "ok" }) { ContentType = "application/json" };
        }
    }
}
