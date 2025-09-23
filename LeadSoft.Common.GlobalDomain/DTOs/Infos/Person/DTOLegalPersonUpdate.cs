using LeadSoft.Common.Library.Constants;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Person
{
    /// <summary>
    /// DTOLegalPersonUpdate
    /// </summary>

    [Serializable]
    [DataContract]
    public class DTOLegalPersonUpdate
    {
        /// <summary>
        /// Company Name
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Business Name
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = Constant.RequiredField)]
        public string BusinessName { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        [DataMember]
        public Uri Website { get; set; }

    }
}
