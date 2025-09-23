using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTODocumentInsert
    {
        /// <summary>
        /// Document type enum
        ///  - Passport
        ///  - Driver license
        ///  - Others
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Type is required.")]
        public DocumentType Type { get; set; }

        /// <summary>
        /// Oficial number
        /// </summary>
        [DataMember]

        [Required(ErrorMessage = "Number is required.")]
        public string Number { get; set; }

        /// <summary>
        /// Date when document was issued, if needed
        /// </summary>
        [DataMember]

        [DataType(DataType.Date)]
        public DateTime? Issue { get; set; }

        /// <summary>
        /// Date when document expires, if needed
        /// </summary>
        [DataMember]

        [DataType(DataType.Date)]
        public DateTime? Expiration { get; set; }
    }
}
