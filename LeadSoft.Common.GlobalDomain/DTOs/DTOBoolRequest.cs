using LeadSoft.Common.Library.Constants;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Bool Request
    /// </summary>
    [Serializable]
    [DataContract]
    public class DTOBoolRequest
    {
        /// <summary>
        /// Boolean value
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public virtual bool Value { get; set; }
    }
}
