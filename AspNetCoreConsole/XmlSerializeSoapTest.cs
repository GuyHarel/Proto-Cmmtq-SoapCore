using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AspNetCoreConsole
{
    public class XmlSerializeSoapTest
    {
        public void Test()
        {
            var chemin = "C:\\GH-ORDI\\GH-DEV\\LGS\\DemoSoapRequestSoap.xml";

            Envelope envelope = DeserializeFromSoap<Envelope>(chemin);

        }

        static T DeserializeFromSoap<T>(string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                return (T)serializer.Deserialize(fileStream);
            }
        }

        //public T DeserializeFromSoap<T>(string xml)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(T));
        //    using (StringReader reader = new StringReader(xml))
        //    {
        //        return (T)serializer.Deserialize(reader);
        //    }
        //}
    }

    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        public Body Body { get; set; }
    }

    public class Body
    {
        [XmlElement(Namespace = "http://AspNetCoreSoapAuthBasicService.net")]
        public ObtenirDemoSoapReponse ObtenirDemoSoapReponse { get; set; }
    }

    public class ObtenirDemoSoapReponse
    {
        public Request request { get; set; }
    }

    public class Request
    {
        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/AspNetCoreSoapAuthBasicService.SoapServices")]
        public string ChaineIntegRetourDEG { get; set; }

        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/AspNetCoreSoapAuthBasicService.SoapServices")]
        public string CodRaisonAppel { get; set; }

        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/AspNetCoreSoapAuthBasicService.SoapServices")]
        public DateTime? DateDebutChargeRole { get; set; }

        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/AspNetCoreSoapAuthBasicService.SoapServices")]
        public short? NoSecteurActivite { get; set; }
    }
}
