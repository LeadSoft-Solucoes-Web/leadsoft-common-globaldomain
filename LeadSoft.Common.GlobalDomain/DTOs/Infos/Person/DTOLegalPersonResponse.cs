using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Person
{
    /// <summary>
    /// DTOLegalPerson
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTOLegalPersonResponse : DTOResponse
    {
        public DTOLegalPersonResponse()
        {

        }

        /// <summary>
        /// Company Name
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// Business Name
        /// </summary>
        [DataMember]
        public string BusinessName { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        [DataMember]
        public Uri Website { get; set; }

    }
}
