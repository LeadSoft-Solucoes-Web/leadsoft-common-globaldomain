using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOPhoneContact
    {
        public static explicit operator DTOPhoneContact(PhoneContact aPhone)
        {
            if (aPhone.IsNull())
                return null;

            return new DTOPhoneContact()
            {
                DDI = aPhone.DDI,
                DDD = aPhone.DDD,
                Number = aPhone.Number,
                CanNotify = aPhone.CanNotify
            };
        }

        public static explicit operator PhoneContact(DTOPhoneContact aDto)
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
