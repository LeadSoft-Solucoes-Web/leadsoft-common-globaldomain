using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Page Search request DTO.
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTOPagedSearchRequest : DTOPagedRequest
    {
        /// <summary>
        /// Search Text
        /// </summary>
        [DataMember]
        public virtual string SearchText { get; set; } = string.Empty;
    }
}
