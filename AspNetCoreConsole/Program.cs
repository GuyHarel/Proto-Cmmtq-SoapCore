// See https://aka.ms/new-console-template for more information
using AspNetCoreConsole;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

//var validate = new ValidateSoapMessage();
//validate.Validate();

//var test = new XmlSerializeTest();
//test.Test();

//var test = new XmlSerializeSoapTest();
//test.Test();

var test = DateTime.Now.ToString("yyyy-MM-dd");

ValidateOAuthToken.VAlidate();

Console.WriteLine("termine:" + test);


void Injection()
{
    // Injection dans program.cs:

    using IHost host = Host.CreateApplicationBuilder(args).Build();

    var logger = host.Services.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("test de logg");
}

