using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{

    [Serializable]
    [DataContract]
    public partial class DTOPriceRange
    {
        /// <summary>
        /// Minimum Price Value
        /// </summary>
        [DataMember]
        [DefaultValue(null)]
        [DataType(DataType.Currency)]
        public decimal? Min { get; set; }

        /// <summary>
        /// Maximum Price Value
        /// </summary>
        [DataMember]
        [DefaultValue(null)]
        [DataType(DataType.Currency)]
        public decimal? Max { get; set; }
    }
}
