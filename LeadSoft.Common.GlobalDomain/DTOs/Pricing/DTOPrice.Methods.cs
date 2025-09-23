
using LeadSoft.Common.GlobalDomain.Entities.Pricing;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DTOPrice
    {
        /// <summary>
        /// Method available to Transform this object into a Price
        /// </summary>
        /// <returns>Price object</returns>
        public Price ToPrice() => (Price)this;

        /// <summary>
        /// Method available to hide cost if flagged to. Default = true.
        /// </summary>
        /// <returns></returns>
        public DTOPrice HideCost(bool aHide = true)
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
        public static DTOPrice ToDTO(Price aPrice) => (DTOPrice)aPrice;
    }
}
