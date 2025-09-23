using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTOAddressUpsert
    {
        /// <summary>
        /// Address description.
        /// - Country home
        /// - Matrix office
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }

        /// <summary>
        /// Number of address
        /// </summary>

        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Neighborhood name
        /// </summary>
        [DataMember]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Complement
        /// - House 2
        /// - Apartment 3
        /// - 15th floor
        /// </summary>
        [DataMember]
        public string Complement { get; set; }

        /// <summary>
        /// Some reference
        /// - Next to Plaza
        /// - Close to main cemetery gate
        /// </summary>
        [DataMember]
        public string Reference { get; set; }

        /// <summary>
        /// CEP / ZIP code
        /// </summary>
        [DataMember]
        public string ZIP { get; set; }

        /// <summary>
        /// State / Unidade Federativa
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "State is required.")]
        public UF State { get; set; }

        /// <summary>
        /// City IBGE Code
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "CityId is required.")]
        public int CityId { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        /// <summary>
        /// Country enum
        /// Brazil is default
        /// </summary>
        [DataMember]
        public Country Country { get; set; } = Country.BR;

        /// <summary>
        /// Is this a billing address? If yes, place true
        /// </summary>
        [DataMember]
        public bool? IsBilling { get; set; }


        /// <summary>
        /// Item 1: Latitude
        /// Item 2: Longitude
        /// </summary>
        [DataMember]
        public Tuple<double, double> Geolocation { get; set; }

        /// <summary>
        /// Indicates if this address should become primary
        /// </summary>
        [DataMember]
        public bool IsPrimary { get; set; }


    }
}
