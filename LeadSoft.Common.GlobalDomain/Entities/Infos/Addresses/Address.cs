
using System;
using System.ComponentModel.DataAnnotations;
using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Address Object
    /// </summary>
    public partial class Address
    {
        /// <summary>
        /// Address description.
        /// - Country home
        /// - Matrix office
        /// </summary>
        [Required(ErrorMessage = "Description is required!")]
        public virtual string Description { get; private set; }

        /// <summary>
        /// Street name
        /// </summary>
        [Required(ErrorMessage = "Street is required.")]
        public virtual string Street { get; set; }

        /// <summary>
        /// Number of address
        /// </summary>
        public virtual string Number { get; set; }

        /// <summary>
        /// Neighborhood name
        /// </summary>
        public virtual string Neighborhood { get; set; }

        /// <summary>
        /// Complement
        /// - House 2
        /// - Apartment 3
        /// - 15th floor
        /// </summary>
        public virtual string Complement { get; set; }

        /// <summary>
        /// Some reference
        /// - Next to Plaza
        /// - Close to main cemetery gate
        /// </summary>
        public virtual string Reference { get; set; }

        /// <summary>
        /// CEP / ZIP code
        /// </summary>
        public virtual string ZIP { get; set; }

        /// <summary>
        /// State / Unidade Federativa enum based
        /// </summary>
        [Required(ErrorMessage = "State is required.")]
        public virtual UF State { get; set; }

        /// <summary>
        /// This Id comes from IBGE
        /// </summary>
        public virtual int CityId { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required(ErrorMessage = "City is required.")]
        public virtual string City { get; set; }

        /// <summary>
        /// Country enum
        /// Brazil is default
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Is this a billing address? If yes, place true
        /// </summary>
        public virtual bool? IsBilling { get; set; }

        /// <summary>
        /// Geolocation information
        /// Item 1: Latitude
        /// Item 2: Longitude
        /// </summary>
        public virtual Tuple<double, double> Geolocation { get; set; }
    }
}
