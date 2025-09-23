using LeadSoft.Common.Library.Constants;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO DateTime Request
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTODateTimeRequest
    {
        /// <summary>
        /// DateTime value
        /// </summary>
        [DataMember]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = Constant.RequiredField)]
        public virtual DateTime Value { get; set; }
    }
}
