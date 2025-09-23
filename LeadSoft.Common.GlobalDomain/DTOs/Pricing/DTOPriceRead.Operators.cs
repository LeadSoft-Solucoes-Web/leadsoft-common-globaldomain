using LeadSoft.Common.GlobalDomain.Entities.Pricing;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    public partial class DTOPriceRead
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPrice"></param>
        public static explicit operator DTOPriceRead(Price aPrice)
        {
            if (aPrice.IsNull())
                return null;

            return new()
            {
                Value = aPrice.Value
            };
        }
    }
}
