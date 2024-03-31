using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using static SoapCore.DocumentationWriter.SoapDefinition;

namespace AspNetCoreSoapAuthBasicService.Services
{
    public class WcfClientService : IWcfClientService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public WcfClientService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

        }

        public void RecupererFichier2()
        {
            try
            {

                string username = "util01";
                string password = "mdp01";

                var env = new RecupererFichierSoapEnveloppe(username, password);

                using (var client = httpClientFactory.CreateClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost/WcfServiceNet472AuthBasic/RecupererFichierService.svc/endpointWcfServiceNet472AuthBasic");

                    request.Headers.Add("Connection", "Keep-Alive");
                    request.Headers.Add("Accept-Encoding", "gzip,deflate");
                    request.Headers.Add("Host", "localhost");
                    request.Headers.Add("User-Agent", "Apache-HttpClient/4.5.5 (Java/16.0.1)");

                    var content = new StringContent(env.SoapString, System.Text.Encoding.UTF8, "application/soap+xml");
                    request.Content = content;
                    content.Headers.Add("action", "http://tempuri.org/IRecupererFichier/TelechargerFichier");

                    var reponse = client.Send(request);

                    var reponseContenu = reponse.Content.ReadAsStringAsync().Result;

                    var test = 123;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void RecupererFichier1()
        {
            try
            {
                using (var client = httpClientFactory.CreateClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost/WcfServiceNet472AuthBasic/RecupererFichierService.svc/endpointWcfServiceNet472AuthBasic");

                    request.Headers.Add("Connection", "Keep-Alive");
                    request.Headers.Add("Accept-Encoding", "gzip,deflate");
                    request.Headers.Add("Host", "localhost");
                    request.Headers.Add("User-Agent", "Apache-HttpClient/4.5.5 (Java/16.0.1)");

                    var content = new StringContent(Requests.RecupererFichier, System.Text.Encoding.UTF8, "application/soap+xml");
                    request.Content = content;
                    content.Headers.Add("action", "http://tempuri.org/IRecupererFichier/TelechargerFichier");

                    var reponse = client.Send(request);

                    var reponseContenu = reponse.Content.ReadAsStringAsync().Result;

                    var test = 123;
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }
    }

    public class RecupererFichierSoapEnveloppe
    {
		public string SoapString { get; set; }
        public RecupererFichierSoapEnveloppe(string username, string password)
        {

            // config
            string encodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            string serverNamespace = "WcfServiceNet472AuthBasic.RecupererFichier";
            string action = "IRecupererFichier/TelechargerFichier";
            string messageID = "41d3780f-0f36-4090-b9f3-3196ef5f586f";
            string url = "https://localhost/WcfServiceNet472AuthBasic/RecupererFichierService.svc/endpointWcfServiceNet472AuthBasic";

            // Extrant
            string codCategorie = "cat01";
            string nomFichier = "nom01";
            string codEtape = "etap01";
            string noRSI = "d15d3a52-9a7e-4bf0-bb26-2d8e7e15a879";
            string idPartenaire = "d15d3a52-9a7e-4bf0-bb26-2d8e7e15a879";

            SoapString = @$"
<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:tem=""http://tempuri.org/""
	xmlns:wcf=""http://schemas.datacontract.org/2004/07/{serverNamespace}"">
	<soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing""
		xmlns:wsrm=""http://docs.oasis-open.org/ws-rx/wsrm/200702"">
		<wsse:Security soap:mustUnderstand=""true""
			xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd""
			xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
			<wsse:UsernameToken wsu:Id=""UsernameToken-8E7F5D71FB52819FAE17117434355581"">
				<wsse:Username>{username}</wsse:Username>
				<wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{password}</wsse:Password>
				<wsse:Nonce
					EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">{encodedPassword}</wsse:Nonce>
				<wsu:Created>2024-03-29T20:17:15.557Z</wsu:Created>
			</wsse:UsernameToken>
		</wsse:Security>
		<wsrm:Sequence>
			<wsrm:Identifier>s:Sender

				a:InvalidSecurity</wsrm:Identifier>
			<wsrm:MessageNumber>1</wsrm:MessageNumber>
		</wsrm:Sequence>
		<wsa:Action soap:mustUnderstand=""1"">http://tempuri.org/{action}</wsa:Action>
		<wsa:MessageID soap:mustUnderstand=""1"">uuid:{messageID}</wsa:MessageID>
		<wsa:To soap:mustUnderstand=""1"">{url}</wsa:To>
	</soap:Header>
	<soap:Body>
		<tem:TelechargerFichier>
			<!--Optional:-->
			<tem:intrant>
				<!--Optional:-->
				<wcf:CodCategorie>{codCategorie}</wcf:CodCategorie>
				<!--Optional:-->
				<wcf:CodEtape>{codEtape}</wcf:CodEtape>
				<!--Optional:-->
				<wcf:IdPartenaire>{idPartenaire}</wcf:IdPartenaire>
				<!--Optional:-->
				<wcf:NoRSI>{noRSI}</wcf:NoRSI>
				<!--Optional:-->
				<wcf:NomFichier>{nomFichier}</wcf:NomFichier>
			</tem:intrant>
		</tem:TelechargerFichier>
	</soap:Body>
</soap:Envelope>
            ";
        }
    }



}

public static class Requests
{
    public static string RecupererFichier = @"
<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:tem=""http://tempuri.org/""
	xmlns:wcf=""http://schemas.datacontract.org/2004/07/WcfServiceNet472AuthBasic.RecupererFichier"">
	<soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing""
		xmlns:wsrm=""http://docs.oasis-open.org/ws-rx/wsrm/200702"">
		<wsse:Security soap:mustUnderstand=""true""
			xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd""
			xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
			<wsse:UsernameToken wsu:Id=""UsernameToken-8E7F5D71FB52819FAE17117434355581"">
				<wsse:Username>util01</wsse:Username>
				<wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">mdp01</wsse:Password>
				<wsse:Nonce
					EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">
					z510JUE49SLh1B117zMxIA==</wsse:Nonce>
				<wsu:Created>2024-03-29T20:17:15.557Z</wsu:Created>
			</wsse:UsernameToken>
		</wsse:Security>
		<wsrm:Sequence>
			<wsrm:Identifier>s:Sender

				a:InvalidSecurity</wsrm:Identifier>
			<wsrm:MessageNumber>1</wsrm:MessageNumber>
		</wsrm:Sequence>
		<wsa:Action soap:mustUnderstand=""1"">http://tempuri.org/IRecupererFichier/TelechargerFichier</wsa:Action>
		<wsa:MessageID soap:mustUnderstand=""1"">uuid:41d3780f-0f36-4090-b9f3-3196ef5f586f</wsa:MessageID>
		<wsa:To soap:mustUnderstand=""1"">
			https://localhost/WcfServiceNet472AuthBasic/RecupererFichierService.svc/endpointWcfServiceNet472AuthBasic</wsa:To>
	</soap:Header>
	<soap:Body>
		<tem:TelechargerFichier>
			<!--Optional:-->
			<tem:intrant>
				<!--Optional:-->
				<wcf:CodCategorie>?</wcf:CodCategorie>
				<!--Optional:-->
				<wcf:CodEtape>?</wcf:CodEtape>
				<!--Optional:-->
				<wcf:IdPartenaire>d15d3a52-9a7e-4bf0-bb26-2d8e7e15a879</wcf:IdPartenaire>
				<!--Optional:-->
				<wcf:NoRSI>d15d3a52-9a7e-4bf0-bb26-2d8e7e15a879</wcf:NoRSI>
				<!--Optional:-->
				<wcf:NomFichier>?</wcf:NomFichier>
			</tem:intrant>
		</tem:TelechargerFichier>
	</soap:Body>
</soap:Envelope>
";

}

/*
 

POST https://localhost/WcfServiceNet472AuthBasic/RecupererFichierService.svc/endpointWcfServiceNet472AuthBasic HTTP/1.1
Accept-Encoding: gzip,deflate
Content-Type: application/soap+xml;charset=UTF-8;action="http://tempuri.org/IRecupererFichier/TelechargerFichier"
Content-Length: 2200
Host: localhost
Connection: Keep-Alive
User-Agent: Apache-HttpClient/4.5.5 (Java/16.0.1)

<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope" xmlns:tem="http://tempuri.org/" xmlns:wcf="http://schemas.datacontract.org/2004/07/WcfServiceNet472AuthBasic.RecupererFichier">
   <soap:Header xmlns:wsa="http://www.w3.org/2005/08/addressing" xmlns:wsrm="http://docs.oasis-open.org/ws-rx/wsrm/200702"><wsse:Security soap:mustUnderstand="true" xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"><wsse:UsernameToken wsu:Id="UsernameToken-8E7F5D71FB52819FAE17117434355581"><wsse:Username>util01</wsse:Username><wsse:Password Type="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText">mdp01</wsse:Password><wsse:Nonce EncodingType="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary">z510JUE49SLh1B117zMxIA==</wsse:Nonce><wsu:Created>2024-03-29T20:17:15.557Z</wsu:Created></wsse:UsernameToken></wsse:Security><wsrm:Sequence><wsrm:Identifier>s:Sender
            
               a:InvalidSecurity</wsrm:Identifier><wsrm:MessageNumber>1</wsrm:MessageNumber></wsrm:Sequence><wsa:Action soap:mustUnderstand="1">http://tempuri.org/IRecupererFichier/TelechargerFichier</wsa:Action><wsa:MessageID soap:mustUnderstand="1">uuid:41d3780f-0f36-4090-b9f3-3196ef5f586f</wsa:MessageID><wsa:To soap:mustUnderstand="1">https://localhost/WcfServiceNet472AuthBasic/RecupererFichierService.svc/endpointWcfServiceNet472AuthBasic</wsa:To></soap:Header>
   <soap:Body>
      <tem:TelechargerFichier>
         <!--Optional:-->
         <tem:intrant>
            <!--Optional:-->
            <wcf:CodCategorie>?</wcf:CodCategorie>
            <!--Optional:-->
            <wcf:CodEtape>?</wcf:CodEtape>
            <!--Optional:-->
            <wcf:IdPartenaire>d15d3a52-9a7e-4bf0-bb26-2d8e7e15a879</wcf:IdPartenaire>
            <!--Optional:-->
            <wcf:NoRSI>d15d3a52-9a7e-4bf0-bb26-2d8e7e15a879</wcf:NoRSI>
            <!--Optional:-->
            <wcf:NomFichier>?</wcf:NomFichier>
         </tem:intrant>
      </tem:TelechargerFichier>
   </soap:Body>
</soap:Envelope>

 */