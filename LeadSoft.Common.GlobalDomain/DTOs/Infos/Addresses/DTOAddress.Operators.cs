using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOAddress
    {
        public static implicit operator DTOAddress(Address aAddress)
        {
            if (aAddress.IsNull())
                return null;

            return new DTOAddress()
            {
                Description = aAddress.Description,
                Street = aAddress.Street,
                Number = aAddress.Number,
                Neighborhood = aAddress.Neighborhood,
                Complement = aAddress.Complement,
                Reference = aAddress.Reference,
                ZIP = aAddress.ZIP,
                State = aAddress.State,
                CityId = aAddress.CityId,
                City = aAddress.City,
                Country = aAddress.Country,
                IsBilling = aAddress.IsBilling,
                Geolocation = aAddress.Geolocation,
            };
        }

        public static implicit operator Address(DTOAddress aDto)
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
