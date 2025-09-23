
using LeadSoft.Common.GlobalDomain.Entities.Pricing;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DTOPriceInsert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Price ToPrice() => (Price)this;
    }
}
