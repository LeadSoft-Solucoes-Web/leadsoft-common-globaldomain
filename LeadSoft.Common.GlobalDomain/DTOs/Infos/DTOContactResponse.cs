using System.Runtime.Serialization;

using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    [Serializable]
    [DataContract]

    public abstract partial class DTOContactResponse : DTOResponse
    {
        /// <summary>
        /// Contact type enum
        /// </summary>
        /// <example>Mobile</example>
        [DataMember]
        public ContactType Type { get; set; } = ContactType.Other;

        /// <summary>
        /// According to LGPD, this field is required and must be filled by user, if he want's to disable notifications.
        /// This flag tells system if it can be used to receive notifications (e-mail/sms/call)
        /// </summary>
        [DataMember]
        public bool CanNotify { get; set; } = false;

        /// <summary>
        /// Indicates if this Email should become primary
        /// </summary>
        [DataMember]
        public bool IsPrimary { get; set; } = false;
    }
}
