using LeadSoft.Common.Library.Constants;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Guid Request
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTOGuidRequest
    {
        /// <summary>
        /// Guid value
        /// </summary>

        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public virtual Guid Value { get; set; }
    }
}
