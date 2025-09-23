using LeadSoft.Adapter.ViaCep.DTOs;
using LeadSoft.Common.Library.Extensions;
using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    public partial class Address
    {
        /// <summary>
        /// This operator points to Common.Library.ViaCEPService.DTOs
        /// Autofill Address with found Cep on Via CEP API
        /// </summary>
        /// <param name="aDto">DTOFoundAddress</param>
        public static explicit operator Address(DTOFoundAddress aDto)
        {
            if (aDto.IsNull())
                return null;

            return new Address(string.Format(DTOFoundAddress.ViaCEP, aDto.CEP), Country.BR)
            {
                Street = aDto.Logradouro,
                Neighborhood = aDto.Bairro,
                Complement = aDto.Complemento,
                ZIP = aDto.CEP,
                State = GetByValueString<UF>(aDto.UF),
                City = aDto.Localidade
            };
        }
    }
}
