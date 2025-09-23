using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library;
using System;
using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Phone contact methods
    /// </summary>
    public partial class DTOPhoneContact
    {
        public DTOPhoneContact()
        {
        }

        public DTOPhoneContact(string aPhoneNumber)
        {
            if (!PhoneContact.IsValidPhone(aPhoneNumber))
                throw new OperationCanceledException(ApplicationStatusMessage.InvalidPhoneNumber);

            DDD = aPhoneNumber.Substring(0, 2);
            Number = aPhoneNumber[2..];
            Type = ContactType.Other;
            CanNotify = true;
        }

        /// <summary>
        /// DTO to Phone contact class
        /// </summary>
        /// <returns>Phone Contact class</returns>
        public PhoneContact ToPhoneContact() => (PhoneContact)this;
    }
}
