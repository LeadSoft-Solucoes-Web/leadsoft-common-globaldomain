using Newtonsoft.Json;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    [Serializable]
    [DataContract]
    public partial class DTOPriceResponse : DTOResponse
    {
        /// <summary>
        /// Price value vigency
        /// </summary>
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime Vigency { get; set; }

        /// <summary>
        /// Price value
        /// </summary>
        [DataMember]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        /// <summary>
        /// Price display value
        /// </summary>
        [DataMember]
        public virtual string Price { get => Value.ToString("C2"); }

        /// <summary>
        /// Cost value
        /// </summary>
        [DataMember]
        [DataType(DataType.Currency)]
        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal Cost { get; set; }
    }
}
