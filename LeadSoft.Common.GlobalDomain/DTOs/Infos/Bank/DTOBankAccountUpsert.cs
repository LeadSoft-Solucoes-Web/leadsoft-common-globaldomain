using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Bank
{
    /// <summary>
    /// DTO Bank Account Update
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOBankAccountUpsert
    {

        /// <summary>
        /// Code
        /// </summary>
        [DataMember]

        public string Code { get; set; }

        /// <summary>
        /// Legal Name
        /// </summary>
        [DataMember]

        public string LegalName { get; set; }

        /// <summary>
        /// Document Number
        /// </summary>
        [DataMember]

        public string DocumentNumber { get; set; }

        /// <summary>
        /// Agency Number
        /// </summary>
        [DataMember]

        public string AgencyNumber { get; set; }

        /// <summary>
        /// Agency Vc
        /// </summary>
        [DataMember]

        public string AgencyVc { get; set; }

        /// <summary>
        /// Account Number
        /// </summary>
        [DataMember]

        public string AccountNumber { get; set; }

        /// <summary>
        /// Account Vc
        /// </summary>
        [DataMember]

        public string AccountVc { get; set; }

        /// <summary>
        /// Pix Key
        /// </summary>
        [DataMember]

        public string Pix { get; set; }
    }
}
