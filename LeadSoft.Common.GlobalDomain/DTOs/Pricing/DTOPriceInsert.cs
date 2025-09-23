using LeadSoft.Common.Library.Constants;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    /// <summary>
    /// Price Insert DTO
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOPriceInsert
    {
        /// <summary>
        /// Optional Price value vigency. Null means that is current date time vigency
        /// </summary>
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime? Vigency { get; set; }

        /// <summary>
        /// Price value
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value higher than {1}.")]
        public decimal Value { get; set; }

        /// <summary>
        /// Cost value
        /// </summary>
        [DataMember]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value higher than {1}.")]
        public decimal Cost { get; set; } = 0;
    }
}
