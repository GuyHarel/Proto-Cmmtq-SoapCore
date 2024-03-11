using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace TestProject.SoapServices
{


    public class BasicAuthDemoSoapService : IBasicAuthDemoSoapService
    {
        private ILogger<BasicAuthDemoSoapService> _logger;

        public BasicAuthDemoSoapService(ILogger<BasicAuthDemoSoapService> logger)
        {
            _logger = logger;
        }
        public DemoSoapReponse ObtenirDemoSoapReponse(DemoSoapRequest request)
        {
            _logger.LogTrace("ObtenirDemoSoapReponse {request}", JsonSerializer.Serialize<DemoSoapRequest>(request));

            var resultat = new DemoSoapReponse
            { 
                CodErreur = "0",
                CodRetour = EnumCodRetour.Succes,
                MessageErreur = "Sans Erreur"
            };

            return resultat;
        }
    }
}
