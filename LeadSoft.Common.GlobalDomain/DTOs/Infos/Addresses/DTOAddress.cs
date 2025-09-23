using LeadSoft.Common.Library.Constants;
using LeadSoft.Common.Library.Enumerators;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    [Serializable]
    [DataContract]
    public partial class DTOAddress
    {
        /// <summary>
        /// Address description
        /// </summary>
        /// <example>Matrix office</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public string Description { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        /// <example>Av. Brasil</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public string Street { get; set; }

        /// <summary>
        /// Number of address
        /// </summary>
        /// <example>2048</example>

        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Neighborhood name
        /// </summary>
        /// <example>Santa Felicidade</example>
        [DataMember]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Complement
        /// </summary>
        /// <example>Bloco C. 15º andar</example>
        [DataMember]
        public string Complement { get; set; }

        /// <summary>
        /// Some reference
        /// </summary>
        /// <example>Next to Plaza</example>
        [DataMember]
        public string Reference { get; set; }

        /// <summary>
        /// CEP / ZIP code
        /// </summary>
        /// <example>82006456</example>
        [DataMember]
        public string ZIP { get; set; }

        /// <summary>
        /// State / Unidade Federativa
        /// Get those options on Root Controller
        /// </summary>
        /// <example>PR</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public UF State { get; set; }

        /// <summary>
        /// State / Unidade Federativa name
        /// </summary>
        /// <example>Curitiba</example>
        [DataMember]
        public string StateName { get { return State.GetDescription(); } }

        /// <summary>
        /// City IBGE Code.
        /// Get those options on Root Controller.
        /// </summary>
        /// <example>4106902</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public int CityId { get; set; }

        /// <summary>
        /// City
        /// Get those options on Root Controller.
        /// </summary>
        /// <example>Curitiba</example>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public string City { get; set; }

        /// <summary>
        /// Country enum
        /// Brazil is default
        /// </summary>
        /// <example>BR</example>
        [DataMember]
        public Country Country { get; set; } = Country.BR;

        /// <summary>
        /// Is this a billing address? If yes, place true
        /// </summary>
        /// <example>false</example>
        [DataMember]
        public bool? IsBilling { get; set; }

        /// <summary>
        /// Item 1: Latitude
        /// Item 2: Longitude
        /// </summary>
        [DataMember]
        public Tuple<double, double> Geolocation { get; set; }

        /// <summary>
        /// Indicates if this address is primary
        /// </summary>
        [DataMember]
        public bool IsPrimary { get; set; } = false;
    }
}
