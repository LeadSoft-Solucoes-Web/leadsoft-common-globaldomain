using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO string response
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class DTOStringResponse : DTOResponse
    {
        /// <summary>
        /// String value
        /// </summary>
        [DataMember]
        public virtual string Value { get; set; }
    }
}
