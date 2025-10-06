using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOAddressResponse
    {
        public DTOAddressResponse()
        {

        }

        public static implicit operator DTOAddressResponse(Address aAddress)
        {
            if (aAddress.IsNull())
                return null;

            return new DTOAddressResponse()
            {
                Description = aAddress.Description,
                Street = aAddress.Street,
                Number = aAddress.Number,
                Neighborhood = aAddress.Neighborhood,
                Complement = aAddress.Complement,
                Reference = aAddress.Reference,
                ZIP = aAddress.ZIP,
                State = aAddress.State,
                City = aAddress.City,
                CityId = aAddress.CityId,
                Country = aAddress.Country,
                IsBilling = aAddress.IsBilling,
                Geolocation = aAddress.Geolocation
            };
        }
    }
}
