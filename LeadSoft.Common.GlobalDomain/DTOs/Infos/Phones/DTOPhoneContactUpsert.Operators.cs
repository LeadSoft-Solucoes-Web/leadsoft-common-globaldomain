using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOPhoneContactUpsert
    {
        public static explicit operator PhoneContact(DTOPhoneContactUpsert aDto)
        {
            if (aDto.IsNull())
                return null;

            return new PhoneContact(aDto.Type, aDto.DDD, aDto.Number)
            {
                CanNotify = aDto.CanNotify,
            }.SetDDI(aDto.DDI);
        }
    }
}
