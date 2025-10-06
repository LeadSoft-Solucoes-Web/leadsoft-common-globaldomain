using LeadSoft.Common.GlobalDomain.Entities.Pricing;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    public partial class DTOPriceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPrice"></param>
        public static implicit operator DTOPriceResponse(Price aPrice)
        {
            if (aPrice.IsNull())
                return new DTOPriceResponse();

            return new(aPrice);
        }
    }
}
