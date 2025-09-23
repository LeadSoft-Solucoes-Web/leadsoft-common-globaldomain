using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOEmailContactResponse
    {
        public static explicit operator DTOEmailContactResponse(EmailContact aEmailContact)
        {
            if (aEmailContact.IsNull())
                return null;

            return new DTOEmailContactResponse()
            {
                Type = aEmailContact.Type,
                CanNotify = aEmailContact.CanNotify,
                Address = aEmailContact.Address
            };
        }
    }
}
