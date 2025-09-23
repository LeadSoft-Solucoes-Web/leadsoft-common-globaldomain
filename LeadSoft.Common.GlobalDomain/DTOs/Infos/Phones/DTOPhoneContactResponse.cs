using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTOPhoneContactResponse : DTOContactResponse
    {
        public DTOPhoneContactResponse()
        {

        }

        /// <summary>
        /// Discagem Direta Internacional
        /// </summary>
        [DataMember]
        public string DDI { get; set; }

        /// <summary>
        /// Discagem Direta à Distância
        /// </summary>
        [DataMember]
        public string DDD { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [DataMember]
        public string Number { get; set; }
    }
}
