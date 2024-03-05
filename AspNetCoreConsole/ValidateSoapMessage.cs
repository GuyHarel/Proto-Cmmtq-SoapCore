using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AspNetCoreConsole
{
    public class ValidateSoapMessage
    {
        private string[] _xsdFilePaths = new string[]
            {
                "C:\\GH-ORDI\\GH-DEV\\LGS\\AspNetCoreSoapAuthBasicService\\AspNetCoreSoapAuthBasicService\\RecevoirSIPGIntrant.xsd",
                 "C:\\GH-ORDI\\GH-DEV\\LGS\\AspNetCoreSoapAuthBasicService\\AspNetCoreSoapAuthBasicService\\Serialisation.xsd"

            };

        public ValidateSoapMessage()
        { 
        
        }

        public string Test()
        {
            return "abcd";
        }

        public void Validate()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            foreach (var xsdFilePath in _xsdFilePaths)
            {
                using (FileStream fs = new FileStream(xsdFilePath, FileMode.Open))
                {
                    XmlSchema schema = XmlSchema.Read(fs, null);
                    schemas.Add(schema);
                }
            }

            schemas.XmlResolver = new XmlUrlResolver();

            XDocument xmlDoc;
            // Charger la requête SOAP dans un XmlDocument
                string xmlContent = @"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:asp=""http://AspNetCoreSoapAuthBasicService.net"" xmlns:asp1=""http://schemas.datacontract.org/2004/07/AspNetCoreSoapAuthBasicService.SoapServices"">
   <soapenv:Header/>
   <soapenv:Body>
      <asp:ObtenirDemoSoapReponse>
         <asp:request>
            <!--Optional:-->
            <asp1:ChaineIntegRetourDEG>?</asp1:ChaineIntegRetourDEG>
            <asp1:CodRaisonAppel>ExecuterEtape</asp1:CodRaisonAppel>
            <!--Optional:-->
            <asp1:DateDebutChargeRole>2024-03-02</asp1:DateDebutChargeRole>
            <!--Optional:-->
            <asp1:NoSecteurActivite222>abcd</asp1:NoSecteurActivite222>
         </asp:request>
      </asp:ObtenirDemoSoapReponse>
   </soapenv:Body>
</soapenv:Envelope>

";

                xmlDoc = XDocument.Parse(xmlContent);

                // Traitez le XDocument selon vos besoins

            // Valider le document XML par rapport aux schémas XSD
            bool isValid = true;

            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationCallback);

            xmlDoc.Validate(schemas, eventHandler);
            //xmlDoc.Validate(schemas, (sender, e) => isValid = false);
        }

        private static void ValidationCallback(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error || e.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine($"Erreur de validation : {e.Message}");
                //isValid = false;
            }
        }

    }
}
