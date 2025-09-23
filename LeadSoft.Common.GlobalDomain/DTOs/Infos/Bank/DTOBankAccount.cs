using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Bank
{

    [Serializable]
    [DataContract]
    public partial class DTOBankAccount
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]

        public string LegalName { get; set; }

        [DataMember]

        public string DocumentNumber { get; set; }

        [DataMember]

        public string AgencyNumber { get; set; }

        [DataMember]

        public string AgencyVc { get; set; }
        [DataMember]


        public string AccountNumber { get; set; }

        [DataMember]

        public string AccountVc { get; set; }

        [DataMember]

        public string Pix { get; set; }

        public DTOBankAccount()
        {

        }
    }
}
