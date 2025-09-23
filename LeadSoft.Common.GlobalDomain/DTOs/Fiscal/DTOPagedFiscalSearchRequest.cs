using System;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Fiscal
{
    /// <summary>
    /// Paged Fiscal info Search request DTO.
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTOPagedFiscalSearchRequest : DTOPagedSearchRequest
    {
        /// <summary>
        /// Order by key instead of description
        /// </summary>
        [DataMember]
        public virtual bool OrderByKey { get; set; } = false;
    }
}
