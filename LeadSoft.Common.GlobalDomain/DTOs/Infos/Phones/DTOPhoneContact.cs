using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Phone contact DTO
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOPhoneContact : DTOContact
    {
        /// <summary>
        /// Discagem Direta Internacional
        /// </summary>
        /// <example>55</example>
        [DataMember]
        public string DDI { get; set; } = string.Empty;

        /// <summary>
        /// Discagem Direta à Distância
        /// </summary>
        /// <example>31</example>
        [DataMember]
        [Required(ErrorMessage = "DDD is required")]
        public string DDD { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        /// <example>997759557</example>
        [DataMember]
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; } = string.Empty;
    }
}
