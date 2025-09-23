using LeadSoft.Common.Library.Constants;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Person
{
    /// <summary>
    /// DTONaturalPersonUpdate
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTONaturalPersonUpdate
    {
        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public string Name { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public string LastName { get; set; }

        /// <summary>
        /// Birth Date
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public Gender Gender { get; set; }
    }
}
