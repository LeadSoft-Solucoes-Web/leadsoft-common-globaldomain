using LeadSoft.Common.GlobalDomain.Entities.Pricing;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    public partial class DTOPriceInsert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDto"></param>
        public static implicit operator Price(DTOPriceInsert aDto)
        {
            if (aDto.IsNull())
                return null;

            if (aDto.Vigency.HasValue)
                return new(aDto.Vigency.Value, aDto.Value, aDto.Cost);
            else
                return new(aDto.Value, aDto.Cost);
        }
    }
}
