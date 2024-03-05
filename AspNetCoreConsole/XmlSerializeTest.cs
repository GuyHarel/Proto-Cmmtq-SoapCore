using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AspNetCoreConsole
{
    public class XmlSerializeTest
    {
        public void Test()
        {
            var chemin = "C:\\GH-ORDI\\GH-DEV\\LGS\\DemoSoapRequest.xml";
            //var requete = new DemoSoapRequest
            //{
            //    ChaineIntegRetourDEG = "chaine",
            //    CodRaisonAppel = EnumCodRaisonAppel.SignalerErreur,
            //    DateDebutChargeRole = DateTime.Now,
            //    NoSecteurActivite = 10

            //};

            //SerializeToXml(requete, chemin);

            var test = DeserializeFromSoap<DemoSoapRequest>(chemin);
        }

        public void SerializeToXml(object obj, string xmlFilePath)
        {
            // Créer une instance de XmlSerializer pour le type de classe à sérialiser
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            // Ouvrir un flux de sortie vers le fichier XML
            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Create))
            {
                // Appeler la méthode Serialize pour sérialiser les données dans le fichier XML
                serializer.Serialize(fileStream, obj);
            }
        }

        public T DeserializeFromSoap<T>(string xmlFilePath)
        {
            // Créer une instance de XmlSerializer pour le type de classe à désérialiser
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // Ouvrir un flux d'entrée vers le fichier XML contenant le message SOAP
            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                // Appeler la méthode Deserialize pour désérialiser les données du fichier XML en objet
                return (T)serializer.Deserialize(fileStream);
            }
        }
    }
}
