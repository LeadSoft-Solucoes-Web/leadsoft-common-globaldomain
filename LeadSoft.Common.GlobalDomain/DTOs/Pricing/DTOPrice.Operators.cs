using LeadSoft.Common.GlobalDomain.Entities.Pricing;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    public partial class DTOPrice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPrice"></param>
        public static explicit operator DTOPrice(Price aPrice)
        {
            if (aPrice.IsNull())
                return new DTOPrice();

            return new()
            {
                Vigency = aPrice.Vigency,   
                Cost = aPrice.Cost, 
                Value = aPrice.Value
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDto"></param>
        public static explicit operator Price(DTOPrice aDto)
        {
            if (aDto.IsNull())
                return null;

            return new (aDto.Vigency, aDto.Value, aDto.Cost);
        }
    }
}
