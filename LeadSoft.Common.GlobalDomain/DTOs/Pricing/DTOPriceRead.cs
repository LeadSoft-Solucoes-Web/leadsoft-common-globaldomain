using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Pricing
{
    /// <summary>
    /// Price read DTO
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOPriceRead
    {
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
    }
}
