using LeadSoft.Common.Library;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Page request DTO.
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOPagedRequest : PagedRequest
    {
        /// <summary>
        /// Page to be shown
        /// (IsPaged must be true)
        /// </summary>
        /// <example>1</example>

        [DataMember]
        [DefaultValue(1)]
        [Range(1, int.MaxValue, ErrorMessage = ApplicationStatusMessage.CurrentPageMustBeAtLeastZero)]
        public override int CurrentPage { get => base.CurrentPage; set => base.CurrentPage = value; }

        /// <summary>
        /// Page size (number of results per page)
        /// (IsPaged must be true)
        /// </summary>
        /// <example>10</example>
        [DataMember]
        [DefaultValue(10)]
        [Range(1, 100, ErrorMessage = ApplicationStatusMessage.PageSizeRange)]
        public override int PageSize { get => base.PageSize; set => base.PageSize = value; }

        /// <summary>
        /// Enable or disable page list for request
        /// </summary>
        /// <example>true</example>
        [DataMember]
        [DefaultValue(true)]
        public virtual bool IsPaged { get; set; } = true;
    }
}
