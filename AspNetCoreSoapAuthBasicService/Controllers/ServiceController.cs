using AspNetCoreSoapAuthBasicService.SoapServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSoapAuthBasicService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IConfiguration _configuration;

        public ServiceController(
            ILogger<ServiceController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/Service")]
        public ActionResult Get()
        {
            var hostName = _configuration.GetSection("Service:HostName").Value;

            hostName += "/BasicAuthDemoSoapService.asmx";

            string htmlContent = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>AspNetCoreSoapAuthBasicService</title>
                </head>
                <body>
                    <ul>
                        <li><a href={hostName}>{hostName}</a></li>
                        <li>Version GitHub 2024-03-05 09:15</li>
                    </ul>
                </body>
                </html>";

            return new ContentResult() { Content = htmlContent, ContentType= "text/html" };
        }

        [HttpPost]
        [Route("/Service/Asmx")]
        //[Authorize]
        public ActionResult GetAsmx()
        {
            return RedirectPermanent("https://localhost:7248/BasicAuthDemoSoapService.asmx");

        }

        [HttpPost]
        [Route("/Service/Authbasic")]
        [Authorize]
        public ActionResult GetAuthbasic()
        {
            string htmlContent = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>AspNetCoreSoapAuthBasicService</title>
                </head>
                <body>
                   <p>public ActionResult GetAuthbasic()</p>
                </body>
                </html>";

            return new ContentResult() { Content = htmlContent, ContentType = "text/html" };

        }
    }
}
