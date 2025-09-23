using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO DateTime Period
    /// </summary>

    [Serializable]
    [DataContract]
    public partial class DTOPeriod
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

        /// <summary>
        /// UTC Now
        /// </summary>

        [DataMember]
        [DataType(DataType.DateTime)]
        public virtual DateTime Now { get => DateTime.UtcNow; }

        /// <summary>
        /// If date time now utc is in period
        /// </summary>

        [DataMember]
        public virtual bool IsInIt { get; set; }

    }
}
