using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOAddressUpsert
    {
        public static implicit operator Address(DTOAddressUpsert aDto)
        {
            if (aDto.IsNull())
                return null;

            return new Address(aDto.Description, aDto.Country)
            {
                Street = aDto.Street,
                Number = aDto.Number,
                Neighborhood = aDto.Neighborhood,
                Complement = aDto.Complement,
                Reference = aDto.Reference,
                ZIP = aDto.ZIP,
                State = aDto.State,
                CityId = aDto.CityId,
                City = aDto.City,
                IsBilling = aDto.IsBilling,
                Geolocation = aDto.Geolocation
            };
        }
    }
}
