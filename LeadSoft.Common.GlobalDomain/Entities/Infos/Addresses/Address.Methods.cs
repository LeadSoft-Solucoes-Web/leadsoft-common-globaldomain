using LeadSoft.Adapter.ViaCep;
using LeadSoft.Adapter.ViaCep.DTOs;
using LeadSoft.Common.Library.Extensions;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Address methods
    /// </summary>
    public partial class Address
    {
        private const string _DefaultDescription = "Default";

        public Address()
        {
            Description = _DefaultDescription;
            Country aCountry = Country.BR;
        }

        /// <summary>
        /// Constructor for Address. Requires a description and a country
        /// </summary>
        /// <param name="aDescription">Address description</param>
        /// <param name="aCountry">Country enum based. Default: BR</param>
        public Address(string aDescription, Country aCountry = Country.BR)
        {
            Description = aDescription.IsSomething() ? aDescription : _DefaultDescription;
            Country = aCountry;
            IsBilling = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToLine()
            => string.Concat(Street, ", ",
                             Number, ". ",
                             Complement.IsSomething() ? string.Concat(Complement, ". ") : string.Empty,
                             Neighborhood, ". ",
                             City, "-",
                             State.ToString(), ". ",
                             "CEP ", ZIP);

        /// <summary>
        /// This asyncronous method auto fill address information searching for CEP on Via CEP API
        /// </summary>
        public async Task AutofillAsync()
        {
            DTOFoundAddress dtoViaCEPAddress = await new ViaCEP().GetAddressAsync(ZIP);

            Street = dtoViaCEPAddress.Logradouro;
            Neighborhood = dtoViaCEPAddress.Bairro;
            Complement = dtoViaCEPAddress.Complemento;
            ZIP = dtoViaCEPAddress.CEP;
            CityId = dtoViaCEPAddress.IBGECode.ToIntOrDefault(0);
            State = GetByValueString<UF>(dtoViaCEPAddress.UF);
            City = dtoViaCEPAddress.Localidade;
            Country = Country.BR;
        }
    }
}
