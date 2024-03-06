using AspNetCoreSoapAuthBasicService;
using AspNetCoreSoapAuthBasicService.Middlewares;
using AspNetCoreSoapAuthBasicService.SoapServices;
using Microsoft.AspNetCore.Authentication;
using SoapCore;
using SoapCore.Extensibility;
using System.ServiceModel.Channels;
using System.ServiceModel;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSoapCore();

builder.Services.AddSingleton<IFaultExceptionTransformer, SoapCoreFaultExceptionTransformer>();
builder.Services.AddSingleton<IBasicAuthDemoSoapService, BasicAuthDemoSoapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseMiddleware<AuthenticationBasicMiddleware>();

app.UseSoapEndpoint<IBasicAuthDemoSoapService>("/BasicAuthDemoSoapService.asmx", new SoapEncoderOptions());


app.Run();
