using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library;
using System;
using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Email contact Methods
    /// </summary>
    public partial class DTOEmailContact
    {
        public DTOEmailContact()
        {
        }

        public DTOEmailContact(string aAddress)
        {
            if (!EmailContact.IsValidEmail(aAddress))
                throw new OperationCanceledException(ApplicationStatusMessage.InvalidEmail);

            Address = aAddress;
            Type = ContactType.Other;
            CanNotify = true;
        }

        /// <summary>
        /// DTO to Email contact class
        /// </summary>
        /// <returns>Email contact class</returns>
        public EmailContact ToEmailContact() => (EmailContact)this;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="aEmailContact"></param>
      /// <returns></returns>
        public static DTOEmailContact ToDTO(EmailContact aEmailContact) => (DTOEmailContact)aEmailContact;
    }
}
