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
        public ActionResult Get(string? p1)
        {
            //_loggerManager.LogInformation("/Log information");
            //_loggerManager.LogError("/Log error");

            _logger.LogInformation("/Log information:"+p1);
            _logger.LogError("/Log error:" + p1);
            _logger.LogWarning("/Log warning:" + p1);

            return new JsonResult(new { result = "ok", p1 = p1 }) { ContentType = "application/json" };
        }
    }
}
