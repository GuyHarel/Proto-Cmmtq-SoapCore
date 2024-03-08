using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.Extensions.Logging.AzureAppServices;

namespace AspNetCoreSoapAuthBasicService.Azure
{
    public static class AzureLoggingExtentions
    {
        public static void ConfigAzureTextLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.AddAzureWebAppDiagnostics();
            builder.Services.Configure<AzureFileLoggerOptions>(options =>
            {
                options.FileName = "logs-";
                options.FileSizeLimit = 50 * 1024;
                options.RetainedFileCountLimit = 5;
            });
        }
    }

    /*
    <PackageReference Include="Microsoft.Extensions.Logging.ApplicationInsights" Version="2.22.0" />
    <PackageReference Include="Microsoft.Extensions.Logging.AzureAppServices" Version="8.0.2" />

    */

//    public static class AzureLogging
//    {
//        public static void ConfigTextLog(WebApplicationBuilder builder)
//        {
//            builder.Logging.AddAzureWebAppDiagnostics();
//            builder.Services.Configure<AzureFileLoggerOptions>(options =>
//            {
//                options.FileName = "logs-";
//                options.FileSizeLimit = 50 * 1024;
//                options.RetainedFileCountLimit = 5;
//            });

//        }

//        public static void ConfigBlobLog(WebApplicationBuilder builder)
//        {
//            builder.Logging.AddAzureWebAppDiagnostics();
//            // Logging vers blob
//            builder.Services.Configure<AzureBlobLoggerOptions>(options =>
//            {
//                options.BlobName = "journal.txt";
//            });
//        }

//        public static void ConfigInsightLog(WebApplicationBuilder builder)
//        {
//            ConfigTextLog(builder);

//            var loggingConnection = builder.Configuration.GetConnectionString("ApplicationInsights");

//            builder.Logging.AddApplicationInsights(
//                configureTelemetryConfiguration: (config) =>
//                    config.ConnectionString = loggingConnection,
//                    configureApplicationInsightsLoggerOptions: (options) => { }
//                );

//            builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);
//        }
//    }
}
