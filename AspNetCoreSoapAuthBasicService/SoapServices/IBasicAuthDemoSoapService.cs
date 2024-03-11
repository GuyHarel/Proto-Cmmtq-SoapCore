using System.ServiceModel;

namespace TestProject.SoapServices
{
    [ServiceContract(Namespace = "http://AspNetCoreSoapAuthBasicService.net")]
    public interface IBasicAuthDemoSoapService
    {
        [OperationContract(Name = "ObtenirDemoSoapReponse")]
        DemoSoapReponse ObtenirDemoSoapReponse(DemoSoapRequest request);

    }
}
