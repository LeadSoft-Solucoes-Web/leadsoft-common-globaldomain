using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOEmailContactResponse
    {
        public static implicit operator DTOEmailContactResponse(EmailContact aEmailContact)
        {
            if (aEmailContact.IsNull())
                return null;

            return new()
            {
                Type = aEmailContact.Type,
                CanNotify = aEmailContact.CanNotify,
                Address = aEmailContact.Address
            };
        }
    }
}
