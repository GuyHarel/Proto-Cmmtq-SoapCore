using TestProject.Middlewares;
using TestProject.SoapServices;
using Microsoft.AspNetCore.Authentication;
using SoapCore;
using SoapCore.Extensibility;
using TestProject.Handlers;
using TestProject.Transformers;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.Extensions.Logging.AzureAppServices;
using TestProject.Azure;
using TestProject;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers(); // MVC, routage, controleur, modèle, injection
builder.Services.AddSoapCore();

// Ajouter l'authentication basic (pour les route de controler avec  [Authorize], et pour le middleware soap ci bas
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddSingleton<IFaultExceptionTransformer, SoapCoreFaultExceptionTransformer>();
builder.Services.AddSingleton<IBasicAuthDemoSoapService, BasicAuthDemoSoapService>();
//builder.Services.AddSingleton<ILoggingManager, LoggingManager>();

// Configurer le logging dans fichier text dans Azure
builder.Logging.AddAzureWebAppDiagnostics();
builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "j-";
    options.FileSizeLimit = 50 * 1024;
    options.RetainedFileCountLimit = 5;
});

//// Configurer le logging dans un blob (dépend de celui ci-haut)
//builder.Services.Configure<AzureBlobLoggerOptions>(config => {
//    config.BlobName = "testblob";
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection(); // Renvoi automatique des HTTP vers HTTPS

// Inutile (mais recommendé)
app.UseAuthentication();  // Active le middle ware d'authentication
app.UseAuthorization();  // Active le middleware d'autorisation

app.MapControllers();  // configure pipeline routage, map des endpoints, routes

app.UseMiddleware<TestProject.Middlewares.SoapRequestMiddleware>();  // Gestion des URL asmx

app.UseSoapEndpoint<IBasicAuthDemoSoapService>("/BasicAuthDemoSoapService.asmx", new SoapEncoderOptions()); // création du asmx par SoapCore


app.Run();


