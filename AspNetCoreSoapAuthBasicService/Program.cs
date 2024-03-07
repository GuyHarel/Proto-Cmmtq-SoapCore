using AspNetCoreSoapAuthBasicService.Middlewares;
using AspNetCoreSoapAuthBasicService.SoapServices;
using Microsoft.AspNetCore.Authentication;
using SoapCore;
using SoapCore.Extensibility;
using AspNetCoreSoapAuthBasicService.Handlers;
using AspNetCoreSoapAuthBasicService.Transformers;
using Microsoft.Extensions.Logging.ApplicationInsights;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers(); // MVC, routage, controleur, modèle, injection
builder.Services.AddSoapCore();

// Ajouter l'authentication basic (pour les route de controler avec  [Authorize]
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddSingleton<IFaultExceptionTransformer, SoapCoreFaultExceptionTransformer>();
builder.Services.AddSingleton<IBasicAuthDemoSoapService, BasicAuthDemoSoapService>();

// Logging
builder.Logging.AddApplicationInsights(
    configureTelemetryConfiguration: (config) => 
        config.ConnectionString = builder.Configuration.GetConnectionString("InstrumentationKey=79da0935-963c-48a0-bc28-71557cae03dd;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/"),
        configureApplicationInsightsLoggerOptions: (options) => { }
    );

builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Trace);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection(); // Renvoi automatique des HTTP vers HTTPS

// Inutile (mais recommendé)
app.UseAuthentication();  // Active le middle ware d'authentication
app.UseAuthorization();  // Active le middleware d'autorisation

app.MapControllers();  // configure pipeline routage, map des endpoints, routes

app.UseMiddleware<AspNetCoreSoapAuthBasicService.Middlewares.SoapRequestMiddleware>();

app.UseSoapEndpoint<IBasicAuthDemoSoapService>("/BasicAuthDemoSoapService.asmx", new SoapEncoderOptions());


app.Run();


