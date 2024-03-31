//using SoapCore;
//using System.Runtime.Serialization;
//using System.Xml.Serialization;

//namespace AspNetCoreSoapAuthBasicService.SoapServices.RecupererFichierDTO
//{
//    [DataContract(Name = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
//    public class RecupererFichierSoap
//    {
//        [DataMember(Name = "Header", Order = 0)]
//        public RecupererFichierSoapHeader Header { get; set; }

//        [DataMember(Name = "Body", Order = 1)]
//        public RecupererFichierSoapBody Body { get; set; }

//        public RecupererFichierSoap()
//        {
//            Header = new RecupererFichierSoapHeader();
//            Body = new RecupererFichierSoapBody();
//        }
//    }

//    [DataContract(Name = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
//    public class RecupererFichierSoapHeader
//    {
//        [DataMember(Name = "Security", Order = 0)]
//        public WsseSecurity Security { get; set; }

//        //[DataMember(Name = "wsa:To", Order = 1)]
//        [XmlAttribute("wsa:To", Namespace = "http://www.w3.org/2005/08/addressing")]
//        public string To { get; set; }

//        //[DataMember(Name = "wsa:Action", Order = 2, Namespace = "http://www.w3.org/2005/08/addressing")]
//        public string Action { get; set; }

//        //[DataMember(Name = "wsa:MessageID", Order = 3, Namespace = "http://www.w3.org/2005/08/addressing")]
//        public string MessageID { get; set; }

//        public RecupererFichierSoapHeader()
//        {
//            Security = new WsseSecurity();
//            To = "https://localhost/WcfServiceNet472AuthBasic/RecupererFichierService.svc/endpointWcfServiceNet472AuthBasic";
//            Action = "http://tempuri.org/IRecupererFichier/TelechargerFichier";
//            MessageID = "uuid:" + Guid.NewGuid().ToString();
//        }
//    }

//    [DataContract(Name = "Security", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
//    public class WsseSecurity
//    {
//        [DataMember(Name = "UsernameToken", Order = 0)]
//        public UsernameToken UsernameToken { get; set; }

//        public WsseSecurity()
//        {
//            UsernameToken = new UsernameToken();
//        }
//    }

//    [DataContract(Name = "UsernameToken", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
//    public class UsernameToken
//    {
//        [DataMember(Name = "Username", Order = 0)]
//        public string Username { get; set; }

//        [DataMember(Name = "Password", Order = 1)]
//        public string Password { get; set; }

//        [DataMember(Name = "Nonce", Order = 2)]
//        public string Nonce { get; set; }

//        [DataMember(Name = "Created", Order = 3)]
//        public DateTime Created { get; set; }

//        public UsernameToken()
//        {
//            Username = "util01";
//            Password = "mdp01";
//            Nonce = "z510JUE49SLh1B117zMxIA==";
//            Created = DateTime.UtcNow;
//        }

//    }

//    [DataContract(Name = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
//    public class RecupererFichierSoapBody
//    {
//        //[DataMember(Name = "TelechargerFichier", Order = 0, Namespace = "http://tempuri.org/")]
//        public Intrant TelechargerFichier { get; set; }

//        public RecupererFichierSoapBody()
//        {
//            TelechargerFichier = new Intrant();
//        }

//    }

//    [DataContract(Name = "intrant", Namespace = "http://tempuri.org/")]
//    public class Intrant
//    {
//        [DataMember(Name = "CodCategorie", Order = 0)]
//        public string CodCategorie { get; set; }

//        [DataMember(Name = "CodEtape", Order = 1)]
//        public string CodEtape { get; set; }

//        [DataMember(Name = "IdPartenaire", Order = 2)]
//        public Guid IdPartenaire { get; set; }

//        [DataMember(Name = "NoRSI", Order = 3)]
//        public Guid NoRSI { get; set; }

//        [DataMember(Name = "NomFichier", Order = 4)]
//        public string NomFichier { get; set; }

//        public Intrant()
//        {
//            CodCategorie = "";
//            CodEtape = "";
//            IdPartenaire = Guid.NewGuid();
//            NoRSI = Guid.NewGuid();
//            NomFichier = "";
//        }
//    }
//}
