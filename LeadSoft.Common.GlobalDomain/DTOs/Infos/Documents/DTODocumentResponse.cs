using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTODocumentResponse : DTOResponse
    {
        /// <summary>
        /// Document type enum
        ///  - Passport
        ///  - Driver license
        ///  - Others
        /// </summary>
        [DataMember]

        public DocumentType Type { get; set; }

        /// <summary>
        /// Official number
        /// </summary>
        [DataMember]

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

        /// <summary>
        /// File info if attachment for this document exists
        /// </summary>
        [DataMember]

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DTODocumentFileInfo DtoFileInfo { get; set; }
    }
}
