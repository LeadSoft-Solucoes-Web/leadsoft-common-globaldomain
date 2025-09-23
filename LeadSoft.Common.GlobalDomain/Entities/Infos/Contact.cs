using System.ComponentModel.DataAnnotations;

using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Contact abstract class
    /// </summary>
    public abstract partial class Contact
    {
        /// <summary>
        /// Contact type enum
        /// </summary>
        [Required]
        public ContactType Type { get; set; } = ContactType.Personal;

        /// <summary>
        /// Nome do contato
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// According to LGPD, this field is required and must be filled by user, if he want's to disable notifications.
        /// This flag tells system if it can be used to receive notifications (e-mail/sms/call)
        /// </summary>
        [Required]
        public bool CanNotify { get; set; } = true;
    }
}
