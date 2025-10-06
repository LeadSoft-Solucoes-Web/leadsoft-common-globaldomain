using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTOPhoneContactUpsert : DTOContact
    {
        /// <summary>
        /// Discagem Direta Internacional
        /// </summary>
        [DataMember]
        public string DDI { get; set; } = string.Empty;

        /// <summary>
        /// Discagem Direta à Distância
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "DDD is required")]
        public string DDD { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; } = string.Empty;
    }
}
