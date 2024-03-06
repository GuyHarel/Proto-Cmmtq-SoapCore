using AspNetCoreSoapAuthBasicService.SoapServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
        //[Authorize]
        public ActionResult Get()
        {

            System.IO.File.WriteAllText("test.txt", "ceci est un test");

            Console.WriteLine("ceci est un test de console");


            _logger.LogInformation("ceci est un test de LogInformation");
            _logger.LogError("ceci est un test de LogError");

            var hostName = _configuration.GetSection("Service:HostName").Value;

            hostName += "/BasicAuthDemoSoapService.asmx";
            var soapUser = Environment.GetEnvironmentVariable("SoapUser");
            var soapPassword = Environment.GetEnvironmentVariable("SoapPassword");

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
                        <li>Version SoapUser: {soapUser} </li>
                        <li>Version SoapPassword: {soapPassword} </li>
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

        [HttpPost]
        [Route("/BasicAuthDemoSoapService.asmx")]
        //[Authorize]
        public ActionResult PostSoap()
        {
            return RedirectPermanent("https://localhost:7248/BasicAuthDemoSoapService.asmx");

        }
    }
}
