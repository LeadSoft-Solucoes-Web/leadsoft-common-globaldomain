using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOPhoneContactResponse
    {


        public static implicit operator DTOPhoneContactResponse(PhoneContact aPhone)
        {
            if (aPhone.IsNull())
                return null;

            return new()
            {
                DDI = aPhone.DDI,
                DDD = aPhone.DDD,
                Number = aPhone.Number,
                CanNotify = aPhone.CanNotify,
                Type = aPhone.Type
            };
        }
    }
}
