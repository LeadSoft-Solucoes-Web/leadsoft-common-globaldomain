using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Abstract DTO Contact
    /// </summary>

    [Serializable]
    [DataContract]
    public abstract partial class DTOContact
    {
        /// <summary>
        /// Contact type enum
        /// </summary>
        /// <example>Mobile</example>
        [DataMember]
        [Required(ErrorMessage = "Contact type is required.")]
        public ContactType Type { get; set; }

        /// <summary>
        /// According to LGPD, this field is required and must be filled by user, if he want's to disable notifications.
        /// This flag tells system if it can be used to receive notifications (e-mail/sms/call)
        /// </summary>
        /// <example>true</example>
        [DataMember]
        public bool CanNotify { get; set; }

        /// <summary>
        /// Indicates if this Email should become primary
        /// </summary>
        /// <example>true</example>
        [DataMember]
        public bool IsPrimary { get; set; } = false;
    }
}
