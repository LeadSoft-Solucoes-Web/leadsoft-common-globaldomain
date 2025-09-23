using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Email contact Operators
    /// </summary>
    public partial class DTOEmailContact
    {
        /// <summary>
        /// Email contact to DTO Email contact
        /// </summary>
        /// <param name="aEmailContact">Email contact class</param>
        public static explicit operator DTOEmailContact(EmailContact aEmailContact)
        {
            if (aEmailContact.IsNull())
                return null;

            return new DTOEmailContact()
            {
                Type = aEmailContact.Type,
                CanNotify = aEmailContact.CanNotify,
                Address = aEmailContact.Address
            };
        }

        /// <summary>
        /// DTO Email contact to email contact class
        /// </summary>
        /// <param name="aDtoEmailContact">DTO Email contact</param>
        public static explicit operator EmailContact(DTOEmailContact aDtoEmailContact)
        {
            if (aDtoEmailContact.IsNull())
                return null;

            return new EmailContact(aDtoEmailContact.Type, aDtoEmailContact.Address)
            {
                CanNotify = aDtoEmailContact.CanNotify
            };
        }
    }
}
