using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreConsole
{
    [DataContract]
    public class DemoSoapRequest
    {
        [DataMember]
        public string? ChaineIntegRetourDEG { get; set; }

        [DataMember]
        public EnumCodRaisonAppel? CodRaisonAppel { get; set; }

        [DataMember]
        public DateTime? DateDebutChargeRole { get; set; }

        [DataMember]
        public short? NoSecteurActivite { get; set; }

    }

    public enum EnumCodRaisonAppel
    {
        [EnumMember]
        InitierEtape,

        [EnumMember]
        ExecuterEtape,

        [EnumMember]
        SignalerErreur,

        [EnumMember]
        SignalerAnnulation
    }
}
