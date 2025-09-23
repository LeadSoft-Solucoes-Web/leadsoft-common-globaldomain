using LeadSoft.Common.GlobalDomain.Entities.Pricing;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    public partial class DTOPriceRead
    {
        public DTOPriceRead()
        {

        }

        public static DTOPriceRead ToDTO(Price aPrice) => (DTOPriceRead)aPrice;
    }
}
