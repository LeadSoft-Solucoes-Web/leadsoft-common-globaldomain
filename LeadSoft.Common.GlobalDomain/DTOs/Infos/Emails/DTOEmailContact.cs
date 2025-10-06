using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO E-mail contact
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOEmailContact : DTOContact
    {
        /// <summary>
        /// Address
        /// </summary>
        /// <example>leadsoft@leadsoft.inf.br</example>
        [DataMember]
        [Required(ErrorMessage = "Address is required.")]
        [EmailAddress]
        public string Address { get; set; } = string.Empty;
    }
}
