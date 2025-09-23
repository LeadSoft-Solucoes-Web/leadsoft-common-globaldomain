using LeadSoft.Common.GlobalDomain.DTOs.Validations;
using LeadSoft.Common.Library.Constants;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// IP Address request dto
    /// </summary>
    [Serializable]
    [DataContract]

    [IpAddressRequestValidation]
    public class DTOIpAddressRequest
    {
        /// <summary>
        /// Frontend IP Address
        /// </summary>
        /// <example>192.58.56.181</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public virtual string IpAddress { get; set; }
    }
}
