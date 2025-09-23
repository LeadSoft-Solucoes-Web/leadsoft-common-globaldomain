using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO DateTime Period Request
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOPeriodRequest
    {
        /// <summary>
        /// DateTime value
        /// </summary>

        [DataMember]
        [DataType(DataType.DateTime)]
        public virtual DateTime? Since { get; set; }

        /// <summary>
        /// DateTime value
        /// </summary>

        [DataMember]
        [DataType(DataType.DateTime)]
        public virtual DateTime? Until { get; set; }
    }
}
