
using LeadSoft.Common.GlobalDomain.Entities.Pricing;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DTOPriceResponse
    {
        public DTOPriceResponse()
        {
        }

        public DTOPriceResponse(Price aPrice)
        {
            Vigency = aPrice.Vigency;
            Cost = aPrice.Cost;
            Value = aPrice.Value;
        }

        /// <summary>
        /// Method available to hide cost if flagged to. Default = true.
        /// </summary>
        /// <returns></returns>
        public DTOPriceResponse HideCost(bool aHide = true)
        {
            if (aHide)
                Cost = 0;

            return this;
        }

        /// <summary>
        /// Method available to convert a Price object to DTO
        /// </summary>
        /// <param name="aPrice">Price object</param>
        /// <returns>Price Converted to DTO</returns>
        public static DTOPriceResponse ToDTO(Price aPrice) => (DTOPriceResponse)aPrice;
    }
}
