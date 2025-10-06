using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTOEmailContactUpsert : DTOContact
    {
        /// <summary>
        /// Address
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Address is required.")]
        [EmailAddress]
        public string Address { get; set; } = string.Empty;
    }
}
