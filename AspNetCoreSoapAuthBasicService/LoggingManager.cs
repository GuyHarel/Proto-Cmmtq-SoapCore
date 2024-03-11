//using AspNetCoreSoapAuthBasicService.Controllers;
//using Microsoft.Extensions.Logging;
//using System.ServiceModel.Channels;

//namespace TestProject
//{
//    public class LoggingManager : ILoggingManager
//    {
//        private readonly ILogger<LoggingManager> _logger;
//        private readonly IConfiguration _configuration;
//        private string? LogLevels = string.Empty;

//        public LoggingManager(ILogger<LoggingManager> logger,
//            IConfiguration configuration)
//        {
//            _logger = logger;
//            _configuration = configuration;
//            LogLevels = _configuration["LoggingManagers:LogLevel"];
//        }

//        public void LogError(string message)
//        {
//            if (LogLevels is not null && !LogLevels.Contains("Error"))
//                return;

//            _logger.LogError(message);
//        }

//        public void LogInformation(string message)
//        {
//            if (LogLevels is not null && !LogLevels.Contains("Information"))
//                return;

//            _logger.LogInformation(message);
//        }
//    }
//}
