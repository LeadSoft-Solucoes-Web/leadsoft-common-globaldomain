using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOEmailContactUpsert
    {
        public static explicit operator EmailContact(DTOEmailContactUpsert aDtoEmailContact)
        {
            if (aDtoEmailContact.IsNull())
                return null;

            return new EmailContact(aDtoEmailContact.Type,
                                    aDtoEmailContact.Address)
            {
                CanNotify = aDtoEmailContact.CanNotify
            };
        }
    }
}
