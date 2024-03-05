using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;

namespace AspNetCoreConsole
{
    public class ValidateXml
    {

        void Valider()
        {
            try
            {
                // Chemin vers le fichier XSD
                string xsdPath = "example.xsd";

                // Chemin vers le fichier XML à valider
                string xmlPath = "example.xml";

                // Charger le schéma XSD
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add("", xsdPath);

                // Créer les paramètres de validation
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaSet;
                settings.ValidationEventHandler += ValidationCallback;

                // Créer un lecteur XML pour le fichier XML à valider
                using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                {
                    // Lire le document XML, cela déclenchera la validation par rapport au schéma XSD
                    while (reader.Read()) { }
                }

                Console.WriteLine("Validation réussie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de validation : {ex.Message}");
            }
        }

        // Fonction de rappel pour la gestion des erreurs de validation
        private static void ValidationCallback(object sender, ValidationEventArgs e)
        {
            Console.WriteLine($"Erreur de validation : {e.Message}");
        }
    }
}
